using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using DOT_NET_7_Assignment_01_Swapno_SuperShop.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace DOT_NET_7_Assignment_01_Swapno_SuperShop.Data
{
    public class AuthRepository : IAuthRepository
    {
        private readonly DataContext _context;
        private readonly IConfiguration _configuration;

        public AuthRepository(DataContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public async Task<ServiceResponse<string>> Login(string username, string password)
        {
            var response = new ServiceResponse<string>();
            var manager = await _context.Managers.FirstOrDefaultAsync(manager => manager.Username.ToLower() == username);

            if (manager is null)
            {
                response.Message = "Manager Not found!";
                response.Success = false;
            }
            else if (!VerifyPasswordHash(password, manager.PasswordHash, manager.PasswordSalt))
            {
                response.Success = false;
                response.Message = "Wrong Password";
            }
            else
            {
                response.Data = CreateToken(manager);
            }
            return response;
        }

        private string CreateToken(Manager manager)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, manager.Id.ToString()),
                new Claim(ClaimTypes.Name, manager.Username)
            };

            var appSettingsToken = _configuration.GetSection("AppSettings:Token").Value;
            if (appSettingsToken is null)
                throw new Exception("AppSettings Token is null!");

            SymmetricSecurityKey key = new SymmetricSecurityKey(System.Text.Encoding.UTF8
                .GetBytes(appSettingsToken));

            SigningCredentials creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds
            };

            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }

        public async Task<ServiceResponse<int>> Register(Manager manager, string password)
        {
            var response = new ServiceResponse<int>();

            if (await UserExists(manager.Username))
            {
                response.Success = false;
                response.Message = "Manager already exists!";
                return response;
            }

            CreatePasswordWithHash(password, out byte[] passwordHash, out byte[] passwordSalt);

            manager.PasswordHash = passwordHash;
            manager.PasswordSalt = passwordSalt;

            _context.Managers.Add(manager);
            await _context.SaveChangesAsync();
            response.Data = manager.Id;
            return response;

        }

        private void CreatePasswordWithHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        public async Task<bool> UserExists(string username)
        {

            if (await _context.Managers.AnyAsync(u => u.Username.ToLower() == username.ToLower()))
            {
                return true;
            }
            return false;
        }

        private void CreatePasswordHasH(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {

            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {

                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(passwordHash);
            }
        }
    }
}