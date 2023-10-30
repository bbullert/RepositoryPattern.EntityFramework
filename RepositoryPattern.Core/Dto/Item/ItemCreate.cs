using System.ComponentModel.DataAnnotations;

namespace RepositoryPattern.Core.Dto
{
    public class ItemCreate
    {
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

        [Required]
        public Guid UserId { get; set; }

        public Data.Entities.Item ToEntity()
        {
            return new Data.Entities.Item()
            {
                Name = Name,
                UserId = UserId
            };
        }
    }
}
