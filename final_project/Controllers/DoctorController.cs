using Application.DTOs;
using Application.IService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using UserManagement.Api.Controllers;

namespace UserManagement.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DoctorController : BaseController
    {
        private readonly IDoctorService _doctorService;

        public DoctorController(ILogger<DoctorController> logger, IDoctorService doctorService)
            : base(logger)
        {
            _doctorService = doctorService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var doctors = _doctorService.GetAllDoctors();
                return HandleResponse(doctors);
            }
            catch (Exception ex)
            {
                return HandleError(ex, "Failed to retrieve doctors.");
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                var doctor = _doctorService.GetDoctorById(id);
                if (doctor == null)
                {
                    return NotFound(new { message = "Doctor not found.", success = false });
                }
                return HandleResponse(doctor);
            }
            catch (Exception ex)
            {
                return HandleError(ex, $"Failed to retrieve doctor with ID: {id}.");
            }
        }

        [HttpPost]
        public IActionResult Create([FromBody] DoctorDto doctorDto)
        {
            try
            {
                if (doctorDto == null)
                {
                    return BadRequest(new { message = "Invalid doctor data.", success = false });
                }

                _doctorService.CreateDoctor(doctorDto);
                return HandleResponse(new { message = "Doctor created successfully.", success = true });
            }
            catch (Exception ex)
            {
                return HandleError(ex, "Failed to create doctor.");
            }
        }

        [HttpPut]
        public IActionResult Update([FromBody] DoctorDto doctorDto)
        {
            try
            {
                if (doctorDto == null)
                {
                    return BadRequest(new { message = "Invalid doctor data.", success = false });
                }

                _doctorService.UpdateDoctor(doctorDto);
                return HandleResponse(new { message = "Doctor updated successfully.", success = true });
            }
            catch (ArgumentException)
            {
                return NotFound(new { message = "Doctor not found to update.", success = false });
            }
            catch (Exception ex)
            {
                return HandleError(ex, "Failed to update doctor.");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _doctorService.DeleteDoctor(id);
                return HandleResponse(new { message = "Doctor deleted successfully.", success = true });
            }
            catch (Exception ex)
            {
                return HandleError(ex, $"Failed to delete doctor with ID: {id}.");
            }
        }
    }
}
