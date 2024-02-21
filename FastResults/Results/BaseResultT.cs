using FastResults.Errors;
using System;
using System.Collections.Generic;
using System.Text;

namespace FastResults.Results
{
    /// <summary>
    /// Represents a base result that encapsulates a value of type TValue along with success or failure information.
    /// </summary>
    /// <typeparam name="TValue">The type of the encapsulated value.</typeparam>
    public class BaseResult<TValue> : BaseResult
    {
        #region Properties

        public TValue Value { get; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseResult{TValue}"/> class with the specified value, success status, and error.
        /// </summary>
        /// <param name="value">The encapsulated value.</param>
        /// <param name="isSuccess">A flag indicating whether the result is successful.</param>
        /// <param name="error">The error information.</param>
        protected internal BaseResult(TValue value, bool isSuccess, Error error)
            : base(isSuccess, error)
        {
            Value = value!;
        }

        #endregion Constructors

        /// <summary>
        /// Implicitly converts a value to a <see cref="BaseResult{TValue}"/>.
        /// </summary>
        /// <param name="value">The value to encapsulate.</param>
        public static implicit operator BaseResult<TValue>(TValue value) => Create(value);
    }
}
