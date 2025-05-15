namespace TodoCore
{
    public class Task
    {
        public int number = 0;
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public Task()
        {
        }

        public Task(string name, string description)
        {
            Id = number + 1;
            Name = name;
            Description = description;
            number++;
        }

    }

    public interface ITaskList
    {
        public void AddTask();
        public void RemoveTask();
        public void UpdateTask();

    }


    public class TaskManager : ITaskList
    {
        protected List<Task> _tasks;

        public void AddTask()
        {
            Console.WriteLine("Enter the name of the task:");
            string name = Console.ReadLine();
            Console.WriteLine("Enter the description of the task:");
            string description = Console.ReadLine();
            Task task = new Task(name, description);
            _tasks.Add(task);
        }

        public void RemoveTask()
        {
        }
        public void UpdateTask()
        {
        }



    }
}

