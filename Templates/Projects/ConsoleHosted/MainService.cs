using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace ConsoleHosted
{
  internal class MainService : IHostedService
  {
    private readonly IConfiguration _configuration;
    private readonly IHostApplicationLifetime _appLifetime;
    private readonly ILogger _logger;

    public MainService(IConfiguration configuration,
      IHostApplicationLifetime appLifetime,
      ILogger<MainService> logger)
    {
      _configuration = configuration;
      _appLifetime = appLifetime;
      _logger = logger;
    }
    
    public Task StartAsync(CancellationToken cancellationToken)
    {
      _logger.LogInformation($"Starting with arguments: {string.Join(" ", Environment.GetCommandLineArgs())}");
      
      _appLifetime.ApplicationStarted.Register(() =>
      {
        Task.Run(async () =>
        {
          try
          {
            await ServiceMain().ConfigureAwait(false);
            _logger.LogInformation("done.");
          }
          catch (Exception ex)
          {
            _logger.LogError(ex, $"Unhandled exception: '{ex.Message}'");
          }
          finally
          {
            _appLifetime.StopApplication();
          }
        }, cancellationToken);
      });

      return Task.CompletedTask;
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
      return Task.CompletedTask;
    }

    private Task ServiceMain()
    {
       Console.WriteLine("Hello, World: the Hosted Service.");

       return Task.CompletedTask;
    }
  }
}