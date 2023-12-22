using Academy.Business.Interfaces;
using Academy.Business.Utilities.Exceptions;
using Academy.Core.Entities;
using Academy.DataAccess.Contexts;
using System.Xml.Linq;

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
        if (group.MaxStudentCount == group.CurrentStudentCount)
        {
            throw new GroupIsFullException($"{group.Name} is already full");
        }
        Student student = new(name, surname, email, group);
        AcademyDbContext.Students.Add(student);
        group.CurrentStudentCount++;
    }
    public void ChangeGroup(int studentId, string newGroupName)
    {
        var student = AcademyDbContext.Students.Find(x => x.Id == studentId);
        if (student is null) throw new NotFoundException("student Not Found");

        if (String.IsNullOrEmpty(newGroupName)) throw new ArgumentNullException();
        var group = AcademyDbContext.Groups.Find(x => x.Name.ToLower() == newGroupName.ToLower());
        if (group is null) throw new NotFoundException("Group Not Found");

        Delete(student.Id);

        Create(student.Name,student.Surname,student.Email, group.Name);
    }

    public void Delete(int Id)
    {
        var student = AcademyDbContext.Students.Find(x => x.Id == Id);
        if (student is null) throw new NotFoundException("student Not Found");
        student.IsDelete = true;
        if (student.Group.CurrentStudentCount > 4)
        {
            student.Group.CurrentStudentCount--;
        }
        else groupService.Delete(student.Group.Name);
    }

    public void ShowAll()
    {
        foreach (var item in AcademyDbContext.Students)
        {
            if (item.IsDelete == false)
            {
                Console.WriteLine($"ID: {item.Id}\n" +
                                 $"Name: {item.Name}\n" +
                                 $"Surname: {item.Surname}\n" +
                                 $"Email: {item.Email}");
            }
        }
    }
}
