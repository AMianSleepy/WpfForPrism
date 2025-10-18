using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfForPrism.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IEventAggregator EventAggregator;

        public MainWindow(IEventAggregator _EventAggregator)
        {
            InitializeComponent();

            EventAggregator = _EventAggregator;
        }

        /// <summary>
        /// 发布
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnPub_Click(object sender, RoutedEventArgs e)
        {
            //              获取事件            发布
            EventAggregator.GetEvent<MsgEvent>().Publish("发布1");
        }

        /// <summary>
        /// 订阅
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSub_Click(object sender, RoutedEventArgs e)
        {
            EventAggregator.GetEvent<MsgEvent>().Subscribe(Sub);
        }

        /// <summary>
        /// 订阅
        /// </summary>
        /// <param name="obj">接受的订阅消息</param>
        private void Sub(string obj)
        {
            MessageBox.Show($"收到的订阅信息：{obj}");
        }

        /// <summary>
        /// 取消订阅
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            EventAggregator.GetEvent<MsgEvent>().Unsubscribe(Sub);
        }
    }
}