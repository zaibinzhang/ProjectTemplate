using System.Runtime.Remoting.Messaging;
using ProjectTemplate.Common;

namespace ProjectTemplate.Model
{
    public static class DbContextFactory
    {
        public static ProjectTemplateContext Instance
        {
            get
            {
                if (CallContext.GetData("DbContext") == null)
                {
                    CallContext.SetData("DbContext", CreateInstance());
                }
                return CallContext.GetData("DbContext") as ProjectTemplateContext;
            }
        }

        public static ProjectTemplateContext CreateInstance()
        {
            var context = new ProjectTemplateContext();
            context.Database.Log = s =>
            {
                LogHelper.Debug(s);
            };
            return context;
        }
    }
}