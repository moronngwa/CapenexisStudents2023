using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CapenexisStudents2023.Models;

namespace CapenexisStudents2023.Data
{
    public class CapenexisStudents2023Context : DbContext
    {
        public CapenexisStudents2023Context (DbContextOptions<CapenexisStudents2023Context> options)
            : base(options)
        {
        }

        public DbSet<CapenexisStudents2023.Models.Learners> Learner { get; set; } = default!;

        public DbSet<CapenexisStudents2023.Models.Facilitators> Facilitator { get; set; } = default!;

        public DbSet<CapenexisStudents2023.Models.Courses> Course { get; set; } = default!;
    }
}
