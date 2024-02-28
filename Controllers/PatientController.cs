using Backend.Entities;
using Backend.IRepository;
using Microsoft.AspNetCore.DataProtection.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IPatientRepo _ptrepository;
        public PatientController(IPatientRepo ptrepository)
        {
            _ptrepository = ptrepository;
        }

        [HttpPost]
        public void Create(Patient patient)
        {
            try
            {
                _ptrepository.Create(patient);

            }
            catch (Exception ex)
            {
                //log error
                throw ex;
            }
        }

        [HttpGet("{id}")]
        public Patient GetSinglePatient(int patientId)
        {
            try
            {

                Patient patient = _ptrepository.GetSinglePatient(patientId);
                return patient;

            }
            catch (Exception ex)
            {
                //log error
                throw ex;
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdatePatient(int id, Patient patient)
        {
            try
            {
                _ptrepository.Update(id, patient);
                return NoContent();
            }
            catch
            {
                return BadRequest();
            }

        }

        [HttpGet]

        public List<Patient> GetAllPatients()

        {

            List<Patient> patient = _ptrepository.GetPatients();

            return patient;

        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _ptrepository.DeletePatient(id);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

         [HttpGet("{AppointmentDate}/Appointment")]
        
        public List<Patient> CheckAppointment(DateTime AppointmentDate)
        {

            var checkappointment =  _ptrepository.GetAppoinment(AppointmentDate);
            return checkappointment;


        }

        


    }
}
