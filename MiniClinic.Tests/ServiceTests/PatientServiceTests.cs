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
    [TestClass]
    public class PatientServiceTests : TestBase
    {
        private Mock<IPatientsRepository> repo; private PatientServiceImpl service;
        [TestInitialize] public void Setup(){ repo=new Mock<IPatientsRepository>(); service=new PatientServiceImpl(repo.Object,Mapper); }
        private static PatientDto Valid(int id=0)=>new PatientDto{Id=id,PatientName="Ali",Phone="123456789",Age=20,Gender="Male"};
        [TestMethod] public void CreatePatient_ValidData_AddsMappedEntity(){service.CreatePatient(Valid()); repo.Verify(r=>r.Add(It.Is<Patients>(p=>p.Id==0&&p.PatientName=="Ali")),Times.Once);}
        [TestMethod] public void CreatePatient_NullDto_ThrowsArgumentNullException(){Assert.ThrowsException<ArgumentNullException>(()=>service.CreatePatient(null)); repo.Verify(r=>r.Add(It.IsAny<Patients>()),Times.Never);}
        [TestMethod] public void CreatePatient_InvalidPhone_ThrowsArgumentException(){Assert.ThrowsException<ArgumentException>(()=>service.CreatePatient(new PatientDto{PatientName="Ali",Phone="1",Age=20,Gender="Male"}));}
        [TestMethod] public void CreatePatient_NonPositiveAge_ThrowsArgumentException(){Assert.ThrowsException<ArgumentException>(()=>service.CreatePatient(new PatientDto{PatientName="Ali",Phone="123456789",Age=0,Gender="Male"}));}
        [TestMethod] public void GetPatientById_ExistingPatient_ReturnsMappedDto(){repo.Setup(r=>r.GetById(1)).Returns(new Patients{Id=1,PatientName="Ali",Phone="123456789",Age=20,Gender="Male"}); Assert.AreEqual("Ali",service.GetPatientById(1).PatientName);}
        [TestMethod] public void GetPatientById_MissingPatient_ReturnsNull(){repo.Setup(r=>r.GetById(2)).Returns((Patients)null); Assert.IsNull(service.GetPatientById(2));}
        [TestMethod] public void GetAllPatients_RepositoryReturnsEntities_ReturnsDtos(){repo.Setup(r=>r.GetAll()).Returns(new List<Patients>{new Patients{Id=1,PatientName="Ali"}}); Assert.AreEqual(1,service.GetAllPatients().Count);}
        [TestMethod] public void UpdatePatient_ExistingPatient_UpdatesRepository(){var e=new Patients{Id=1}; repo.Setup(r=>r.GetById(1)).Returns(e); service.UpdatePatient(Valid(1)); repo.Verify(r=>r.Update(e),Times.Once); Assert.AreEqual("Ali",e.PatientName);}
        [TestMethod] public void UpdatePatient_MissingPatient_ThrowsArgumentException(){repo.Setup(r=>r.GetById(1)).Returns((Patients)null); Assert.ThrowsException<ArgumentException>(()=>service.UpdatePatient(Valid(1)));}
        [TestMethod] public void DeletePatient_ExistingPatient_DeletesIt(){repo.Setup(r=>r.GetById(1)).Returns(new Patients{Id=1}); service.DeletePatient(1); repo.Verify(r=>r.Delete(1),Times.Once);}
        [TestMethod] public void DeletePatient_MissingPatient_ThrowsArgumentNullException(){repo.Setup(r=>r.GetById(1)).Returns((Patients)null); Assert.ThrowsException<ArgumentNullException>(()=>service.DeletePatient(1));}
    }
}
