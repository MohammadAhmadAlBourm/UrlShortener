using Domain.Repositories;
using Microsoft.Extensions.Hosting;

namespace Infrastructure.BackgroundJobs;

internal class DeleteUnnecessaryUrlsBackgroundJob(IUnitOfWork _unitOfWork) : BackgroundService
{
    private readonly TimeSpan _period = TimeSpan.FromDays(7);

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        using PeriodicTimer timer = new(_period);

        while (!stoppingToken.IsCancellationRequested &&
               await timer.WaitForNextTickAsync(stoppingToken))
        {
            await _unitOfWork.ShortenedUrlRepository.DeleteUnnecessaryUrls(stoppingToken);
            await _unitOfWork.CompleteAsync(stoppingToken);
        }
    }
}