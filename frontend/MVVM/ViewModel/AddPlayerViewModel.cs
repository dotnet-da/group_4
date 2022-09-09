using System;
using System.Net.Http;
using System.Threading.Tasks;
using frontend.Core;

namespace frontend.MVVM.ViewModel
{
    internal class AddPlayerViewModel : ObservableObject
    {
        private string _name;
        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }

        public IAsyncCommand AddPlayerCommand { get; set; }

        public AddPlayerViewModel()
        {
            AddPlayerCommand = new AsyncCommand(async () =>
            {
                try
                {
                    Name = AddPlayer().Result;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            });
        }

        private async Task<string> AddPlayer()
        {
            //hier kommt dann so api shit... kp wie die domain und so is
            using (HttpClient client = new HttpClient()) //
            {
                client.BaseAddress = new Uri("http://h073.de");
                client.DefaultRequestHeaders.Add("XApiKey", "pgH7QzFHJx4w46fI~5Uzi4RvtTwlEXp");

                Console.WriteLine($"Name {Name}");

                var response = await client.PostAsync($"/tool/player?name={Name}", null);
                return response.ToString();
            }
        }
    }
}
