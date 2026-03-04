# ToDoList (WPF MVVM CRUD Practice)

WPF와 MVVM 패턴을 사용하여 ToDoList CRUD 기능을 구현하고  
Git 협업 및 브랜치 전략 연습을 위해 제작한 프로젝트입니다.

## 📌 프로젝트 목적

- Git Branch 전략 연습 --> 주 목적
- 기능 단위 브랜치 개발 경험
- WPF 기반 CRUD 애플리케이션 제작
- MVVM 패턴 구조 이해 및 적용

---

## 🛠 사용 기술

- **Language** : C#
- **Framework** : WPF (.NET)
- **Architecture** : MVVM Pattern
- **Version Control** : Git / GitHub
- **Data Storage** : JSON

---

## 📂 프로젝트 구조

```
ToDoList
│
├─ Models
│   └─ TodoItem.cs
│
├─ Services
│   └─ JsonService.cs
│
├─ ViewModels
│   ├─ CreateViewModel.cs
│   └─ ReadViewModel.cs
│
├─ Views
│   ├─ MainPage.xaml
│   ├─ MainPage.xaml.cs
│   │
│   ├─ CreateTodoWindow.xaml
│   ├─ CreateTodoWindow.xaml.cs
│   │
│   ├─ ReadTodoWindow.xaml
│   └─ ReadTodoWindow.xaml.cs
│
├─ App.xaml
├─ App.xaml.cs
│
├─ MainWindow.xaml
├─ MainWindow.xaml.cs
│
└─ README.md
```
---

## ⚙️ 주요 기능

### Create
- 새로운 Todo 일정 생성
- 제목 / 시작일 / 종료일 / 메모 입력
- 생성 후 JSON 파일에 저장

### Read
- 메인 화면에서 Todo 목록 확인
- 일정 클릭 시 상세 정보 확인

### Update
- Read 화면에서 수정 모드 활성화
- 제목 / 날짜 / 메모 수정 가능

### Delete
- Read 화면에서 일정 삭제
- 삭제 시 JSON 데이터에서도 제거

### Data Save
- Todo 데이터를 **JSON 파일로 저장**
- 애플리케이션 실행 시 JSON 데이터 로드

---

## 🌿 Git Branch 전략

Git 협업 연습을 위해 기능 단위 브랜치를 사용했습니다.

```
master
    └─ dev
        ├─ feat/main-page
        ├─ feat/create
        ├─ feat/read
        ├─ feat/datasave
        └─ feat/update
```

---

### 브랜치 설명

| Branch | 기능 |
|------|------|
feat/main-page | 메인 화면 UI 및 Todo 목록 표시 |
feat/create | Todo 생성 기능 |
feat/read | Todo 상세 조회 |
feat/datasave | JSON 데이터 저장/불러오기 |
feat/update | Todo 수정 및 삭제 기능 |

※ `delete` 기능은 `feat/update` 브랜치에서 함께 구현했습니다.

---

## 📋 Git Workflow

1. `dev` 브랜치에서 기능 브랜치 생성
2. 기능 단위로 개발 진행
3. 개발 완료 후 `dev` 브랜치로 merge
4. 최종적으로 `master` 브랜치로 merge

---

## 💡 프로젝트 학습 내용

- WPF MVVM 구조 이해
- ObservableCollection을 이용한 UI 데이터 바인딩
- ICommand를 이용한 MVVM 이벤트 처리
- JSON 기반 간단한 데이터 저장 방식
- Git 브랜치 전략을 통한 기능 단위 개발

---

## 🚀 향후 개선 사항

- SQLite 데이터베이스 적용
- Todo 완료 상태 추가
- 일정 검색 기능
- UI/UX 개선
- Unit Test 추가

---