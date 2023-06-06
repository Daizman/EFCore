# Изучение EF и AutoMapper на примере книжного магазина

## Описание функционала

- Есть книги, у которых может быть несколько авторов и несколько жанров. У авторов может быть несколько книг. Один жанр может быть у нескольких книг.
- Книга принадлежит издательству.
- Помимо книг еще есть журналы, которые как книги, но имеют еще тираж. (введено, чтобы отработать наследование)
- Пользователь API может создавать, читать, удалять книги, авторов, издательства. Получать список жанров.
- На второй итерации (разные версии API и миграций). У книг появляется рейтинг, который может менять пользователь. У автора появляется его рейтинг, который считается как среднее по книгам.

## Требования к реализации

- [x] БД создается, если ее нет.
- [x] Жанры заполяются при создании БД с помощью вызова ХП.
  - ХП нет в sqlite, смотреть `Notes.md`
- [x] Часть книг, авторов, издательств заполняются при создании БД с помощью механизмов EF.
  - Возможные проблемы описаны в `Notes.md`
- [x] Для выполнения операций авторов используются ХП.
  - ХП нет в sqlite, смотреть `Notes.md`
- [ ] Для вывода автора со списком его книг используется представление в БД.
- [x] Для всех таблиц созданы необходимые индексы.
- [x] Журналы наследуются от книг.
- [ ] На втором этапе добавить возможность выставления рейтинга для книги и подсчета рейтинга автора.
- [x] Стараться использовать rich-model.
- [x] Все поля имеют ограничения целостности, которые задаются с использованием FluentAPI и отражаются в БД.
- [ ] Разделены представления для пользователя и модели в БД.
- [ ] Помимо обычного чтения данных сделать чтение "Топ 10 авторов по жанру", "Авторы работающие в одном жанре".
- [ ] Для всего, кроме работы с БД стараться использовать максимально простые и готовые решения. Для БД по максимуму разнообразный EF.

## Используемые технологии

- SQLite
- EntityFramework Core
- MiniAPI
- AutoMapper
- Swagger

## Примеры моделей

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
    IPublisher Publisher { get; set; }
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

- Журнал

```csharp
public interface IJournal : IBook
{
    int Edition { get; set; }
}
```

## Диагарамма зависимостей

![Diagram](Diagrams/EFCoreBookStoreDB.drawio.png)

## План работы

1. [x] Сделать модели для БД.
2. [x] Создать контекст БД. С настройкой автосоздания.
3. [x] Сделать конфигурацию сущностей БД через FluentAPI. С индексами и ограничениями.
4. [x] Сделать начальную миграцию.
5. [x] Сделать заполнение жанров.
6. [x] Сделать заполнение книг, авторов, издательств.
7. [ ] Подключить сваггер и сделать вывод api.
8. [ ] Сделать представления в БД.
9. [ ] Сделать ХП для работы с авторами.
10. [ ] Сделать DTO для отправки в ответ на запросы к API.
11. [ ] Сделать маппинг модели на DTO и наоборот.
12. [ ] Сделать API для базовых CRUD-операций.
13. [ ] Добавить рейтинг в БД без потери сущностей.
14. [ ] Сделать запросы из списка.

## Возможные улучшения

- Интерфейс пользователя.
- FluentValidation.
- CQRS.
