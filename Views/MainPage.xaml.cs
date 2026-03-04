using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Collections.Specialized;
using ToDoList.Models;
using ToDoList.Services;

namespace ToDoList.Views
{
    public partial class MainPage : Page
    {
        public ObservableCollection<TodoItem> TodoItems { get; set; }

        public MainPage()
        {
            InitializeComponent();

            TodoItems = TodoItem.Database;

            // 1) 시작 시 JSON 불러오기
            JsonService.LoadInto(TodoItems);

            // 2) DB가 바뀌면 자동 저장 (추가/삭제)
            TodoItems.CollectionChanged += TodoItems_CollectionChanged;

            // 테스트 데이터: 최초 1회만(저장 파일 없을 때만)
            if (TodoItems.Count == 0)
            {
                TodoItems.Add(new TodoItem { Id = 1, Title = "Git 협업 연습", Memo = "CRUD 연결 테스트" });
                TodoItems.Add(new TodoItem { Id = 2, Title = "WPF 메인 화면 만들기" });
            }

            DataContext = this;
        }

        private void TodoItems_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
        {
            JsonService.Save(TodoItems);
        }

        private void Todo_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button btn && btn.DataContext is TodoItem todo)
            {
                var readWindow = new ReadTodoWindow(todo);
                readWindow.Owner = Window.GetWindow(this);
                readWindow.ShowDialog();

                // ✅ 수정(속성 변경)은 CollectionChanged가 안 울릴 수 있으니 여기서도 저장
                JsonService.Save(TodoItems);
            }
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            var createWindow = new CreateTodoWindow();
            createWindow.Owner = Window.GetWindow(this);
            createWindow.ShowDialog();

            // Create 후 저장
            JsonService.Save(TodoItems);
        }
    }
}