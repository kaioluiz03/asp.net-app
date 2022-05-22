using System;


namespace CrudIntelectah.Models
{
    public class Patient
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Cpf { get; set; }

        public DateTime BirthDate { get; set; }

        public string Gender { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }
    }

    public class TypeOfExam
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }

    public class ExamRecord
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Observation { get; set; }

        public int TypeOfExamId { get; set; }
    }

    public class AppointmentScheduling
    {
        public int Id { get; set; }

        public string PatientId { get; set; }

        public int ExamRecordId { get; set; }

        public DateTime ConsultationDate { get; set; }

        public string ProtocolNumber { get; set; }
    }
}