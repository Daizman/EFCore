namespace EFCore.Models
{
    public class Genre
    {
        private readonly List<Book> _books;

        public Genre (int id, string name)
        {
            Id = id;
            Name = name;
            _books = new();
        }

        public int Id { get; }
        public string Name { get; }
        public IEnumerable<Book> Books => _books;

        public void AddBook(Book book)
        {
            if (BookExistsInGenre(book))
            {
                throw new InvalidOperationException("Book already in genre");
            }

            _books.Add(book);
        }

        public void AddBooks(IEnumerable<Book> books)
        {
            if (books.Any(b => BookExistsInGenre(b)))
            {
                throw new InvalidOperationException("Some book from list already in genre");
            }

            _books.AddRange(books);
        }

        public void RemoveBook(Book book)
        {
            if (!BookExistsInGenre(book))
            {
                throw new InvalidOperationException("Book not found in genre");
            }

            _books.RemoveAt(_books.FindIndex(b => b == book));
        } 

        public bool BookExistsInGenre(Book book)
            => _books.FirstOrDefault(b => b == book) is not null;

        public override bool Equals(object? obj)
            => obj is not null && obj is Genre && (obj as Genre)?.Id == Id;

        public override int GetHashCode()
            => base.GetHashCode();
    }
}