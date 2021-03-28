using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Senseition.Models;
using Senseition.Models.DataModels;
using System;
using System.Threading.Tasks;

namespace Senseition.Datas
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> option) : base(option)
        {
            
        }

        public DbSet<Course> Course { get; set; }
        public DbSet<Faculty> Faculty { get; set; }
        public DbSet<Major> Major { get; set; }
        public DbSet<Survey> Survey { get; set; }
        public DbSet<Teacher> Teacher { get; set; }
        public DbSet<TeacherCourse> TeacherCourse { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<UserReview> UserReview { get; set; }

    }

}