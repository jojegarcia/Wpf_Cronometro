using System;
using System.Diagnostics;

namespace Core
{
    /// <summary>
    /// Watch class, based on Stopwatch object
    /// </summary>
    public class Watch : ITimeable
    {
        private Stopwatch _watch = null;

        public Watch()
        {
            this._watch = new Stopwatch();
        }

        TimeSpan? ITimeable.getTime()
        {
            return this._watch.Elapsed;
        }
        

        void ITimeable.Pause()
        {
            this._watch.Stop();
        }

        void ITimeable.Start()
        {
            this._watch.Start();
        }

        void ITimeable.Stop()
        {
            this._watch.Reset();
        }
    }
}
