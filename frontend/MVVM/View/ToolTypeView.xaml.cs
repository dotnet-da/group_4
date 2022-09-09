using frontend.MVVM.Model;
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
    /// Interaktionslogik für ToolTypeView.xaml
    /// </summary>
    public partial class ToolTypeView : UserControl
    {
        public ToolTypeView()
        {
            InitializeComponent();
            FetchTypes();
        }

        public async void FetchTypes()
        {
            try
            {
                var resultPosts = await GetAllTypes();
                var postCollection = JsonSerializer.Deserialize<List<ToolModel.Type>>(resultPosts);

                //postCollection.ForEach(i => Console.WriteLine(i.Name));
                postCollection.ForEach(i => Console.WriteLine(i.Identifier));

                ItemsControl.ItemsSource = postCollection;
            }
            catch (Exception e)
            {

            }
        }

        public static async Task<string> GetAllTypes()
        {
            string message = string.Empty;
            using (var client = new HttpClient())
            {

                client.BaseAddress = new Uri("http://h073.de");
                client.DefaultRequestHeaders.Add("XApiKey", "pgH7QzFHJx4w46fI~5Uzi4RvtTwlEXp");

                var response = await client.GetAsync($"tool/type");
                message = await response.Content.ReadAsStringAsync();
            }
            return message;
        }
    }
}
