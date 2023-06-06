using AutoMapper;
using EFCore.Dtos.Read;
using EFCore.Models;

namespace EFCore.Configuration;

public class CommonAutomapperConfiguration : Profile
{
    public CommonAutomapperConfiguration()
    {
        CreateMap<Genre, GenreReadDto>()
            .ForMember(d => d.Books, opt => opt.MapFrom(s => s.Books));
        CreateMap<Genre, GenreForBookReadDto>();

        CreateMap<Book, BookReadDto>();
        CreateMap<Book, BookForGenreReadDto>();
        CreateMap<Book, BookForAuthorReadDto>();
        CreateMap<Book, BookForPublisherReadDto>();

        CreateMap<Journal, JournalReadDto>();

        CreateMap<Author, AuthorReadDto>();
        CreateMap<Author, AuthorForBookReadDto>();
        CreateMap<Author, AuthorForPublisherReadDto>();

        CreateMap<Publisher, PublisherReadDto>();
        CreateMap<Publisher, PublisherForBookReadDto>();
        CreateMap<Publisher, PublisherForAuthorReadDto>();
    }
}