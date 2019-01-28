using System.Threading;

namespace StandardCore.Routine
{
    public class WaitGroup
    {
        private int _counter = 0;

        public void Add(uint delta)
        {
            if(delta == 1) Interlocked.Increment(ref _counter);
            else
            {
                for(var i = 0; i < delta; i++)
                {
                    Interlocked.Increment(ref _counter);
                }
            }
        }

        public void Done()
        {
            Interlocked.Decrement(ref _counter);
        }

        public void Await()
        {
            while (_counter > 0) continue;
        }
    }
}
