using E_Commerce_Coffee_And_Tea_Client.DataAccess.Repositories;
using E_Commerce_Coffee_And_Tea_Client.DataAccess;
using E_Commerce_Coffee_And_Tea_Client.Services.Product;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;
using Unity.WebApi;
using Unity.Lifetime;
using Unity.Injection;
using E_Commerce_Coffee_And_Tea_Client.Services.Size;
using E_Commerce_Coffee_And_Tea_Client.DataAccess.Repositories.Dosage;
using E_Commerce_Coffee_And_Tea_Client.Services.Dosage;
using E_Commerce_Coffee_And_Tea_Client.Services.Employee;
using E_Commerce_Coffee_And_Tea_Client.Services.Customer;
using E_Commerce_Coffee_And_Tea_Client.DataAccess.Repositories.Category;
using E_Commerce_Coffee_And_Tea_Client.Services.Category;
using E_Commerce_Coffee_And_Tea_Client.DataAccess.Repositories.Cart;
using E_Commerce_Coffee_And_Tea_Client.Services.Cart;
using System.Web.Http;

namespace E_Commerce_Coffee_And_Tea_Client
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            #region Chỉ định chuỗi kết nối trực tiếp và đăng ký DataContext

            // Đăng ký chuỗi kết nối (ConnectionString)
            //string connectionString = "";
            //container.RegisterInstance(connectionString);

            // Đăng ký DataContext với InjectionConstructor nhận chuỗi kết nối
            //container.RegisterType<E_Commerce_Coffee_And_TeaDataContext>(new InjectionConstructor(new ResolvedParameter<string>()));

            #endregion

            #region Đăng ký DataContext khi đã cấu hình chuỗi kết nối trong "web.config" và class "E_Commerce_Coffee_And_TeaDataContext"

            // Đăng ký DataContext
            container.RegisterType<E_Commerce_Coffee_And_TeaDataContext>();

            #endregion

            #region Đăng ký các repositories và services

            //Category
            container.RegisterType<ICategoryRepository, CategoryRepository>();
            container.RegisterType<ICategoryService, CategoryService>();

            //Product
            container.RegisterType<IProductRepository, ProductRepository>();
            container.RegisterType<IProductService, ProductService>();

            //Size
            container.RegisterType<ISizeRepository, SizeRepository>();
            container.RegisterType<ISizeService, SizeService>();

            //Dosage
            container.RegisterType<IDosageRepository, DosageRepository>();
            container.RegisterType<IDosageService, DosageService>();

            //Employee
            container.RegisterType<IEmployeeRepository, EmployeeRepository>();
            container.RegisterType<IEmployeeService, EmployeeService>();

            //Customer
            container.RegisterType<ICustomerRepository, CustomerRepository>();
            container.RegisterType<ICustomerService, CustomerService>();

            //Cart
            container.RegisterType<ICartRepository, CartRepository>();
            container.RegisterType<ICartService, CartService>();

            #endregion

            // Thiết lập Dependency Resolver cho Web Mvc5
            DependencyResolver.SetResolver(new Unity.Mvc5.UnityDependencyResolver(container));

            // Thiết lập Dependency Resolver cho Web API
            GlobalConfiguration.Configuration.DependencyResolver = new Unity.WebApi.UnityDependencyResolver(container);
        }
    }
}