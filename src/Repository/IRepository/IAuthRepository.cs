using Sample_MinimalAPI.Models.DTOs;

namespace Sample_MinimalAPI.Repository.IRepository
{
    public interface IAuthRepository
    {
        bool IsUniqueUser(string username);

        Task<LoginResponseDTO> Login(LoginRequestDTO loginRequestDTO);

        Task<UserDTO> Register(RegisterationRequestDTO requestDTO);
    }
}
