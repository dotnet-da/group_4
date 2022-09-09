using System.Windows.Input;
using frontend.Core;
using frontend.MVVM.View;

namespace frontend.MVVM.ViewModel
{
    internal class PlayerViewModel : ObservableObject
    {
        public ICommand OpenAddPlayerCommand { get; set; }

        public PlayerViewModel()
        {
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