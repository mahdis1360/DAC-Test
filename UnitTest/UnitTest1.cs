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
     //   [TestMethod]
     
      
            //public void Test_Create_Method()
            //{
            //    //arrange
            //    UserDto user = new UserDto()
            //    {
            //        Id = Guid.NewGuid(),
            //        Name = "Joe",
            //        Family="Smith",
            //        Email="joesmith@outlook.com",
            //        Password="1234",
            //        UserName="joes"

            //    };

            //    Mock<IDataRepository<User>> mock = new Mock<IDataRepository<User>>();
            //    UserLogic logic = new UserLogic(mock.Object);

            //    try
            //    {
            //        logic.Add(user);

            //    }
            //    catch (Exception)
            //    {

            //        Assert.Fail("bad happen");
            //    }


            //}

            [TestMethod]
            public void Test_Get_Method()
            {
                //arrange
                Guid id = Guid.NewGuid();
                Mock<IDataRepository<UserDto>> mock = new Mock<IDataRepository<UserDto>>();
                mock.Setup(repo => repo.Get( i=> i.Id ==id)).Returns(
                new UserDto()
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
                Assert.AreEqual("Family", poco.Family);


            }

        //    [TestMethod]
        //    public void Test_Update_Method()
        //    {
        //        //arrange

        //        Mock<IDataRepository<UserDto>> mock = new Mock<IDataRepository<UserDto>>();
        //        UserDto user = new UserDto()
        //        {
        //            Name = "Joe",
        //            Family = "Smith",
        //            Email = "joesmith@outlook.com",
        //            Password = "1234",
        //            UserName = "joes",
        //            Id = Guid.NewGuid(),
        //        };

        //        UserLogic logic = new UserLogic(null);

        //        try
        //        {
        //            logic.Update(user);

        //        }
        //        catch (Exception)
        //        {

        //            Assert.Fail("bad happen");
        //        }
        //    }
        //    [TestMethod]
        //    public void Test_Search_Method()
        //    {
        //        //arrange
        //        string searchdetail = "travel to Mexico";
        //        Mock<IDataRepository<BookPoco>> mock = new Mock<IDataRepository<BookPoco>>();
        //        mock.Setup(repo => repo.GetList(searchdetail)).Returns(
        //        new BookPoco()
        //        {
        //            AutorId = Guid.NewGuid(),
        //            Description = "travel to Mexico",
        //            Title = "travel",
        //            Price = 20,
        //            Id = Guid.NewGuid(),


        //        });


        //        BookLogic logic = new BookLogic(mock.Object);
        //        //act
        //        BookPoco poco = logic.Search(searchdetail);
        //        //assert

        //        Assert.IsNotNull(logic);
        //        Assert.AreEqual("travel to Mexico", poco.Description);


        //    }
        //}
    }
}
