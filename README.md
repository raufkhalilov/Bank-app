# Проект в процессе...
Доступные get-запросы:
1)http://localhost:8080/
2)http://localhost:8080/get/Contracts
3)http://localhost:8080/get/Clients

Доступные post-запросы:
```curl -X POST http://localhost:8080/post/Client -H "Content-Type: application/json" -d '{"client_name": "<...>", "phone_number":"<...>"}'```

# Пользовательский интерфейс:
1) Работает вывод таблиц клиентов и контрактов.
2) Реализован метод для записи в БД Service.PostDataToApi. К событию пока не привязан.
