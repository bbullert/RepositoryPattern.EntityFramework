namespace Chat.Core.Validators
{
    public static class ValidationErrorMessage
    {
        public static readonly string Required = "{PropertyName} is required";
        public static readonly string MaxLength = "{PropertyName} must be at most {MaxLength} characters long";
    }
}
