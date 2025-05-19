using TodoCore;




var nombre = "";
Console.WriteLine("Ingrese el nombre de la tarea:");
nombre = Console.ReadLine();
Console.WriteLine("Ingrese la descripcion de la tarea:");
var descripcion = Console.ReadLine();
var task = new TaskLong();
task.AddTask(nombre, descripcion);
var list = new TaskList<TaskLong>();
list.AddTask(task);


