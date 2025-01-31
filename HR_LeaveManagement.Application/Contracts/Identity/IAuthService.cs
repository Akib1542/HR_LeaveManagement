﻿using HR_LeaveManagement.Application.Models.Identity;

namespace HR_LeaveManagement.Application.Contracts.Identity
{
    public interface IAuthService   
    {
        Task<AuthResponse>Login(AuthRequest request);
        Task<RegistrationResponse>Register(RegistrationRequest request);   
    }
}
