using frontend.MVVM.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace frontend.MVVM.ViewModel
{
    internal class CollectionViewModel : ViewModelBase
    {
        public ICommand OpenAddCollectionCommand { get; set; }

        public CollectionViewModel()
        {
            OpenAddCollectionCommand = new ViewModelCommand(
                _ =>
                {
                    var addCollection = new AddCollectionView();
                    addCollection.ShowDialog();
                }
            );
        }
    }
}
