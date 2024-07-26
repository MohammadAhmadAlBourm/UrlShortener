using Application.Abstractions.Messaging;

namespace Application.Features.ShortenedUrls.Queries.GetByCode;

public sealed record GetByCodeQuery(string Code) : IQuery<GetByCodeResponse>;