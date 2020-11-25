using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace adet_mid_assignment_Espeleta_Michelle.Models
{
    public class TaskDatabaseContext : DbContext
    {
        public TaskDatabaseContext(DbContextOptions<TaskDatabaseContext> options) : base(options)
        {

        }

        public DbSet<TaskModel> Tasks { get; set; }
    }
}
