using Academy.Core.Entities;

namespace Academy.Business.Interfaces;

public interface ICategoryService
{
    void Create(string? name, string description);
    /// <summary>
    /// If empty category
    /// </summary>
    /// <param name="name"></param>
    void Delete(string name);
    void Activate(string name, bool isActive=false);
    void ShowAll();
    Category GetCategory(int Id);
    void GetGroupIncluded(string name);
    Category? FindCategoryByName(string name);
}
