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

            var vm = new ReadViewModel(item);
            vm.CloseAction = Close;   // 삭제 후 창 닫기
            DataContext = vm;
        }
    }
}