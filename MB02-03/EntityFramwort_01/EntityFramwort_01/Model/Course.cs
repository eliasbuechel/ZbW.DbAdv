namespace EFCoreDemo.Model
{
    public class Course
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public virtual Author Author { get; set; }
        public CourseLevel Level { get; set; }
        public decimal FullPrice { get; set; }
        public virtual ICollection<CourseTag> CourseTags { get; set; }
        public virtual Category Category { get; set; }
    }
}
