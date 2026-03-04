using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using ToDoList.Models;

namespace ToDoList.Views
{
    public partial class MainPage : Page
    {
        public ObservableCollection<TodoItem> TodoItems { get; set; }

        public MainPage()
        {
            InitializeComponent();

            // 공용 DB를 메인 리스트에 바인딩
            TodoItems = TodoItem.Database;

            // 테스트 데이터: 최초 1회만
            if (TodoItems.Count == 0)
            {
                TodoItems.Add(new TodoItem
                {
                    Id = 1,
                    Title = "Git 협업 연습",
                    Memo = "CRUD 연결 테스트"
                });

                TodoItems.Add(new TodoItem
                {
                    Id = 2,
                    Title = "WPF 메인 화면 만들기"
                });
            }

            DataContext = this;
        }

        // 카드 클릭 → READ 창
        private void Todo_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button btn && btn.DataContext is TodoItem todo)
            {
                var readWindow = new ReadTodoWindow(todo);
                readWindow.Owner = Window.GetWindow(this);
                readWindow.ShowDialog(); // Show()도 가능하지만 보통 Read는 Dialog가 자연스럽습니다
            }
        }

        // Add 버튼 → CREATE 창
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            var createWindow = new CreateTodoWindow();
            createWindow.Owner = Window.GetWindow(this);

            // ShowDialog : 저장 전까지 메인 잠금
            createWindow.ShowDialog();
        }
    }
}