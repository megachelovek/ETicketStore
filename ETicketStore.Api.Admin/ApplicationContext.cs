using ETicketStore.Common.Models;
using ETicketStore.Common.Repository;

namespace ETicketStore.Api.Admin
{
    public class ApplicationContext 
    {
        private readonly RoleRepository _roleRepository;
        private readonly UserRepository _userRepository;

        public List<User> Users { get; set; }
        public List<Role> Roles { get; set; }        

        public ApplicationContext(RoleRepository roleRepository, UserRepository userRepository)            
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