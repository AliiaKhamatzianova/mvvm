namespace SampleMVVM.Models
{
    class Task
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Priority { get; set; }

        public Task(string name, string description, int priority)
        {
            this.Name = name;
            this.Description = description;
            this.Priority = priority;
        }
    }
}
