using frontend.MVVM.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace frontend.MVVM.ViewModel
{
    internal class PlayerViewModel : ViewModelBase
    {
        public ICommand OpenAddPlayerCommand { get; set; }

        public PlayerViewModel()
        {
            OpenAddPlayerCommand = new ViewModelCommand(
                _ =>
                {
                    var addPlayer = new AddPlayerView();
                    addPlayer.ShowDialog();
                }
            );
        }
    }
}