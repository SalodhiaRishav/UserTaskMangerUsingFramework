using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.DomainModels;
using Shared.Interfaces.BusinessLogicInterfaces;
using Shared.Interfaces.RepositoryInterfaces;
using Shared.Utils;

namespace BAL.BusinessLogics
{
    public class UserBusinessLogic : IUserBusinessLogic
    {
        IUserRepository UserRepository;
        public UserBusinessLogic(IUserRepository userRepository)
        {
            UserRepository = userRepository;
        }
        public MessageFormat<User> Add(User user)
        {
            user.CreatedOn = DateTime.Now;
            user.ModifiedOn = DateTime.Now;
            MessageFormat<User> result = new MessageFormat<User>();
            try
            {
                var userList = UserRepository.List;
                if (userList.Count != 0)
                {
                    var tempuser = userList.Find(fuser => fuser.Email == user.Email);
                    if (tempuser != null)
                    {
                        result.Message = "Email already exists";
                        result.Success = false;
                        return result;
                    }
                    else
                    {
                        UserRepository.Add(user);                                           
                        result.Data = user;
                        result.Message = "Added successfully";
                        result.Success = true;
                        return result;
                    }
                }
                else
                {
                    UserRepository.Add(user);
                    result.Data = user;
                    result.Message = "Added successfully";
                    result.Success = true;
                    return result;                    
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public MessageFormat<User> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public MessageFormat<List<User>> GetAll()
        {
            throw new NotImplementedException();
        }

        public MessageFormat<User> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public MessageFormat<User> Update(User userDTO)
        {
            throw new NotImplementedException();
        }
    }
}
