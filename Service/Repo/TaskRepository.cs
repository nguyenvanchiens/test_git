namespace Service.Repo
{
    public class TaskRepository : ITaskRepository
    {
        public TaskRepository() { }

        public TaskRepository(string name) { }

        public TaskRepository(string name, double a, double c, double d) { }

        public TaskRepository(string name, double a, string c) { }

        public string GetA()
        {
            return "";
        }

        public string GetById(string id)
        {
            return id;
        }

        public string GetB()
        {
            return "1";
        }
    }
}
