using System.Collections.ObjectModel;

namespace VoinarovskyTestSystem.Model
{
    public class Test
    {
        public string Title { get; set; }
        public ObservableCollection<Question> Questions { get; set; }
    }
}