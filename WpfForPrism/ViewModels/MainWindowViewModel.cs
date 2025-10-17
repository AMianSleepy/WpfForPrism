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
        /// 打开对话框命令
        /// </summary>
        public DelegateCommand<string> ShowDialogCmm { get; set; }

        /// <summary>
        /// 区域管理
        /// </summary>
        private readonly IRegionManager RegionManager;

        /// <summary>
        /// 对话框服务
        /// </summary>
        private readonly IDialogService DialogService;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="_RegionManager"></param>
        public MainWindowViewModel(IRegionManager _RegionManager, IDialogService _DialogService)
        {
            ShowContentCmm = new DelegateCommand<string>(ShowContentFunc);
            BackCmm = new DelegateCommand(Back);

            RegionManager = _RegionManager;

            // 对话框服务
            DialogService = _DialogService;
            ShowDialogCmm = new DelegateCommand<string>(ShowDialogFunc);
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
        /// 打开对话框方法
        /// </summary>
        /// <param name="ucName">用户控件名称</param>
        private void ShowDialogFunc(string ucName)
        {
            DialogParameters paras = new()
            {
                {"Title","传入标题" },
                {"paras1","业务参数值1" },
                {"paras2","业务参数值2" }
            };

            DialogService.ShowDialog(ucName, paras,
                callback => 
                {
                    if (callback.Result == ButtonResult.OK)
                    {
                        // 获取对话框传来的值
                        if (callback.Parameters.ContainsKey("Result1"))// 接收参数前都应该先判断
                        {
                            string r1 = callback.Parameters.GetValue<string>("Result1");
                        }
                        string r2 = callback.Parameters.GetValue<string>("Result2");
                    }
                });
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
