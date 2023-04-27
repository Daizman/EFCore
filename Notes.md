[[_TOC_]]
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
- Мы не можем передавать навигационные поля в конструкторе, а иногда мы хотим ограничить модель, чтобы ее можно было создать только с другим объектом. [Источник](https://learn.microsoft.com/en-us/ef/core/modeling/constructors)
  - Решение: сделать приватный конструктор без параметров для EF Core, а публичный сделать с параметрами.
- Хотим задать seed data для отношения many to many.
  - Решение: подумать, действительно ли оно нам нужно. Если да, то создаем пустую миграцию и делаем через InsertData.
- Хотим добавить какие-то поля, которые от нас скрыты в seed data.
  - Решение: анонимные типы. [Решение](https://learn.microsoft.com/en-us/ef/core/modeling/data-seeding)


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
