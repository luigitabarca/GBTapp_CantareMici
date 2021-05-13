using GBTapp_CantareMici.BLL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GBTapp_CantareMici.DAL
{
    class PortDAL
    {
       

        #region Select
        
        public DataTable Select(SqlConnection conn)
        {
            

            DataTable dt = new DataTable();

            try
            {
                //sql Query
                string sql = "SELECT * FROM Porturi";

                //sql comand
                SqlCommand cmd = new SqlCommand(sql,conn);

                //sql adapter

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                //open conection
                conn.Open();

                //transfer data from adapter to table

                adapter.Fill(dt);

            }
            catch(Exception ex)
            {
                //eror
                MessageBox.Show(ex.Message);

            }
            finally
            {
                conn.Close();
            }

            return dt;
        }
        
        #endregion

        #region Insert

        public bool Insert(PortBLL p, SqlConnection conn)
        {
            //set bool var
            bool isSuccess = false;


          
            try
            {
                //sql Query
                string sql = "INSERT INTO Porturi(Port, Baudrate, Parity, Databits, Stopbits) VALUES (@Port, @Baudrate, @Parity, @Databits, @Stopbits)";

                //sql comand
                SqlCommand cmd = new SqlCommand(sql, conn);

                //param to get value
                cmd.Parameters.AddWithValue("@Port", p.Port);
                cmd.Parameters.AddWithValue("@Baudrate", p.Baudrate);
                cmd.Parameters.AddWithValue("@Parity", p.Parity);
                cmd.Parameters.AddWithValue("@Stopbits", p.Stopbits);
                cmd.Parameters.AddWithValue("@Databits", p.Databits);

                

                //open conection
                conn.Open();

                //var to hold value after quer executed
                int rows = cmd.ExecuteNonQuery();

                if(rows>0)
                {
                    isSuccess = true;

                }
                else
                {
                    isSuccess = false;
                }

            }
            catch (Exception ex)
            {
                //eror
                MessageBox.Show(ex.Message);

            }
            finally
            {
                conn.Close();
            }



            return isSuccess;
        }
        #endregion

        #region Update datain DB
        public bool Update(PortBLL p, SqlConnection conn)
        {
            //set bool var
            bool isSuccess = false;


            try
            {
                //sql Query
                string sql = "UPDATE Porturi SET  Baudrate=@Baudrate, Parity=@Parity, Stopbits=@Stopbits, Databits=@Databits WHERE Port=@Port ";

                //sql comand
                SqlCommand cmd = new SqlCommand(sql, conn);

                //param to get value
                cmd.Parameters.AddWithValue("@Port", p.Port);
                cmd.Parameters.AddWithValue("@Baudrate", p.Baudrate);
                cmd.Parameters.AddWithValue("@Parity", p.Parity);
                cmd.Parameters.AddWithValue("@Stopbits", p.Stopbits);
                cmd.Parameters.AddWithValue("@Databits", p.Databits);



                //open conection
                conn.Open();

                //var to hold value after quer executed
                int rows = cmd.ExecuteNonQuery();

                if (rows > 0)
                {
                    isSuccess = true;

                }
                else
                {
                    isSuccess = false;
                }

            }
            catch (Exception ex)
            {
                //eror
                MessageBox.Show(ex.Message);

            }
            finally
            {
                conn.Close();
            }



            return isSuccess;
        }

        #endregion

        #region Delete
        public bool Delete(PortBLL b, SqlConnection conn)
        {

            //set bool var
            bool isSuccess = false;



            try
            {
                //sql Query
                string sql = "DELETE FROM Porturi  ";

                //sql comand
                SqlCommand cmd = new SqlCommand(sql, conn);

                //param to get value
               
              



                //open conection
                conn.Open();

                //var to hold value after quer executed
                int rows = cmd.ExecuteNonQuery();

                if (rows > 0)
                {
                    isSuccess = true;

                }
                else
                {
                    isSuccess = false;
                }

            }
            catch (Exception ex)
            {
                //eror
                MessageBox.Show(ex.Message);

            }
            finally
            {
                conn.Close();
            }



            return isSuccess;
        }

        #endregion
    }
}
