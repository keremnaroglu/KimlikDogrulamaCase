using AutoMapper;
using KimlikDogrulamaCase.DTOs;
using KimlikDogrulamaCase.BLL.Abstract;
using KimlikDogrulamaCase.DAL.Abstract;
using KimlikDogrulamaCase.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TCNoService;

namespace KimlikDogrulamaCase.BLL.Concrete
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<(bool, string)> Create(UserDTO entity)
        {
            var alreadyExist = _userRepository.GetAll().Any(x => x.TCNo == entity.TCNo);
            if (alreadyExist != false)
            {
                return (false, "Kullanıcı Mevcut.");
            }

            var client = new KPSPublicSoapClient(KPSPublicSoapClient.EndpointConfiguration.KPSPublicSoap);

            var result = await client.TCKimlikNoDogrulaAsync(entity.TCNo, entity.FirstName, entity.LastName, entity.DateOfBirth.Year);

            if (!result.Body.TCKimlikNoDogrulaResult)
            {
                return (false, "Kullanıcı Doğrulanamadı.");
            }

            var user = _mapper.Map<User>(entity);
            _userRepository.Create(user);
            return (true, " ");

        }

        public bool Delete(UserDTO entity)
        {
            if (entity != null)
            {
                var user = _mapper.Map<User>(entity);
                _userRepository.Delete(user);
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<UserDTO> GetAll(Expression<Func<UserDTO, bool>> filter = null)
        {
            var users = _userRepository.GetAll().ToList();
            var userDtos = _mapper.Map<List<UserDTO>>(users);
            return userDtos;
        }

        public UserDTO GetById(int id)
        {
            var user = _userRepository.GetById(id);
            return _mapper.Map<UserDTO>(user);
        }

        public UserDTO Update(UserDTO entity)
        {
            var user = _userRepository.GetById(entity.Id);
            _userRepository.Update(_mapper.Map<User>(entity));
            return entity;
        }
    }
}
