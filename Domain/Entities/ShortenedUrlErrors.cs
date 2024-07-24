using Domain.Abstractions;

namespace Domain.Entities;

public static class ShortenedUrlErrors
{
    public static readonly Error ShortenedUrlIdNotFound = new("ShortenedUrl.Id", "Shortened Url was not found");
    public static readonly Error ShortenedUrlCodeNotFound = new("ShortenedUrl.Code", "Shortened Url was not found");
    public static readonly Error CreatedShortenedUrlWasFailed = new("ShortenedUrl.Url", "An issue occurred while creating url from provided url");
}