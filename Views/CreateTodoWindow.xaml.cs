using System.Windows;
using ToDoList.ViewModels;

namespace ToDoList.Views
{
    public partial class CreateTodoWindow : Window
    {
        public CreateTodoWindow()
        {
            InitializeComponent();
            // 뷰모델 객체를 생성하여 데이터 문맥으로 설정
            this.DataContext = new CreateTodoViewModel();
        }
    }
}