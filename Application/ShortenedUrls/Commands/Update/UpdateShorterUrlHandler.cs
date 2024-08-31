using MediatR;

namespace Application.ShortenedUrls.Commands.Update;

internal sealed class UpdateShorterUrlHandler : IRequestHandler<UpdateShorterUrlCommand, UpdateShorterUrlResponse>
{
    public Task<UpdateShorterUrlResponse> Handle(UpdateShorterUrlCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}