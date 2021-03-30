
using B.Library.Steps;
using Boxer.Library;
using System;
using System.Collections.Generic;

namespace Boxer.Packers
{
    public abstract class BasePacker : BoxerBase
    {
        protected readonly IServiceProvider services;

        protected ICollection<IStep> initSteps;
        protected ICollection<IStep> packSteps;
        protected ICollection<IStep> afterPackSteps;

        protected BasePacker(IServiceProvider services) : base(services)
        {
            this.services = services;

            initSteps = new List<IStep>();
            packSteps = new List<IStep>();
            afterPackSteps = new List<IStep>();
        }

        protected void RunThrough(ICollection<IStep> steps)
        {
            foreach (var step in steps)
            {
                step.Run();
            }
        }


    }
}
