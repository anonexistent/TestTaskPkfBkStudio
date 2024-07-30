using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoinarovskyTestSystem.Controller
{
    public class TabItemViewModel
    {
        public string Header { get; set; } // Заголовок вкладки
        public object Content { get; set; } // Содержимое вкладки (может быть любой тип, например, UserControl или View)
    }
}
