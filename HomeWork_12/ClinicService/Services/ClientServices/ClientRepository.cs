using ClinicService.Infrastructure;
using ClinicService.Shared;
using ClinicService.Shared.Entity;
using Microsoft.Data.Sqlite;

namespace ClinicService.Services.ClientServices
{
    public class ClientRepository : IClientRepository
    {
        public async Task<ServiceResponse<Client>> Create(Client client)
        {
            using SqliteConnection connection = new();
            connection.ConnectionString = GlobalConst.CONNECTION_STRING;
            connection.Open();

            using SqliteCommand command =
               new("INSERT INTO clients(Document, SurName, FirstName, Patronymic, Birthday) " +
               "VALUES(@Document, @SurName, @FirstName, @Patronymic, @Birthday)", connection);

            command.Parameters.AddWithValue("@Document", client.Document);
            command.Parameters.AddWithValue("@SurName", client.SurName);
            command.Parameters.AddWithValue("@FirstName", client.FirstName);
            command.Parameters.AddWithValue("@Patronymic", client.Patronymic);
            command.Parameters.AddWithValue("@Birthday", client.Birthday.Ticks);
            command.Prepare();

            if (command.ExecuteNonQuery() == 1)
                return await Task.FromResult(new ServiceResponse<Client> { Data = client });

            else return new ServiceResponse<Client> { Data = null };
        }

        public async Task<ServiceResponse<Client>> Update(Client client)
        {
            using SqliteConnection connection = new();
            connection.ConnectionString = GlobalConst.CONNECTION_STRING;
            connection.Open();

            using SqliteCommand command =
                new("UPDATE clients SET Document = @Document, FirstName = @FirstName, SurName = @SurName, " +
                "Patronymic = @Patronymic, Birthday = @Birthday WHERE ClientId=@ClientId", connection);

            command.Parameters.AddWithValue("@ClientId", client.ClientId);
            command.Parameters.AddWithValue("@Document", client.Document);
            command.Parameters.AddWithValue("@SurName", client.SurName);
            command.Parameters.AddWithValue("@FirstName", client.FirstName);
            command.Parameters.AddWithValue("@Patronymic", client.Patronymic);
            command.Parameters.AddWithValue("@Birthday", client.Birthday.Ticks);
            command.Prepare();

            if (command.ExecuteNonQuery() == 1)
                return await Task.FromResult(new ServiceResponse<Client> { Data = client });

            else return new ServiceResponse<Client> { Data = null };
        }

        public async Task<ServiceResponse<IList<Client>>> GetAll()
        {
            List<Client> list = new();
            using SqliteConnection connection = new();
            connection.ConnectionString = GlobalConst.CONNECTION_STRING;
            connection.Open();

            using SqliteCommand command =
                new("SELECT ClientId, Document, SurName, FirstName, Patronymic, Birthday FROM clients", connection);
            command.Prepare();
            using SqliteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Client client = new();
                client.ClientId = reader.GetInt32(0);
                client.Document = reader.GetString(1);
                client.SurName = reader.GetString(2);
                client.FirstName = reader.GetString(3);
                client.Patronymic = reader.GetString(4);
                client.Birthday = new DateTime(reader.GetInt64(5));
                list.Add(client);
            }

            return await Task.FromResult(new ServiceResponse<IList<Client>> { Data = list });
        }

        public async Task<ServiceResponse<Client>> GetById(int id)
        {
            using SqliteConnection connection = new();
            connection.ConnectionString = GlobalConst.CONNECTION_STRING;
            connection.Open();

            using SqliteCommand command =
                new("SELECT ClientId, Document, SurName, FirstName, Patronymic, Birthday FROM clients WHERE ClientId=@ClientId", connection);

            command.Parameters.AddWithValue("@ClientId", id);
            command.Prepare();
            SqliteDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                Client client = new();
                client.ClientId = reader.GetInt32(0);
                client.Document = reader.GetString(1);
                client.SurName = reader.GetString(2);
                client.FirstName = reader.GetString(3);
                client.Patronymic = reader.GetString(4);
                client.Birthday = new DateTime(reader.GetInt64(5));
                return await Task.FromResult(new ServiceResponse<Client> { Data = client });
            }

            return await Task.FromResult(new ServiceResponse<Client> { Data = null });
        }

        public async Task<ServiceResponse<int>> Delete(int id)
        {
            using SqliteConnection connection = new();
            connection.ConnectionString = GlobalConst.CONNECTION_STRING;
            connection.Open();

            using SqliteCommand command =
                new("DELETE FROM clients WHERE ClientId=@ClientId", connection);

            command.Parameters.AddWithValue("@ClientId", id);
            command.Prepare();

            return await Task.FromResult(new ServiceResponse<int> { Data = command.ExecuteNonQuery() });
        }
    }
}
