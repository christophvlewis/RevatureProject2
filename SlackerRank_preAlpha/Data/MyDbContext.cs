using SlackerRank_preAlpha.Models;
using Microsoft.EntityFrameworkCore;

namespace SlackerRank_preAlpha.Data
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
        }

        public DbSet<TeacherCodeModel> TeacherCode { get; set; }
       

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TeacherCodeModel>().ToTable("TeacherCode");
            

            //modelBuilder.Entity<CourseAssignment>()
              //  .HasKey(c => new { c.CourseID, c.InstructorID });
        }
    }
}