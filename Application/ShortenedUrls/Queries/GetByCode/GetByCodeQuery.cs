using Application.Abstractions.Messaging;

namespace Application.ShortenedUrls.Queries.GetByCode;

public sealed record GetByCodeQuery(string Code) : IQuery<GetByCodeResponse>;