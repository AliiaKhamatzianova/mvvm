using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Runtime.Remoting.Contexts;

namespace SampleMVVM.Models
{
    public class DataBaseInitializer : DropCreateDatabaseAlways<DataBaseContext>//DropCreateDatabaseAlways<DataBaseContext>//CreateDatabaseIfNotExists<DataBaseContext>
    {
        protected override void Seed(DataBaseContext context)
        {
            var tasks = new List<Task>
            {
                new Task {Name = "Cделай это", Description = null, Priority = Priorities.High, Status = Statuses.TODO, StartDate = DateTime.Now },
                new Task {Name = "Сделай то", Description = "Какое-то описание", Priority = Priorities.Middle, Status = Statuses.TODO, StartDate = DateTime.Now },
                new Task {Name = "И про это не забудь", Description = "Еще какое-то описание", Priority = Priorities.Low, Status = Statuses.TODO, StartDate = DateTime.Now}
            };

            //context.Tasks.AddRange(tasks);
            tasks.ForEach(s => context.Tasks.Add(s));
            //context.SaveChanges();
        }
    }

    public class DataBaseContext : DbContext
    {
        public DataBaseContext() : base("DataBaseContext")
        {
            Database.SetInitializer(new DataBaseInitializer());
        }

        public virtual DbSet<Task> Tasks { get; set; }
    }
}
