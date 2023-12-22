using Academy.Business.Interfaces;
using Academy.Business.Utilities.Exceptions;
using Academy.Core.Entities;
using Academy.DataAccess.Contexts;

namespace Academy.Business.Services;

public class CategoryService : ICategoryService
{
    //private IGroupService _groupService { get; }
    //public CategoryService()
    //{
    //    _groupService = new GroupService();

    //}
    public void Create(string? name, string? description)
    {
        if (String.IsNullOrEmpty(name)) throw new ArgumentNullException();
        Category? dbCategory =
            AcademyDbContext.Categories.Find(c => c.Name.ToLower() == name.ToLower());
        if (dbCategory is not null)
            throw new AlreadyExistException($"{dbCategory.Name} is already exist");
        Category category = new(name, description);
        AcademyDbContext.Categories.Add(category);
    }
    public void Activate(string name)
    {
        if (String.IsNullOrEmpty(name)) throw new ArgumentNullException();
        Category? dbCategory =
            AcademyDbContext.Categories.Find(c => c.Name.ToLower() == name.ToLower());
        if (dbCategory is null)
            throw new NotFoundException($"{name} category not found");
        dbCategory.IsActive = true;
    }

    public void Delete(string name)
    {
        if (String.IsNullOrEmpty(name)) throw new ArgumentNullException();
        Category? dbCategory =
            AcademyDbContext.Categories.Find(c => c.Name.ToLower() == name.ToLower());
        if (dbCategory is null)
            throw new NotFoundException($"{name} category not found");
        dbCategory.IsActive = false;
    }

    public void GetCategory(string name)
    {
        if (String.IsNullOrEmpty(name)) throw new ArgumentNullException();
        Category? dbCategory =
            AcademyDbContext.Categories.Find(c => c.Name.ToLower() == name.ToLower());
        if (dbCategory is null)
            throw new NotFoundException($"{name} category not found");
        Console.WriteLine($"id: {dbCategory.Id}\n" +
                          $"Category Name: {dbCategory.Name}\n" +
                          $"Category Description: {dbCategory.Description}");
        GetGroupIncluded(dbCategory.Name);
    }

    public void GetGroupIncluded(string name)
    {
        foreach (var group in AcademyDbContext.Groups)
        {
            if (group.Category.Name.ToLower() == name.ToLower())
            {
                Console.WriteLine($"Id: {group.Id}; Group name:{group.Name}");
                Console.WriteLine("------------------------------------------");
            }
        }
    }

    public void ShowAll()
    {
        foreach (var category in AcademyDbContext.Categories)
        {
            if (category.IsActive == true)
            {
                Console.WriteLine($"id: {category.Id}; Category Name: {category.Name}");
            }
        }
    }

    public Category? FindCategoryByName(string name)
    {
        if (String.IsNullOrEmpty(name)) throw new ArgumentNullException();
        return AcademyDbContext.Categories.Find(c => c.Name.ToLower() == name.ToLower());
    }

    public bool IsCategoryExist()
    {
        foreach (var item in AcademyDbContext.Categories)
        {
            if (item is not null && item.IsActive == true) return true;
        }
        return false;
    }
}
