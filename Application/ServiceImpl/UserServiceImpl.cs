using Application.DTOs;
using Application.IService;
using AutoMapper;
using Domain.Entities;
using Domain.IRepository;
using System;
using System.Collections.Generic;

namespace Application.ServiceImpl
{
    public class UserServiceImpl : IUserService
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository; // dependancy injection

        public UserServiceImpl(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public void CreateUser(UserDto userDto)
        {
            if (userDto == null) throw new ArgumentNullException(nameof(userDto));

            var userEntity = _mapper.Map<Users>(userDto);

            userEntity.Id = 0;

            _userRepository.Add(userEntity);
        }


        public UserDto GetUserById(int id)
        {
            var userEntity = _userRepository.GetById(id);

            if (userEntity == null) return null;

            return _mapper.Map<UserDto>(userEntity);
        }

        public IList<UserDto> GetAllUsers()
        {
            var userEntities = _userRepository.GetAll();

            return _mapper.Map<IList<UserDto>>(userEntities);
        }

        public void UpdateUser(UserDto userDto)
        {
            if (userDto == null) throw new ArgumentNullException(nameof(userDto));

            var existingUser = _userRepository.GetById(userDto.Id);
            if (existingUser == null) throw new ArgumentNullException(nameof(userDto));

            _mapper.Map(userDto, existingUser);

            _userRepository.Update(existingUser);
        }
        public void DeleteUser(int id)
        {

            var existingUser = _userRepository.GetById(id);
            if (existingUser == null) throw new ArgumentNullException(nameof(id));



            _userRepository.Delete(id);
        }
    }
}
