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