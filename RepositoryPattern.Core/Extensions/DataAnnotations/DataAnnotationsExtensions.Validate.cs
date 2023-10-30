using System.ComponentModel.DataAnnotations;

namespace RepositoryPattern.Core.Extensions
{
    public static partial class DataAnnotationsExtensions
    {
        public static IEnumerable<ValidationResult> Validate<T>(T obj)
        {
            if (obj == null)
                throw new ArgumentNullException(nameof(obj));

            var validationResults = new List<ValidationResult>();
            var context = new ValidationContext(obj, null, null);
            var isValid = Validator.TryValidateObject(obj, context, validationResults, true);

            return validationResults;
        }
    }
}
