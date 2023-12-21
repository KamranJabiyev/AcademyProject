using Academy.Core.Entities;

namespace Academy.DataAccess.Contexts;

public static class AcademyDbContext
{
    public static List<Group> Groups { get; set; }= new List<Group>();
    public static List<Category> Categories { get; set; } = new List<Category>();
    public static List<Student> Students { get; set; } = new List<Student>();
}
