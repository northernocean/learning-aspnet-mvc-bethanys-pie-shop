using Microsoft.AspNetCore.Components;

namespace HiltonHello.Pages
{
    public class TimerBase: ComponentBase, IDisposable
    {

        private int timeLeft = 60;
        private PeriodicTimer? timer;
        protected string remaining => TimeSpan.FromSeconds(timeLeft).ToString(@"mm\:ss");

        protected async Task Start()
        {
            timer?.Dispose();
            timer = new PeriodicTimer(TimeSpan.FromSeconds(1));
            while (await timer.WaitForNextTickAsync())
            {
                if (timeLeft > 0)
                {
                    timeLeft -= 1;
                    Console.WriteLine("tick");
                    await InvokeAsync(StateHasChanged);
                }
            }
        }

        protected void Stop()
        {
            timer?.Dispose();
        }

        public void Dispose()
        {
            timer?.Dispose();
        }

    }
}
