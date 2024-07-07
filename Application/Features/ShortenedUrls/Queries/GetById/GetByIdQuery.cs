using MediatR;

namespace Application.Features.ShortenedUrls.Queries.GetByCode;

public sealed record GetByIdQuery(Guid Id) : IRequest<GetByIdResponse>;