using Academy.Business.Services;

Console.WriteLine("Academy App Start:");
CategoryService categoryService = new();
StudentService studentService = new();
GroupService groupService = new();

categoryService.Create("Programming", "safs");
categoryService.Create("UX|UI", "safs");
categoryService.Create("Digital Marketing", "safs");
Console.WriteLine("All Categories:");
categoryService.ShowAll();

groupService.Create("P238", 4, "programming");
Console.WriteLine("All Groups:");
groupService.ShowAll();

studentService.Create("Onur", "Eliyev", "oe@code.edu.az", "P238");
studentService.Create("Onur", "Eliyev", "oe@code.edu.az", "P238");
studentService.Create("Onur", "Eliyev", "oe@code.edu.az", "P238");
studentService.Create("Onur", "Eliyev", "oe@code.edu.az", "P238");
studentService.Create("Onur", "Eliyev", "oe@code.edu.az", "P238");


