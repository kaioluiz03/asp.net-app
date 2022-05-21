using System.ComponentModel.DataAnnotations;
using System;

namespace CrudIntelectah.ViewModels
{

    public class CreatePatientViewModel
    {
        public int PatientId { get; set; }

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
        public int TypeOfExamId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }
    }
}