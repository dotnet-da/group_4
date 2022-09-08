using System.Text.Json.Serialization;
using WpfApp4.Core;

namespace frontend.MVVM.Model;

public class ToolModel
{
    public partial class Player : ObservableObject
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
            
    }
}