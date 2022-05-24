namespace Zbw.DesignPatterns.Strategy
{
    using System;

    public interface ITimeSource
    {
        DateTime Now { get; }
    }
}
