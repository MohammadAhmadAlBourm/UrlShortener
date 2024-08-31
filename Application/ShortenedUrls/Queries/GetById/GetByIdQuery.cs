using Application.Abstractions.Messaging;

namespace Application.ShortenedUrls.Queries.GetById;

public sealed record GetByIdQuery(Guid Id) : IQuery<GetUrlByIdResponse>;