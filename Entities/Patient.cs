namespace Backend.Entities
{
    public class Patient
    {
        public int PatientId { get; set; }
        public string PatientFName { get; set; }
        public string PatientLName { get; set; }
        public int Age { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Gender { get; set; }
        public string BodyPart { get; set; }
        public string ExsistingDisease { get; set; }
        public DateTime DOB { get; set; }
        }

           
    }


