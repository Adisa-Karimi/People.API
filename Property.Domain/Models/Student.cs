using System.ComponentModel.DataAnnotations;

namespace People.Domain.Models
{
    public class Student
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Family { get; set; }
        public int Age { get; set; }
    }
}
