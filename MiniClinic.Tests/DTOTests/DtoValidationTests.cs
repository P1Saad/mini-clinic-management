using Application.DTOs;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace MiniClinic.Tests.DTOTests
{
    [TestClass]
    public class DtoValidationTests : TestBase
    {
        [TestMethod] public void PatientDto_ValidData_HasNoValidationErrors() => Assert.AreEqual(0, Validate(new PatientDto { PatientName="Ali", Phone="123456789", Age=20, Gender="Male" }).Count);
        [TestMethod] public void PatientDto_NullRequiredValues_HasValidationErrors() => Assert.IsTrue(Validate(new PatientDto()).Count >= 4);
        [TestMethod] public void PatientDto_ZeroAge_IsNotRejectedByDataAnnotations() => Assert.IsFalse(Validate(new PatientDto { PatientName="Ali", Phone="123456789", Age=0, Gender="Male" }).Count > 0);
        [TestMethod] public void DoctorDto_ValidData_HasNoValidationErrors() => Assert.AreEqual(0, Validate(new DoctorDto { DoctorName="Dr Ali", Phone="123456789", SpecialtyID=1 }).Count);
        [TestMethod] public void DoctorDto_NullRequiredValues_HasValidationErrors() => Assert.IsTrue(Validate(new DoctorDto()).Count >= 2);
        [TestMethod] public void AppointmentDto_ValidData_HasNoValidationErrors() => Assert.AreEqual(0, Validate(new AppointmentDto { PatientID=1, DoctorID=1, AppointmentDate=DateTime.UtcNow, Status="Booked" }).Count);
        [TestMethod] public void AppointmentDto_NullStatus_HasValidationError() => Assert.IsTrue(Validate(new AppointmentDto { PatientID=1, DoctorID=1, AppointmentDate=DateTime.UtcNow }).Count >= 1);
        [TestMethod] public void SpecialtyDto_EmptyName_HasValidationError() => Assert.IsTrue(Validate(new SpecialtyDto { SpecialtyName="" }).Count >= 1);
        [TestMethod] public void UserDto_ValidData_HasNoValidationErrors() => Assert.AreEqual(0, Validate(new UserDto { UserName="ali", Password="secret", FullName="Ali User" }).Count);
        [TestMethod] public void UserDto_WhitespaceValues_AreAcceptedByRequiredAttribute() => Assert.AreEqual(0, Validate(new UserDto { UserName=" ", Password=" ", FullName=" " }).Count);
    }
}
