using System.ComponentModel.DataAnnotations;

namespace RepositoryPattern.Core.Dto
{
    public class UserUpdate
    {
        [Required]
        [MaxLength(30)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(30)]
        public string LastName { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        public void UpdateEntity(Data.Entities.User entity)
        {
            entity.FirstName = FirstName;
            entity.LastName = LastName;
            entity.BirthDate = BirthDate;
        }

        public static UserUpdate FromEntity(Data.Entities.User entity)
        {
            return new UserUpdate()
            {
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                BirthDate = entity.BirthDate
            };
        }
    }
}
