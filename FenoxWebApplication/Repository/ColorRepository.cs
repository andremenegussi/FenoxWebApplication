using FenoxWebApplication.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;


namespace FenoxWebApplication.Repository
{
    public class ColorRepository: IColor
    {
      
        // private string connectionString = "Server = localhost\\SQLEXPRESS01;Database=fenox;Trusted_Connection=True;";

        public List<Color> GetAllColors()
        {
            List<Color> colors = new List<Color>();

            try
            {
                using (SqlConnection connection = new SqlConnection(DbConnection.connectionString))
                {
                    string query = "SELECT * FROM color order by id";

                    SqlCommand command = new SqlCommand(query, connection);

                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Color color = new Color
                        {
                            Id = Convert.ToInt32(reader["id"]),
                            Description = Convert.ToString(reader["description"]),
                            Status = Convert.ToBoolean(reader["status"])
                        };
                        Console.WriteLine("ID: " + color.Status + " Description: " + color.Description);
                        colors.Add(color);
                    }
                    reader.Close();

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            return colors;
        }

        public void AddColor(Color color)
        {
            Console.WriteLine("Dentro de AddColor ");
            try
            {
                using (SqlConnection connection = new SqlConnection(DbConnection.connectionString))
                {
                    string query = "INSERT INTO color (description, status) VALUES (@Description, @Status)";

                    SqlCommand command = new SqlCommand(query, connection);

                    // Parâmetros para a inserção dos valores
                    command.Parameters.AddWithValue("@Description", color.Description);
                    command.Parameters.AddWithValue("@Status", color.Status);

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

        public void UpdateColor(Color color)
        {
            
            try
            {
                using (SqlConnection connection = new SqlConnection(DbConnection.connectionString))
                {
                    string query = "UPDATE color SET description = @Description, status = @Status WHERE id = @Id";

                    SqlCommand command = new SqlCommand(query, connection);

                    // Parâmetros para a atualização dos valores
                    command.Parameters.AddWithValue("@Description", color.Description);
                    command.Parameters.AddWithValue("@Status", color.Status);
                    command.Parameters.AddWithValue("@Id", color.Id);

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

        public void DeleteColor()
        {
            throw new NotImplementedException();
        }

        public void DeleteColor(int id)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(DbConnection.connectionString))
                {
                    string query = "Delete from color where id = @Id";

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

        public Color getColor(int id)
        {
            Color color = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(DbConnection.connectionString))
                {
                    string query = "SELECT * FROM color WHERE id = @Id";

                    SqlCommand command = new SqlCommand(query, connection);

                    // Id da Cor
                    command.Parameters.AddWithValue("@Id", id);

                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                      color = new Color
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

            return color;
        }

    }
}
