using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//16.08.25 Ninject 사용.
using Ninject;
//16.08.25 Moq 사용.
using Moq;
//16.08.25 Sportsstore.Domain 프로젝트 using.
using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entities;


namespace SportsStore.WebUI.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver {
        private IKernel kernel;

        public NinjectDependencyResolver(IKernel kernelParam) {
            kernel = kernelParam;
            AddBindings();
        }

        public object GetService(Type serviceType) {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType) {
            return kernel.GetAll(serviceType);
        }

        private void AddBindings() {

            //16.08.25 moq 사용식.
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products).Returns(new List<Product> {
                new Product { Name = "Football", Price = 25},
                new Product { Name = "Surf board", Price = 179},
                new Product { Name = "Running shoes", Price = 95}

            });

            //16.08.25 kernel Bind
            kernel.Bind<IProductRepository>().ToConstant(mock.Object);
        }
    }
}