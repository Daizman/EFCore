namespace EFCore.Models;

public class Journal : Book
{
    private int _edition;

    private Journal()
    {
    }

    public Journal(
        in Guid id,
        string title,
        in DateOnly publishDate,
        Publisher publisher,
        IEnumerable<Genre> genres,
        IEnumerable<Author> authors,
        int edition
    ): base(id, title, publishDate, publisher, genres, authors)
    {
        _edition = edition;
    }

    public int Edition
    {
        get => _edition;
        set
        {
            if (value < 0)
            {
                throw new InvalidOperationException("Edition can't be below zero");
            }

            _edition = value;
        }
    }
}