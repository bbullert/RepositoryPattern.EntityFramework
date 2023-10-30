namespace Chat.Core.Validators
{
    public class ValidationError
    {
        public string Name { get; set; }
        public IEnumerable<string> Messages { get; set; }
    }
}
