using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Ninject;
using Ninject.Web.Common;
using RepositoryContract;
using RepositoryLayer;
using ServiceContract;
using ServiceLayer;

namespace MvcProj
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;

        public NinjectDependencyResolver(IKernel kernelParam) { kernel = kernelParam; AddBindings(); }

        public object GetService(Type serviceType) { return kernel.TryGet(serviceType); }

        public IEnumerable<object> GetServices(Type serviceType) { return kernel.GetAll(serviceType); }

        private void AddBindings()
        {
            string conName = "name=DbConnection";
            kernel.Bind<IUnitOfWork>().To<UnitOfWork>().WithConstructorArgument("connectionName", conName);
            kernel.Bind<IEmployeeService>().To<EmployeeService>().InRequestScope();
            kernel.Bind<IDepartmentService>().To<DepartmentService>().InRequestScope();
        }
    }
}
