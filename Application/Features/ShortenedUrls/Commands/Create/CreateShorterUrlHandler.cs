using Application.Abstractions.Messaging;
using Application.Common;
using Domain.Abstractions;
using Domain.Entities;
using Domain.Repositories;
using MapsterMapper;

namespace Application.Features.ShortenedUrls.Commands.Create;

internal sealed class CreateShorterUrlHandler(
    IUnitOfWork _unitOfWork,
    IMapper _mapper) : ICommandHandler<CreateShorterUrlCommand, CreateShorterUrlResponse>
{
    public async Task<Result<CreateShorterUrlResponse>> Handle(CreateShorterUrlCommand request, CancellationToken cancellationToken)
    {
        var shortenedUrl = _mapper.Map<ShortenedUrl>(request);

        if (!Uri.TryCreate(request.LongUrl, UriKind.Absolute, out _))
        {
            return Result.Failure<CreateShorterUrlResponse>(ShortenedUrlErrors.CreatedShortenedUrlWasFailed);
        }

        shortenedUrl.Id = Ulid.NewUlid().ToGuid();
        shortenedUrl.UserId = _unitOfWork.UserContext.UserId;
        shortenedUrl.Code = ShorterUrlHelper.GenerateUniqueCode();
        shortenedUrl.ShortUrl = $"{_unitOfWork.ShortenedUrlContext.Scheme}://{_unitOfWork.ShortenedUrlContext.Host}/api/{shortenedUrl.Code}";

        await _unitOfWork.ShortenedUrlRepository.Create(shortenedUrl, cancellationToken);
        await _unitOfWork.CompleteAsync(cancellationToken);

        return _mapper.Map<CreateShorterUrlResponse>(shortenedUrl);
    }
}