// Import security helpers, contracts, DTOs, domain models, and data access interfaces
using BusinessLayer.Helpers;
using BusinessLayer.Interfaces;
using ModelLayer.DTOs;
using ModelLayer.Entities;
using RepositoryLayer.Interfaces;

namespace BusinessLayer.Services
{
    // Business logic service handling user registration, authentication, and password lifecycle
    public class UserService : IUserService
    {
        // Injected dependencies for data access, security, notifications, and token generation
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IEmailService _emailService;
        private readonly ITokenService _tokenService;

        // Constructor injection initializing all required infrastructure and security dependencies
        public UserService(IUserRepository userRepository, IPasswordHasher passwordHasher,
            IEmailService emailService, ITokenService tokenService)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
            _emailService = emailService;
            _tokenService = tokenService;
        }

        // Registers a new user after verifying email uniqueness and hashing the password
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

        // Validates user credentials and issues a JWT token upon successful authentication
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

        // Generates a 15-minute reset token and sends an email without leaking user existence
        public async Task<ApiResponse> ForgotPasswordAsync(ForgotPasswordRequest request)
        {
            var user = await _userRepository.GetByEmailAsync(request.Email);
            if (user == null)
            {
                // Returns standard success message to prevent user enumeration attacks
                return new ApiResponse { Success = true, Message = "If that email exists, a reset link has been sent." };
            }

            user.ResetToken = Guid.NewGuid().ToString("N");
            user.ResetTokenExpiry = DateTime.UtcNow.AddMinutes(15);
            await _userRepository.UpdateAsync(user);

            await _emailService.SendPasswordResetEmailAsync(user.Email, user.ResetToken);

            return new ApiResponse { Success = true, Message = "If that email exists, a reset link has been sent." };
        }

        // Validates the token and expiry timestamp, hashes the new password, and invalidates the token
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