using System.ComponentModel;

namespace FastResults.Enums
{
    public enum TypeError
    {
        [Description("None")]
        None = 0,

        [Description("NotFound")]
        NotFound = 1,

        [Description("Internal Error")]
        InternalError = 2,

        [Description("Unauthorized")]
        Unauthorized = 3,

        [Description("Validation")]
        Validation = 4
    }
}
