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
            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentException("id is required.", nameof(id));

            return id switch
            {
                "1" => "admin",
                "2" => "user",
                _ => throw new InvalidOperationException($"No user mapped for id '{id}'.")
            };
        }

        public string GetB()
        {
            return "1";
        }
    }
}
