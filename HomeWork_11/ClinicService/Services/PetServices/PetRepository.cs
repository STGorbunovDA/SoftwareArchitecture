using ClinicService.Infrastructure;
using ClinicService.Shared;
using ClinicService.Shared.Entity;
using Microsoft.Data.Sqlite;

namespace ClinicService.Services.PetServices
{
    public class PetRepository : IPetRepository
    {
        public async Task<ServiceResponse<Pet>> Create(Pet pet)
        {
            using SqliteConnection connection = new();
            connection.ConnectionString = GlobalConst.CONNECTION_STRING;
            connection.Open();

            using SqliteCommand command =
               new("INSERT INTO pets(ClientId, Name, Birthday) VALUES(@ClientId, @Name, @Birthday)", connection);
            command.Parameters.AddWithValue("@ClientId", pet.ClientId);
            command.Parameters.AddWithValue("@Name", pet.Name);
            command.Parameters.AddWithValue("@Birthday", pet.Birthday.Ticks);
            command.Prepare();

            if (command.ExecuteNonQuery() == 1)
                return await Task.FromResult(new ServiceResponse<Pet> { Data = pet });

            else return new ServiceResponse<Pet> { Data = null };
        }

        public async Task<ServiceResponse<Pet>> Update(Pet pet)
        {
            using SqliteConnection connection = new();
            connection.ConnectionString = GlobalConst.CONNECTION_STRING;
            connection.Open();
            using SqliteCommand command =
                new("UPDATE pets SET ClientId = @ClientId, Name = @Name, " +
                "Birthday = @Birthday WHERE PetId=@PetId", connection);
            command.Parameters.AddWithValue("@PetId", pet.PetId);
            command.Parameters.AddWithValue("@ClientId", pet.ClientId);
            command.Parameters.AddWithValue("@Name", pet.Name);
            command.Parameters.AddWithValue("@Birthday", pet.Birthday.Ticks);
            command.Prepare();

            if (command.ExecuteNonQuery() == 1)
                return await Task.FromResult(new ServiceResponse<Pet> { Data = pet });

            else return new ServiceResponse<Pet> { Data = null };
        }

        public async Task<ServiceResponse<IList<Pet>>> GetAll()
        {
            List<Pet> list = new();
            using SqliteConnection connection = new();
            connection.ConnectionString = GlobalConst.CONNECTION_STRING;
            connection.Open();

            using SqliteCommand command =
                new("SELECT PetId, ClientId, Name, Birthday FROM pets", connection);
            command.Prepare();
            using SqliteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Pet pet = new();
                pet.PetId = reader.GetInt32(0);
                pet.ClientId = reader.GetInt32(1);
                pet.Name = reader.GetString(2);
                pet.Birthday = new DateTime(reader.GetInt64(3));
                list.Add(pet);
            }

            return await Task.FromResult(new ServiceResponse<IList<Pet>> { Data = list });
        }

        public async Task<ServiceResponse<Pet>> GetById(int id)
        {
            using SqliteConnection connection = new();
            connection.ConnectionString = GlobalConst.CONNECTION_STRING;
            connection.Open();
            using SqliteCommand command =
                new("SELECT PetId, ClientId, Name, Birthday FROM pets WHERE PetId=@PetId", connection);
            command.Parameters.AddWithValue("@PetId", id);
            command.Prepare();
            SqliteDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                Pet pet = new();
                pet.PetId = reader.GetInt32(0);
                pet.ClientId = reader.GetInt32(1);
                pet.Name = reader.GetString(2);
                pet.Birthday = new DateTime(reader.GetInt64(3));
                return await Task.FromResult(new ServiceResponse<Pet> { Data = pet });
            }

            return await Task.FromResult(new ServiceResponse<Pet> { Data = null });
        }

        public async Task<ServiceResponse<int>> Delete(int id)
        {
            using SqliteConnection connection = new();
            connection.ConnectionString = GlobalConst.CONNECTION_STRING;
            connection.Open();
            using SqliteCommand command =
                new("DELETE FROM pets WHERE PetId=@PetId", connection);
            command.Parameters.AddWithValue("@PetId", id);
            command.Prepare();

            return await Task.FromResult(new ServiceResponse<int> { Data = command.ExecuteNonQuery() });
        }
    }
}
