namespace EFCore.Models;

public class Publisher
{
    private string _name;
    private List<Book> _books;
    private List<Author> _authors;

    protected Publisher()
    {
    }

    public Publisher(
        Guid id,
        string name
    )
    {
        Id = id;
        _name = name;
        _books = new();
        _authors = new();
    }

    public Guid Id { get; }
    public string Name
    {
        get => _name;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new InvalidOperationException("Name can't be empty");
            }

            _name = value.Trim();
        }
    }
    public IEnumerable<Book> Books => _books;
    public IEnumerable<Author> Authors => _authors;

    public void AddBooks(IEnumerable<Book> books)
    {
        if (books.Any(b => IsPublisherForBook(b)))
        {
            throw new InvalidOperationException("Book already in this publisher books");
        }

        _books.AddRange(books);
    }

    public void EditBooks(IEnumerable<Book> books)
    {
        _books = books.ToList();
    }

    public void RemoveBooks(IEnumerable<Book> books)
    {
        if (books.Any(b => !IsPublisherForBook(b)))
        {
            throw new InvalidOperationException("Not publisher of this book");
        }

        foreach(var book in books)
        {
            _books.RemoveAt(_books.FindIndex(b => b == book));
        }
    }

    public void AddAuthors(IEnumerable<Author> authors)
    {
        if (authors.Any(a => IsAuthorWithPublisher(a)))
        {
            throw new InvalidOperationException("Author already with this publisher");
        }

        _authors.AddRange(authors);
    }

    public void EditAuthors(IEnumerable<Author> authors)
    {
        _authors = authors.ToList();
    }

    public void RemoveAuthors(IEnumerable<Author> authors)
    {
        if (authors.Any(a => !IsAuthorWithPublisher(a)))
        {
            throw new InvalidOperationException("Author not with publisher");
        }

        foreach(var author in authors)
        {
            _authors.RemoveAt(_authors.FindIndex(a => a == author));
        }
    }

    public bool IsPublisherForBook(Book book)
        => _books.FirstOrDefault(b => b == book) is not null;

    public bool IsAuthorWithPublisher(Author author)
        => _authors.FirstOrDefault(a => a == author) is not null;

    public override bool Equals(object? obj)
        => obj is not null && obj is Publisher && (obj as Publisher)?.Id == Id;

    public override int GetHashCode()
        => base.GetHashCode();
}