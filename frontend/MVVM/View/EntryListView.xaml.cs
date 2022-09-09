using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Controls;
using frontend.MVVM.Model;
using frontend.MVVM.ViewModel;

namespace frontend.MVVM.View;

public partial class EntryListView : UserControl
{
    public EntryListView()
    {
        InitializeComponent();
        DataContext = new EntryListViewModel();
        FetchEntries();
    }
    
    public async void FetchEntries()
    {
        try
        {
            var result = await GetAllEntries();
            var collection = JsonSerializer.Deserialize<List<ToolModel.Entry>>(result);
            ItemsControl.ItemsSource = collection;
        }
        catch (Exception e)
        {
            //ignore
        }
    }

    public static async Task<string> GetAllEntries()
    {
        string message = string.Empty;
        using (var client = new HttpClient())
        {

            client.BaseAddress = new Uri("http://h073.de");
            client.DefaultRequestHeaders.Add("XApiKey", "pgH7QzFHJx4w46fI~5Uzi4RvtTwlEXp");

            var response = await client.GetAsync($"tool/entry");
            message = await response.Content.ReadAsStringAsync();
        }
        return message;
    }
    
}