using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CodeBeerProject.Views
{
    /// <summary>
    /// Interaction logic for UserControlReloj.xaml
    /// </summary>
    public partial class UserControlReloj : UserControl
    {
        public UserControlReloj()
        {
            InitializeComponent();

            Storyboard seconds = (Storyboard)second.FindResource("sbseconds");
            seconds.Begin();
            seconds.Seek(new TimeSpan(0, 0, 0, DateTime.Now.Second, 0));

            Storyboard minutes = (Storyboard)minute.FindResource("sbminutes");
            minutes.Begin();
            minutes.Seek(new TimeSpan(0, 0, DateTime.Now.Minute, DateTime.Now.Second, 0));

            Storyboard hours = (Storyboard)hour.FindResource("sbhours");
            hours.Begin();
            hours.Seek(new TimeSpan(0, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second, 0));
        }
    }
}
