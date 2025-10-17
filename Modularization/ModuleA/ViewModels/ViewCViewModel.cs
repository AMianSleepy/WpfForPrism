using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleA.ViewModels
{
    internal class ViewCViewModel : IDialogAware
    {
        public DialogCloseListener RequestClose { get; set; }

        public ViewCViewModel()
        {
            ConfirmCmm = new DelegateCommand(Confirm);
            CancelCmm = new DelegateCommand(Cancel);
        }

        /// <summary>
        /// 确定命令
        /// </summary>
        public DelegateCommand ConfirmCmm { get; set; }

        /// <summary>
        /// 取消命令
        /// </summary>
        public DelegateCommand CancelCmm { get; set; }

        /// <summary>
        /// 确定
        /// </summary>
        private void Confirm()
        {
            if (RequestClose.WeakRefReuseWrapperGCed() != null)
            {
                DialogParameters paras = new()
                {
                    { "Result1", "张三" },
                    { "Result2", 100 }
                };
                RequestClose.Invoke(paras,ButtonResult.OK);
            }
        }

        /// <summary>
        /// 取消
        /// </summary>
        private void Cancel()
        {
            if (RequestClose.WeakRefReuseWrapperGCed() != null)
            {
                RequestClose.Invoke(new DialogResult(ButtonResult.No));
            }
        }

        /// <summary>
        /// 是否能够关闭对话框
        /// </summary>
        /// <returns></returns>
        public bool CanCloseDialog()
        {
            return true;
        }

        /// <summary>
        /// 对话框关闭
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        public void OnDialogClosed()
        {

        }

        /// <summary>
        /// 打开对话框
        /// </summary>
        /// <param name="parameters"></param>
        /// <exception cref="NotImplementedException"></exception>
        public void OnDialogOpened(IDialogParameters parameters)
        {
            // 主窗口向对话框传值
            string s1 = parameters.GetValue<string>("Title");
            string s2 = parameters.GetValue<string>("paras1");
            string s3 = parameters.GetValue<string>("paras2");
        }
    }
}
