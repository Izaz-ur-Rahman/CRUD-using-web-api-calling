using System.ComponentModel.DataAnnotations;

namespace CRUDusingWebApi.Models
{
   
    public class Student
    {
        public int id { get; set; }
        [Required]
        public string studentName { get; set; }
        [Required]
        public string gender { get; set; }
        [Required]
        public int age { get; set; }
        [Required]
        public string standard { get; set; }
        [Required]
        public string fatherName { get; set; }
    }

}
