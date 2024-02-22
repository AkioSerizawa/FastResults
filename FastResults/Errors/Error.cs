using FastResults.Enums;
using FastResults.Extensions;
using System;
using System.Net;

namespace FastResults.Errors
{
    /// <summary>
    /// Represents an error entity encapsulating information about an HTTP error response.
    /// </summary>
    public class Error
    {
        #region Properties

        public HttpStatusCode StatusCode { get; set; } = HttpStatusCode.NotFound;
        public string Message { get; private set; }
        public Enum? Type { get; private set; }
        public string TypeDescription { get; private set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Error"/> class with a specified status code and message.
        /// </summary>
        /// <param name="statusCode">The HTTP status code associated with the error.</param>
        /// <param name="message">The message describing the error.</param>
        /// <param name="type">The type error.</param>
        public Error(HttpStatusCode statusCode, string message, Enum type)
        {
            StatusCode = statusCode;
            Message = message;
            Type = type;

            TypeDescription = Type.GetDescription();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Error"/> class with a specified message and default status code.
        /// </summary>
        /// <param name="statusCode">The HTTP status code associated with the error.</param>
        /// <param name="message">The message describing the error.</param>
        public Error(HttpStatusCode statusCode, string message)
        {
            StatusCode = statusCode;
            Message = message;
            Type = TypeError.NotFound;

            TypeDescription = Type.GetDescription();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Error"/> class with a specified message and default status code.
        /// </summary>
        /// <param name="message">The message describing the error.</param>
        public Error(string message)
        {
            Message = message;
            Type = TypeError.NotFound;

            TypeDescription = Type.GetDescription();
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Represents an empty error entity.
        /// </summary>
        public static readonly Error None = new Error(HttpStatusCode.NoContent, string.Empty, TypeError.None);

        #endregion Methods
    }
}
