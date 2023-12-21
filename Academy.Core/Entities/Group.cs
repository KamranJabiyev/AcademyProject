using Academy.Core.Interfaces;

namespace Academy.Core.Entities;

public class Group:IEntity
{
    public int Id { get; }
    public string Name { get; set; }
    public int MaxStudentCount { get; set; }
    public int CurrentStudentCount { get; set; }
    public Category Category { get; set; }
    public bool IsActive { get; set; }
    private static int _id;
    public Group(string name, int maxStudentCount,Category category)
    {
        Id = _id++;
        Name = name;
        MaxStudentCount = maxStudentCount;
        Category = category;
    }
   
}
