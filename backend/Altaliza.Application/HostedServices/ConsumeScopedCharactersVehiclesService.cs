using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;


namespace Altaliza.Application.HostedServices
{
    public class ConsumeScopedCharactersVehiclesService : BackgroundService
    {
        private Timer _timer;

        private readonly IServiceProvider _serviceProvider;

        private readonly int TASK_TIME = 60 * 60;

        public ConsumeScopedCharactersVehiclesService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        // Method called when IHostedService starts
        protected override Task ExecuteAsync(CancellationToken cancellationToken)
        {
            Console.WriteLine("[Consumer][CharactersVehicles Service] Service started");

            _timer = new Timer(DoWork, null, TimeSpan.Zero,
            TimeSpan.FromSeconds(TASK_TIME));

            return Task.CompletedTask;
        }

        private async void DoWork(object state)
        {
            await DoWorkAsync();

        }

        private async Task DoWorkAsync()
        {
            try
            {
                using (IServiceScope scope = _serviceProvider.CreateScope())
                {
                    var scopedProcessingService = scope.ServiceProvider.GetRequiredService<ScopedCharactersVehiclesService>();

                    await scopedProcessingService.DoWorkAsync();
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine("[Consumer][CharactersVehicles Service] Error occured during background task");
                Console.WriteLine("-------------------------------- ERROR MESSAGE--------------------------------");
                Console.WriteLine();
                Console.Write(exception.Message);
                Console.WriteLine();
                Console.WriteLine("-------------------------------- ERROR MESSAGE --------------------------------");
            }

            
        }

        public override async Task StopAsync(CancellationToken cancellationToken)
        {
            Console.WriteLine("[Consumer][CharactersVehicles Service] Service is stopping");

            _timer?.Change(Timeout.Infinite, 0);

            await base.StopAsync(cancellationToken);
        }

        public override void Dispose()
        {
            _timer?.Dispose();
        }
    }
}