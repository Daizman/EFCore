namespace EFCore.Models
{
    public class Journal : Book
    {
        private int _edition;

        public Journal(
            Guid id,
            string title,
            DateOnly publishDate,
            Guid publisherId,
            List<Genre> genres,
            List<Author> authors,
            int edition
        ) : base(id, title, publishDate, publisherId, genres, authors)
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
}