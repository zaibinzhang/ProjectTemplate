using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;

namespace ProjectTemplate.MVC.Web
{
    public static class InstanceFactory
    {
        private static IUnityContainer _container;

        static InstanceFactory()
        {
            _container = new UnityContainer();
            _container.LoadConfiguration("ProjectTemplateContainer");
        }

        public static T GetInstance<T>()
        {
            return _container.Resolve<T>();
        }
    }
}