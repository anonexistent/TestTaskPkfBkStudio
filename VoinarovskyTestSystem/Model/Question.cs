using System.Collections.ObjectModel;

namespace VoinarovskyTestSystem.Model
{

    public class Question
    {
        public string Text { get; set; }
        public ObservableCollection<Answer> Answers { get; set; }
        public int CorrectAnswerIndex { get; set; }
    }
}