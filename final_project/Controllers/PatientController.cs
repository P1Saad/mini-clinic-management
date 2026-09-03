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
    public class PatientController : BaseController
    {
        private readonly IPatientService _patientService;

        public PatientController(ILogger<PatientController> logger, IPatientService patientService)
            : base(logger)
        {
            _patientService = patientService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var patients = _patientService.GetAllPatients();
                return HandleResponse(patients);
            }
            catch (Exception ex)
            {
                return HandleError(ex, "Failed to retrieve patients.");
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                var patient = _patientService.GetPatientById(id);
                if (patient == null)
                {
                    return NotFound(new { message = "Patient not found.", success = false });
                }
                return HandleResponse(patient);
            }
            catch (Exception ex)
            {
                return HandleError(ex, $"Failed to retrieve patient with ID: {id}.");
            }
        }

        [HttpPost]
        public IActionResult Create([FromBody] PatientDto patientDto)
        {
            try
            {
                if (patientDto == null)
                {
                    return BadRequest(new { message = "Invalid patient data.", success = false });
                }

                _patientService.CreatePatient(patientDto);
                return HandleResponse(new { message = "Patient created successfully.", success = true });
            }
            catch (Exception ex)
            {
                return HandleError(ex, "Failed to create patient.");
            }
        }

        [HttpPut]
        public IActionResult Update([FromBody] PatientDto patientDto)
        {
            try
            {
                if (patientDto == null)
                {
                    return BadRequest(new { message = "Invalid patient data.", success = false });
                }

                _patientService.UpdatePatient(patientDto);
                return HandleResponse(new { message = "Patient updated successfully.", success = true });
            }
            catch (ArgumentException)
            {
                return NotFound(new { message = "Patient not found to update.", success = false });
            }
            catch (Exception ex)
            {
                return HandleError(ex, "Failed to update patient.");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _patientService.DeletePatient(id);
                return HandleResponse(new { message = "Patient deleted successfully.", success = true });
            }
            catch (Exception ex)
            {
                return HandleError(ex, $"Failed to delete patient with ID: {id}.");
            }
        }
    }
}