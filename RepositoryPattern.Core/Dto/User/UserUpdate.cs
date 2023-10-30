using System.ComponentModel.DataAnnotations;

namespace RepositoryPattern.Core.Dto
{
    public class UserUpdate
    {
        public Guid Id { get; set; }

        [Required]
        [MaxLength(30)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(30)]
        public string LastName { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }

        public Data.Entities.User ToEntity()
        {
            return new Data.Entities.User()
            {                
                Id = Id,
                FirstName = FirstName,
                LastName = LastName,
                BirthDate = BirthDate
            };
        }

        public static UserUpdate FromEntity(Data.Entities.User entity)
        {
            return new UserUpdate()
            {
                Id = entity.Id,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                BirthDate = entity.BirthDate
            };
        }
    }
}
