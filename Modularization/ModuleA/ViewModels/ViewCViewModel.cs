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
            
        }
    }
}
