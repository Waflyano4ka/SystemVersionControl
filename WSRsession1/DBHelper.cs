using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;

namespace Session1
{
    static class DBHelper
    {
        public static string connectionString = "Data Source=DESKTOP-DFLG2TQ\\DWORETSKIY;Initial Catalog=Karting;User ID=sa;Password=123456";
        private static SqlConnection connection;
        private static SqlCommand cmd;
        private static DataSet dataSet;
        private static SqlDataAdapter dataAdapter;

        /// <summary>
        /// Посыл запроса в базу данных
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public static string CmdScalar(string command)
        {
            connection = new SqlConnection(connectionString);
            try
            {
                connection.Open();
                cmd = new SqlCommand(command, connection);
                cmd.ExecuteNonQuery();
                if (!command.StartsWith("INSERT") && !command.StartsWith("EXEC") && !command.StartsWith("BACKUP") && !command.StartsWith("USE"))
                {
                    if (cmd.ExecuteScalar() != null) return cmd.ExecuteScalar().ToString();
                    else return null;
                }
                else return null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка");
                return null;
            }
            finally
            {
                connection.Close();
            }
        }

        /// <summary>
        /// Заполняет DataSet данными из запроса
        /// </summary>
        /// <param name="command">Запрос</param>
        /// <param name="dataSet">Заполняемый DataSet</param>
        public static DataSet FillDataSet(string command)
        {
            dataSet = new DataSet();
            connection = new SqlConnection(connectionString);
            try
            {
                connection.Open();
                dataAdapter = new SqlDataAdapter(command, connection);
                dataAdapter.Fill(dataSet);
                return dataSet;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка");
                return null;
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
