using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace frontend.MVVM.ViewModel
{
    internal class AddPlayerViewModel : ViewModelBase
    {
        private string _name;
        public string Name {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged();
            } 
        }

        public ViewModelCommand AddPlayerCommand { get; set; }

        public AddPlayerViewModel()
        {
            AddPlayerCommand = new ViewModelCommand(
                (o) =>
                {
                    //hier kommt dann so api shit... kp wie die domain und so is
                }
                );
        }
    }
}
