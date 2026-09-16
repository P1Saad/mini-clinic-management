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
 [TestClass] public class SpecialtyServiceTests:TestBase { Mock<ISpecialtiesRepository> repo; SpecialtyServiceImpl service; [TestInitialize] public void Setup(){repo=new Mock<ISpecialtiesRepository>();service=new SpecialtyServiceImpl(repo.Object,Mapper);} static SpecialtyDto V(int id=0)=>new SpecialtyDto{Id=id,SpecialtyName="Cardiology"};
 [TestMethod] public void CreateSpecialty_Valid_Adds(){service.CreateSpecialty(V());repo.Verify(r=>r.Add(It.Is<Specialties>(s=>s.Id==0&&s.SpecialtyName=="Cardiology")),Times.Once);}
 [TestMethod] public void CreateSpecialty_Null_Throws(){Assert.ThrowsException<ArgumentNullException>(()=>service.CreateSpecialty(null));}
 [TestMethod] public void CreateSpecialty_DefaultString_Throws(){Assert.ThrowsException<ArgumentNullException>(()=>service.CreateSpecialty(new SpecialtyDto{SpecialtyName="string"}));}
 [TestMethod] public void GetSpecialtyById_Missing_ReturnsNull(){repo.Setup(r=>r.GetById(1)).Returns((Specialties)null);Assert.IsNull(service.GetSpecialtyById(1));}
 [TestMethod] public void GetSpecialtyById_Existing_ReturnsDto(){repo.Setup(r=>r.GetById(1)).Returns(new Specialties{Id=1,SpecialtyName="Cardiology"});Assert.AreEqual("Cardiology",service.GetSpecialtyById(1).SpecialtyName);}
 [TestMethod] public void GetAllSpecialties_ReturnsDtos(){repo.Setup(r=>r.GetAll()).Returns(new List<Specialties>{new Specialties{Id=1}});Assert.AreEqual(1,service.GetAllSpecialties().Count);}
 [TestMethod] public void UpdateSpecialty_Existing_Updates(){var e=new Specialties{Id=1};repo.Setup(r=>r.GetById(1)).Returns(e);service.UpdateSpecialty(V(1));repo.Verify(r=>r.Update(e),Times.Once);}
 [TestMethod] public void UpdateSpecialty_Missing_Throws(){repo.Setup(r=>r.GetById(1)).Returns((Specialties)null);Assert.ThrowsException<ArgumentException>(()=>service.UpdateSpecialty(V(1)));}
 [TestMethod] public void DeleteSpecialty_Existing_Deletes(){repo.Setup(r=>r.GetById(1)).Returns(new Specialties{Id=1});service.DeleteSpecialty(1);repo.Verify(r=>r.Delete(1),Times.Once);}
 [TestMethod] public void DeleteSpecialty_Missing_Throws(){repo.Setup(r=>r.GetById(1)).Returns((Specialties)null);Assert.ThrowsException<ArgumentNullException>(()=>service.DeleteSpecialty(1));}
 }
}
