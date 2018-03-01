using System;
using System.Collections.Generic;
using System.Data.SQLite;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ToDoList_C
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Todo> ToDoList;
        InteractDb Db;

        public class Todo
        {
            public String title { get; set; }
            public String description { get; set; }
            public Boolean isFinish { get; set; }
            public int id { get; set; }
        }

        public class InteractDb
        {
            SQLiteConnection Db;
            public InteractDb()
            {
                if (!System.IO.File.Exists("ToDoListv7.db3"))
                {
                    SQLiteConnection.CreateFile("ToDoListv7.db3");
                }
                Db = new SQLiteConnection("data source=ToDoListv7.db3");
                Query("CREATE TABLE IF NOT EXISTS ToDo(ID INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, TITLE TEXT NOT NULL, DESCRIPTION TEXT NOT NULL, ISFINISH INTEGER)", true);
            }

            public void Query(String cmd, Boolean closed)
            {
                Db.Open();
                var command = Db.CreateCommand();
                command.CommandText = cmd;
                command.ExecuteNonQuery().ToString();
                if (closed)
                    Db.Close();
            }

            public void newtask(Todo elem)
            {
                String convertfinish;

                if (elem.isFinish == true)
                    convertfinish = "1";
                else
                    convertfinish = "0";
                Query("INSERT INTO ToDo (TITLE, DESCRIPTION, ISFINISH) Values ('" + elem.title + "','" + elem.description + "'," + convertfinish + ")", false);
            }
            
            public void deletetask(Todo elem)
            {
                Query("DELETE FROM ToDo WHERE id=" + elem.id.ToString(), true);
            }

            public void edittask(Todo elem)
            {
                String finished;

                if (elem.isFinish)
                    finished = "1";
                else
                    finished = "0";
                Query("UPDATE ToDo set TITLE='" + elem.title + "' WHERE ID = " + elem.id.ToString(), true);
                Query("UPDATE ToDo set DESCRIPTION='" + elem.description + "' WHERE ID = " + elem.id.ToString(), true);
                Query("UPDATE ToDo set ISFINISH=" + finished + " WHERE ID = " + elem.id.ToString(), true);
            }

            public void setFinished(Todo elem)
            {
                String res = "0";
                if (elem.isFinish)
                    res = "1";
                Query("UPDATE ToDo set ISFINISH=" + res + " WHERE ID = " + elem.id.ToString(), true);
            }

            public int getID(Todo elem)
            {
                var Command = Db.CreateCommand();
                Command.CommandText = "select last_insert_rowid()";
                int res = Convert.ToInt32(Command.ExecuteScalar());
                Db.Close();
                return (res);
            }

            public List<Todo> get_tasklist()
            {
                List<Todo> ToDoList = new List<Todo>();
                Db.Open();
                var command = Db.CreateCommand();
                command.CommandText = "SELECT * FROM ToDo";
                SQLiteDataReader sdr = command.ExecuteReader();

                while (sdr.Read())
                {
                    Console.WriteLine("ret = " + sdr["ISFINISH"].ToString());
                    ToDoList.Add(new Todo { title = sdr["TITLE"].ToString(), description = sdr["DESCRIPTION"].ToString(), isFinish = (sdr["ISFINISH"].ToString() == "1"), id = Convert.ToInt32(sdr["ID"].ToString()) });
                }
                sdr.Close();
                Db.Close();
                return (ToDoList);
            }
        }

        public void AddToAll(Todo elem)
        {
            Db.newtask(elem);
            elem.id = Db.getID(elem);
            ToDoList.Add(elem);
        }

        public MainWindow()
        {
            InitializeComponent();

            Db = new InteractDb();
            ToDoList = Db.get_tasklist();

            

            TaskList.DataContext = this;
            TaskList.ItemsSource = ToDoList;
        }

        private void refreshList()
        {
            TaskList.ClearValue(ItemsControl.ItemsSourceProperty);
            TaskList.ItemsSource = ToDoList;
        }

        private void ShowDialog(int index)
        {
            TaskDialog dialog = new TaskDialog(ToDoList[index]);
            if (dialog.ShowDialog() == true)
                Db.edittask(dialog.Answer);
        }

        private void TaskList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (TaskList.SelectedIndex >= 0)
                ShowDialog(TaskList.SelectedIndex);
            refreshList();
        }

        private void NewTask_Click(object sender, RoutedEventArgs e)
        {
            AddToAll(new Todo { title = "", description = "", isFinish = false });
            ShowDialog(ToDoList.Count - 1);
            refreshList();
        }

        private void EditTask_Click(object sender, RoutedEventArgs e)
        {
            if (TaskList.SelectedIndex >= 0)
                ShowDialog(TaskList.SelectedIndex);
            refreshList();
        }

        private void DeleteTask_Click(object sender, RoutedEventArgs e)
        {
            if (TaskList.SelectedIndex >= 0)
            {
                Db.deletetask(ToDoList[TaskList.SelectedIndex]);
                ToDoList.Remove(ToDoList[TaskList.SelectedIndex]);
            }
            refreshList();
        }

        private void FinishedTask_Click(object sender, RoutedEventArgs e)
        {
            CheckBox check = sender as CheckBox;
            int index = TaskList.Items.IndexOf(check.DataContext);
            if (index >= 0)
                Db.setFinished(ToDoList[index]);
            refreshList();
        }
    }
}
