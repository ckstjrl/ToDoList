using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using ToDoList.Models;
using ToDoList.Services; // JSON 저장

namespace ToDoList.ViewModels
{
    public class ReadViewModel : INotifyPropertyChanged
    {
        private readonly TodoItem _item;

        // 편집 모드 여부
        private bool _isEditMode;
        public bool IsEditMode
        {
            get => _isEditMode;
            set
            {
                _isEditMode = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(IsReadOnly));
                OnPropertyChanged(nameof(EditButtonText));
            }
        }
        public bool IsReadOnly => !IsEditMode;
        public string EditButtonText => IsEditMode ? "취소" : "수정";

        // 편집용 임시값(저장 누르기 전까진 _item에 반영 안 함)
        private string _title;
        private DateTime _startDate;
        private DateTime _endDate;
        private string _memo;

        public string Title
        {
            get => _title;
            set { _title = value; OnPropertyChanged(); }
        }

        public DateTime StartDate
        {
            get => _startDate;
            set { _startDate = value; OnPropertyChanged(); }
        }

        public DateTime EndDate
        {
            get => _endDate;
            set { _endDate = value; OnPropertyChanged(); }
        }

        public string Memo
        {
            get => _memo;
            set { _memo = value; OnPropertyChanged(); }
        }

        public ICommand ToggleEditCommand { get; }
        public ICommand SaveEditCommand { get; }
        public ICommand DeleteCommand { get; }

        // 창 닫기
        public Action? CloseAction { get; set; }

        public ReadViewModel(TodoItem item)
        {
            _item = item;

            // 초기값 로드
            LoadFromItem();

            ToggleEditCommand = new RelayCommand(ToggleEdit);
            SaveEditCommand = new RelayCommand(SaveEdit);
            DeleteCommand = new RelayCommand(Delete);
        }

        private void LoadFromItem()
        {
            Title = _item.Title ?? "";
            StartDate = _item.StartDate;
            EndDate = _item.EndDate;
            Memo = _item.Memo ?? "";
        }

        private void ToggleEdit()
        {
            if (IsEditMode)
            {
                // 취소: 원본으로 되돌림
                LoadFromItem();
                IsEditMode = false;
            }
            else
            {
                IsEditMode = true;
            }
        }

        private void SaveEdit()
        {
            if (!IsEditMode) return;

            if (string.IsNullOrWhiteSpace(Title))
            {
                MessageBox.Show("제목은 비어 있을 수 없습니다.");
                return;
            }

            if (EndDate < StartDate)
            {
                MessageBox.Show("마감일은 시작일보다 빠를 수 없습니다.");
                return;
            }

            // 원본에 반영
            _item.Title = Title.Trim();
            _item.StartDate = StartDate;
            _item.EndDate = EndDate;
            _item.Memo = Memo ?? "";

            // JSON 저장
            JsonService.Save(TodoItem.Database);

            IsEditMode = false;
            MessageBox.Show("수정 내용이 저장되었습니다.");
        }

        private void Delete()
        {
            var result = MessageBox.Show("정말 삭제하시겠습니까?", "삭제 확인", MessageBoxButton.YesNo);
            if (result != MessageBoxResult.Yes) return;

            // 공용 DB에서 제거
            TodoItem.Database.Remove(_item);

            // JSON 저장
            JsonService.Save(TodoItem.Database);

            MessageBox.Show("삭제되었습니다.");
            CloseAction?.Invoke();
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}