# RestaurantsAPI

Реализация тестовой задачи (C#, MS Sql, Entity Framework, Swagger)

Разработать Web.API с использование .Core, которое имеет 3 метода
1. Получение списка ресторанов по определённому городу с поддержкой пейджинга
2. Добавление города
3. Добавление ресторана 
 
Город: id,name
Ресторан: id, name
 
В качестве хранилища данных можно использовать любую реляционную БД
 
Дополнительные требования:
1. Ахитектурно предусмотреть, что-бы изменение хранилища данных не потребовало переписывания всего приложения.
2. Описание доступных методов API должно быть легко получено клиентом, а так-же клиент должен иметь возможность проверить работу метод.

----

Connection String "DBConnection" в appsettings.json
Выполнить команду в Package Manager Console update-database

Страница для доступа к описанию и проверке методов https://localhost:7289/swagger/index.html
