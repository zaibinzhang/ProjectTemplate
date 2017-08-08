using System.Data.Entity;

namespace ProjectTemplate.Model
{
    public class ProjectTemplateContext : DbContext
    {
        public ProjectTemplateContext() : base("ProjectTemplate")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ProjectTemplateContext, Migrations.Configuration>());
        }

        public DbSet<Test> Tests { get; set; }
    }
}
