using System.Windows;
using ToDoList.Models;
using ToDoList.ViewModels;

namespace ToDoList.Views
{
    public partial class ReadTodoWindow : Window
    {
        public ReadTodoWindow(TodoItem item)
        {
            InitializeComponent();
            DataContext = new ReadViewModel(item);
        }
    }
}