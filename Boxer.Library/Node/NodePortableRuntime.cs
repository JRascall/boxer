using System;
using System.IO;

namespace Boxer.Library
{
    public class NodePortableRuntime : BoxerBase, INodeRuntime
    {
        protected const string NODE_RUNTIME_FOLDER = "node-runtime";

        protected string nodePath;

        public string Path => nodePath;

        public NodePortableRuntime(IServiceProvider services, string nodePath)
            : base(services)
        {
            this.nodePath = nodePath;
        }

        public NodePortableRuntime(IServiceProvider services)
            : base(services)
        {
            nodePath = LookForRuntime();
        }

        private string LookForRuntime()
        {
            var assumedDir = AppDomain.CurrentDomain.BaseDirectory;

            foreach (var dir in new DirectoryInfo(assumedDir).GetDirectories())
            {
                var name = dir.Name.ToLower();

                if (name.Contains(NODE_RUNTIME_FOLDER))
                {
                    return dir.FullName;
                }
            }

            return null;
        }
    }
}
