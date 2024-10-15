#include "crow.h"
#include <pqxx/pqxx>
#include <nlohmann/json.hpp>  

using json = nlohmann::json;

//Функция для получения данных из базы данных
json get_data(pqxx::connection& C) {
    try {
        pqxx::work W(C);
        pqxx::result R = W.exec("SELECT * FROM contracts");

        json j;

        std::cout << R.size() << " rows fetched.\n";

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
crow::response handle_get_data(pqxx::connection& C) {
    return crow::response(get_data(C).dump());  // Возвращаем JSON-строку в качестве ответа
}


int main() {
    crow::SimpleApp app;  // Создаем экземпляр приложения
    pqxx::connection C("host=192.168.80.1 port=5432 dbname=arhiv user=postgres password=1");
    
    // Route для корневого URL
    CROW_ROUTE(app, "/")([](){
        return "Hello, World!";
    });

    // Route для получения всех данных таблицы contracts
    CROW_ROUTE(app, "/DataContracts")([&C]() {
        return handle_get_data(C);
    });

    app.port(8080).multithreaded().run();    
}
