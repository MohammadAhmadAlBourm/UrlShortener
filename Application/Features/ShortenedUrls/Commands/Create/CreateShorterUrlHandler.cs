using Application.Common;
using Domain.Entities;
using Domain.Repositories;
using MapsterMapper;
using MediatR;
using UrlShortener.Services;

namespace Application.Features.ShortenedUrls.Commands.Create;

internal sealed class CreateShorterUrlHandler(
    IShortenedUrlRepository _shortenedUrlRepository,
    IMapper _mapper,
    IShortenedUrlContext _shortenedUrlContext,
    IUserContext _userContext) : IRequestHandler<CreateShorterUrlCommand, CreateShorterUrlResponse>
{
    public async Task<CreateShorterUrlResponse> Handle(CreateShorterUrlCommand request, CancellationToken cancellationToken)
    {
        var shortenedUrl = _mapper.Map<ShortenedUrl>(request);

        if (!Uri.TryCreate(request.LongUrl, UriKind.Absolute, out _))
        {
            throw new Exception();
        }

        shortenedUrl.Id = Guid.NewGuid();
        shortenedUrl.UserId = _userContext.UserId;
        shortenedUrl.Code = ShorterUrlHelper.GenerateUniqueCode();
        shortenedUrl.ShortUrl = $"{_shortenedUrlContext.Scheme}://{_shortenedUrlContext.Host}/api/{shortenedUrl.Code}";

        await _shortenedUrlRepository.Create(shortenedUrl, cancellationToken);

        return _mapper.Map<CreateShorterUrlResponse>(shortenedUrl);
    }
}