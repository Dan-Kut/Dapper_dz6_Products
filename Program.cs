using Microsoft.Extensions.Configuration;

namespace Dapper_dz6_Products
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder(); // Створення конфігуратора.
            string path = Directory.GetCurrentDirectory(); // Отримує поточну директорію програми.
            builder.SetBasePath(path); // Встановлює базовий шлях для конфігураційних файлів.
            builder.AddJsonFile("appsettings.json"); // Додає файл конфігурації.
            var config = builder.Build(); // Завантажує конфігурацію.
            string connectionString = config.GetConnectionString("DefaultConnection"); // Отримує рядок підключення.
        }
    }
}
