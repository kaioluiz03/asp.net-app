using System.ComponentModel.DataAnnotations;
using System;

namespace CrudIntelectah.ViewModels
{

    public class CreatePatientViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Cpf { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }

        [Required]
        public string Gender { get; set; }

        [Required]
        public string Phone { get; set; }

        [Required]
        public string Email { get; set; }
    }

    public class CreateTypeOfExamViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }
    }

    public class CreateExamRecordViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Observation { get; set; }

        public int TypeOfExamId { get; set; }
    }

    public class CreateAppointmentSchedulingViewModel
    {
        public int Id { get; set; }

        public string PatientId { get; set; }

        public int ExamRecordId { get; set; }

        public DateTime ConsultationDate { get; set; }

        public string ProtocolNumber { get; set; }
    }
}