using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Controls;
using frontend.MVVM.Model;
using frontend.MVVM.ViewModel;

namespace frontend.MVVM.View
{
    /// <summary>
    /// Interaktionslogik für View1.xaml
    /// </summary>
    public partial class PlayerView : UserControl
    {
        public PlayerView()
        {
            InitializeComponent();
            this.DataContext = new PlayerViewModel();
            FetchPlayers();
        }

        public async void FetchPlayers()
        {
            try
            {
                var resultPosts = await GetAllPlayers();
                var postCollection = JsonSerializer.Deserialize<List<ToolModel.Player>>(resultPosts);

                postCollection.ForEach(i => Console.WriteLine(i.Name));

                ItemsControl.ItemsSource = postCollection;
            }
            catch (Exception e)
            {

            }
        }

        public static async Task<string> GetAllPlayers()
        {
            string message = string.Empty;
            using (var client = new HttpClient())
            {

                client.BaseAddress = new Uri("http://h073.de");
                client.DefaultRequestHeaders.Add("XApiKey", "pgH7QzFHJx4w46fI~5Uzi4RvtTwlEXp");

                var response = await client.GetAsync($"tool/player");
                message = await response.Content.ReadAsStringAsync();
            }
            return message;
        }
    }


}
