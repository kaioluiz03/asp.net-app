using System;


namespace CrudIntelectah.Models
{
    public class Patient
    {
        public int PatientId { get; set; }

        public string Name { get; set; }

        public string Cpf { get; set; }

        public DateTime BirthDate { get; set; }

        public string Gender { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }
    }

    public class TypeOfExam
    {
        public int TypeOfExamId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}