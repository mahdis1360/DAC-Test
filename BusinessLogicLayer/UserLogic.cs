using AutoMapper;
using DataAccessLayer;
using DTOs;
using Poco;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BusinessLogicLayer
{
     public class UserLogic :BaseLogic<User>
    {
        public UserLogic(IDataRepository<User> repository) : base(repository)
        {
        }
        protected  override void Verify(User[] users)
        {
            List<ValidationException> exceptions = new List<ValidationException>();
            foreach (var user in users)
            {
                if (string.IsNullOrEmpty(user.Name))
                {
                    exceptions.Add(new ValidationException ("Name can not be empty"));
                }
                if (string.IsNullOrEmpty(user.Family))
                {
                    exceptions.Add(new ValidationException("Family can not be empty"));
                }
            }
            if (exceptions.Count > 0)
            {
                throw new AggregateException(exceptions);
            }
        }


        public  void Add(UserDto[] dtos)
        {
            List<User> users = new List<User>();

            MapperConfiguration config = new MapperConfiguration(
                cfg => cfg.CreateMap<UserDto, User>());

            var mapper = config.CreateMapper();

            foreach (var dto in dtos)
            {

              User user=  mapper.Map<User>(dto);
                users.Add(user);
            }

            Verify(users.ToArray());
            base.Add(users.ToArray());
        }
        public void Update(UserDto[] dtos)
        {
            List<User> users = new List<User>();

            MapperConfiguration config = new MapperConfiguration(
                cfg => cfg.CreateMap<UserDto, User>());

            var mapper = config.CreateMapper();

            foreach (var dto in dtos)
            {

                User user = mapper.Map<User>(dto);
                users.Add(user);
            }
            Verify(users.ToArray());
            base.Update(users.ToArray());
        }
    }
}
