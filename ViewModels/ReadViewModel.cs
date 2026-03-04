using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using ToDoList.Models;

namespace ToDoList.ViewModels
{
    public class ReadViewModel : INotifyPropertyChanged
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

        public string Title => SelectedItem?.Title ?? string.Empty;
        public DateTime? StartDate => SelectedItem?.StartDate;
        public DateTime? EndDate => SelectedItem?.EndDate;
        public string Memo => SelectedItem?.Memo ?? string.Empty;

        // 생성자 이름을 클래스 이름과 동일하게
        public ReadViewModel(TodoItem? item)
        {
            SelectedItem = item;
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}