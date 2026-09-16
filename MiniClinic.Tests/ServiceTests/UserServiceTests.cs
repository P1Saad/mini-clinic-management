using Application.DTOs;
using Application.ServiceImpl;
using Domain.Entities;
using Domain.IRepository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;

namespace MiniClinic.Tests.ServiceTests
{
 [TestClass] public class UserServiceTests:TestBase { Mock<IUserRepository> repo; UserServiceImpl service; [TestInitialize] public void Setup(){repo=new Mock<IUserRepository>();service=new UserServiceImpl(repo.Object,Mapper);} static UserDto V(int id=0)=>new UserDto{Id=id,UserName="ali",Password="secret",FullName="Ali User"};
 [TestMethod] public void CreateUser_Valid_AddsMappedEntity(){service.CreateUser(V());repo.Verify(r=>r.Add(It.Is<Users>(u=>u.Id==0&&u.Username=="ali")),Times.Once);}
 [TestMethod] public void CreateUser_Null_Throws(){Assert.ThrowsException<ArgumentNullException>(()=>service.CreateUser(null));}
 [TestMethod] public void CreateUser_DefaultString_Throws(){Assert.ThrowsException<ArgumentException>(()=>service.CreateUser(new UserDto{UserName="string",Password="secret",FullName="Ali"}));}
 [TestMethod] public void GetUserById_Missing_ReturnsNull(){repo.Setup(r=>r.GetById(1)).Returns((Users)null);Assert.IsNull(service.GetUserById(1));}
 [TestMethod] public void GetUserById_Existing_ReturnsDto(){repo.Setup(r=>r.GetById(1)).Returns(new Users{Id=1,Username="ali"});Assert.AreEqual("ali",service.GetUserById(1).UserName);}
 [TestMethod] public void GetAllUsers_ReturnsDtos(){repo.Setup(r=>r.GetAll()).Returns(new List<Users>{new Users{Id=1}});Assert.AreEqual(1,service.GetAllUsers().Count);}
 [TestMethod] public void UpdateUser_Existing_Updates(){var e=new Users{Id=1};repo.Setup(r=>r.GetById(1)).Returns(e);service.UpdateUser(V(1));repo.Verify(r=>r.Update(e),Times.Once);}
 [TestMethod] public void UpdateUser_Missing_Throws(){repo.Setup(r=>r.GetById(1)).Returns((Users)null);Assert.ThrowsException<ArgumentNullException>(()=>service.UpdateUser(V(1)));}
 [TestMethod] public void DeleteUser_Existing_Deletes(){repo.Setup(r=>r.GetById(1)).Returns(new Users{Id=1});service.DeleteUser(1);repo.Verify(r=>r.Delete(1),Times.Once);}
 [TestMethod] public void DeleteUser_Missing_Throws(){repo.Setup(r=>r.GetById(1)).Returns((Users)null);Assert.ThrowsException<ArgumentNullException>(()=>service.DeleteUser(1));}
 }
}
