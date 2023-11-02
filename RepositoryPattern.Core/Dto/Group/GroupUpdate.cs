using System.ComponentModel.DataAnnotations;

namespace RepositoryPattern.Core.Dto
{
    public class GroupUpdate
    {
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

        public void UpdateEntity(Data.Entities.Group entity)
        {
            entity.Name = Name;
        }
    }
}
