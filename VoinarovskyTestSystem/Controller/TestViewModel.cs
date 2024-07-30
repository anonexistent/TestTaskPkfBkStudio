using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using VoinarovskyTestSystem.Model;
using Newtonsoft.Json;
using System.IO;
using System.Collections.ObjectModel;
using VoinarovskyTestSystem.View;

namespace VoinarovskyTestSystem.Controller
{
    public class TestViewModel : BaseViewModel
    {
        private ObservableCollection<Test> _tests;
        private Test _currentTest;
        private int _currentQuestionIndex;
        private int _score;
        private bool _isTestCompleted;
        public bool IsLastQuestion => CurrentQuestionIndex == (CurrentTest?.Questions.Count - 1);
        public ObservableCollection<TabItemViewModel> Tabs { get; set; }
        public TabItemViewModel SelectedTab { get; set; }

        public ObservableCollection<Test> Tests
        {
            get => _tests;
            set => SetProperty(ref _tests, value);
        }

        public Test CurrentTest
        {
            get => _currentTest;
            set
            {
                if (SetProperty(ref _currentTest, value))
                {
                    _currentQuestionIndex = 0;
                    _score = 0;
                    _isTestCompleted = false;
                    OnPropertyChanged(nameof(CurrentQuestion));
                    OnPropertyChanged(nameof(IsNextButtonVisible));
                    OnPropertyChanged(nameof(IsSubmitButtonVisible));
                    OnPropertyChanged(nameof(IsTestCompleted));
                    OnPropertyChanged(nameof(ScoreText)); 
                    OnPropertyChanged(nameof(CurrentQuestionNumber));

                }
            }
        }
        public int CurrentQuestionIndex
        {
            get { return _currentQuestionIndex; }
            set
            {
                _currentQuestionIndex = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(CurrentQuestion));
                OnPropertyChanged(nameof(IsLastQuestion));
                OnPropertyChanged(nameof(IsNextButtonVisible));
                OnPropertyChanged(nameof(IsSubmitButtonVisible));
                OnPropertyChanged(nameof(CurrentQuestionNumber));
            }
        }
        public TestViewModel()
        {
            Tests = new ObservableCollection<Test>();
            NextCommand = new RelayCommand(NextQuestion);
            SubmitCommand = new RelayCommand(SubmitTest);
            LoadTests();

            Tabs = new ObservableCollection<TabItemViewModel>();
            LoadTests();

            // Добавляем вкладку "Add Test"
            Tabs.Add(new TabItemViewModel
            {
                Header = "Add Test",
                Content = new AddTestView()
            });

            // Устанавливаем вкладку по умолчанию
            SelectedTab = Tabs.FirstOrDefault();
        }

        public string CurrentQuestionNumber => $"Question {CurrentQuestionIndex + 1} of {CurrentTest?.Questions.Count}";

        public Question CurrentQuestion => CurrentTest?.Questions[_currentQuestionIndex];

        public bool IsNextButtonVisible => !_isTestCompleted && _currentQuestionIndex < CurrentTest?.Questions.Count - 1;
        public bool IsSubmitButtonVisible => !_isTestCompleted && _currentQuestionIndex == CurrentTest?.Questions.Count - 1;
        public bool IsTestCompleted => _isTestCompleted;

        public string ScoreText => _isTestCompleted ? $"You scored: {_score} out of {CurrentTest?.Questions.Count}" : string.Empty;

        public ICommand NextCommand { get; }
        public ICommand SubmitCommand { get; }

        private void LoadTests()
        {
            string json = File.ReadAllText("tests.json");
            List<Test> testList = JsonConvert.DeserializeObject<List<Test>>(json);
            Tests = new ObservableCollection<Test>(testList);
            CurrentTest = Tests.FirstOrDefault();
        }

        private void SaveTests()
        {
            string json = JsonConvert.SerializeObject(Tests, Formatting.Indented);
            File.WriteAllText("tests.json", json);
        }

        private void NextQuestion(object parameter)
        {
            if (_currentQuestionIndex < CurrentTest.Questions.Count - 1)
            {
                _currentQuestionIndex++;
                OnPropertyChanged(nameof(CurrentQuestion));
                OnPropertyChanged(nameof(IsNextButtonVisible));
                OnPropertyChanged(nameof(IsSubmitButtonVisible));
            }
        }

        private void SubmitTest(object parameter)
        {
            foreach (var question in CurrentTest.Questions)
            {
                if (question.Answers[question.CorrectAnswerIndex].IsSelected)
                {
                    _score++;
                }
            }

            _isTestCompleted = true;

            OnPropertyChanged(nameof(IsNextButtonVisible));
            OnPropertyChanged(nameof(IsSubmitButtonVisible));
            OnPropertyChanged(nameof(IsTestCompleted));
            OnPropertyChanged(nameof(ScoreText));
        }

        public void AddTest(Test newTest)
        {
            if (newTest != null && !string.IsNullOrWhiteSpace(newTest.Title))
            {
                Tests.Add(newTest);
                SaveTests();
                CurrentTest = newTest;

                // Добавляем новый тест в вкладки
                Tabs.Insert(Tabs.Count - 1, new TabItemViewModel
                {
                    Header = newTest.Title,
                    Content = new AddTestView { DataContext = new TestViewModel() }
                });
                OnPropertyChanged(nameof(Tabs));
            }
        }
    }
}