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
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ToDoList_C
{
    /// <summary>
    /// Logique d'interaction pour Window1.xaml
    /// </summary>
    public partial class TaskDialog : Window
    {
        MainWindow.Todo tmp;
        public TaskDialog(MainWindow.Todo elem)
        {
            InitializeComponent();
            tmp = elem;
            AnswTitle.Text = tmp.title;
            AnswDescr.Text = tmp.description;
        }

        private void btnDialogOk_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            if (AnswTitle.Text != "")
                tmp.title = AnswTitle.Text;
            if (AnswDescr.Text != "")
                tmp.description = AnswDescr.Text;
        }

        public MainWindow.Todo Answer
        {
            get { return tmp; }
        }

        private void Window_ContentRendered(object sender, EventArgs e)
        {

        }
    }
}
