using frontend.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WpfApp4.Core;

namespace frontend.MVVM.ViewModel
{
    internal class AddTypeViewModel : ObservableObject
    {
        private string _identifier;
        public string Identifier
        {
            get => _identifier;
            set
            {
                _identifier = value;
                OnPropertyChanged();
            }
        }

        private string _description;
        public string Description
        {
            get => _description;
            set
            {
                _description = value;
                OnPropertyChanged();
            }
        }

        public IAsyncCommand AddPlayerCommand { get; set; }

        public AddTypeViewModel()
        {
            AddPlayerCommand = new AsyncCommand(async () =>
            {
                try
                {
                    AddType();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            });
        }

        private async Task<string> AddType()
        {
            //hier kommt dann so api shit... kp wie die domain und so is
            using (HttpClient client = new HttpClient()) //
            {
                client.BaseAddress = new Uri("http://h073.de");
                client.DefaultRequestHeaders.Add("XApiKey", "pgH7QzFHJx4w46fI~5Uzi4RvtTwlEXp");

                var response = await client.PostAsync($"/tool/type?identifier={Identifier}&description={Description}", null);
                return response.ToString();
            }
        }
    }
}
