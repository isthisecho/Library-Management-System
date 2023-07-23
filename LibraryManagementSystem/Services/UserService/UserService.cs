using Library.API.AuthenticationModels;
using LibraryManagementSystem.API.Entities;
using LibraryManagementSystem.DataLayer.Abstractions;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Library.API.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> _userRepository;
        private readonly IConfiguration _configuration;

        public UserService(IRepository<User> userRepository, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _configuration = configuration;
        }

        public async Task<User?> SignUp(RegisterModel user)
        {

            CreatePasswordHash(user.Password, out byte[] passwordHash, out byte[] passwordSalt);

            User newUser = new User()
            {
                Name         =  user.Name,
                Email        =  user.Email,
                PasswordHash =  passwordHash,
                PasswordSalt =  passwordSalt,
                UserRole     =  user.UserRole,
            };

                return await _userRepository.Create(newUser);

        }

        public async Task<string> Login(LoginModel user)
        {
            IEnumerable<User> users =  await _userRepository.Where(x=> x.Email ==  user.Email);
            User? selectedUser = users.FirstOrDefault();
            if (selectedUser != null )
            {
                CreatePasswordHash(user.Password , out byte[] passwordHash, out byte[] passwordSalt);

                if (!VerifyPasswordHash(user.Password, selectedUser.PasswordHash, selectedUser.PasswordSalt))
                    return "Wrong password";

                return CreateToken(selectedUser);
            }
            return "Wrong Email address.";


        }


        private string CreateToken(User user)
        {
            List<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Email, user.Email),
            };

            SymmetricSecurityKey key = new SymmetricSecurityKey
                                            (Encoding.UTF8.GetBytes(_configuration["JwtSettings:Key"]!));

            SigningCredentials credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            JwtSecurityToken token =new JwtSecurityToken( 
                claims : claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: credentials
                );

            string jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }
        private static void CreatePasswordHash(string password, out byte[] passwordHash , out byte[] passwordSalt)
        {
            using HMACSHA512 hmac = new();
            passwordSalt = hmac.Key;
            passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
        }

        private static bool VerifyPasswordHash(string password,  byte[] passwordHash,  byte[] passwordSalt)
        {
            using HMACSHA512 hmac = new(passwordSalt);
            byte[] computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));

            return computedHash.SequenceEqual(passwordHash); 

        }

    }


}
