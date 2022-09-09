using frontend.MVVM.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using frontend.Core;

namespace frontend.MVVM.ViewModel
{
    internal class ToolTypeViewModel
    {
        public ICommand OpenAddTypeCommand { get; set; }

        public ToolTypeViewModel()
        {
            OpenAddTypeCommand = new Command(
                _ =>
                {
                    var addType = new AddType();
                    addType.ShowDialog();
                }
            );
        }
    }
}
