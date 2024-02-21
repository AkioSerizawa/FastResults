using FastResults.Errors;
using FastResults.Results;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace FastResults.Controllers
{
    /// <summary>
    /// An abstract controller providing common functionality for handling responses in API controllers.
    /// </summary>
    [ApiController]
    public abstract class BaseController : ControllerBase
    {
        /// <summary>
        /// Handles a base result and generates an appropriate HTTP response.
        /// </summary>
        /// <param name="result">The base result to handle.</param>
        /// <param name="message">An optional message for the response.</param>
        /// <param name="httpStatus">The HTTP status code for successful responses.</param>
        /// <param name="httpStatusError">The HTTP status code for failed responses.</param>
        /// <returns>An HTTP response based on the result.</returns>
        protected new ActionResult Response(
            BaseResult result,
            string message = "",
            HttpStatusCode httpStatus = HttpStatusCode.OK,
            HttpStatusCode httoStatusError = HttpStatusCode.NotFound)
        {
            if (result.IsFailure)
            {
                result.Error.StatusCode = httoStatusError;
                return StatusCode((int)httoStatusError, new BaseResponse<Error>(result.Error));
            }

            return StatusCode((int)httpStatus, new BaseResponse<string>(message));
        }

        /// <summary>
        /// Handles a generic base result and generates an appropriate HTTP response.
        /// </summary>
        /// <typeparam name="TValue">The type of value encapsulated in the result.</typeparam>
        /// <param name="result">The generic base result to handle.</param>
        /// <param name="httpStatus">The HTTP status code for successful responses.</param>
        /// <param name="httpStatusError">The HTTP status code for failed responses.</param>
        /// <returns>An HTTP response based on the result.</returns>
        protected new ActionResult Response<TValue>(
        BaseResult<TValue> result,
        HttpStatusCode httpStatus = HttpStatusCode.OK,
        HttpStatusCode httoStatusError = HttpStatusCode.NotFound)
        {
            if (result.IsFailure)
            {
                result.Error.StatusCode = httoStatusError;
                return StatusCode((int)httoStatusError, new BaseResponse<Error>(result.Error));
            }

            return StatusCode((int)httpStatus, new BaseResponse<TValue>(result.Value));
        }
    }
}
