#include "crow.h"
#include <pqxx/pqxx>
#include <nlohmann/json.hpp>  
#include <iostream>

using json = nlohmann::json;

//---GET
json get_dataClients(pqxx::connection& C) {
    try {
        pqxx::work W(C);
        pqxx::result R = W.exec("SELECT * FROM clients");
        json j;

        for (const auto &row : R) {
            j.push_back(json{
                {"client_id", row["id"].is_null() ? nullptr : json(row["id"].as<int>())}, // Изменение здесь
                {"client_name", row["full_name"].is_null() ? nullptr : json(row["full_name"].as<std::string>())}, // Изменение здесь
                {"phone_number", row["phone_number"].is_null() ? nullptr : json(row["phone_number"].as<std::string>())},
            });
        }
        W.commit();
        return j;
    } 
    catch (const std::exception &e) {
        std::cerr << "Ошибка: " << e.what() << std::endl;
        return json{};
    }
}

json get_dataContracts(pqxx::connection& C) {
    try {
        pqxx::work W(C);
        pqxx::result R = W.exec("SELECT * FROM contracts");

        json j;

        for (const auto &row : R) {
            j.push_back({
                {"id", row["id"].is_null() ? nullptr : json(row["id"].as<int>())},
                {"client_id", row["client_id"].is_null() ? nullptr : json(row["client_id"].as<int>())},
                {"description", row["description"].is_null() ? nullptr : json(row["description"].as<std::string>())},
                {"product_type_id", row["product_type_id"].is_null() ? nullptr : json(row["product_type_id"].as<int>())},
                {"start_date", row["start_date"].is_null() ? nullptr : json(row["start_date"].as<std::string>())},
                {"end_date", row["end_date"].is_null() ? nullptr : json(row["end_date"].as<std::string>())},
                {"contract_amount", row["contract_amount"].is_null() ? nullptr : json(row["contract_amount"].as<double>())}
            });
        }

        W.commit();
        return j;
    } catch (const std::exception &e) {
        std::cerr << "Error: " << e.what() << std::endl;
        return json{};
    }
}

// Обработчик для маршрута получения данных
crow::response handle_get_data(pqxx::connection& C, int k) {
    if(k==1)
        return crow::response(get_dataContracts(C).dump());
    if(k==2)
        return crow::response(get_dataClients(C).dump());
}

//--POST
crow::response add_client(pqxx::connection& C, const json& client_data) {
    try {
        pqxx::work W(C);
        
        // данные из json
        std::string name = client_data["client_name"];
        std::string phone = client_data["phone_number"];

        W.exec_prepared("insert_clients", name, phone);
        W.commit();

        return crow::response(201);
    } 
    catch (const std::exception &e) {
        std::cerr << "Ошибка: " << e.what() << std::endl;
        return crow::response(500);  // Код 500 - Internal Server Error
    }
}

int main() {
    crow::SimpleApp app;
    pqxx::connection C("host=192.168.80.1 port=5432 dbname=arhiv user=postgres password=1");

    // запрос для вставки данных
    C.prepare("insert_clients", "INSERT INTO clients (client_name, phone_number) VALUES ($1, $2)"); // Исправлено на full_name

    CROW_ROUTE(app, "/")([](){
        return "Hello, World!";
    });

    CROW_ROUTE(app, "/get/Contracts")([&C]() {
        return handle_get_data(C, 1);
    });

    CROW_ROUTE(app, "/get/Clients")([&C]() {
        return handle_get_data(C, 2);
    });

    CROW_ROUTE(app, "/post/Client").methods(crow::HTTPMethod::POST)([&C](const crow::request& req) {
        auto client_data = json::parse(req.body);  // Парсится тело запроса
        return add_client(C, client_data);         // Добавление в бд
    });

    app.port(8080).multithreaded().run();    
}
