namespace EFCore.Dtos.Read;

public record GenreReadDto(string Name, IEnumerable<BookForGenreReadDto> Books);
public record BookForGenreReadDto(string Title);

public record BookReadDto(
    string Title,
    DateOnly PublishDate,
    PublisherForBookReadDto Publisher,
    IEnumerable<GenreForBookReadDto> Genres,
    IEnumerable<AuthorForBookReadDto> Authors);
public record PublisherForBookReadDto(string Name);
public record AuthorForBookReadDto(string Name);
public record GenreForBookReadDto(string Name);

public record JournalReadDto(
    string Title,
    DateOnly PublishDate,
    PublisherForBookReadDto Publisher,
    IEnumerable<GenreForBookReadDto> Genres,
    IEnumerable<AuthorForBookReadDto> Authors,
    int Edition) : BookReadDto (Title, PublishDate, Publisher, Genres, Authors);

public record AuthorReadDto(
    string Fio,
    DateOnly BirthDate,
    IEnumerable<BookForAuthorReadDto> Books,
    IEnumerable<PublisherForAuthorReadDto> Publishers);
public record BookForAuthorReadDto(string Title);
public record PublisherForAuthorReadDto(string Name);

public record PublisherReadDto(
    string Name,
    IEnumerable<BookForPublisherReadDto> Books,
    IEnumerable<AuthorForPublisherReadDto> Publishers);
public record BookForPublisherReadDto(string Title);
public record AuthorForPublisherReadDto(string Name);
