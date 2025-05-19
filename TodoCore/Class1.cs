using System.Xml.Linq;

namespace TodoCore
{
    public class Task
    {
        private static int counter = 0;
        public int Id { get; private set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public Task() { }

        public Task(string name, string description)
        {
            Id = ++counter;
            Name = name;
            Description = description;
        }

        public override string ToString()
        {
            return $"{Id}. {Name} - {Description}";
        }
    }

    public interface ITaskList<T>
    {
        public void AddTask(string name,string descripction);
        public void Get();
    }

    public class TaskShort : Task,ITaskList<Task>
    {
        public TaskShort() { } 
        public TaskShort(string name, string description) : base(name, description)
        {
        }
        public void AddTask(string name, string descripcion)
        {
            if (descripcion.Length < 200)
            {
                var task = new TaskShort(name, descripcion);
                Console.WriteLine($"Tarea agregada: {task.Name} - {task.Description}");
            }
            else
            {
                Console.WriteLine("La descripcion es muy larga");

            }
        }
        public void Get()
        {
            Console.WriteLine("Get Task");
        }
    }

    public class TaskLong : Task, ITaskList<Task>
    {

        public TaskLong() { }
        public TaskLong(string name, string description) : base(name, description)
        {
        }
        public void AddTask(string name, string descripcion)
        {
            if (descripcion.Length >= 200)
            {
                var task = new TaskLong(name, descripcion);
                Console.WriteLine($"Tarea agregada: {task.Name} - {task.Description}");
            }
            else
            {
                Console.WriteLine("La descripcion es muy corta");

            }
        }
        public void Get()
        {
            Console.WriteLine("Get Task");
        }
    }


    public interface GetListTask<T>
    {
        public void GetTask();
    }


    public interface AddListTask<T>
    {
        public void AddTask(T generic);
    }




    public class TaskList<T> : GetListTask<T>, AddListTask<T>
    {
        protected List<T> tasks = new List<T>();
        public void AddTask(T generic)
        {
          
            tasks.Add(generic);
            Console.WriteLine($"Tarea agregada: {generic}");
        }
        public void GetTask()
        {
            Console.WriteLine("Get Task");
        }
    }



}

