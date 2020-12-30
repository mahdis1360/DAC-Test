using BusinessLogicLayer;
using DataAccessLayer;
using DTOs;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Poco;
using System;

namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]


        public void Test_Create_Method()
        {
            //arrange
            UserDto user = new UserDto()
            {
                Id = Guid.NewGuid(),
                Name = "Joe",
                Family = "Smith",
                Email = "joesmith@outlook.com",
                Password = "1234",
                UserName = "joes"

            };
            
            Mock<IDataRepository<User>> mock = new Mock<IDataRepository<User>>();
            UserLogic logic = new UserLogic(mock.Object);
            UserDto[] users=null;
            users[0] = user; 
            try
            {
                logic.Add(users);

            }
            catch (Exception)
            {

                Assert.Fail("bad happen");
            }


        }

        [TestMethod]
            public void Test_Get_Method()
            {
                //arrange
                Guid id = Guid.NewGuid();
                Mock<IDataRepository<User>> mock = new Mock<IDataRepository<User>>();
                mock.Setup(repo => repo.Get( i=> i.Id ==id)).Returns(
                new User()
                {
                    Name = "Joe",
                    Family = "Smith",
                    Email = "joesmith@outlook.com",
                    Password = "1234",
                    UserName = "joes",
                    Id = id,
                    


                }); ;


                UserLogic logic = new UserLogic(mock.Object);
                //act
                User poco = logic.Get(id);
                //assert

                Assert.IsNotNull(logic);



        }

        [TestMethod]
        public void Test_Update_Method()
        {
            //arrange

            Mock<IDataRepository<User>> mock = new Mock<IDataRepository<User>>();
            UserDto user = new UserDto()
            {
                Name = "Joe",
                Family = "Smith",
                Email = "joesmith@outlook.com",
                Password = "1234",
                UserName = "joes",
                Id = Guid.NewGuid(),
            };

            UserLogic logic = new UserLogic(mock.Object);
            UserDto[] users = null;
            users[0] = user;

            try
            {
                logic.Update(users);

            }
            catch (Exception)
            {

                Assert.Fail("bad happen");
            }
        }




    }
}
