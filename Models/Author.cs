namespace EFCore.Models
{
    public class Author
    {
        private List<Book> _books;
        private List<Publisher> _publishers;
        private string _fio;

        public Author(
            Guid id,
            string fio,
            DateOnly birthDate,
            List<Book> books,
            List<Publisher> publishers
        )
        {
            Id = id;
            _fio = fio;
            BirthDate = birthDate;
            _books = books;
            _publishers = publishers;
        }

        public Guid Id { get; }
        public string Fio 
        {
            get => _fio;
            set 
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new InvalidOperationException("Name can't be empty");
                }

                _fio = value.Trim();
            }
        }
        public DateOnly BirthDate { get; set; }
        public IEnumerable<Book> Books => _books;
        public IEnumerable<Publisher> Publishers => _publishers;

        public void AddBooks(IEnumerable<Book> books)
        {
            if (books.Any(b => IsAuthoOfThisBook(b)))
            {
                throw new InvalidOperationException("Book already in this author books");
            }

            _books.AddRange(books);
        }

        public void EditBooks(IEnumerable<Book> books)
        {
            _books = books.ToList();
        }

        public void RemoveBooks(IEnumerable<Book> books)
        {
            if (books.Any(b => !IsAuthoOfThisBook(b)))
            {
                throw new InvalidOperationException("Not author of this book");
            }

            foreach(var book in books)
            {
                _books.RemoveAt(_books.FindIndex(b => b == book));
            }
        }

        public void AddPublishers(IEnumerable<Publisher> publishers)
        {
            if (publishers.Any(p => IsAuthorWithPublisher(p)))
            {
                throw new InvalidOperationException("Author already with this publisher");
            }

            _publishers.AddRange(publishers);
        }

        public void EditPublisher(IEnumerable<Publisher> publishers)
        {
            _publishers = publishers.ToList();
        }

        public void RemovePublishers(IEnumerable<Publisher> publishers)
        {
            if (publishers.Any(p => !IsAuthorWithPublisher(p)))
            {
                throw new InvalidOperationException("Author not with publisher");
            }

            foreach(var publisher in publishers)
            {
                _publishers.RemoveAt(_publishers.FindIndex(p => p == publisher));
            }
        }

        public bool IsAuthoOfThisBook(Book book)
            => _books.FirstOrDefault(b => b == book) is not null;

        public bool IsAuthorWithPublisher(Publisher publisher)
            => _publishers.FirstOrDefault(p => p == publisher) is not null;
    }
}