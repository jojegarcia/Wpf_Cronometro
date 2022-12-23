using System;

namespace Core
{
    /// <summary>
    /// Interface for timeable elements
    /// </summary>
    public interface ITimeable
    {
        public TimeSpan? getTime();

        public void Start();

        public void Stop();

        public void Pause();
    }
}
