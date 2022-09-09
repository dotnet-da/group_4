using frontend.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace frontend.MVVM.ViewModel
{
    internal class AddCollectionViewModel : ViewModelBase
    {
        private int _playerID;
        public int PlayerID
        {
            get => _playerID;
            set
            {
                _playerID = value;
                OnPropertyChanged();
            }
        }

        public IAsyncCommand AddCollectionCommand { get; set; }

        public AddCollectionViewModel()
        {
            AddCollectionCommand = new AsyncCommand(async () =>
            {
                try
                {
                    //Name = AddPlayer().Result;
                    AddCollection();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            });
        }

        private async Task<string> AddCollection()
        {
            //hier kommt dann so api shit... kp wie die domain und so is
            using (HttpClient client = new HttpClient()) //
            {
                client.BaseAddress = new Uri("http://h073.de");
                client.DefaultRequestHeaders.Add("XApiKey", "pgH7QzFHJx4w46fI~5Uzi4RvtTwlEXp");

                Console.WriteLine($"Name {PlayerID}");

                var response = await client.PostAsync($"/tool/collection?player_id={PlayerID}", null);
                return response.ToString();
            }
        }
    }
}
