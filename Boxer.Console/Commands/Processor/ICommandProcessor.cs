using System.Collections.Generic;
using System.Threading.Tasks;

namespace Boxer
{
    interface ICommandProcessor
    {
        ICollection<string> RegisteredCommands();

        Task Process(string @string);
    }
}
