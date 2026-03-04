using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using ToDoList.Models;

namespace ToDoList.ViewModels
{
    // BaseViewModel 없이 INotifyPropertyChanged 직접 구현
    public class ToDoDetailViewModel : INotifyPropertyChanged
    {
        private TodoItem? _selectedItem;

        public TodoItem? SelectedItem
        {
            get => _selectedItem;
            set
            {
                _selectedItem = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(Title));
                OnPropertyChanged(nameof(StartDate));
                OnPropertyChanged(nameof(EndDate));
                OnPropertyChanged(nameof(Memo));
            }
        }

        // 제목
        public string Title => SelectedItem?.Title ?? string.Empty;

        // 시작/종료 날짜
        public DateTime? StartDate => SelectedItem?.StartDate;
        public DateTime? EndDate => SelectedItem?.EndDate;

        // 메모
        public string Memo => SelectedItem?.Memo ?? string.Empty;

        public ToDoDetailViewModel(TodoItem? item)
        {
            SelectedItem = item;
        }

        // INotifyPropertyChanged 구현
        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}