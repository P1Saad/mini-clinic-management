using Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IService
{
    public interface IAppointmentService
    {
        void CreateAppointment(AppointmentDto appointmentDto);
        AppointmentDto GetAppointmentById(int id);
        IList<AppointmentDto> GetAllAppointments();
        void UpdateAppointment(AppointmentDto appointmentDto);
        void DeleteAppointment(int id);
    }
}
