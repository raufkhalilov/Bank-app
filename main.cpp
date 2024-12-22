#include "crow.h"
#include <pqxx/pqxx>
#include <nlohmann/json.hpp>  
#include <iostream>
#include <fstream>

using json = nlohmann::json;

// --- Загрузка конфигурации ---
json load_config(const std::string& path) {
    std::ifstream config_file(path);
    if (!config_file) {
        throw std::runtime_error("Configuration file not found!");
    }

    json config;
    config_file >> config;
    return config;
}

// --- GET: Получение всех клиентов ---
json get_dataClients(pqxx::connection& C) {
    try {
        json clients = json::array();
        pqxx::work W(C);

        pqxx::result R = W.exec("SELECT * FROM clients WHERE is_deleted = FALSE");

        for (const auto& row : R) {
            clients.push_back(json{
                {"client_id", row["client_id"].as<int>()},
                {"client_name", row["client_name"].as<std::string>()},
                {"phone_number", row["phone_number"].as<std::string>()}
            });
        }
        W.commit();
        return clients;
    } catch (const std::exception& e) {
        std::cerr << "Ошибка при получении клиентов: " << e.what() << std::endl;
        return json{};
    }
}

// --- GET: Получение клиента по ID ---
json get_dataClientID(pqxx::connection& C, int client_id) {
    try {
        json client;
        pqxx::work W(C);

        pqxx::result R = W.exec_prepared("select_client_by_id", client_id);

        if (R.empty() || R[0]["is_deleted"].as<bool>()) {
            return client; // Пустой JSON, если клиент не найден или удалён
        }

        const auto& row = R[0];
        client = {
            {"client_id", row["client_id"].as<int>()},
            {"client_name", row["client_name"].as<std::string>()},
            {"phone_number", row["phone_number"].as<std::string>()}
        };

        W.commit();
        return client;
    } catch (const std::exception& e) {
        std::cerr << "Ошибка при получении клиента по ID: " << e.what() << std::endl;
        return json{};
    }
}

// --- POST: Добавление клиента ---
crow::response add_client(pqxx::connection& C, const json& client_data) {
    try {
        if (!client_data.contains("client_name") || !client_data.contains("phone_number")) {
            return crow::response(400, "Некорректные данные клиента.");
        }

        std::string name = client_data["client_name"];
        std::string phone = client_data["phone_number"];

        pqxx::work W(C);
        W.exec_prepared("insert_clients", name, phone);
        W.commit();

        return crow::response(201, "Клиент успешно добавлен.");
    } catch (const std::exception& e) {
        std::cerr << "Ошибка при добавлении клиента: " << e.what() << std::endl;
        return crow::response(500, "Ошибка на сервере.");
    }
}

// --- DELETE: Логическое удаление клиента ---
crow::response delete_client(pqxx::connection& C, int client_id) {
    try {
        pqxx::work W(C);

        W.exec_prepared("delete_client", client_id);
        W.commit();

        return crow::response(200, "Клиент успешно удалён.");
    } catch (const std::exception& e) {
        std::cerr << "Ошибка при удалении клиента: " << e.what() << std::endl;
        return crow::response(500, "Ошибка на сервере.");
    }
}

// --- GET: Получение всех контрактов ---
json get_contracts(pqxx::connection& C) {
    try {
        json contracts = json::array();
        pqxx::work W(C);

        pqxx::result R = W.exec("SELECT * FROM contracts WHERE is_deleted = FALSE");

        for (const auto& row : R) {
            contracts.push_back(json{
                {"contract_id", row["contract_id"].as<int>()},
                {"client_id", row["client_id"].as<int>()},
                {"contract_details", row["contract_details"].as<std::string>()},
                {"start_date", row["start_date"].as<std::string>()},
                {"end_date", row["end_date"].as<std::string>()}
            });
        }
        W.commit();
        return contracts;
    } catch (const std::exception& e) {
        std::cerr << "Ошибка при получении контрактов: " << e.what() << std::endl;
        return json{};
    }
}

// --- GET: Получение контракта по ID ---
json get_contract_by_id(pqxx::connection& C, int contract_id) {
    try {
        json contract;
        pqxx::work W(C);

        pqxx::result R = W.exec_prepared("select_contract_by_id", contract_id);

        if (R.empty() || R[0]["is_deleted"].as<bool>()) {
            return contract; // Пустой JSON, если контракт не найден или удалён
        }

        const auto& row = R[0];
        contract = {
            {"contract_id", row["contract_id"].as<int>()},
            {"client_id", row["client_id"].as<int>()},
            {"contract_details", row["contract_details"].as<std::string>()},
            {"start_date", row["start_date"].as<std::string>()},
            {"end_date", row["end_date"].as<std::string>()}
        };

        W.commit();
        return contract;
    } catch (const std::exception& e) {
        std::cerr << "Ошибка при получении контракта по ID: " << e.what() << std::endl;
        return json{};
    }
}

// --- POST: Добавление контракта ---
crow::response add_contract(pqxx::connection& C, const json& contract_data) {
    try {
        if (!contract_data.contains("client_id") || !contract_data.contains("contract_details") ||
            !contract_data.contains("start_date") || !contract_data.contains("end_date")) {
            return crow::response(400, "Некорректные данные контракта.");
        }

        int client_id = contract_data["client_id"];
        std::string details = contract_data["contract_details"];
        std::string start_date = contract_data["start_date"];
        std::string end_date = contract_data["end_date"];

        pqxx::work W(C);
        W.exec_prepared("insert_contract", client_id, details, start_date, end_date);
        W.commit();

        return crow::response(201, "Контракт успешно добавлен.");
    } catch (const std::exception& e) {
        std::cerr << "Ошибка при добавлении контракта: " << e.what() << std::endl;
        return crow::response(500, "Ошибка на сервере.");
    }
}

// --- DELETE: Логическое удаление контракта ---
crow::response delete_contract(pqxx::connection& C, int contract_id) {
    try {
        pqxx::work W(C);

        W.exec_prepared("delete_contract", contract_id);
        W.commit();

        return crow::response(200, "Контракт успешно удалён.");
    } catch (const std::exception& e) {
        std::cerr << "Ошибка при удалении контракта: " << e.what() << std::endl;
        return crow::response(500, "Ошибка на сервере.");
    }
}

int main() {
    crow::SimpleApp app;

    json config;
    try {
        config = load_config("config.json");
    } catch (const std::exception& e) {
        std::cerr << "Ошибка загрузки конфигурации: " << e.what() << std::endl;
        return 1;
    }

    const auto& db_config = config["db"];
    std::string conn_str = "host=" + db_config["host"].get<std::string>() +
                           " port=" + std::to_string(db_config["port"].get<int>()) +
                           " dbname=" + db_config["dbname"].get<std::string>() +
                           " user=" + db_config["user"].get<std::string>() +
                           " password=" + db_config["password"].get<std::string>();

    pqxx::connection C;
    try {
        C = pqxx::connection(conn_str);
    } catch (const std::exception& e) {
        std::cerr << "Ошибка подключения к базе данных: " << e.what() << std::endl;
        return 1;
    }

    // Подготовка SQL-запросов
    C.prepare("insert_clients", "INSERT INTO clients (client_name, phone_number) VALUES ($1, $2)");
    C.prepare("select_client_by_id", "SELECT * FROM clients WHERE client_id = $1");
    C.prepare("delete_client", "UPDATE clients SET is_deleted = TRUE WHERE client_id = $1");

    C.prepare("insert_contract", "INSERT INTO contracts (client_id, contract_details, start_date, end_date) VALUES ($1, $2, $3, $4)");
    C.prepare("select_contract_by_id", "SELECT * FROM contracts WHERE contract_id = $1");
    C.prepare("delete_contract", "UPDATE contracts SET is_deleted = TRUE WHERE contract_id = $1");

    // Маршруты
    CROW_ROUTE(app, "/")([]() {
        return "Сервер работает!";
    });

    CROW_ROUTE(app, "/get/Clients")([&C]() {
        return crow::response(get_dataClients(C).dump());
    });

    CROW_ROUTE(app, "/get/Clients/ID/<int>")([&C](int client_id) {
        json result = get_dataClientID(C, client_id);
        if (result.empty()) {
            return crow::response(404, "Клиент не найден.");
        }
        return crow::response(result.dump());
    });

    CROW_ROUTE(app, "/get/Contracts")([&C]() {
        return crow::response(get_contracts(C).dump());
    });

    CROW_ROUTE(app, "/get/Contracts/ID/<int>")([&C](int contract_id) {
        json result = get_contract_by_id(C, contract_id);
        if (result.empty()) {
            return crow::response(404, "Контракт не найден.");
        }
        return crow::response(result.dump());
    });

    CROW_ROUTE(app, "/post/Client").methods(crow::HTTPMethod::POST)([&C](const crow::request& req) {
        try {
            auto client_data = json::parse(req.body);
            return add_client(C, client_data);
        } catch (const std::exception& e) {
            return crow::response(400, "Некорректный JSON.");
        }
    });

    CROW_ROUTE(app, "/post/Contract").methods(crow::HTTPMethod::POST)([&C](const crow::request& req) {
        try {
            auto contract_data = json::parse(req.body);
            return add_contract(C, contract_data);
        } catch (const std::exception& e) {
            return crow::response(400, "Некорректный JSON.");
        }
    });

    CROW_ROUTE(app, "/delete/Client/<int>").methods(crow::HTTPMethod::DELETE)([&C](int client_id) {
        return delete_client(C, client_id);
    });

    CROW_ROUTE(app, "/delete/Contract/<int>").methods(crow::HTTPMethod::DELETE)([&C](int contract_id) {
        return delete_contract(C, contract_id);
    });

    app.port(8080).multithreaded().run();
}
