using System.ComponentModel.DataAnnotations;

namespace RepositoryPattern.Core.Dto
{
    public class GroupCreate
    {
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

        public Data.Entities.Group ToEntity()
        {
            return new Data.Entities.Group()
            {
                Name = Name
            };
        }
    }
}
