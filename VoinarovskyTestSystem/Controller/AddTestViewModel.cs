using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using VoinarovskyTestSystem.Model;

namespace VoinarovskyTestSystem.Controller
{
    public class AddTestViewModel : BaseViewModel
    {
        public ObservableCollection<Question> Questions { get; set; }
        private string _testTitle;

        public string TestTitle
        {
            get => _testTitle;
            set => SetProperty(ref _testTitle, value);
        }

        public ICommand AddTestCommand { get; }

        public AddTestViewModel()
        {
            Questions = new ObservableCollection<Question>();
            AddTestCommand = new RelayCommand(AddTest);
        }

        private void AddTest(object parameter)
        {
            if (string.IsNullOrWhiteSpace(TestTitle))
            {
                // Handle validation error, e.g., show a message to the user
                return;
            }

            var newTest = new Test
            {
                Title = TestTitle,
                Questions = Questions
            };

            // Access the main ViewModel to add the new test
            var mainViewModel = Application.Current.MainWindow.DataContext as TestViewModel;
            mainViewModel?.AddTest(newTest);
        }
    }
}
