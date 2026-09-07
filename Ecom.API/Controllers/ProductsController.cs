using AutoMapper;
using Ecom.API.Helper;
using Ecom.Core.DTO;
using Ecom.Core.interfaces;
using Ecom.Core.Sharing;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Ecom.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : BaseController
    {
        public ProductsController(IUnitOfWork work, IMapper mapper) : base(work, mapper)
        {
        }
        [HttpGet("get-all")]
        public async Task<IActionResult> get([FromQuery] ProductParams productParams)
        {
            try
            {
                var Product = await work.productRepositry
                    .GetAllAsync(productParams);
                var totalcount = await work.productRepositry.CountAsync();
                return Ok(new Pagination<ProductDTO>(productParams.PageNumber, productParams.pageSize, totalcount, Product));
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        [HttpGet("get-by-id/{id}")]
        public async Task<IActionResult> getById(int id)
        {
            try
            {
                var product = await work.productRepositry.GetByIdAsync(id,
                    x => x.Category, x => x.Photos);

                var result = mapper.Map<ProductDTO>(product);

                if (product is null) return BadRequest(new ResponseAPI(400));


                return Ok(result);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        [HttpPost("Add-Product")]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> add([FromForm] AddProductDTO productDTO)
        {

            try
            {
                await work.productRepositry.AddAsync(productDTO);
                return Ok(new ResponseAPI(200));
            }
            catch (Exception ex)
            {

                return BadRequest(new ResponseAPI(400, ex.Message));
            }
        }
        [HttpPut("Update-Product")]
        public async Task<IActionResult> Update([FromForm] UpdateProductDTO updateProductDTO)
        {
            try
            {
                var result = await work.productRepositry
                    .UpdateAsync(updateProductDTO);

                if (!result)
                {
                    return NotFound(new ResponseAPI(404, "Product not found"));
                }

                return Ok(new ResponseAPI(200));
            }
            catch (Exception ex)
            {

                return BadRequest(new ResponseAPI(400, ex.Message));
            }
        }
        [HttpDelete("Delete-Product/{Id}")]
        public async Task<IActionResult> Delete(int Id)
        {
            try
            {
                var product = await work.productRepositry
                    .GetByIdAsync(Id);

                if (product == null)
                    return NotFound(new ResponseAPI(404, "Product not found"));

                await work.productRepositry.DeleteAsync(product);

                return Ok(new ResponseAPI(200));
            }
            catch (Exception ex)
            {
                return BadRequest(new ResponseAPI(400, ex.Message));
            }
        }
    }
}
