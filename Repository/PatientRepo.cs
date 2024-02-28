using Backend.Context;
using Backend.Entities;
using Backend.IRepository;
using Dapper;
using System.Data;
using System.Data.SqlClient;
using System.Numerics;
using System.Reflection;

namespace Backend.Repository
{
    public class PatientRepo : IPatientRepo
    {
        private SqlConnection _context;
        public PatientRepo(DbContext context)
        {
            _context = (SqlConnection)context.CreateConnection();
        }
    

        public void Create(Patient pt)
        {
             _context.Execute("insert into Patient(PatientFName,PatientLName,Age,Email,AppointmentDate,Phone,Gender,BodyPart,ExsistingDisease,DOB) values(@PatientFName,@PatientLName,@Age,@Email,@AppointmentDate,@Phone,@Gender,@BodyPart,@ExsistingDisease,@DOB)", new
            {
                // ProductId = ProductId,
                PatientFName = pt.PatientFName,
                PatientLName = pt.PatientLName,
                Age = pt.Age,
                Email = pt.Email,
                AppointmentDate = pt.AppointmentDate,
                Phone = pt.Phone,
                Gender = pt.Gender,
                BodyPart = pt.BodyPart,
                ExsistingDisease = pt.ExsistingDisease,
                DOB = pt.DOB
            }, commandType: CommandType.Text);
        }

        

        public void DeletePatient(int PatientId)
        {
            _context.Execute("PatientDelete", new
            {
                PatientId = PatientId
            }, commandType: CommandType.StoredProcedure);
        }
        public List<Patient> GetPatients()
        {
            List<Patient> patientlist = _context.Query<Patient>("AllPatients", commandType: CommandType.StoredProcedure).ToList();
            return patientlist;
        }
        public Patient GetSinglePatient(int PatientId)
        {
            var patient = _context.QuerySingle<Patient>("GetSinglePatient", new
            {
                PatientId = PatientId,
            }, commandType: CommandType.StoredProcedure);
            return patient;
        }

        public void Update(int PatientId, Patient pt)
        {
            _context.Execute("PatientUpdate", new
            {
                PatientId = PatientId,
                PatientFName = pt.PatientFName,
                PatientLName = pt.PatientLName,
                Age = pt.Age,
                Email = pt.Email,
                AppointmentDate = pt.AppointmentDate,
                Phone = pt.Phone,
                Gender = pt.Gender,
                BodyPart = pt.BodyPart,
                ExsistingDisease = pt.ExsistingDisease,
                DOB = pt.DOB
            }, commandType: CommandType.StoredProcedure);
        }

       List< Patient> IPatientRepo.GetAppoinment(DateTime AppointmentDate)
        {
            List<Patient> patients = (List<Patient>)_context.Query<Patient>("GetAppointment", new
            {
                AppointmentDate = AppointmentDate,
            }, commandType: CommandType.StoredProcedure);
            return patients;




        }




       
    }
}
