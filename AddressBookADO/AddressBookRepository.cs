using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookADO
{
    public class AddressBookRepository
    {
        private static string connectionString = @"Data Source=(localdb)\ProjectsV13;Initial Catalog=Address_Book_Service;Integrated Security=True";
        SqlConnection connection = new SqlConnection(connectionString);

       
        public void GetAllContacts()
        {
            try
            {
                AddressBookModel model = new AddressBookModel();
                using (this.connection)
                {
                    string query = "Select * from New_Address_Book";
                    SqlCommand command = new SqlCommand(query, this.connection);
                    this.connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            model.ContactId = reader.GetInt32(0);
                            model.FirstName = reader.GetString(1);
                            model.LastName = reader.GetString(2);
                            model.Address = reader.GetString(3);
                            model.City = reader.GetString(4);
                            model.State = reader.GetString(5);
                            model.Zip = reader.GetInt32(6);
                            model.PhoneNumber = reader.GetString(7);
                            model.Email = reader.GetString(8);

                            Console.WriteLine(model.ContactId + "\t" + model.FirstName + "\t" + model.LastName + "\t" + model.Address + "\t"
                                + model.City + "\t" + model.State + "\t" + model.Zip + "\t" + model.PhoneNumber + "\t" + model.Email);

                            Console.WriteLine();
                        }
                    }
                    else
                    {
                        Console.WriteLine("Data Not Found");
                    }
                    reader.Close();
                    this.connection.Close();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                this.connection.Close();
            }
        }


        public bool UpdateContactTable()
        {
            try
            {
                string query = @"update New_Address_Book set Address = 'DollarsColony' , City = 'Nazimabada' where  Id = 3";
                using (this.connection)
                {
                    SqlCommand command = new SqlCommand(query, this.connection);
                    this.connection.Open();
                    int result = command.ExecuteNonQuery();
                    if (result != 0)
                    {
                        return true;
                    }
                    return false;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                this.connection.Close();
            }
        }


        public void RetrieveContactWithinDateRange()
        {
            try
            {
                AddressBookModel model = new AddressBookModel();
                using (this.connection)
                {
                    string query = @"select * from New_Address_Book  
                    where  AddedDate between cast('01-01-2019' as date) and SYSDATETIME();";

                    SqlCommand command = new SqlCommand(query, this.connection);
                    this.connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            model.ContactId = reader.GetInt32(0);
                            model.FirstName = reader.GetString(1);
                            model.LastName = reader.GetString(2);
                            model.Address = reader.GetString(3);
                            model.City = reader.GetString(4);
                            model.State = reader.GetString(5);
                            model.Zip = reader.GetInt32(6);
                            model.PhoneNumber = reader.GetString(7);
                            model.Email = reader.GetString(8);
                            model.AddedDate = reader.GetDateTime(9);

                            Console.WriteLine(model.ContactId + "\t" + model.FirstName + "\t" + model.LastName + "\t" + model.Address + "\t"
                                + model.City + "\t" + model.State + "\t" + model.Zip + "\t" + model.PhoneNumber + "\t" + model.Email + "\t"
                                + model.AddedDate);
                        }
                    }
                    else
                    {
                        Console.WriteLine("No Data Found");
                    }
                    reader.Close();
                    this.connection.Close();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                this.connection.Close();
            }
        }

        public void RetrieveContactByCity()
        {
            try
            {
                AddressBookModel model = new AddressBookModel();
                using (this.connection)
                {
                    string query = @"select * from New_Address_Book where City = 'Bangalore';";

                    SqlCommand command = new SqlCommand(query, this.connection);
                    this.connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            model.ContactId = reader.GetInt32(0);
                            model.FirstName = reader.GetString(1);
                            model.LastName = reader.GetString(2);
                            model.Address = reader.GetString(3);
                            model.City = reader.GetString(4);
                            model.State = reader.GetString(5);
                            model.Zip = reader.GetInt32(6);
                            model.PhoneNumber = reader.GetString(7);
                            model.Email = reader.GetString(8);
                            model.AddedDate = reader.GetDateTime(9);

                            Console.WriteLine(model.ContactId + "\t" + model.FirstName + "\t" + model.LastName + "\t" + model.Address + "\t"
                                + model.City + "\t" + model.State + "\t" + model.Zip + "\t" + model.PhoneNumber + "\t" + model.Email + "\t"
                                + model.AddedDate);
                        }
                    }
                    else
                    {
                        Console.WriteLine("No Data Found");
                    }
                    reader.Close();
                    this.connection.Close();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                this.connection.Close();
            }
        }

    }

}
