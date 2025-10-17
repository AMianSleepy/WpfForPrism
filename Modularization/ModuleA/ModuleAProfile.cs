using ModuleA.ViewModels;
using ModuleA.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleA
{
    public class ModuleAProfile : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            
        }

        /// <summary>
        /// Registers application-specific types with the provided container registry.
        /// </summary>
        /// <remarks>Call this method during application startup to configure dependency injection. Types
        /// registered here will be available for resolution throughout the application's lifetime.</remarks>
        /// <param name="containerRegistry">The container registry used to register types for dependency injection. Cannot be null.</param>
        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            // 注入导航服务                                手动绑定视图模型
            containerRegistry.RegisterForNavigation<ViewA, ViewAViewModel>();

            // 注入对话框服务
            containerRegistry.RegisterDialog<ViewC, ViewCViewModel>();
        }
    }
}
