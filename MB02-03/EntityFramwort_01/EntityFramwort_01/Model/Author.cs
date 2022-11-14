using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreDemo.Model
{
    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? City { get; set; }
        public CourseLevel Level { get; set; }
        public string? Phone { get; set; }

        [Column(TypeName = "decimal(7,2)")]
        public decimal Salary { get; set; }
        public virtual ICollection<Course> Courses { get; set; }
    }
}
