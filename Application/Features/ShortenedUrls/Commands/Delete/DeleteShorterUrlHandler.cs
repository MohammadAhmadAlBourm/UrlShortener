using MediatR;

namespace Application.Features.ShortenedUrls.Commands.Delete;

internal sealed class DeleteShorterUrlHandler : IRequestHandler<DeleteShorterUrlCommand, bool>
{
    public Task<bool> Handle(DeleteShorterUrlCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}