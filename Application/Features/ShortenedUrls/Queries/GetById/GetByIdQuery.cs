using Application.Abstractions;

namespace Application.Features.ShortenedUrls.Queries.GetById;

public sealed record GetByIdQuery(Guid Id) : IQuery<GetUrlByIdResponse>;