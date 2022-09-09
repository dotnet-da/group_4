using System.Windows.Input;
using frontend.Core;
using frontend.MVVM.Model;
using frontend.MVVM.View;

namespace frontend.MVVM.ViewModel
{
    internal class PlayerViewModel : ObservableObject
    {
        public PlayerRepository PlayerRepository;
        
        public ICommand OpenAddPlayerCommand { get; set; }

        public PlayerViewModel()
        {
            PlayerRepository = new PlayerRepository();
            OpenAddPlayerCommand = new Command(
                _ =>
                {
                    var addPlayer = new AddPlayerView();
                    addPlayer.ShowDialog();
                }
            );
        }
    }
}