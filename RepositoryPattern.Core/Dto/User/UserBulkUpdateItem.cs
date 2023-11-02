using System.ComponentModel.DataAnnotations;

namespace RepositoryPattern.Core.Dto
{
    public class UserBulkUpdateItem : UserUpdate
    {
        [Required]
        public Guid Id { get; set; }
    }
}
