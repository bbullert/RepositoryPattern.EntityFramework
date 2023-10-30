using Microsoft.EntityFrameworkCore;
using RepositoryPattern.Core.Dto;
using RepositoryPattern.Data.Extensions;
using RepositoryPattern.Data.Infrastructure;
using System.Net;

namespace RepositoryPattern.Core.Services
{
    public partial class UserService
    {
        public async Task<User> GetAsync(Guid id)
        {
            var a = await _userUnitOfWork.UserAuditRepository.GetEarliestListAsync(id);

            var user = await _userUnitOfWork.UserRepository.GetAsync(
                x => x.Id == id, 
                include => include
                    .Include(include => include.Groups)
                    .Include(include => include.Items));
            if (user == null)
                throw new HttpRequestException("User not found.", null, HttpStatusCode.NotFound);

            var userDto = User.FromEntity(user);
            return userDto;
        }

        public async Task<IEnumerable<User>> GetListAsync()
        {
            var users = await _userUnitOfWork.UserRepository.GetListAsync();
            var userDtos = users.Select(x => User.FromEntity(x)).ToList();
            return userDtos;
        }

        public async Task<IPagination<User>> GetPaginationAsync(UserCriteria criteria)
        {
            var pagination = await _userUnitOfWork.UserRepository.GetPaginationAsync(
                predicate =>
                    (criteria.FirstName == null || predicate.FirstName.Contains(criteria.FirstName)) &&
                    (criteria.LastName == null || predicate.LastName.Contains(criteria.LastName)) &&
                    (criteria.BirthDateFrom == null || predicate.BirthDate >= criteria.BirthDateFrom) &&
                    (criteria.BirthDateTo == null || predicate.BirthDate <= criteria.BirthDateTo) &&
                    (criteria.GroupName == null || predicate.Groups.Any(item => item.Name.Contains(criteria.GroupName))) &&
                    (criteria.ItemName == null || predicate.Items.Any(group => group.Name.Contains(criteria.ItemName))),
                null,
                order => order.OrderBy(criteria.OrderBy), 
                criteria.Index, criteria.Size);

            var userDtos = pagination.Items.Select(x => User.FromEntity(x)).ToList();
            var result = new Pagination<User>(userDtos, pagination.Count, pagination.Index, pagination.Size);
            return result;
        }
    }
}
