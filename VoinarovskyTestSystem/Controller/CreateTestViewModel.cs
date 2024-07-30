using System.Collections.ObjectModel;
using System.Windows.Input;
using VoinarovskyTestSystem.Model;

namespace VoinarovskyTestSystem.Controller
{
    public class CreateTestViewModel : BaseViewModel
    {
        private Test _newTest;

        public Test NewTest
        {
            get => _newTest;
            set => SetProperty(ref _newTest, value);
        }

        public ICommand AddQuestionCommand { get; }
        public ICommand SaveTestCommand { get; }

        public CreateTestViewModel()
        {
            NewTest = new Test { Questions = new ObservableCollection<Question>() };
            AddQuestionCommand = new RelayCommand(AddQuestion);
            SaveTestCommand = new RelayCommand(SaveTest);
        }

        private void AddQuestion(object parameter)
        {
            var newQuestion = new Question
            {
                Text = "New Question",
                Answers = new ObservableCollection<Answer>
            {
                new Answer { Text = "Option 1" },
                new Answer { Text = "Option 2" }
            }
            };
            NewTest.Questions.Add(newQuestion);
        }

        private void SaveTest(object parameter)
        {
            // Implement the logic to save the test
            // For example, you can use an event or callback to notify the main ViewModel to add the new test
        }
    }
}
