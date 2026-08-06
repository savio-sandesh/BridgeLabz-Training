using System.Collections.Generic;
using HealthClinic.Entity;

namespace HealthClinic.Interface
{
    public interface IDoctorService
    {
        void AddDoctor(Doctor doctor);

        List<Doctor> GetAllDoctors();

        Doctor GetDoctorById(int doctorId);

        void UpdateDoctor(Doctor doctor);

        void DeleteDoctor(int doctorId);
    }
}