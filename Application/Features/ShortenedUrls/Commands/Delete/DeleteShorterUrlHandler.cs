using Application.Abstractions;
using Domain.Abstractions;
using Domain.Repositories;

namespace Application.Features.ShortenedUrls.Commands.Delete;

internal sealed class DeleteShorterUrlHandler(IUnitOfWork _unitOfWork)
    : ICommandHandler<DeleteShorterUrlCommand, bool>
{
    public async Task<Result<bool>> Handle(DeleteShorterUrlCommand request, CancellationToken cancellationToken)
    {
        return await _unitOfWork.ShortenedUrlRepository.Delete(request.Id, cancellationToken);
    }
}