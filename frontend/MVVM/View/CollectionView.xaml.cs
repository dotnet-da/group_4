using frontend.MVVM.Model;
using frontend.MVVM.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace frontend.MVVM.View
{
    /// <summary>
    /// Interaktionslogik für CollectionView.xaml
    /// </summary>
    public partial class CollectionView : UserControl
    {
        public CollectionView()
        {
            InitializeComponent();
            this.DataContext = new CollectionViewModel();
            FetchCollections();
        }

        public async void FetchCollections()
        {
            try
            {
                var resultPosts = await GetAllCollections();
                var postCollection = JsonSerializer.Deserialize<List<ToolModel.Collection>>(resultPosts);

                postCollection.ForEach(i => Console.WriteLine(i.Id));

                ItemsControl.ItemsSource = postCollection;
            }
            catch (Exception e)
            {

            }
        }

        public static async Task<string> GetAllCollections()
        {
            string message = string.Empty;
            using (var client = new HttpClient())
            {

                client.BaseAddress = new Uri("http://h073.de");
                client.DefaultRequestHeaders.Add("XApiKey", "pgH7QzFHJx4w46fI~5Uzi4RvtTwlEXp");

                var response = await client.GetAsync($"tool/collection");
                message = await response.Content.ReadAsStringAsync();
            }
            return message;
        }
    }
}
