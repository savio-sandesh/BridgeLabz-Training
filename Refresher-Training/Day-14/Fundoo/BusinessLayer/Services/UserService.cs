using BusinessLayer.Helpers;
using BusinessLayer.Interfaces;
using ModelLayer.DTOs;
using ModelLayer.Entities;
using RepositoryLayer.Interfaces;

namespace BusinessLayer.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IEmailService _emailService;
        private readonly ITokenService _tokenService;

        public UserService(IUserRepository userRepository, IPasswordHasher passwordHasher,
            IEmailService emailService, ITokenService tokenService)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
            _emailService = emailService;
            _tokenService = tokenService;
        }

        public async Task<ApiResponse> RegisterAsync(RegisterRequest request)
        {
            var existing = await _userRepository.GetByEmailAsync(request.Email);
            if (existing != null)
            {
                return new ApiResponse { Success = false, Message = "Email is already registered." };
            }

            var user = new User
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                PasswordHash = _passwordHasher.Hash(request.Password)
            };

            await _userRepository.AddAsync(user);
            return new ApiResponse { Success = true, Message = "Registration successful." };
        }

        public async Task<LoginResponse> LoginAsync(LoginRequest request)
        {
            var user = await _userRepository.GetByEmailAsync(request.Email);
            if (user == null || !_passwordHasher.Verify(request.Password, user.PasswordHash))
            {
                return new LoginResponse { Success = false, Message = "Invalid email or password." };
            }

            var token = _tokenService.GenerateToken(user);
            return new LoginResponse { Success = true, Message = "Login successful.", Token = token };
        }

        public async Task<ApiResponse> ForgotPasswordAsync(ForgotPasswordRequest request)
        {
            var user = await _userRepository.GetByEmailAsync(request.Email);
            if (user == null)
            {
                return new ApiResponse { Success = true, Message = "If that email exists, a reset link has been sent." };
            }

            user.ResetToken = Guid.NewGuid().ToString("N");
            user.ResetTokenExpiry = DateTime.UtcNow.AddMinutes(15);
            await _userRepository.UpdateAsync(user);

            await _emailService.SendPasswordResetEmailAsync(user.Email, user.ResetToken);

            return new ApiResponse { Success = true, Message = "If that email exists, a reset link has been sent." };
        }

        public async Task<ApiResponse> ResetPasswordAsync(ResetPasswordRequest request)
        {
            var user = await _userRepository.GetByEmailAsync(request.Email);
            if (user == null || user.ResetToken != request.ResetToken ||
                user.ResetTokenExpiry == null || user.ResetTokenExpiry < DateTime.UtcNow)
            {
                return new ApiResponse { Success = false, Message = "Invalid or expired reset token." };
            }

            user.PasswordHash = _passwordHasher.Hash(request.NewPassword);
            user.ResetToken = null;
            user.ResetTokenExpiry = null;
            await _userRepository.UpdateAsync(user);

            return new ApiResponse { Success = true, Message = "Password has been reset successfully." };
        }
    }
}