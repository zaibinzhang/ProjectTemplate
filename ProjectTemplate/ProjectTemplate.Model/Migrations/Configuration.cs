using System.Data.Entity.Migrations;

namespace ProjectTemplate.Model.Migrations
{
    public class Configuration : DbMigrationsConfiguration<ProjectTemplateContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }
        /// <summary>
        /// 用于初始化数据
        /// </summary>
        /// <param name="context"></param>
        protected override void Seed(ProjectTemplateContext context)
        {

        }
    }
}