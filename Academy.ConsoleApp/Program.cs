using Academy.Business.Services;
using Academy.Business.Utilities.Helpers;
using Academy.DataAccess.Contexts;

Console.WriteLine("Academy App Start:");
CategoryService categoryService = new();
StudentService studentService = new();
GroupService groupService = new();
bool isContinue = true;
while (isContinue)
{
    Console.WriteLine("Choose the option:");
    Console.WriteLine("-- Category--\n" +
                      "1 - Create Category \n" +
                      "2 - Show All Category \n" +
                      "3 - Activate Category \n" +
                      "4 - Delete Category \n" +
                      "5 - Get Category Group\n" +

                      "-- Group--\n" +
                      "6 - Create Group \n" +
                      "7 - Show All Group \n" +
                      "8 - Activate Group \n" +
                      "9 - Delete Group \n" +
                      "10 - Get Group Student \n" +

                      "-- Student--\n" +
                      "11 - Create Student \n" +
                      "12 - Show All Student \n" +


                      "13 - Get Category \n" +
                      "14 - Move Student \n" +
                      "0 - Exit");

    string? option = Console.ReadLine();
    int optionNumber;
    bool isInt = int.TryParse(option, out optionNumber);
    if (isInt)
    {
        if (optionNumber >= 0 && optionNumber <= 15)
        {
            switch (optionNumber)
            {
                case (int)Menu.CreateCategory:
                    try
                    {
                        Console.WriteLine("Enter Category Name:");
                        string? categoryName = Console.ReadLine();
                        Console.WriteLine("Enter Category Description:");
                        string? categoryDesc = Console.ReadLine();
                        categoryService.Create(categoryName, categoryDesc);
                        Console.WriteLine("Yaratdi");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        goto case (int)Menu.CreateCategory;
                    }
                    break;
                case (int)Menu.ShowAllCategory:

                    Console.WriteLine("All Category:");
                    if (categoryService.IsCategoryExist() == false)
                    {
                        Console.WriteLine("Category yoxdur:");
                    }
                    categoryService.ShowAll();
                    break;
                case (int)Menu.ActivateCategory:
                    if (categoryService.IsCategoryExist() == false) Console.WriteLine("Category yoxdur:");
                    try
                    {
                        Console.WriteLine("Enter Category Name:");
                        string? categoryName = Console.ReadLine();
                        categoryService.Activate(categoryName);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    break;
                case (int)Menu.DeleteCategory:
                    if (categoryService.IsCategoryExist() == false) Console.WriteLine("Category yoxdur:");
                    try
                    {
                        Console.WriteLine("Enter Category Name:");
                        string? categoryName = Console.ReadLine();
                        categoryService.Delete(categoryName);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    break;
                case (int)Menu.GetByNameCategory:
                    try
                    {
                        Console.WriteLine("Enter Category Name:");
                        string? categoryName = Console.ReadLine();
                        categoryService.GetCategory(categoryName);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    break;
                //----------------------Category Menu Finish------------------------




                case (int)Menu.CreateGroup:
                    if (categoryService.IsCategoryExist() == false)
                    {
                        Console.WriteLine("Category yoxdur get evvelce category yarat sonra gel:");
                        goto case (int)Menu.CreateCategory;
                    }
                    try
                    {
                        Console.WriteLine("Enter group name:");
                        string? groupName = Console.ReadLine();
                        Console.WriteLine("Enter group max Student count:");
                        int maxStuCount = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("----------------------");
                        categoryService.ShowAll();
                        Console.WriteLine("----------------------");
                        Console.WriteLine("Enter category name:");
                        string? categoryName2 = Console.ReadLine();
                        groupService.Create(groupName, maxStuCount, categoryName2);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        goto case 3;
                    }
                    break;
                case (int)Menu.ShowAllGroup:
                    if (groupService.IsGroupExist() == false)
                    {
                        Console.WriteLine("Group Yoxdur");
                        goto case (int)Menu.CreateGroup;
                    }
                    Console.WriteLine("All Group:");
                    groupService.ShowAll();
                    break;

                case (int)Menu.ActivateGroup:
                    try
                    {
                        Console.WriteLine("Enter group name:");
                        string? groupName = Console.ReadLine();
                        groupService.Activate(groupName);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    break;

                case (int)Menu.DeleteGroup:
                    try
                    {
                        Console.WriteLine("Enter group name:");
                        string? groupName = Console.ReadLine();
                        groupService.Delete(groupName);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    break;

                case (int)Menu.GetGroupStudent:
                    try
                    {
                        Console.WriteLine("Enter group name:");
                        string? groupName = Console.ReadLine();
                        groupService.GetGroupStudent(groupName);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    break;
                //----------------------Group Menu Finish------------------------


                case (int)Menu.CreateStudent:
                    try
                    {
                        Console.WriteLine("Enter Student Name:");
                        string? studentName = Console.ReadLine();
                        Console.WriteLine("Enter Student Surname:");
                        string? studentSurname = Console.ReadLine();
                        Console.WriteLine("Enter Student Email:");
                        string? studentEmail = Console.ReadLine();
                        Console.WriteLine("-----------------------");
                        groupService.ShowAll();
                        Console.WriteLine("-----------------------");
                        Console.WriteLine("Enter Group Name:");
                        string? groupName = Console.ReadLine();
                        studentService.Create(studentName, studentSurname, studentEmail, groupName);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    break;

                case (int)Menu.ShowAllStudent:
                    Console.WriteLine("All Student:");
                    studentService.ShowAll();
                    break;
                case (int)Menu.getCategory:
                    try
                    {
                        Console.WriteLine("Enter Category Name:");
                        string? categoryName = Console.ReadLine();
                        categoryService.GetCategory(categoryName);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    break;

                case (int)Menu.moveStudent:
                    try
                    {
                        Console.WriteLine("----------students-------------");
                        studentService.ShowAll();
                        Console.WriteLine("-----------------------");
                        Console.WriteLine("Enter Student ID");
                        int studentId = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("-----------groups------------");
                        groupService.ShowAll();
                        Console.WriteLine("-----------------------");
                        Console.WriteLine("Enter Group name:");
                        string? groupName = Console.ReadLine();
                        studentService.ChangeGroup(studentId, groupName);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    break;

                default:
                    isContinue = false;
                    break;
            }
        }
        else
        {
            Console.WriteLine("Please enter correct option number!");
        }
    }
    else
    {
        Console.WriteLine("Please enter correct format!");
    }
}


