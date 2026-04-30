using Service.Repo;

namespace Service.Service
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _taskRepository;

        public TaskService(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public string Hello()
        {
            return _taskRepository.GetA();
        }

        public string Hello2()
        {
            return _taskRepository.GetB();
        }

        public string Hello3()
        {
            return "";
        }

        public string Hello4()
        {
            return "";
        }

        public string Hello5()
        {
            return "sua loi";
        }


        public int Sum(int a, int b)
        {
            return a + b;
        }

        public int Sum(int a, int b, int c)
        {
            return a + b + c;
        }

        public int Testnhan(int a, int b)
        {
            return a * b;
        }
    }
}
