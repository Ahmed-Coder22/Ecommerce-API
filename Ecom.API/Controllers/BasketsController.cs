using AutoMapper;
using Ecom.API.Helper;
using Ecom.Core.Entities;
using Ecom.Core.interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecom.API.Controllers
{
    public class BasketsController : BaseController
    {
        public BasketsController(IUnitOfWork work, IMapper mapper) : base(work, mapper)
        {
        }

        [HttpGet("get-baskets-item/{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var result = await work.CustomerBasketRepositry.GetBasketAsync(id);
            if (result is null)
            {
                return Ok(new CustomerBasket());
            }
            return Ok(result);
        }
        [HttpPost("update-basket")]
        public async Task<IActionResult> Add(CustomerBasket basket)
        {
            var result =
                await work.CustomerBasketRepositry.UpdateBasketAsync(basket);

            if (result is null)
            {
                return BadRequest(new ResponseAPI(400));
            }

            return Ok(result);
        }
        [HttpDelete("delete-basket-item/{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var result = await work.CustomerBasketRepositry.DeleteBasketAsync(id);
            return result ? Ok(new ResponseAPI(200, "item deleted!")) :
                BadRequest(new ResponseAPI(400));
        }
    }
}
