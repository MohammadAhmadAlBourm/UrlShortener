using Domain.Abstractions;

namespace Domain.Entities;

public static class ShortenedUrlErrors
{
    public static Error NotFound(Guid id) => Error.NotFound(
        "ShortenedUrl.NotFound",
        $"The Url item with the Id = '{id}' was not found");

    public static Error NotFound(string code) => Error.NotFound(
        "ShortenedUrl.NotFound",
        $"The Url item with the code = '{code}' was not found");

    public static Error Failure(string url) => Error.Failure(
        "ShortenedUrl.Failure",
        $"The Url item with the Url = '{url}' was not created successfully");
}