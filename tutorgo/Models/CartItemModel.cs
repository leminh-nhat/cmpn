namespace tutorgo.Models
{
    public class CartItemModel
    {
        public long CourseId { get; set; }
        public string CourseName { get; set; }
        public decimal Price { get; set; }
        public decimal Total
        {
            get { return Price; }
        }
        public string Image { get; set; }
        public CartItemModel()
        {

        }
        public CartItemModel(CourseModel course)
        {
            CourseId = course.Id;
            CourseName = course.Name;
            Price = course.Price;
            Image = course.Image;
        }
    }
}
