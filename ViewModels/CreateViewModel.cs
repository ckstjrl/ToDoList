using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using ToDoList.Models;

namespace ToDoList.ViewModels
{
    public class CreateTodoViewModel : INotifyPropertyChanged
    {
        private string _title;
        private DateTime _startDate = DateTime.Now;
        private DateTime _endDate = DateTime.Now.AddDays(1);
        private string _memo;

        public string Title { get => _title; set { _title = value; OnPropertyChanged(); } }
        public DateTime StartDate { get => _startDate; set { _startDate = value; OnPropertyChanged(); } }
        public DateTime EndDate { get => _endDate; set { _endDate = value; OnPropertyChanged(); } }
        public string Memo { get => _memo; set { _memo = value; OnPropertyChanged(); } }

        public ICommand SaveCommand { get; }

        public CreateTodoViewModel()
        {
            SaveCommand = new RelayCommand(ExecuteSave);
        }

        private void ExecuteSave()
        {
            // 1. 새로운 객체 생성
            var newItem = new TodoItem
            {
                Title = this.Title,
                StartDate = this.StartDate,
                EndDate = this.EndDate,
                Memo = this.Memo
            };

            // 2. 클래스 내부의 정적 리스트에 즉시 추가
            TodoItem.Database.Add(newItem);

            System.Windows.MessageBox.Show($"'{newItem.Title}'이(가) 공용 저장소에 추가되었습니다!");
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }

    public class RelayCommand : ICommand
    {
        private readonly Action _execute;
        public RelayCommand(Action execute) => _execute = execute;
        public bool CanExecute(object parameter) => true;
        public void Execute(object parameter) => _execute();
        public event EventHandler CanExecuteChanged;
    }
}