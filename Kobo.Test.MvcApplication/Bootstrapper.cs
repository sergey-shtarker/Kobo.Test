using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Unity.Mvc4;
using Kobo.Test.MvcApplication.Contracts;
using Kobo.Test.MvcApplication.Services;

namespace Kobo.Test.MvcApplication
{
  public static class Bootstrapper
  {
    public static IUnityContainer Initialise()
    {
      var container = BuildUnityContainer();

      DependencyResolver.SetResolver(new UnityDependencyResolver(container));

      return container;
    }

    private static IUnityContainer BuildUnityContainer()
    {
      var container = new UnityContainer();

      // register all your components with the container here 
      // it is NOT necessary to register your controllers
      container.RegisterType<IPersonModelService, PersonModelService>(new InjectionConstructor());

      return container;
    }
  }
}