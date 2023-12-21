using Academy.Business.Interfaces;
using Academy.Business.Utilities.Exceptions;
using Academy.Core.Entities;
using Academy.DataAccess.Contexts;

namespace Academy.Business.Services;

public class StudentService : IStudentService
{
    private IGroupService groupService { get; }
    public StudentService()
    {
        groupService = new GroupService();
    }
    public void Create(string name, string surname, string email, string groupName)
    {
        if (String.IsNullOrEmpty(name)) throw new ArgumentNullException();
        Group? group = groupService.GetByName(groupName);
        if (group is null) throw new NotFoundException($"{groupName} is not exist");
        Student student = new(name,surname,email,group);
        AcademyDbContext.Students.Add(student);
    }
    public void ChangeGroup(int studentId, string newGroupName)
    {
        throw new NotImplementedException();
    }

    public void Delete(int Id)
    {
        throw new NotImplementedException();
    }
}
