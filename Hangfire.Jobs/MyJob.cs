using Hangfire;
using System.Threading;

namespace Hang.Jobs
{
    public class MyJob
    {
        [MaximumConcurrentExecutions(2)]
        [Queue("alpha")]
        public void DoJob(int sleep)
        {
            Thread.Sleep(sleep);
        }
    }
}
