namespace ZbW.DesignPatterns.Strategy
{
    using System;

    public interface ITimeSource
    {
        DateTime Now { get; }
    }
}
