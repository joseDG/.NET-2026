using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Pacagroup.Ecomerce.Services.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomersApplication customersApplication;

        public CustomersController(ICustomersApplication customersApplication)
        {
            _ICustomersApplication = customersApplication;
        }

        [HttPost("InsertAsync")]
        public async Task<IActionResult> InsertAsync([FromBody] CustomerDto customerDto)
        {
            if (customerDto == null)
                return BadRequest();


            var response = await _customerApplication.InsertAsync(customerDto);

            if (response.IsSuccess)
                return Ok(response);

            return StatusCode((int)HttpStatusCode.InternalServerError, response);

        }

        [HttPut("UpdateAsync/{customerId}")]
        public async Task<IActionResult> UpdateAsync([FromRoute] string customerId, [FromBody] CustomerDto customerDto)
        {
            if (customerDto == null)
                return BadRequest();

            if (!customerId.Equals(customerDto.CustomerId))
                return BadRequest();

            var response = await _customerApplication.UpdateAsync(customerDto);

            if (response.IsSuccess)
                return Ok(response);

            return StatusCode((int)HttpStatusCode.InternalServerError, response);
        }

        [HttpDelete("DeleteAsync/{customerId}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] string customerId)
        {
            if (string.IsNullOrEmpty(customerId))
                return BadRequest();

            var response = await _customerApplication.DeleteAsync(customerId);

            if (response.IsSuccess)
                return Ok(response);

            return StatusCode((int)HttpStatusCode.InternalServerError, response);
        }

        [HttpGet("GetAsync/{customerId}")]
        public async Task<IActionResult> GetAsync([FromRoute] string customerId)
        {
            if (string.IsNullOrEmpty(customerId))
                return BadRequest();

            var response = await _customerApplication.GetAsync(customerId);

            if (response.IsSuccess)
                return Ok(response);


            return StatusCode((int)HttpStatusCode.InternalServerError, response);
        }

        [HttpGet("GetAllAsync")]
        public async Task<IActionResult> GetAllAsync()
        {
            var response = await _customerApplication.GetAllAsync();

            if (response.IsSuccess)
                return Ok(response);

            return StatusCode((int)HttpStatusCode.InternalServerError, response);
        }

    }
}
