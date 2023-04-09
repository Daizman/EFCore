namespace EFCore.Models
{
    public class Book
    {
        private List<Genre> _genres;
        private List<Author> _authors;

        public Book(
            Guid id,
            string title,
            DateOnly publishDate,
            Guid publisherId,
            List<Genre> genres,
            List<Author> authors)
        {
            Id = id;
            Title = title;
            PublishDate = publishDate;
            PublisherId = publisherId;
            _genres = genres;
            _authors = authors;
        }

        public Guid Id { get; }
        public string Title { get; private set; }
        public DateOnly PublishDate { get; set; }
        public Guid PublisherId { get; set; }
        public ICollection<Genre> Genres => _genres;
        public ICollection<Author> Authors => _authors;

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
            => obj is not null && obj is Book && (obj as Book).Id == Id;

        public override int GetHashCode()
            => base.GetHashCode();
    }
}