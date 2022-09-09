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
    internal class CollectionViewModel : ViewModelBase
    {
        public ICommand OpenAddCollectionCommand { get; set; }

        public CollectionViewModel()
        {
            OpenAddCollectionCommand = new Command(
                _ =>
                {
                    var addCollection = new AddCollectionView();
                    addCollection.ShowDialog();
                }
            );
        }
    }
}
