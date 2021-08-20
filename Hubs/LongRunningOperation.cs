using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;

namespace ApiServiceHub.Hubs
{
    public class LongRunningOperation
    {
        #region Properties
        private readonly static ConcurrentDictionary<string, bool> _cancellationRequests
           = new ConcurrentDictionary<string, bool>();

        private readonly static ConcurrentDictionary<string, int> _currentProgress
            = new ConcurrentDictionary<string, int>();
        #endregion

        public static int GetCurrentProgress(string operationId)
            => _currentProgress.GetOrAdd(operationId, 0);

        public static void CancelProcessing(string operationId)
            => _cancellationRequests.AddOrUpdate(operationId, true, (k, v) => true);

        public static bool IsCancelled(string operationId)
            => _cancellationRequests.GetOrAdd(operationId, false);


        private readonly IHubContext<ProgressHub, IProgressHubClientFunctions> _progressHub;

        public LongRunningOperation(IHubContext<ProgressHub, IProgressHubClientFunctions> progressHub)
        {
            _progressHub = progressHub;
        }

        public async Task DoOperation(string operationId)
        {
            await Task.Yield();
            Random rnd = new Random(DateTime.Now.Millisecond);
            decimal totalDelay = 0;

            await _progressHub.Clients.Group(operationId).SetMessage("Processing...");
            for (int progress = 0; progress <= 100; progress++)
            {
                if (IsCancelled(operationId))
                {
                    await _progressHub.Clients.Group(operationId).SetMessage("Processing Cancelled!");
                    return;
                }
                _currentProgress.AddOrUpdate(operationId, progress, (o, p) => progress);
                await _progressHub.Clients.Group(operationId).SetProgress(progress);

                int nextDelay = rnd.Next(1000, 2000);
                await Task.Delay(nextDelay);
                totalDelay += nextDelay;
                await _progressHub.Clients.Group(operationId).SetMessage($"{progress}% done, {(totalDelay / 1000):F2}s elapsed");
            }
            await _progressHub.Clients.Group(operationId).SetMessage("Processing Done!");
        }
    }
}
