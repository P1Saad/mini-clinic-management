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
 [TestClass] public class AppointmentServiceTests:TestBase { Mock<IAppointmentsRepository> repo; AppointmentServiceImpl service; [TestInitialize] public void Setup(){repo=new Mock<IAppointmentsRepository>();service=new AppointmentServiceImpl(repo.Object,Mapper);} static AppointmentDto V(int id=0)=>new AppointmentDto{Id=id,PatientID=1,DoctorID=1,AppointmentDate=new DateTime(2026,1,1),Status="Booked"};
 [TestMethod] public void CreateAppointment_Valid_AddsMappedEntity(){service.CreateAppointment(V());repo.Verify(r=>r.Add(It.Is<Appointments>(a=>a.Id==0&&a.PatientID==1&&a.DoctorID==1)),Times.Once);}
 [TestMethod] public void CreateAppointment_Null_Throws(){Assert.ThrowsException<ArgumentNullException>(()=>service.CreateAppointment(null));}
 [TestMethod] public void CreateAppointment_NegativePatientId_Throws(){Assert.ThrowsException<ArgumentException>(()=>service.CreateAppointment(new AppointmentDto{PatientID=-1,DoctorID=1,AppointmentDate=DateTime.UtcNow,Status="Booked"}));}
 [TestMethod] public void GetAppointmentById_Missing_ReturnsNull(){repo.Setup(r=>r.GetById(1)).Returns((Appointments)null);Assert.IsNull(service.GetAppointmentById(1));}
 [TestMethod] public void GetAppointmentById_Existing_ReturnsDto(){repo.Setup(r=>r.GetById(1)).Returns(new Appointments{Id=1,PatientID=2,DoctorID=3,AppointmentDate=new DateTime(2026,1,1),Status="Booked"});Assert.AreEqual(2,service.GetAppointmentById(1).PatientID);}
 [TestMethod] public void GetAllAppointments_ReturnsDtos(){repo.Setup(r=>r.GetAll()).Returns(new List<Appointments>{new Appointments{Id=1}});Assert.AreEqual(1,service.GetAllAppointments().Count);}
 [TestMethod] public void UpdateAppointment_Existing_Updates(){var e=new Appointments{Id=1};repo.Setup(r=>r.GetById(1)).Returns(e);service.UpdateAppointment(V(1));repo.Verify(r=>r.Update(e),Times.Once);}
 [TestMethod] public void UpdateAppointment_Missing_Throws(){repo.Setup(r=>r.GetById(1)).Returns((Appointments)null);Assert.ThrowsException<ArgumentException>(()=>service.UpdateAppointment(V(1)));}
 [TestMethod] public void DeleteAppointment_Existing_Deletes(){repo.Setup(r=>r.GetById(1)).Returns(new Appointments{Id=1});service.DeleteAppointment(1);repo.Verify(r=>r.Delete(1),Times.Once);}
 [TestMethod] public void DeleteAppointment_Missing_Throws(){repo.Setup(r=>r.GetById(1)).Returns((Appointments)null);Assert.ThrowsException<ArgumentNullException>(()=>service.DeleteAppointment(1));}
 }
}
