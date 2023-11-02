namespace Chat.Core.Validators
{
    public class ValidationResult
    {
        public bool IsValid => !Errors.Any();
        public IEnumerable<ValidationError> Errors { get; set; }

        public ValidationResult()
        {
            Errors = Enumerable.Empty<ValidationError>();
        }

        public void AddError(ValidationError error)
        {
            var errors = Errors.ToList();
            var currentError = errors.FirstOrDefault(x => x.Name == error.Name);
            if (currentError == null) errors.Add(error);
            else currentError.Messages.ToList().AddRange(error.Messages);
            Errors = errors;
        }
    }
}
