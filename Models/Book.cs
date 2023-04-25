namespace EFCore.Models;

public class Book
{
    private List<Genre> _genres;
    private List<Author> _authors;
    private string _title;

    protected Book() { }

    public Book(
        Guid id,
        string title,
        DateOnly publishDate,
        Publisher publisher,
        IEnumerable<Genre> genres,
        IEnumerable<Author> authors
    )
    {
        Id = id;
        _title = title;
        PublishDate = publishDate;
        Publisher = publisher;
        _genres = genres.ToList();
        _authors = authors.ToList();
    }

    public Guid Id { get; }
    public string Title 
    {
        get => _title;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new InvalidOperationException("Title can't be empty");
            }

            _title = value.Trim();
        }
    }
    public DateOnly PublishDate { get; set; }
    public Publisher Publisher { get; set; }
    public IEnumerable<Genre> Genres => _genres;
    public IEnumerable<Author> Authors => _authors;

    public void AddAuthors(IEnumerable<Author> authors)
    {
        if (authors.Any(auth => IsAuthorThisBook(auth)))
        {
            throw new InvalidOperationException("Author already in this book authors list");
        }

        _authors.AddRange(authors);
    }

    public void EditAuthors(IEnumerable<Author> authors)
    {
        _authors = authors.ToList();
    }

    public void RemoveAuthors(IEnumerable<Author> authors)
    {
        if (authors.Any(auth => !IsAuthorThisBook(auth)))
        {
            throw new InvalidOperationException("This is not author of this book");
        }

        foreach(var auth in authors)
        {
            _authors.RemoveAt(_authors.FindIndex(a => a == auth));
        }
    }

    public bool IsAuthorThisBook(Author author)
        => _authors.FirstOrDefault(auth => auth == author) is not null;

    public void AddGenres(IEnumerable<Genre> genres)
    {
        if (genres.Any(g => IsBookHaveGenre(g)))
        {
            throw new InvalidOperationException("Book already have this genre");
        }

        _genres.AddRange(genres);   
    }

    public void EditGenres(IEnumerable<Genre> genres)
    {
        _genres = genres.ToList();
    }

    public void RemoveGenres(IEnumerable<Genre> genres)
    {
        if (genres.Any(g => !IsBookHaveGenre(g)))
        {
            throw new InvalidOperationException("This book don't have this genre");
        }

        foreach(var genre in genres)
        {
            _genres.RemoveAt(_genres.FindIndex(g => g == genre));
        }
    }


    public bool IsBookHaveGenre(Genre genre)
        => _genres.FirstOrDefault(g => g == genre) is not null;

    public override bool Equals(object? obj)
        => obj is not null && obj is Book && (obj as Book)?.Id == Id;

    public override int GetHashCode()
        => base.GetHashCode();
}