# Заметки по работе с EF.


## Конфигурация сущностей:
- Создание конфигурации: `IEntityTypeConfiguration<T>`

## Основные команды:
- Создание миграции: `dotnet ef migrations add name`
- Удалить последнюю миграцию: `dotnet ef migrations remove`
- Обновить БД на миграцию: `dotnet ef database update migration_name`
- Основная справка через: `dotnet ef --help`

## Полный алгоритм создания БД из миграции:
- `dotnet ef migrations add init`
- `dotnet ef database update init`

## Возможные проблемы:
- Если где-то в конструкторе контекста вызывается Database.EnsureCreated(), то при миграции через `dotnet ef database update` мы будем получать сообщение об ошибке, что таблица уже создана.
  - Решение: заменить Database.EnsureCreated() на Database.Migrate() [Решение](https://stackoverflow.com/questions/38238043/how-and-where-to-call-database-ensurecreated-and-database-migrate)

## Хранимые процедуры:
- В sqlite их нет, поэтому он будет использовать тот язык, на котором ты пишешь)
- Для других языков:
  - Добавить пустую миграцию,
  - В методе Up прописать создание процедуры в строке,
  - Вызвать ее создание в конце через migrationBuilder.Sql(command),
  - Добавить в метод Down ее дроп.
- Чтобы вызвать ХП есть несколько способов:
  - Использовать FromSql: context.Books.FromSql("Вызов хп по имени и передача параметров через интерполяцию или как-то еще (не забываем про sql-инъекции)))"). [Подробнее](https://www.entityframeworktutorial.net/efcore/working-with-stored-procedure-in-ef-core.aspx)
  - Использование ExecuteSqlCommand: context.Database.ExecuteSqlCommand("Вызов ХП").
