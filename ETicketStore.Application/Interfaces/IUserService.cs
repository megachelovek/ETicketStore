namespace ETicketStore.Application.Interfaces
{
    internal interface IUserService
    {
        Task<CreateUserResponse> CreateUser(CreateUserRequest req);

        Task<ValidateUserResponse> ValidateUser(ValidateUserRequest req);

        Task<GetAllActiveUsersResponse> GetAllActiveUsers();
    }
}
