using HelpDesk.DAL.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace HelpDesk.DAL.Workers;

public class TokenWorker(IServiceScopeFactory scopeFactory):BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        using IServiceScope scope = scopeFactory.CreateScope();
        HelpDeskContext dbContext = scope.ServiceProvider.GetRequiredService<HelpDeskContext>();
        while (!stoppingToken.IsCancellationRequested)
        {
            await dbContext.Auditory.Where(t => t.DateExpiration <=  DateTime.Now && t.DateRevoked == null)
                .ExecuteUpdateAsync(ex => ex.SetProperty(t => t.DateRevoked, DateTime.Now), stoppingToken);
            await Task.Delay(new TimeSpan(0, 30, 0), stoppingToken);
        }
    }
}
