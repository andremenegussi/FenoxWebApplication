using FenoxWebApplication.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace FenoxWebApplication.Repository
{
    public class VehicleBrandRepository : IVehicleBrand
    {
       
        public List<VehicleBrand> GetAllVehicleBrands()
        {
            List<VehicleBrand> vehicleBrands = new List<VehicleBrand>();

            try
            {
                using (SqlConnection connection = new SqlConnection(DbConnection.connectionString))
                {
                    string query = "SELECT * FROM vehicle_brand order by id";

                    SqlCommand command = new SqlCommand(query, connection);

                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        VehicleBrand vehicle_brand = new VehicleBrand
                        {
                            Id = Convert.ToInt32(reader["id"]),
                            Name = Convert.ToString(reader["name"]),
                            Status = Convert.ToBoolean(reader["status"])
                        };
                        Console.WriteLine("ID: " + vehicle_brand.Status + " Name: " + vehicle_brand.Name);
                        vehicleBrands.Add(vehicle_brand);
                    }
                    reader.Close();

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            return vehicleBrands;
        }

        public void AddVehicleBrand(VehicleBrand vehicleBrand)
        {
            Console.WriteLine("Dentro de AddVehicleBrand ");
            try
            {
                using (SqlConnection connection = new SqlConnection(DbConnection.connectionString))
                {
                    string query = "INSERT INTO vehicle_brand (name, status) VALUES (@Name, @Status)";

                    SqlCommand command = new SqlCommand(query, connection);

                    // Parâmetros para a inserção dos valores
                    command.Parameters.AddWithValue("@Name", vehicleBrand.Name);
                    command.Parameters.AddWithValue("@Status", vehicleBrand.Status);

                    connection.Open();

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        Console.WriteLine("Inserção bem-sucedida!");
                    }
                    else
                    {
                        Console.WriteLine("Nenhuma linha afetada pela inserção.");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao inserir na tabela: " + ex.Message);
            }

        }

        public void UpdateVehicleBrand(VehicleBrand vehicleBrand)
        {

            try
            {
                using (SqlConnection connection = new SqlConnection(DbConnection.connectionString))
                {
                    string query = "UPDATE vehicle_brand SET name = @name, status = @Status WHERE id = @Id";

                    SqlCommand command = new SqlCommand(query, connection);

                    // Parâmetros para a atualização dos valores
                    command.Parameters.AddWithValue("@name", vehicleBrand.Name);
                    command.Parameters.AddWithValue("@Status", vehicleBrand.Status);
                    command.Parameters.AddWithValue("@Id", vehicleBrand.Id);

                    connection.Open();

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        Console.WriteLine("Atualização bem-sucedida!");
                    }
                    else
                    {
                        Console.WriteLine("Nenhuma linha afetada pela atualização.");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao atualizar na tabela: " + ex.Message);
            }

        }

        public VehicleBrand getVehicleBrand(int id)
        {
            Console.WriteLine("getVehicleBrand valor de id: " + id);

            VehicleBrand vehicleBrand = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(DbConnection.connectionString))
                {
                    string query = "SELECT * FROM vehicle_brand WHERE id = @Id";

                    SqlCommand command = new SqlCommand(query, connection);

                    // Id da Cor
                    command.Parameters.AddWithValue("@Id", id);

                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        vehicleBrand = new VehicleBrand
                        {
                            Id = Convert.ToInt32(reader["id"]),
                            Name = Convert.ToString(reader["name"]),
                            Status = Convert.ToBoolean(reader["status"])
                        };
                    }

                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao atualizar na tabela: " + ex.Message);
            }

            return vehicleBrand;
        }

        public void DeleteVehicleBrand(int id )
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(DbConnection.connectionString))
                {
                    string query = "Delete from vehicle_brand where id = @Id";

                    SqlCommand command = new SqlCommand(query, connection);

                    // Parâmetros para a atualização dos valores
                    command.Parameters.AddWithValue("@Id", id);

                    connection.Open();

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        Console.WriteLine("Atualização bem-sucedida!");
                    }
                    else
                    {
                        Console.WriteLine("Nenhuma linha afetada pela atualização.");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao atualizar na tabela: " + ex.Message);
            }
        }

    
    }
}
