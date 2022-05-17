namespace ZbW.DesignPatterns.Strategy
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    internal class TimeSource : ITimeSource
    {
        public DateTime Now => DateTime.Now;
    }

    // Other things to mock:
    // - Environment
    // - FileSystem
    // - Network
}
