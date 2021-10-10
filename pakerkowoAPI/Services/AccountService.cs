using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PakerkowoAPI.Entities;
using PakerkowoAPI.Exceptions;
using PakerkowoAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PakerkowoAPI.Services
{
    public class AccountService
    {
        private readonly PakerkowoDbContext _dbContext;
        private readonly IPasswordHasher<User> _passwordHasher;

        public AccountService(PakerkowoDbContext dbContext, IPasswordHasher<User> passwordHasher)
        {
            _dbContext = dbContext;
            _passwordHasher = passwordHasher;
        }
        public async Task RegisterUser(RegisterUserDto dto)
        {
            var newUser = new User()
            {
                Email = dto.Email,
                DateOfBirth = dto.DateOfBirth,
                RoleId = dto.RoleId
            };
            var passwordHash = _passwordHasher.HashPassword(newUser, dto.Password);
            newUser.PasswordHash = passwordHash;
            _dbContext.Users.Add(newUser);
            _dbContext.SaveChanges();
        }
        public async Task<string> GenerateJwt(LoginDto dto)
        {
            var user = _dbContext
                .Users
                .Include(u => u.Role)
                .FirstOrDefaultAsync(u => u.Email == dto.Email)
                .Result;
            if(user is null)
            {
                throw new BadRequestException("Invalid username or password!");
            }
            var result = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, dto.Password);
            if (result == PasswordVerificationResult.Failed)
            {
                throw new BadRequestException("Invalid user name or password!");
            }

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, $"{user.Nickname}"),
                new Claim(ClaimTypes.Role, $"{user.Role.Name}"),
            };
            if (user.DateOfBirth != null)
            {
                claims.Add(
                    new Claim("DateOfBirth", user.DateOfBirth.Value.ToString("yyyy-MM-dd"))
                    );
            };
            //TODO

        }
    }
}
