namespace EFCoreDemo.Model
{
    public class CourseTag
    {
        public virtual Course Course { get; set; }
        public virtual Tag Tag { get; set; }

        public int CourseId { get; set; }
        public int TagId { get; set; }
    }
}
