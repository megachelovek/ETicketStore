using ETicketStore.Domain.Core.Interfaces;
using ETicketStore.Domain.Models;

namespace ETicketStore.Application.Services
{
    public class UserService
    {
        private readonly IRoleRepository _roleRepository;
        private readonly IUserRepository _userRepository;

        public List<User> Users { get; set; }
        public List<Role> Roles { get; set; }

        public UserService(IRoleRepository roleRepository, IUserRepository userRepository)
        {
            _roleRepository = roleRepository;
            _userRepository = userRepository;
        }

        public async Task UpdateUsersAndRoles()
        {
            if (Users == null)
            {
                this.Users = await _userRepository.GetAllUsers();
                this.Roles = await _roleRepository.GetAllRoles();
                var rolesDictionary = Roles.Select(t => new { t.Id, t })
                       .ToDictionary(t => t.Id, t => t);
                Users.ForEach(t => { t.Role = Roles[t.RoleId]; });
            }
        }
    }
}
