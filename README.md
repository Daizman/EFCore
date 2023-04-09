# Изучение EF и AutoMapper на примере книжного магазина.

## Описание функционала.
- Есть книги, у которых может быть несколько авторов и несколько жанров. У авторов может быть несколько книг. Один жанр может быть у нескольких книг.
- Книга принадлежит издательству.
- Пользователь API может создавать, читать, удалять книги, авторов, издательства. Получать список жанров.
- На второй итерации (разные версии API и миграций). У книг появляется рейтинг, который может менять пользователь. У автора появляется его рейтинг, который считается как среднее по книгам.


## Требования к реализации.
- БД создается, если ее нет.
- Жанры заполяются при создании БД с помощью вызова ХП.
- Часть книг, авторов, издательств заполняются при создании БД с помощью механизмов EF.
- Для выполнения операций авторов используются ХП.
- Для вывода автора со списком его книг используется представление в БД.
- Для всех таблиц созданы необходимые индексы.
- На втором этапе добавить возможность выставления рейтинга для книги и подсчета рейтинга автора.
- Стараться использовать rich-model.
- Все поля имеют ограничения целостности, которые задаются с использованием FluentAPI и отражаются в БД.
- Разделены представления для пользователя и модели в БД.
- Помимо обычного чтения данных сделать чтение "Топ 10 авторов по жанру", "Авторы работающие в одном жанре".
- Для всего, кроме работы с БД стараться использовать максимально простые и готовые решения. Для БД по максимуму разнообразный EF.


## Используемые технологии.
- SQLite
- EntityFramework Core
- MiniAPI
- AutoMapper
- Swagger


## Примеры моделей.
Модели могут отличаться от описанных интерфейсов, чтобы улучшить ограничения целостности.
- Жанр
```csharp
public interface IGenre
{
    int Id { get; set; }
    string Name { get; set; }
    IList<IBook> Books { get; set; }
}
```
- Книга
```csharp
public interface IBook
{
    Guid Id { get; set; }
    string Title { get; set; }
    DateOnly PublishDate { get; set; }
    IList<IGenre> Genres { get; set; }
    IList<IAuthor> Authors { get; set; }
    IPublisher PublisherId { get; set; }
    // 2-nd iteration
    double Rating { get; set; }
}
```
- Автор
```csharp
public interface IAuthor
{
    Guid Id { get; set; }
    string Fio { get; set; }
    DateOnly BirthDate { get; set; }
    IList<IBook> Books { get; set; }
    IList<IPublisher> Publishers { get; set; }
}
```
- Издательство
```csharp
public interface IPublisher
{
    Guid Id { get; set; }
    string Name { get; set; }
    IList<IBook> Books { get; set; }
    ILIst<IAuthor> Authors { get; set; }
}
```
## Диагарамма зависимостей
![Diagram](https://github.com/Daizman/EFCore/blob/main/Diagrams/EFCoreBookStoreDB.drawio.png)

## Возможные улучшения.
- Интерфейс пользователя.
- FluentValidation.
- CQRS.