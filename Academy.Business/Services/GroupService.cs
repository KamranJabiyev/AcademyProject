using Academy.Business.Interfaces;
using Academy.Business.Utilities.Exceptions;
using Academy.Core.Entities;
using Academy.DataAccess.Contexts;

namespace Academy.Business.Services;

public class GroupService : IGroupService
{
    private ICategoryService categoryService { get; }
    public GroupService()
    {
        categoryService = new CategoryService();
    }
    public void Create(string name, int maxStudentCount, string categoryName)
    {
        if (String.IsNullOrEmpty(name)) throw new ArgumentNullException();
        Group? dbGroup =
            AcademyDbContext.Groups.Find(c => c.Name.ToLower() == name.ToLower());
        if (dbGroup is not null)
            throw new AlreadyExistException($"{dbGroup.Name} is already exist");
        if (maxStudentCount < 4)
            throw new MinCountException("Minimum student count requirement is 4");
        Category? category=categoryService.FindCategoryByName(categoryName);
        if (category is null) throw new NotFoundException($"{categoryName} is not exist");
        Group group = new(name,maxStudentCount, category);
        AcademyDbContext.Groups.Add(group);
    }
    public void Activate(string name, bool activated)
    {
        throw new NotImplementedException();
    }

    public void Delete(string name)
    {
        throw new NotImplementedException();
    }

    public Group? GetById(int id)
    {
        throw new NotImplementedException();
    }

    public Group? GetByName(string name)
    {
        if (String.IsNullOrEmpty(name)) throw new ArgumentNullException();
        return AcademyDbContext.Groups.Find(g=>g.Name.ToLower()==name.ToLower());
    }

    public void ShowAll()
    {
        foreach (var group in AcademyDbContext.Groups)
        {
            Console.WriteLine($"Id: {group.Id}; Group name:{group.Name}");
        }
    }

    public void ShowAllStudents(string name)
    {
        throw new NotImplementedException();
    }
}
