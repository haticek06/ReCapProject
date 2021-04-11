using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Entities.Concrete;
using Core.Utilities.Aspects.Autofac.Validation;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        [ValidationAspect(typeof(UserValidator))]
        public IResult Add(User entity)
        {
            _userDal.Add(entity);
            return new SuccessResult(Messages.AddUserMessage);
        }

        public IResult Delete(User entity)
        {
            _userDal.Delete(entity);
            return new SuccessResult(Messages.DeleteUserMessage);
        }

        public IDataResult<User> Get(int id)
        {
            User user = _userDal.Get(p => p.Id == id);
            if (user == null)
            {
                return new ErrorDataResult<User>(Messages.GetErrorUserMessage);
            }
            else
            {
                return new SuccessDataResult<User>(user, Messages.GetSuccessUserMessage);
            }
        }

        public IDataResult<List<User>> GetAll()
        {
            List<User> users = _userDal.GetAll();
            if (users.Count == 0)
            {
                return new ErrorDataResult<List<User>>(Messages.GetErrorUserMessage);
            }
            else
            {
                return new SuccessDataResult<List<User>>(users, Messages.GetSuccessUserMessage);
            }
        }

        public IDataResult<User> GetByEmail(string email)
        {
            User user = _userDal.Get(p => p.Email.ToLower() == email.ToLower());
            if (user == null)
            {
                return new ErrorDataResult<User>(Messages.GetErrorUserMessage);
            }
            else
            {
                return new SuccessDataResult<User>(user, Messages.GetSuccessUserMessage);
            }
        }

        public IDataResult<UserBasicDto> GetByEmailDto(string email)
        {
            User user = _userDal.Get(p => p.Email.ToLower() == email.ToLower());
            if (user == null)
            {
                return new ErrorDataResult<UserBasicDto>(Messages.GetErrorUserMessage);
            }
            else
            {
                return new SuccessDataResult<UserBasicDto>(new UserBasicDto { Id = user.Id, Email = user.Email, FirstName = user.FirstName, LastName = user.LastName }, Messages.GetSuccessUserMessage);
            }
        }

        public IDataResult<List<OperationClaim>> GetClaims(User user)
        {
            return new SuccessDataResult<List<OperationClaim>>(_userDal.GetClaims(user));
        }


        [ValidationAspect(typeof(UserValidator))]
        public IResult Update(User entity)
        {
            _userDal.Update(entity);
            return new SuccessResult(Messages.EditUserMessage);
        }


    }

}
