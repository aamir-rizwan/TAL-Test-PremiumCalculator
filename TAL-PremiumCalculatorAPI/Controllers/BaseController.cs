using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TAL_PremiumCalculatorAPI.Models;

namespace TAL_PremiumCalculatorAPI.Controllers
{
    [Route("api/[controller]")] 
    public class BaseController : ControllerBase
    {
        public BaseController() { }
         
        protected ActionResult<ApiResponse> HandleResult(Result result)
        {
            var response = new ApiResponse
            {
                Success = result.IsSuccess,
            };

            if (!result.IsSuccess)
            {
                response.Message = result.Error;
                return new ObjectResult(response)
                {
                    StatusCode = result.StatusCode
                };
            }

            return Ok(response);
        }

        protected ActionResult<ApiResponse<T>> HandleResult<T>(Result<T> result)
        {
            var response = new ApiResponse<T>
            {
                Content = result.Data,
                Success = result.IsSuccess,
            };

            if (!result.IsSuccess)
            {
                response.Message = result.Error;
                return new ObjectResult(response)
                {
                    StatusCode = result.StatusCode
                };
            }

            return Ok(response);
        }
    }
}
