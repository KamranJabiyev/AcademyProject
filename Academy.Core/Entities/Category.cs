using Academy.Core.Interfaces;

namespace Academy.Core.Entities;

public class Category : IEntity
{
    public int Id { get; }
    public string Name { get; set; }
    public string Description { get; set; }
    public bool IsActive { get; set; } = true;
    private static int _id;
    public Category(string name, string description)
    {
        Id = _id++;
        Name = name;
        Description = description;
    }

}
