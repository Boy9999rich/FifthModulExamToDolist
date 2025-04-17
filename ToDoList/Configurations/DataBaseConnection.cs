using ToDoList.StorageBroker.Setting;

namespace ToDoList.Configurations;

public static class DataBaseConnection
{
    public static void AddDataBaseConnection(this WebApplicationBuilder builder)
    {
        var connectionString = builder.Configuration.GetConnectionString("DatabaseConnection");
        var sqlDbConnectionString = new SqlDbConnectionString(connectionString);

        builder.Services.AddSingleton<SqlDbConnectionString>(sqlDbConnectionString);

        //builder.Services.AddDbContext<MainContext>(options =>
        //    options.UseSqlServer(connectionString));
    }
}
