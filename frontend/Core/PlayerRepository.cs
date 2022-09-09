using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using frontend.MVVM.Model;

namespace frontend.Core;

public class PlayerRepository : IPlayerRepository
{
    private static Uri baseUri = new Uri("http://h073.de/tool/");
    
    public async Task<ToolModel.Player> Get(int id)
    {
        var json = await GetStringAsync(new Uri(baseUri, $"player?id={id}").ToString());
        var entity = JsonSerializer.Deserialize<ToolModel.Player>(json);
        return entity;
    }
    
    public async Task<IEnumerable<ToolModel.Player>> GetAll()
    {
        var json = await GetStringAsync(new Uri(baseUri, $"player").ToString());
        var entity = JsonSerializer.Deserialize<IEnumerable<ToolModel.Player>>(json);
        return entity;
    }
    
    private static Task<string> GetStringAsync(string url)
    {
        using (var httpClient = new HttpClient())
        {
            return httpClient.GetStringAsync(url);
        }
    }


}