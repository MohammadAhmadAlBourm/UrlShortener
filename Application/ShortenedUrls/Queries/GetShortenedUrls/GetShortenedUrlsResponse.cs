﻿namespace Application.ShortenedUrls.Queries.GetShortenedUrls;

public sealed class GetShortenedUrlsResponse
{
    public Guid Id { get; set; }
    public string LongUrl { get; set; } = string.Empty;
    public string ShortUrl { get; set; } = string.Empty;
    public string Code { get; set; } = string.Empty;
    public DateTime CreatedDate { get; set; }
}