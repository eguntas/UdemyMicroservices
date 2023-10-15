using Dapper;
using Discount.API.Models;
using FreeCourse.Shared.Dtos;
using Npgsql;
using System.Data;
using System.Data.Common;

namespace Discount.API.Services
{
    public class DiscountService : IDiscountService
    {
        private IConfiguration _configuration;
        private readonly IDbConnection _db;

        public DiscountService(IConfiguration configuration)
        {
            _configuration = configuration;
            _db = new NpgsqlConnection(_configuration.GetConnectionString("PostgreSql"));
        }
        public async Task<Response<NoContent>> DeleteById(int Id)
        {
            var status = await _db.ExecuteAsync("DELETE FROM discount where id=@id",new {id = Id });

            return status > 0 ? Response<NoContent>.Success(204) : Response<NoContent>.Fail("Discount not found", 404);
        }

        public async Task<Response<List<Models.Discount>>> GetAll()
        {
            var discount = await _db.QueryAsync<Models.Discount>("select * from discount");
            return Response<List<Models.Discount>>.Success(discount.ToList() , 200);
        }

        public async Task<Response<Models.Discount>> GetByCodeAndUserId(string code, string userId)
        {
            var discount = await _db.QueryAsync<Models.Discount>("select * from discount where userid=@UserId and code=@Code", new { UserId = userId, Code = code });
            var hasDiscount = discount.FirstOrDefault();
            if(hasDiscount == null) 
            {
                return Response<Models.Discount>.Fail("discount not found", 404);
            }
            return Response<Models.Discount>.Success(hasDiscount, 200);
        }

        public async Task<Response<Models.Discount>> GetById(string id)
        {
            var discount = (await _db.QueryAsync<Models.Discount>("select * from discount where Id=@id",new {id=id })).SingleOrDefault();
            if (discount == null)
                return Response<Models.Discount>.Fail("Discount not found" ,404);

            return Response<Models.Discount>.Success(discount, 200);
        }

        public async Task<Response<NoContent>> Save(Models.Discount discount)
        {
            var status = await _db.ExecuteAsync("INSERT INTO discount (userid , rate ,code) VALUES (@UserId , @Rate , @Code)",discount);
            if (status > 0)
                return Response<NoContent>.Success(204);

            return Response<NoContent>.Fail("An error accourding while adding",500);        
        }

        public async Task<Response<NoContent>> Update(Models.Discount discount)
        {
            var status = await _db.ExecuteAsync("UPDATE discount set userid=@UserId , code=@Code , rate=@Rate where id=@Id", 
                new {Id=discount.Id, UserId = discount.UserId ,Code=discount.Code ,Rate = discount.Rate});

            if(status > 0)
                return Response<NoContent>.Success(204);
            return Response<NoContent>.Fail("Discount not found", 404);




        }
    }
}
