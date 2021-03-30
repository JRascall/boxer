using Boxer.Library;
using System;
using System.Diagnostics;

namespace B.Library.Shells
{
    public abstract class BaseShell : BoxerBase, IShell
    {
        protected string pName;

        protected BaseShell(IServiceProvider services) : base(services)
        {

        }

        public virtual void Run
        (
            string cmd,
            Action<IShellResult> cb = null
        )
        {
            var process = new Process();
            process.StartInfo.FileName = pName;
            process.StartInfo.RedirectStandardInput = true;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.RedirectStandardError = true;
            process.StartInfo.UseShellExecute = false;
            process.Start();

            process.StandardInput.WriteLine(cmd);
            process.StandardInput.Flush();
            process.StandardInput.Close();

            var output = process.StandardOutput.ReadToEnd();
            var error = process.StandardError.ReadToEnd();

            process.WaitForExit();

            var hasError = error.Length > 0;

            if (hasError) output = error;

            cb?.Invoke(
                ShellResult.Create(hasError, output)
            );
        }
    }
}
