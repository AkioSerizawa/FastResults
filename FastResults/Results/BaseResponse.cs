using FastResults.Errors;

namespace FastResults.Results
{
    /// <summary>
    /// Represents a base response that encapsulates generic response data and error information.
    /// </summary>
    /// <typeparam name="TResponse">The type of response data.</typeparam>
    public class BaseResponse<TResponse>
    {
        #region Properties

        public TResponse Data { get; private set; }

        public Error Error { get; private set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseResponse{TResponse}"/> class with specified response data and no error.
        /// </summary>
        /// <param name="data">The response data.</param>
        public BaseResponse(TResponse data)
        {
            Data = data;
            Error = Error.None;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseResponse{TResponse}"/> class with specified error information and no response data.
        /// </summary>
        /// <param name="error">The error information.</param>
        public BaseResponse(Error error)
        {
            Data = default;
            Error = error;
        }

        #endregion Constructors
    }

}
