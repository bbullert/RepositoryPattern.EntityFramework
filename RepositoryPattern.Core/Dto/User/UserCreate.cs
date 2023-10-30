using System.ComponentModel.DataAnnotations;

namespace RepositoryPattern.Core.Dto
{
    public class UserCreate
    {
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
                FirstName = FirstName,
                LastName = LastName,
                BirthDate = BirthDate,
            };
        }

        public static UserCreate FromEntity(Data.Entities.User entity)
        {
            return new UserCreate()
            {
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                BirthDate = entity.BirthDate
            };
        }
    }
}
