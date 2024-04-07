

namespace Infrastructure.Entities;

public class CoursesEntity
{
    public int Id { get; set; }
    public string? CourseImage { get; set; }
    public string Title { get; set; } = null!;
    public string Price { get; set; } = null!;
    public string? DiscountPrice { get; set; } 
    public string Hours { get; set; } = null!;
    public bool IsBestSeller { get; set; }
    public string? LikesInNumber { get; set; }
    public string? LikesInProcent { get; set; }
    public string Author { get; set; } = null!;
}
