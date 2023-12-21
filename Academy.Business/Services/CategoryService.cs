using Academy.Business.Interfaces;
using Academy.Business.Utilities.Exceptions;
using Academy.Core.Entities;
using Academy.DataAccess.Contexts;

namespace Academy.Business.Services;

public class CategoryService : ICategoryService
{
    public void Create(string? name, string? description)
    {
        if(String.IsNullOrEmpty(name)) throw new ArgumentNullException();
        Category? dbCategory=
            AcademyDbContext.Categories.Find(c=>c.Name.ToLower() == name.ToLower());
        if(dbCategory is not null) 
            throw new AlreadyExistException($"{dbCategory.Name} is already exist");
        Category category = new(name,description);
        AcademyDbContext.Categories.Add(category);
    }
    public void Activate(string name, bool isActive = false)
    {
        throw new NotImplementedException();
    }

    public void Delete(string name)
    {
        throw new NotImplementedException();
    }

    public Category GetCategory(int Id)
    {
        throw new NotImplementedException();
    }

    public void GetGroupIncluded(string name)
    {
        throw new NotImplementedException();
    }

    public void ShowAll()
    {
        foreach (var category in AcademyDbContext.Categories)
        {
            Console.WriteLine($"id: {category.Id}; Category Name: {category.Name}");
        }
    }

    public Category? FindCategoryByName(string name)
    {
        if (String.IsNullOrEmpty(name)) throw new ArgumentNullException();
        return AcademyDbContext.Categories.Find(c => c.Name.ToLower() == name.ToLower());
    }
}
