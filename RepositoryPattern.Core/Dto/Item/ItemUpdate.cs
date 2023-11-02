using System.ComponentModel.DataAnnotations;

namespace RepositoryPattern.Core.Dto
{
    public class ItemUpdate
    {
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

        [Required]
        public Guid UserId { get; set; }

        public void UpdateEntity(Data.Entities.Item entity)
        {
            entity.Name = Name;
            entity.UserId = UserId;
        }
    }
}
