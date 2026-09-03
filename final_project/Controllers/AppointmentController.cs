using Application.DTOs;
using Application.IService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using MiniClinicManagement.Controllers.Base;

namespace MiniClinicManagement.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AppointmentController : BaseController
    {
        private readonly IAppointmentService _appointmentService;

        public AppointmentController(ILogger<AppointmentController> logger, IAppointmentService appointmentService)
            : base(logger)
        {
            _appointmentService = appointmentService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var appointments = _appointmentService.GetAllAppointments();
                return HandleResponse(appointments);
            }
            catch (Exception ex)
            {
                return HandleError(ex, "Failed to retrieve appointments.");
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                var appointment = _appointmentService.GetAppointmentById(id);
                if (appointment == null)
                {
                    return NotFound(new { message = "Appointment not found.", success = false });
                }
                return HandleResponse(appointment);
            }
            catch (Exception ex)
            {
                return HandleError(ex, $"Failed to retrieve appointment with ID: {id}.");
            }
        }

        [HttpPost]
        public IActionResult Create([FromBody] AppointmentDto appointmentDto)
        {
            try
            {
                if (appointmentDto == null)
                {
                    return BadRequest(new { message = "Invalid appointment data.", success = false });
                }

                _appointmentService.CreateAppointment(appointmentDto);
                return HandleResponse(new { message = "Appointment created successfully.", success = true });
            }
            catch (Exception ex)
            {
                return HandleError(ex, "Failed to create appointment.");
            }
        }

        [HttpPut]
        public IActionResult Update([FromBody] AppointmentDto appointmentDto)
        {
            try
            {
                if (appointmentDto == null)
                {
                    return BadRequest(new { message = "Invalid appointment data.", success = false });
                }

                _appointmentService.UpdateAppointment(appointmentDto);
                return HandleResponse(new { message = "Appointment updated successfully.", success = true });
            }
            catch (ArgumentException)
            {
                return NotFound(new { message = "Appointment not found to update.", success = false });
            }
            catch (Exception ex)
            {
                return HandleError(ex, "Failed to update appointment.");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _appointmentService.DeleteAppointment(id);
                return HandleResponse(new { message = "Appointment deleted successfully.", success = true });
            }
            catch (Exception ex)
            {
                return HandleError(ex, $"Failed to delete appointment with ID: {id}.");
            }
        }
    }
}