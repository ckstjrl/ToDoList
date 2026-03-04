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

            TodoItems = new ObservableCollection<TodoItem>();

            // 테스트 데이터
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

            DataContext = this;
        }

        // 카드 클릭 → READ 창
        private void Todo_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            TodoItem todo = btn.DataContext as TodoItem;

            var readWindow = new ReadWindow(todo);
            readWindow.Show();
        }

        // Add 버튼 → CREATE 창
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            var createWindow = new CreateWindow();
            createWindow.Show();
        }
    }
}