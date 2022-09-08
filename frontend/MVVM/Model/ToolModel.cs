using WpfApp4.Core;

namespace frontend.MVVM.Model;

public class ToolModel
{
    public partial class Player : ObservableObject
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}