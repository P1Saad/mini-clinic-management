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
    [TestClass] public class DoctorServiceTests : TestBase
    {
        Mock<IDoctorsRepository> repo; DoctorServiceImpl service;
        [TestInitialize] public void Setup(){repo=new Mock<IDoctorsRepository>();service=new DoctorServiceImpl(repo.Object,Mapper);}
        static DoctorDto Valid(int id=0)=>new DoctorDto{Id=id,DoctorName="Dr Ali",Phone="123456789",SpecialtyID=1};
        [TestMethod] public void CreateDoctor_ValidData_AddsEntity(){service.CreateDoctor(Valid());repo.Verify(r=>r.Add(It.Is<Doctors>(d=>d.Id==0)),Times.Once);}
        [TestMethod] public void CreateDoctor_NullDto_ThrowsArgumentNullException(){Assert.ThrowsException<ArgumentNullException>(()=>service.CreateDoctor(null));}
        [TestMethod] public void CreateDoctor_InvalidPhone_ThrowsArgumentException(){Assert.ThrowsException<ArgumentException>(()=>service.CreateDoctor(new DoctorDto{DoctorName="Dr",Phone="1",SpecialtyID=1}));}
        [TestMethod] public void GetDoctorById_Missing_ReturnsNull(){repo.Setup(r=>r.GetById(1)).Returns((Doctors)null);Assert.IsNull(service.GetDoctorById(1));}
        [TestMethod] public void GetDoctorById_Existing_ReturnsDto(){repo.Setup(r=>r.GetById(1)).Returns(new Doctors{Id=1,DoctorName="Dr Ali"});Assert.AreEqual("Dr Ali",service.GetDoctorById(1).DoctorName);}
        [TestMethod] public void GetAllDoctors_ReturnsMappedDtos(){repo.Setup(r=>r.GetAll()).Returns(new List<Doctors>{new Doctors{Id=1}});Assert.AreEqual(1,service.GetAllDoctors().Count);}
        [TestMethod] public void UpdateDoctor_Existing_UpdatesRepository(){var e=new Doctors{Id=1};repo.Setup(r=>r.GetById(1)).Returns(e);service.UpdateDoctor(Valid(1));repo.Verify(r=>r.Update(e),Times.Once);}
        [TestMethod] public void UpdateDoctor_Missing_ThrowsArgumentException(){repo.Setup(r=>r.GetById(1)).Returns((Doctors)null);Assert.ThrowsException<ArgumentException>(()=>service.UpdateDoctor(Valid(1)));}
        [TestMethod] public void DeleteDoctor_Existing_Deletes(){repo.Setup(r=>r.GetById(1)).Returns(new Doctors{Id=1});service.DeleteDoctor(1);repo.Verify(r=>r.Delete(1),Times.Once);}
        [TestMethod] public void DeleteDoctor_Missing_ThrowsArgumentNullException(){repo.Setup(r=>r.GetById(1)).Returns((Doctors)null);Assert.ThrowsException<ArgumentNullException>(()=>service.DeleteDoctor(1));}
    }
}
