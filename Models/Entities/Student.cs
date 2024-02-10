using System.ComponentModel.DataAnnotations;

namespace MvsStudentApplication.Models.Entities
{
    public class Student
    {
       
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public bool IsActive { get; set; }
    }
}
