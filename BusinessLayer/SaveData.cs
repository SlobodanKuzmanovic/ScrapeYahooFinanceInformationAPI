using BusinessLayer.Interfaces;
using CommonLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class SaveData : ISaveData
    {
        public bool Save(DatabaseDataModel data)
        {
            string connectionString = "Data Source=DESKTOP-R46BFPQ;Initial Catalog=YahooFinance;User ID=admin;Password=admin";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("InsertHistoryData", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@FullCompanyName", data.fullCompanyName);
                    command.Parameters.AddWithValue("@MarcetCap", data.marcetCap);
                    command.Parameters.AddWithValue("@YearFounded", data.yearFounded);
                    command.Parameters.AddWithValue("@NumberOfEmployees", data.numberOfEmployees);
                    command.Parameters.AddWithValue("@HeadquartersCity", data.headquartersCity);
                    command.Parameters.AddWithValue("@HeadquartersCountry", data.headquartersCountry);
                    command.Parameters.AddWithValue("@DateOfTheData", data.date);
                    command.Parameters.AddWithValue("@ClosePrice", data.closePrice);
                    command.Parameters.AddWithValue("@OpenPrice", data.openPrice);
                    command.Parameters.AddWithValue("@Symbol", data.Symbol);

                    command.ExecuteNonQuery();
                }
            }

            return true;
        }
    }
}
