using FastResults.Errors;

namespace FastResults.Results
{
    /// <summary>
    /// Represents a base result indicating success or failure, along with optional error information.
    /// </summary>
    public class BaseResult
    {
        #region Properties

        public bool IsSuccess { get; }
        public bool IsFailure => !IsSuccess;
        public Error Error { get; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseResult"/> class with the specified success status and error information.
        /// </summary>
        /// <param name="isSuccess">A value indicating whether the result is a success.</param>
        /// <param name="error">The error information associated with the result.</param>
        protected BaseResult(bool isSuccess, Error error)
        {
            IsSuccess = isSuccess;
            Error = error;
        }

        #endregion Constructors

        #region Methods

        #region Success

        /// <summary>
        /// Creates a successful result with no associated value.
        /// </summary>
        public static BaseResult Sucess() => new BaseResult(true, Error.None);

        /// <summary>
        /// Creates a successful result with the specified value.
        /// </summary>
        /// <typeparam name="TValue">The type of value.</typeparam>
        /// <param name="value">The value.</param>
        public static BaseResult<TValue> Sucess<TValue>(TValue value) => new BaseResult<TValue>(value, true, Error.None);

        #endregion Success

        #region Failure

        /// <summary>
        /// Creates a failure result with the specified error message.
        /// </summary>
        /// <param name="message">The error message.</param>
        public static BaseResult Failure(string message) => new BaseResult(false, new Error(message));

        /// <summary>
        /// Creates a failure result with the specified error information.
        /// </summary>
        /// <param name="error">The error information.</param>
        public static BaseResult Failure(Error error) => new BaseResult(false, error);

        /// <summary>
        /// Creates a failure result with the specified error message and default value.
        /// </summary>
        /// <typeparam name="TValue">The type of value.</typeparam>
        /// <param name="message">The error message.</param>
        public static BaseResult<TValue> Failure<TValue>(string message) => new BaseResult<TValue>(default, false, new Error(message));

        /// <summary>
        /// Creates a failure result with the specified error information and default value.
        /// </summary>
        /// <typeparam name="TValue">The type of value.</typeparam>
        /// <param name="error">The error information.</param>
        public static BaseResult<TValue> Failure<TValue>(Error error) => new BaseResult<TValue>(default, false, error);

        #endregion Failure

        /// <summary>
        /// Creates a result based on the specified value.
        /// </summary>
        /// <typeparam name="TValue">The type of value.</typeparam>
        /// <param name="value">The value.</param>
        /// <returns>A successful result if the value is not null; otherwise, a failure result with no error information.</returns>
        protected static BaseResult<TValue> Create<TValue>(TValue value) =>
            value != null ? Sucess(value) : Failure<TValue>(Error.None);

        #endregion Methods
    }

}
