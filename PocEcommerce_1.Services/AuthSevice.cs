using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using PocEcommerce_1.Business.Interfaces;
using PocEcommerce_1.DTOs;
using PocEcommerce_1.Services.Interfaces;
using PocEcommerce_1.Shared.Messages;
using PocEcommerce_1.Shared.PasswordUtility;
using PocEcommerce_1.ViewModels;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PocEcommerce_1.Services
{
    public class AuthSevice : IAuthService
    {
        private readonly IUserBusiness _userBusiness;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;

        public AuthSevice(IUserBusiness userBusiness, IConfiguration configuration, IMapper mapper)
        {
            _userBusiness = userBusiness;
            _configuration = configuration;
            _mapper = mapper;
        }

        public async Task<ServiceResponseViewModel<string>> Login(UserViewModel userLoginViewModel)
        {
            ServiceResponseViewModel<string> serviceResponseDTO = new ServiceResponseViewModel<string>();
            try
            {
                UserDTO userOnDatabase = await _userBusiness.GetByEmail(userLoginViewModel.Email);
                if (userOnDatabase.Id == 0)
                {
                    serviceResponseDTO.IsSucess = false;
                    serviceResponseDTO.Message = ConstantMessages.UserNotFound;
                    return serviceResponseDTO;
                }
                else if (!PasswordHashUtility.CheckHash(userLoginViewModel.Password, userOnDatabase.PasswordHash, userOnDatabase.PasswordSalt))
                {
                    serviceResponseDTO.IsSucess = false;
                    serviceResponseDTO.Message = ConstantMessages.UserNotFound;
                    return serviceResponseDTO;
                }

                string token = CreateToken(userOnDatabase);
                serviceResponseDTO.Data = token;
            }
            catch (Exception ex)
            {
                serviceResponseDTO.IsSucess = false;
                serviceResponseDTO.Message = ex.GetBaseException().Message;
            }

            return serviceResponseDTO;
        }

        public async Task<ServiceResponseViewModel<UserViewModel>> Register(UserToInsertViewModel userToInsertViewModel)
        {
            ServiceResponseViewModel<UserViewModel> serviceResponseDTO = new ServiceResponseViewModel<UserViewModel>();
            try
            {
                UserDTO userOnDatabase = await _userBusiness.GetByEmail(userToInsertViewModel.Email);
                if (userOnDatabase.Id != 0)
                {
                    serviceResponseDTO.IsSucess = false;
                    serviceResponseDTO.Message = ConstantMessages.UserAlreadyExists;
                    return serviceResponseDTO;
                }

                UserDTO userDTO = _mapper.Map<UserDTO>(userToInsertViewModel);
                PasswordHashUtility.CreateHash(userToInsertViewModel.Password, out byte[] passwordHash, out byte[] passwordSalt);
                userDTO.PasswordHash = passwordHash;
                userDTO.PasswordSalt = passwordSalt;
                userDTO.Id = await _userBusiness.Insert(userDTO);
                serviceResponseDTO.Data = _mapper.Map<UserViewModel>(userDTO);
            }
            catch (Exception ex)
            {
                serviceResponseDTO.IsSucess = false;
                serviceResponseDTO.Message = ex.GetBaseException().Message;
            }

            return serviceResponseDTO;
        }

        public string CreateToken(UserDTO userDTO)
        {
            List<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, userDTO.Id.ToString()),
                new Claim(ClaimTypes.Name, userDTO.Email)
            };

            SymmetricSecurityKey symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:Token").Value));
            SigningCredentials signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha512Signature);

            SecurityTokenDescriptor securityTokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(7),
                SigningCredentials = signingCredentials
            };

            JwtSecurityTokenHandler jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            SecurityToken securityToken = jwtSecurityTokenHandler.CreateToken(securityTokenDescriptor);

            return jwtSecurityTokenHandler.WriteToken(securityToken);
        }
    }
}