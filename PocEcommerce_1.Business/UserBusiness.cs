using AutoMapper;
using PocEcommerce_1.Business.Interfaces;
using PocEcommerce_1.Data.Interfaces;
using PocEcommerce_1.DTOs;
using PocEcommerce_1.Entities;

namespace PocEcommerce_1.Business
{
    public class UserBusiness : IUserBusiness
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public UserBusiness(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public  async Task<UserDTO> GetByEmail(string email)
        {
            User user = await _userRepository.GetByEmail(email);
            UserDTO userDTO = _mapper.Map<UserDTO>(user);
            return userDTO;
        }

        public async Task<UserDTO> Insert(UserDTO userDTO)
        {
            User user = _mapper.Map<User>(userDTO);
            userDTO.Id = await _userRepository.Insert(user);
            return userDTO;
        }

        public async Task<UserDTO> Update(UserDTO userDTO)
        {
            User user = _mapper.Map<User>(userDTO);
            user = await _userRepository.Update(user);
            userDTO = _mapper.Map<UserDTO>(user);
            return userDTO;
        }
    }
}
