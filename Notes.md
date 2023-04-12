# Заметки по работе с EF.

## Основные команды:
- Создание конфигурации: IEntityTypeConfiguration<T>
- Создание миграции: dotnet ef migrations add name
- Удалить последнюю миграцию: dotnet ef migrations remove
- Обновить БД на миграцию: dotnet ef database update migration_name
- Основная справка через: dotnet ef --help

## Полный алгоритм создания БД из миграции:
- `dotnet ef migrations add init`
- `dotnet ef database update init`

## Возможные проблемы:
- Если где-то в конструкторе контекста вызывается Database.EnsureCreated(), то при миграции через `dotnet ef database update` мы будем получать сообщение об ошибке, что таблица уже создана.
  - Решение: заменить Database.EnsureCreated() на Database.Migrate() [Решение](https://stackoverflow.com/questions/38238043/how-and-where-to-call-database-ensurecreated-and-database-migrate)

