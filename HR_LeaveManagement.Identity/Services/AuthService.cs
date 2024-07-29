using HR_LeaveManagement.Application.Contracts.Identity;
using HR_LeaveManagement.Application.Models.Identity;
using HR_LeaveManagement.Identity.Models;
using Microsoft.AspNetCore.Identity;

namespace HR_LeaveManagement.Identity.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        public Task<AuthResponse> Login(AuthRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<RegistrationResponse> Register(RegistrationRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
