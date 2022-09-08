using frontend.MVVM.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace frontend.MVVM.ViewModel
{
    internal class PlayerViewModel : ViewModelBase
    {
        public ViewModelCommand OpenAddPlayerCommand { get; set; }

        public PlayerViewModel()
        {
            OpenAddPlayerCommand = new ViewModelCommand(
                (o) =>
                {
                    AddPlayerView addPlayer = new AddPlayerView();
                    addPlayer.ShowDialog();
                }
                );
        }
    }
}
