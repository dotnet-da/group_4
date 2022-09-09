using System.Collections.Generic;
using System.Threading.Tasks;
using frontend.MVVM.Model;

namespace frontend.Core;

public interface IPlayerRepository
{
    Task<ToolModel.Player?> Get(int id);
    Task<IEnumerable<ToolModel.Player>> GetAll();
}