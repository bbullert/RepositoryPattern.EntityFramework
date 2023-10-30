using RepositoryPattern.Data.Infrastructure;

namespace RepositoryPattern.Core.Dto
{
    public class UserCriteria : Criteria
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime? BirthDateFrom { get; set; }
        public DateTime? BirthDateTo { get; set; }
        public string? GroupName { get; set; }
        public string? ItemName { get; set; }
    }
}
