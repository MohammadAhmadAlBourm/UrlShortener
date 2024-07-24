using Application.Abstractions;

namespace Application.Features.ShortenedUrls.Queries.GetByCode;

public sealed record GetByCodeQuery(string Code) : IQuery<GetByCodeResponse>;