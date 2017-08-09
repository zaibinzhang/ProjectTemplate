using System;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;

namespace ProjectTemplate.Common
{
    public static class InstanceFactory
    {
        private static IUnityContainer _container;

        static InstanceFactory()
        {
            try
            {
                _container = new UnityContainer();
                _container.LoadConfiguration("ProjectTemplateContainer");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public static T GetInstance<T>()
        {
            return _container.Resolve<T>();
        }
    }
}