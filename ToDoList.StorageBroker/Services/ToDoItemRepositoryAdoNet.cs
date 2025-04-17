using Microsoft.Data.SqlClient;
using System.Data;
using ToDolist.Dal.Entity;
using ToDoList.StorageBroker.Setting;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ToDoList.StorageBroker.Services;

public class ToDoItemRepositoryAdoNet : IToDoItemRepositoryAdoNet
{
    private readonly string ConnectionString;

    public ToDoItemRepositoryAdoNet(SqlDbConnectionString connectionString)
    {
        ConnectionString = connectionString.ConnectionString;
    }

    public async Task DeleteToDoItemByIdAsync(long Id)
    {
        using (var conn = new SqlConnection(ConnectionString))
        {
            await conn.OpenAsync();
            using (var cmd = new SqlCommand("DeleteToDOList", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", Id);
                cmd.ExecuteNonQuery();
            }
        }
    }

    public int GetToDoListCount()
    {
        var counts = 0;
        using (var conn = new SqlConnection(ConnectionString))
        {
            conn.Open();
            using(var cmd = new SqlCommand("SELECT dbo.CountOfToDoLists()", conn))
            {
                cmd.CommandType = CommandType.Text;
                counts = (int)cmd.ExecuteScalar();
            }
        }
        return counts;
    }

    public async Task<long> InsertToDoItemAsync(ToDoItem toDoItem)
    {
        using (var conn = new SqlConnection(ConnectionString))
        {
            await conn.OpenAsync();
            using (var cmd = new SqlCommand("InsertToDoList", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Title", toDoItem.Title);
                cmd.Parameters.AddWithValue("@Description", toDoItem.Description);
                cmd.Parameters.AddWithValue("@CreatedAt", toDoItem.CreatedAt);
                cmd.Parameters.AddWithValue("@DueDate", toDoItem.DueDate);
                cmd.Parameters.AddWithValue("@IsCompleated", toDoItem.IsCompleted);
                return (long)await cmd.ExecuteScalarAsync();
            }
        }
    }

    public async Task<List<ToDoItem>> SelectByDueDateAsync(DateTime DateTime)
    {
        var ToDoLists = new List<ToDoItem>();
        using (var conn = new SqlConnection(ConnectionString))
        {
            await conn.OpenAsync();
            using (var cmd = new SqlCommand("GetToDoListByDueDate", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@DueDate", conn);
                using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        ToDoLists.Add(new ToDoItem
                        {
                            ToDoItemId = reader.GetInt64(0),
                            Title = reader.GetString(1),
                            Description = reader.GetString(2),
                            IsCompleted = reader.GetBoolean(3),
                            CreatedAt = reader.GetDateTime(4),
                            DueDate = reader.GetDateTime(5)
                        });
                    }
                }
            }
        }
        return ToDoLists;
    }

    public async Task<List<ToDoItem>> SelectCompletedAsync(int skip = 0, int take = 10)
    {
        if (skip < 0) skip = 0;
        if (take < 0 || take > 100) take = 100;

        var ToDoLists = new List<ToDoItem>();
        using (var conn = new SqlConnection(ConnectionString))
        {
            await conn.OpenAsync();
            using (var cmd = new SqlCommand("SelectAllCompletedToDoListPagenation", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Offset", skip);
                cmd.Parameters.AddWithValue("@PageSize", take);
                using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        ToDoLists.Add(new ToDoItem
                        {
                            ToDoItemId = reader.GetInt64(0),
                            Title = reader.GetString(1),
                            Description = reader.GetString(2),
                            IsCompleted = reader.GetBoolean(3),
                            CreatedAt = reader.GetDateTime(4),
                            DueDate = reader.GetDateTime(5)
                        });
                    }
                }
            }
        }
        return ToDoLists;
    }

    public async Task<List<ToDoItem>> SelectInCompletedAsync(int skip = 0, int take = 10)
    {
        if (skip < 0) skip = 0;
        if (take < 0 || take > 100) take = 100;
        var ToDoLists = new List<ToDoItem>();
        using (var conn = new SqlConnection(ConnectionString))
        {
            await conn.OpenAsync();
            using (var cmd = new SqlCommand("SelectAllInCompletedToDoListPagenation", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Offset", skip);
                cmd.Parameters.AddWithValue("@PageSize", take);
                using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        ToDoLists.Add(new ToDoItem
                        {
                            ToDoItemId = reader.GetInt64(0),
                            Title = reader.GetString(1),
                            Description = reader.GetString(2),
                            IsCompleted = reader.GetBoolean(3),
                            CreatedAt = reader.GetDateTime(4),
                            DueDate = reader.GetDateTime(5)
                        });
                    }
                }
            }
        }
        return ToDoLists;
    }

    public async Task<ToDoItem> SelectToDoItemByIdAsync(long Id)
    {
        using (var conn = new SqlConnection(ConnectionString))
        {
            await conn.OpenAsync();
            using (var cmd = new SqlCommand("GetToTOListByID", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", Id);
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    if (reader.Read())
                    {
                        return new ToDoItem
                        {
                            ToDoItemId = reader.GetInt64(0),
                            Title = reader.GetString(1),
                            Description = reader.GetString(2),
                            IsCompleted = reader.GetBoolean(3),
                            CreatedAt = reader.GetDateTime(4),
                            DueDate = reader.GetDateTime(5)
                        };
                    }
                }
            }
        }
        throw new Exception("ToDoItemNotFound");
    }

    public async Task<List<ToDoItem>> SelectToDoItemsAsync(int skip = 0, int take = 10)
    {
        if (skip < 0) skip = 0;
        if (take < 0 || take > 100) take = 100;
        var ToDoLists = new List<ToDoItem>();
        using (var conn = new SqlConnection(ConnectionString))
        {
            await conn.OpenAsync();
            using (var cmd = new SqlCommand("GetToDoListsPagenation", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Offset", skip);
                cmd.Parameters.AddWithValue("@PageSize", take);
                using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        ToDoLists.Add(new ToDoItem
                        {
                            ToDoItemId = reader.GetInt64(0),
                            Title = reader.GetString(1),
                            Description = reader.GetString(2),
                            IsCompleted = reader.GetBoolean(3),
                            CreatedAt = reader.GetDateTime(4),
                            DueDate = reader.GetDateTime(5)
                        });
                    }
                }
            }
        }
        return ToDoLists;
    }

    public async Task UpdateToDoItemAsync(ToDoItem pdateToDoItem)
    {
        using (var conn = new SqlConnection(ConnectionString))
        {
            await conn.OpenAsync();

            using (var cmd = new SqlCommand("UpdateToDoList", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Title", pdateToDoItem.Title);
                cmd.Parameters.AddWithValue("@Id", pdateToDoItem.ToDoItemId);
                cmd.Parameters.AddWithValue("@Discription", pdateToDoItem.Description);
                cmd.Parameters.AddWithValue("@IsCompleted", pdateToDoItem.IsCompleted);
                cmd.Parameters.AddWithValue("@CreatedAt", pdateToDoItem.CreatedAt);
                cmd.Parameters.AddWithValue("@DueDate", pdateToDoItem.DueDate);

                cmd.ExecuteNonQuery();
            }
        }
    }
}
