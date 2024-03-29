﻿using PocEcommerce_1.DTOs;

namespace PocEcommerce_1.Business.Interfaces
{
    public interface IUserBusiness
    {
        Task<UserDTO> GetByEmail(string email);

        Task<int> Insert(UserDTO userDTO);

        Task<UserDTO> Update(UserDTO userDTO);
    }
}
