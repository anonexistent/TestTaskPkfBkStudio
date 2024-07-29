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

namespace VoinarovskyTestSystem.Controller
{
    public class TestViewModel : BaseViewModel
    {
        private ObservableCollection<Test> _tests;
        private Test _currentTest;
        private int _currentQuestionIndex;
        private int _score;
        private bool _isTestCompleted;

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
                }
            }
        }

        public Question CurrentQuestion => CurrentTest?.Questions[_currentQuestionIndex];

        public bool IsNextButtonVisible => !_isTestCompleted && _currentQuestionIndex < CurrentTest?.Questions.Count - 1;
        public bool IsSubmitButtonVisible => !_isTestCompleted && _currentQuestionIndex == CurrentTest?.Questions.Count - 1;
        public bool IsTestCompleted => _isTestCompleted;

        public string ScoreText => _isTestCompleted ? $"You scored: {_score} out of {CurrentTest?.Questions.Count}" : string.Empty;

        public ICommand NextCommand { get; }
        public ICommand SubmitCommand { get; }

        public TestViewModel()
        {
            NextCommand = new RelayCommand(NextQuestion);
            SubmitCommand = new RelayCommand(SubmitTest);
            LoadTests();
        }

        private void LoadTests()
        {
            string json = File.ReadAllText("tests.json");
            List<Test> testList = JsonConvert.DeserializeObject<List<Test>>(json);
            Tests = new ObservableCollection<Test>(testList);
            CurrentTest = Tests.FirstOrDefault();
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
            // Подсчет результатов
            foreach (var question in CurrentTest.Questions)
            {
                if (question.Answers[question.CorrectAnswerIndex].IsSelected)
                {
                    _score++;
                }
            }

            _isTestCompleted = true;

            // Обновление привязанных свойств
            OnPropertyChanged(nameof(IsNextButtonVisible));
            OnPropertyChanged(nameof(IsSubmitButtonVisible));
            OnPropertyChanged(nameof(IsTestCompleted));
            OnPropertyChanged(nameof(ScoreText));
        }
    }
}