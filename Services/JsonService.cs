using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text.Json;
using ToDoList.Models;

namespace ToDoList.Services
{
    public static class JsonService
    {
        // 실행 파일 폴더에 저장 (원하면 경로 바꾸셔도 됩니다)
        private static readonly string FilePath = Path.Combine(
            AppDomain.CurrentDomain.BaseDirectory,
            "todos.json"
        );

        private static readonly JsonSerializerOptions Options = new()
        {
            WriteIndented = true
        };

        public static void Save(ObservableCollection<TodoItem> todos)
        {
            // ObservableCollection은 바로 직렬화 가능하지만,
            // List로 변환해 저장하면 더 안전합니다.
            var list = new List<TodoItem>(todos);
            var json = JsonSerializer.Serialize(list, Options);
            File.WriteAllText(FilePath, json);
        }

        public static void LoadInto(ObservableCollection<TodoItem> target)
        {
            if (!File.Exists(FilePath))
                return;

            var json = File.ReadAllText(FilePath);
            var list = JsonSerializer.Deserialize<List<TodoItem>>(json) ?? new List<TodoItem>();

            target.Clear();
            foreach (var item in list)
                target.Add(item);
        }
    }
}