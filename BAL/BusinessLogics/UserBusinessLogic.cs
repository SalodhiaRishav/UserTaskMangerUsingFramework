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
            MessageFormat<User> result = new MessageFormat<User>();
            try
            {
                User user = this.UserRepository.FindById(id);
                if (user == null)
                {
                    result.Message = "No task found with this id";
                    result.Success = false;
                    return result;
                }
                this.UserRepository.Delete(user);           
                result.Message = "Deleted successfully";
                result.Success = true;
                return result;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public MessageFormat<List<User>> GetAll()
        {
            MessageFormat<List<User>> result = new MessageFormat<List<User>>();
            try
            {
                List<User> userList = this.UserRepository.List;
                if (userList.Count == 0)
                {
                    result.Message = "Empty List";
                    result.Success = false;
                    return result;
                }
                result.Message = "Retrieved Successfully";
                result.Success = true;
                result.Data = userList;
                return result;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public MessageFormat<User> GetById(int id)
        {
            MessageFormat<User> result = new MessageFormat<User>();
            try
            {
                User user = this.UserRepository.FindById(id);
                if (user == null)
                {
                    result.Message = "No task found with this id";
                    result.Success = false;
                    return result;
                }
              
                result.Message = "Retrieved successfully";
                result.Success = true;
                result.Data = user;
                return result;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public MessageFormat<User> Update(User user)
        {
            MessageFormat<User> result = new MessageFormat<User>();
            user.ModifiedOn = DateTime.Now;
            try
            {
               this.UserRepository.Update(user);                
                result.Message = "Updated Successfully";
                result.Data = user;
                result.Success = true;
                return result;

            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
    }
}
