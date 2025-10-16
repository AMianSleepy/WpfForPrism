using DryIoc.ImTools;
using MyToDo.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace MyToDo.ViewModels
{
    internal class MainWindowViewModel : BindableBase
    {
        public DelegateCommand<string> ShowContentCmm { get; set; }

        private readonly IRegionManager RegionManager;

        public MainWindowViewModel(IRegionManager _RegionManager)
        {
            ShowContentCmm = new DelegateCommand<string>(ShowContentFunc);

            RegionManager = _RegionManager;
        }

        /// <summary>
        /// 改变显示用户控件
        /// </summary>
        /// <param name="viewName"></param>
        private void ShowContentFunc(string viewName)
        {
            NavigationParameters keyValuePairs = new()
            {
                { "MsgA","导航A"}
            };

            RegionManager.Regions["ContentRegion"].RequestNavigate(viewName, keyValuePairs);
        }

        /// <summary>
        /// 显示的内容
        /// </summary>
        private UserControl _ShowContent;

        /// <summary>
        /// 显示的内容
        /// </summary>
        public UserControl ShowContent
        {
            get { return _ShowContent; }
            set { _ShowContent = value;
                RaisePropertyChanged();
            }
        }
    }
}
