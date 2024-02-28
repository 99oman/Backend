using Backend.Entities;

namespace Backend.IRepository
{
    public interface IPatientRepo
    {

       
       
      
        public Patient GetSinglePatient(int PatientId);
        public void Create(Patient pt);
        public void Update(int PatientId,Patient pt);
        public List<Patient> GetAppoinment(DateTime AppointmentDate);

        public List<Patient> GetPatients();
        public void DeletePatient(int patientId); 

    }
}
