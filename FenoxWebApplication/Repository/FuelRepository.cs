using FenoxWebApplication.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace FenoxWebApplication.Repository
{
    public class FuelRepository : IFuel
    {
       
        public List<Fuel> GetAllFuels()
        {
            List<Fuel> fuels = new List<Fuel>();

            try
            {
                using (SqlConnection connection = new SqlConnection(DbConnection.connectionString))

                {
                    string query = "SELECT * FROM fuel order by id";

                    SqlCommand command = new SqlCommand(query, connection);

                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Fuel fuel = new Fuel
                        {
                            Id = Convert.ToInt32(reader["id"]),
                            Description = Convert.ToString(reader["description"]),
                            Status = Convert.ToBoolean(reader["status"])
                        };
                        Console.WriteLine("ID: " + fuel.Status + " Description: " + fuel.Description);
                        fuels.Add(fuel);
                    }
                    reader.Close();

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            return fuels;
        }


        public void AddFuel(Fuel fuel)
        {
            Console.WriteLine("Dentro de AddFuel ");
            try
            {
                using (SqlConnection connection = new SqlConnection(DbConnection.connectionString))
                {
                    string query = "INSERT INTO fuel (description, status) VALUES (@Description, @Status)";

                    SqlCommand command = new SqlCommand(query, connection);

                    // Parâmetros para a inserção dos valores
                    command.Parameters.AddWithValue("@Description", fuel.Description);
                    command.Parameters.AddWithValue("@Status", fuel.Status);

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

     

        public void DeleteFuel(int id)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(DbConnection.connectionString))
                {
                    string query = "Delete from fuel where id = @Id";

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

        public void UpdateFuel(Fuel fuel)
        {

            try
            {
                using (SqlConnection connection = new SqlConnection(DbConnection.connectionString))
                {
                    string query = "UPDATE fuel SET description = @Description, status = @Status WHERE id = @Id";

                    SqlCommand command = new SqlCommand(query, connection);

                    // Parâmetros para a atualização dos valores
                    command.Parameters.AddWithValue("@Description", fuel.Description);
                    command.Parameters.AddWithValue("@Status", fuel.Status);
                    command.Parameters.AddWithValue("@Id", fuel.Id);

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

        public Fuel getFuel(int id)
        {
            Console.WriteLine("getFuel valor de id: " + id);
            Fuel fuel = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(DbConnection.connectionString))
                {
                    string query = "SELECT * FROM fuel WHERE id = @Id";

                    SqlCommand command = new SqlCommand(query, connection);

                    // Id da Cor
                    command.Parameters.AddWithValue("@Id", id);

                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        fuel = new Fuel
                        {
                            Id = Convert.ToInt32(reader["id"]),
                            Description = Convert.ToString(reader["description"]),
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

            return fuel;
        }


    }




}

