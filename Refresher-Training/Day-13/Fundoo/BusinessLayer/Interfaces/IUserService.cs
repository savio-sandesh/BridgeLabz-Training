using ModelLayer.DTOs;

namespace BusinessLayer.Interfaces
{
    public interface IUserService
    {
        Task<ApiResponse> RegisterAsync(RegisterRequest request);
        Task<LoginResponse> LoginAsync(LoginRequest request);
        Task<ApiResponse> ForgotPasswordAsync(ForgotPasswordRequest request);
        Task<ApiResponse> ResetPasswordAsync(ResetPasswordRequest request);
    }
}
