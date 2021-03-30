using System.Threading.Tasks;

namespace Boxer
{
    interface ICommand
    {
        string Name { get; }
        Task Run(params string[] args);

    }
}
