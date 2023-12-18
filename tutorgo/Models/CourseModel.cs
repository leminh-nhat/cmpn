using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tutorgo.Models
{
    public class CourseModel
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Yêu cầu nhập tên khóa học")]
        public string Name { get; set; }
        public string Slug { get; set; }
        [Required, MinLength(4, ErrorMessage = "Yêu cầu nhập mô tả khóa học")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Yêu cầu nhập giá khóa học")]
        public decimal Price { get; set; }
        [Required, Range(1, int.MaxValue, ErrorMessage = "Chọn danh mục")]
        public int CategoryId { get; set; }
        public CategoryModel Category { get; set; }
        public string Image { get; set; } = "noimage.jpg";
        [NotMapped]
        [FileExtensions]
        public IFormFile ImageUpload { get; set; }
    }
}
