using System.Reflection;
using AutoMapper;
using EFCore.Dtos.Read;
using EFCore.Infrastructure;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFile));
});

builder.Services.AddDbContext<EFCoreContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("SqliteDb")));

builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "api");
        options.RoutePrefix = string.Empty;
    });
}

app.UseHttpsRedirection();

app.MapGet("/genre", async (EFCoreContext context, IMapper mapper) =>
{
    var genres = await context.Genres.AsNoTracking().ToListAsync();
    return genres.ConvertAll(genre => mapper.Map<GenreReadDto>(genre));
});

app.MapGet("/book", async (EFCoreContext context, IMapper mapper) =>
{
    var books = await context.Books.AsNoTracking().ToListAsync();
    return books.ConvertAll(book => mapper.Map<BookReadDto>(book));
});

app.MapGet("/journal", async (EFCoreContext context, IMapper mapper) =>
{
    var journals = await context.Journals.AsNoTracking().ToListAsync();
    return journals.ConvertAll(journal => mapper.Map<JournalReadDto>(journal));
});

app.MapGet("/author", async (EFCoreContext context, IMapper mapper) =>
{
    var authors = await context.Authors.AsNoTracking().ToListAsync();
    return authors.ConvertAll(author => mapper.Map<AuthorReadDto>(author));
});

app.MapGet("/publisher", async (EFCoreContext context, IMapper mapper) =>
{
    var publishers = await context.Publishers.AsNoTracking().ToListAsync();
    return publishers.ConvertAll(publisher => mapper.Map<PublisherReadDto>(publisher));
});

app.Run();
