using System;
using System.IO;
using System.Linq;

namespace B.Library.Steps
{
    public class EnsureTempFolder : BaseStep
    {
        private string CurrentDirectory => Directory.GetCurrentDirectory();

        public EnsureTempFolder(IServiceProvider services, Action nextStep = null)
            : base(services, nextStep) { }

        public override void Run()
        {
            logger.Debug("Creating a temporary folder for the compiling...");

            var temps = Directory.GetDirectories(CurrentDirectory).Where(X => X.Contains("temp"));
            var nxt = temps.Count() + 1;
            var name = $"temp{nxt}";
            var path = Path.Combine(CurrentDirectory, name);

            Directory.CreateDirectory(path);


            logger.Debug("tempory folder created");

            NextStep?.Invoke();
        }
    }
}
