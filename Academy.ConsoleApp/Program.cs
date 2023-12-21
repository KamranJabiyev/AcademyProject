using Academy.Business.Services;

Console.WriteLine("Academy App Start:");
CategoryService categoryService = new();
StudentService studentService = new();
GroupService groupService = new();
bool isContinue = true;
while (isContinue)
{
    Console.WriteLine("Choose the option:");
    Console.WriteLine("1 - Create Category \n" +
                      "2 - Show All Category \n" +
                      "3 - Create Group \n" +
                      "4 - Show All Group \n" +
                      "5 - Create Student \n" +
                      "0 - Exit");

    string? option=Console.ReadLine();
    int optionNumber;
    bool isInt=int.TryParse(option, out optionNumber);
    if (isInt)
    {
        if(optionNumber >=0 && optionNumber <=5)
        {
            switch (optionNumber) 
            { 
                case 1:
                    createCategory: try
                    {
                        Console.WriteLine("Enter Category Name:");
                        string? categoryName = Console.ReadLine();
                        Console.WriteLine("Enter Category Description:");
                        string? categoryDesc = Console.ReadLine();
                        categoryService.Create(categoryName, categoryDesc);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        goto createCategory;
                    }
                    break;
                case 2:
                    Console.WriteLine("All Category:");
                    categoryService.ShowAll();
                    break;
                case 3:
                    break;
                case 4:
                    break;
                case 5:
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


