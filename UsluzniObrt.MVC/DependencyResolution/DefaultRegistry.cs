// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DefaultRegistry.cs" company="Web Advanced">
// Copyright 2012 Web Advanced (www.webadvanced.com)
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0

// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace UsluzniObrt.MVC.DependencyResolution {
    using System.Data.Entity;
    using System.Web;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Microsoft.Owin.Security;
    using StructureMap.Configuration.DSL;
    using StructureMap.Graph;
    using UsluzniObrt.Repository;
    using UsluzniObrt.Model;
    using UsluzniObrt.Service;
	
    public class DefaultRegistry : Registry {
        #region Constructors and Destructors

        public DefaultRegistry() {
            Scan(
                scan => {
                    scan.TheCallingAssembly();
                    scan.WithDefaultConventions();
					scan.With(new ControllerConvention());
                });
            For<IAuthenticationManager>().Use(() => HttpContext.Current.GetOwinContext().Authentication);
            For<IUserStore<User>>().Use<UserStore<User>>();
            For<IRoleStore<IdentityRole, string>>().Use<RoleStore<IdentityRole>>();
            For<DbContext>().Use<UsluzniObrtDbContext>();
            For<IUserService>().Use<UserService>();
            For<IUserRepository>().Use<UserRepository>();
            For<IMenuService>().Use<MenuService>();
            For<IMenuitemRepository>().Use<MenuItemRepository>();
            For<ICategoryRepository>().Use<CategoryRepository>();
            For<ICategoryService>().Use<CategoryService>();
            For<IOrderService>().Use<OrderService>();
            For<IOrderRepository>().Use<OrderRepository>();
            For<IOrderItemRepository>().Use<OrderItemRepository>();

            //For<>().Use<>();
            //For<>().Use<>();
        }

        #endregion
    }
}