namespace CapitalPlacement.Shared
{
    public sealed class Error
    {
        public static readonly Error None = new(string.Empty, string.Empty);
        public static readonly Error NullValue = new("Error.NullValue", "Result Value is Null");
        public static class Errors
        {
            public static class General
            {
                public static Error IsRequiredError()
                    => new Error("value.is.required", "value is required");
                public static Error IsRequiredError(string value)
                    => new Error("value.is.required", $"{value} is required", value);
                public static Error LengthError()
                    => new Error("length.is.incorrect", "value length is incorrect");
                public static Error LengthError(string value, byte minLength)
                    => new Error("length.is.incorrect", $"{value} length should be at least ${minLength}");
                public static Error LengthError(string value, byte minLength, byte maxLength)
                    => new Error("length.is.incorrect", $"{value} length should be at least ${minLength} and ${maxLength} at most");
                public static Error RequestIsNull(string request)
                    => new Error("null.request.error", $"{request} is null");
                public static Error InvalidFieldDataType(string field)
                    => new Error("invalid.input.data", $"Input Data Error in field '{field}'", field);
            }

            public static class CapitalPrograms
            {
                public static Error ProgramNotFound()
                    => new Error("program.not.found", "program not found!");
                public static Error QuestionNotFound()
                   => new Error("question.not.found", "question not found!");
            }

            public static class Applications
            {
                public static Error ApplicationNotFound()
                    => new Error("application.not.found", "application not found!");
            }
        }

        
        public string Code { get; }
        public string Message { get; }
        public string? InvalidField { get;}

        public Error(string code, string msg):this(code, msg, "N/A")
        {
        }

        public Error(string code, string msg, string invalidField)
        {
            Code = code;
            Message = msg;
            InvalidField = invalidField;
        }

        public static implicit operator string(Error error) => error.Code;
    }
}
