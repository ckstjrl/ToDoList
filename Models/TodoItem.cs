using System;
using System.Collections.ObjectModel; // 리스트를 위해 필요

namespace ToDoList.Models
{
    public class TodoItem
    {
        // 모든 파트가 공유할 정적 바구니
        public static ObservableCollection<TodoItem> Database { get; } = new ObservableCollection<TodoItem>();

        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Memo { get; set; }

        public TodoItem()
        {
            // 기본 날짜 설정
            StartDate = DateTime.Now;
            EndDate = DateTime.Now.AddDays(1);
        }
    }
}