using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace RepositoryPattern.Api.Extnesions
{
    public static partial class ModelStateDictionaryExtensions
    {
        public static void AddValidationResults(this ModelStateDictionary modelState, IEnumerable<ValidationResult> results)
        {
            foreach (var result in results)
            {
                foreach (var memberName in result.MemberNames)
                {
                    modelState.AddModelError(memberName, result.ErrorMessage);
                }
            }
        }
    }
}
