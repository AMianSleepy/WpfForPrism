using DryIoc.ImTools;
using WpfForPrism.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace WpfForPrism.ViewModels
{
    internal class MainWindowViewModel : BindableBase
    {
        /// <summary>
        /// 导航记录
        /// </summary>
        private IRegionNavigationJournal Journal;

        public DelegateCommand<string> ShowContentCmm { get; set; }

        /// <summary>
        /// 后退命令
        /// </summary>
        public DelegateCommand BackCmm { get; set; }

        /// <summary>
        /// 区域管理
        /// </summary>
        private readonly IRegionManager RegionManager;

        public MainWindowViewModel(IRegionManager _RegionManager)
        {
            ShowContentCmm = new DelegateCommand<string>(ShowContentFunc);
            BackCmm = new DelegateCommand(Back);

            RegionManager = _RegionManager;
        }

        /// <summary>
        /// 后退方法
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        private void Back()
        {
            if (Journal != null && Journal.CanGoBack)
            {
                Journal.GoBack();
            }
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

            RegionManager.Regions["ContentRegion"].RequestNavigate(viewName, callback=>
            {
                Journal = callback.Context.NavigationService.Journal;
            },keyValuePairs);
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
