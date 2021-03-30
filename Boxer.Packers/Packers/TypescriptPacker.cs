
using B.Library;
using B.Library.Steps;
using B.Library.Steps.Base;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;

namespace Boxer.Packers
{
    public class TypescriptPacker : BasePacker, IPacker
    {
        private IShell shell => services.GetService<IShell>();

        public TypescriptPacker(IServiceProvider services)
            : base(services)
        {

            initSteps = new List<IStep>
            {
                new EnsureTempFolder(services),
                new EnsureNPMInstalled(services),
                new InstallTypescript(services)


                //new EnsureTypescriptInstalled(services)
            };


            packSteps = new List<IStep>
            {

            };



            RunThrough(initSteps);

            logger.Debug("Typescript packer - Init Completed");
        }

        public void Pack(string path)
        {
            logger.Debug("Typescript packer - Starting Packing...");
            RunThrough(packSteps);
            RunThrough(afterPackSteps);
            logger.Debug("Typescript packer - Finished Packing");
        }
    }
}
