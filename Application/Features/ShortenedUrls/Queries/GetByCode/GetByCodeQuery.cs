using MediatR;

namespace Application.Features.ShortenedUrls.Queries.GetByCode;

public sealed record GetByCodeQuery(string Code) : IRequest<GetByCodeResponse>;