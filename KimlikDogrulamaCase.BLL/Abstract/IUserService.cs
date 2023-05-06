using KimlikDogrulamaCase.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace KimlikDogrulamaCase.BLL.Abstract
{
    public interface IUserService
    {
        Task<(bool,string)> Create(UserDTO entity);
        UserDTO Update(UserDTO entity);
        bool Delete(UserDTO entity);
        List<UserDTO> GetAll(Expression<Func<UserDTO, bool>> filter = null);
        UserDTO GetById(int id);
    }
}
