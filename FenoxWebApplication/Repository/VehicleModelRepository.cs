using FenoxWebApplication.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace FenoxWebApplication.Repository
{
    public class VehicleModelRepository : IVehicleModels
    {
        public List<VehicleModel> GetAllVehicleModels()
        {
            List<VehicleModel> vehicleModels = new List<VehicleModel>();
            try
            {
               

                using (SqlConnection connection = new SqlConnection(DbConnection.connectionString))
                {
                    string query = @"
                                        SELECT 
                                            vehicle_model.id AS id,
                                            vehicle_model.name AS name,
                                            vehicle_model.status AS status,
                                            vehicle_brand.id AS brand_id,
                                            vehicle_brand.name AS brand_name,
                                            vehicle_brand.status AS brand_status
                                        FROM 
                                            vehicle_model
                                        JOIN 
                                            vehicle_brand ON vehicle_brand.id = vehicle_model.fk_vehicle_brand";

                    SqlCommand command = new SqlCommand(query, connection);

                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        VehicleBrand vehicleBrand = new VehicleBrand
                        {
                            Id = Convert.ToInt32(reader["brand_id"]),
                            Name = Convert.ToString(reader["brand_name"]),
                            Status = Convert.ToBoolean(reader["brand_status"])
                        };

                        VehicleModel vehicleModel = new VehicleModel
                        {
                            Id = Convert.ToInt32(reader["id"]),
                            Name = Convert.ToString(reader["name"]),
                            Status = Convert.ToBoolean(reader["status"]),
                            VehicleBrand = vehicleBrand
                        };

                        vehicleModels.Add(vehicleModel);
                    }

                    reader.Close();
                }

                // Agora você tem uma lista de modelos, cada um com sua marca associada
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao recuperar os dados: " + ex.Message);
            }
            return vehicleModels;
        }

        public void AddVehicleModel(VehicleModel vehicleModel)
        {
            Console.WriteLine("Dentro de AddVehicleModel ");
            try
            {
                using (SqlConnection connection = new SqlConnection(DbConnection.connectionString))
                {
                    string query = "INSERT INTO vehicle_model (name, status, fk_vehicle_brand) VALUES (@Name, @Status, @vehicle_brand_id)";

                    SqlCommand command = new SqlCommand(query, connection);

                    // Parâmetros para a inserção dos valores
                    command.Parameters.AddWithValue("@Name", vehicleModel.Name);
                    command.Parameters.AddWithValue("@Status", vehicleModel.Status);
                    command.Parameters.AddWithValue("@vehicle_brand_id", vehicleModel.VehicleBrand.Id);

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

        public void DeleteVehicleModel(int id)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(DbConnection.connectionString))
                {
                    string query = "Delete from vehicle_model where id = @Id";
                    //string query = "UPDATE vehicle_model SET name = @name, status = @Status  WHERE id = @Id";

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

        public void UpdateVehicleModel(VehicleModel vehicleModel)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(DbConnection.connectionString))
                {
                    string query = "UPDATE vehicle_model SET name = @name, status = @Status, fk_vehicle_brand = @vehicle_brand_id WHERE id = @Id";
                    //string query = "UPDATE vehicle_model SET name = @name, status = @Status  WHERE id = @Id";

                    SqlCommand command = new SqlCommand(query, connection);

                    // Parâmetros para a atualização dos valores
                    command.Parameters.AddWithValue("@name", vehicleModel.Name);
                    command.Parameters.AddWithValue("@Status", vehicleModel.Status);
                    command.Parameters.AddWithValue("@vehicle_brand_id", vehicleModel.VehicleBrand.Id);
                    command.Parameters.AddWithValue("@Id", vehicleModel.Id);

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

        public VehicleModel geVehicleModel(int id)
        {
            Console.WriteLine("geVehicleModel valor de id: " + id);
            
            VehicleModel vehicleModel = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(DbConnection.connectionString))
                {
                    string query = @"
                                        SELECT 
                                            vehicle_model.id AS id,
                                            vehicle_model.name AS name,
                                            vehicle_model.status AS status,
                                            vehicle_brand.id AS brand_id,
                                            vehicle_brand.name AS brand_name,
                                            vehicle_brand.status AS brand_status
                                        FROM 
                                            vehicle_model
                                        JOIN 
                                            vehicle_brand ON vehicle_brand.id = vehicle_model.fk_vehicle_brand AND vehicle_model.id = @Id";

                    SqlCommand command = new SqlCommand(query, connection);

                    // Id da Cor
                    command.Parameters.AddWithValue("@Id", id);

                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        VehicleBrand vehicleBrand = new VehicleBrand
                        {
                            Id = Convert.ToInt32(reader["brand_id"]),
                            Name = Convert.ToString(reader["brand_name"]),
                            Status = Convert.ToBoolean(reader["brand_status"])
                        };

                        vehicleModel = new VehicleModel
                        {
                            Id = Convert.ToInt32(reader["id"]),
                            Name = Convert.ToString(reader["name"]),
                            Status = Convert.ToBoolean(reader["status"]),
                            VehicleBrand = vehicleBrand
                        };
                    }

                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao atualizar na tabela: " + ex.Message);
            }

            return vehicleModel;
        }

    }
}
