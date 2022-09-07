using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace frontend.MVVM.ViewModel
{
    internal class MainViewModel : ViewModelBase
    {
        ViewModelCommand toView1Command { get; set; }

        public MainViewModel()
        {
            toView1Command = new ViewModelCommand(
                (o) =>
                {
                   
                }
                );
        }
    }
}
