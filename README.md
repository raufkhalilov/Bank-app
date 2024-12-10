# Проект в процессе...
Доступные get-запросы:
1)http://localhost:8080/
2)http://localhost:8080/get/Contracts
3)http://localhost:8080/get/Clients

Доступные post-запросы:
```curl -X POST http://localhost:8080/post/Client -H "Content-Type: application/json" -d '{"client_name": "<...>", "phone_number":"<...>"}'```

# Пользовательский интерфейс:
login = "admin"
password = "password"

1) Работает вывод таблиц клиентов и контрактов.
2) Работает возможность добавления новых клиентов.
3) Есть возможность ручного переподключения к API (кнопка "Обновить")
4) Есть фиктивная авторизация(логин и пароль заданы в коде программы)
