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
        [DataType(DataType.Date)]
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
    }
}
