using System;

namespace ToDoList.Models
{
    public class TodoItem
    {
        // 각 일정을 구분하기 위한 고유 ID (C,R,U,D 연동 시 필수)
        public int Id { get; set; }

        // 제목
        public string Title { get; set; }

        // 시작일
        public DateTime StartDate { get; set; }

        // 마감일
        public DateTime EndDate { get; set; }

        // 메모
        public string Memo { get; set; }

        // 기본 생성자 (현재 시간으로 날짜 초기화)
        public TodoItem()
        {
            StartDate = DateTime.Now;
            EndDate = DateTime.Now.AddDays(1);
        }
    }
}