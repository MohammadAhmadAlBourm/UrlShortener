using Application.Abstractions.Authentication;
using Application.Abstractions.Helper;
using Application.Abstractions.Messaging;
using Domain.Abstractions;
using Domain.Entities;
using Domain.Repositories;
using MapsterMapper;

namespace Application.ShortenedUrls.Commands.Create;

internal sealed class CreateShorterUrlHandler : ICommandHandler<CreateShorterUrlCommand, CreateShorterUrlResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IShorterUrlHelper _shorterUrlHelper;
    private readonly IUserContext _userContext;
    public CreateShorterUrlHandler(IUnitOfWork unitOfWork, IMapper mapper, IShorterUrlHelper shorterUrlHelper, IUserContext userContext)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _shorterUrlHelper = shorterUrlHelper;
        _userContext = userContext;
    }

    public async Task<Result<CreateShorterUrlResponse>> Handle(CreateShorterUrlCommand request, CancellationToken cancellationToken)
    {
        var shortenedUrl = _mapper.Map<ShortenedUrl>(request);

        if (!Uri.TryCreate(request.LongUrl, UriKind.Absolute, out _))
        {
            return Result.Failure<CreateShorterUrlResponse>(ShortenedUrlErrors.Failure(request.LongUrl));
        }

        shortenedUrl.Id = Ulid.NewUlid().ToGuid();
        shortenedUrl.UserId = _userContext.UserId;
        shortenedUrl.Code = _shorterUrlHelper.GenerateUniqueCode();
        shortenedUrl.ShortUrl = $"{_unitOfWork.ShortenedUrlContext.Scheme}://{_unitOfWork.ShortenedUrlContext.Host}/api/{shortenedUrl.Code}";

        await _unitOfWork.ShortenedUrlRepository.Create(shortenedUrl, cancellationToken);
        await _unitOfWork.CompleteAsync(cancellationToken);

        return _mapper.Map<CreateShorterUrlResponse>(shortenedUrl);
    }
}