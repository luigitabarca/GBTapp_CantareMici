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
    class ClientiDAL
    {
       

        #region Select
        
        public DataTable Select(SqlConnection conn)
        {
            

            DataTable dt = new DataTable();

            try
            {
                //sql Query
                string sql = "SELECT * FROM Clienti";

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

        public bool Insert(ClientiBLL c, SqlConnection conn)
        {
            //set bool var
            bool isSuccess = false;
          
            try
            {
                //sql Query
                string sql = "INSERT INTO Clienti(ID_Client, Nume, Adresa, Cod_fiscal) VALUES (@ID_client, @Nume, @Adresa, @Cod_fiscal)";

                //sql comand
                SqlCommand cmd = new SqlCommand(sql, conn);

                //param to get value
                cmd.Parameters.AddWithValue("@ID_client", c.ID_client);
                cmd.Parameters.AddWithValue("@Nume", c.Nume);
                cmd.Parameters.AddWithValue("@Adresa", c.Adresa);
                cmd.Parameters.AddWithValue("@Cod_fiscal", c.Cod_fiscal);
                
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
        
        #region Update data in DB
        public bool Update(ClientiBLL c, SqlConnection conn)
        {
            //set bool var
            bool isSuccess = false;


            try
            {
                //sql Query
                string sql = "UPDATE Clienti SET  Nume=@Nume, Adresa=@Adresa, Cod_fiscal=@Cod_fiscal WHERE ID_client=@ID_client ";

                //sql comand
                SqlCommand cmd = new SqlCommand(sql, conn);

                //param to get value
                cmd.Parameters.AddWithValue("@ID_client", c.ID_client);
                cmd.Parameters.AddWithValue("@Nume", c.Nume);
                cmd.Parameters.AddWithValue("@Adresa", c.Adresa);
                cmd.Parameters.AddWithValue("@Cod_fiscal", c.Cod_fiscal);
                
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
        public bool Delete(ClientiBLL c, SqlConnection conn)
        {

            //set bool var
            bool isSuccess = false;



            try
            {
                //sql Query
                string sql = "DELETE FROM Clienti WHERE ID_client=@ID_client ";

                //sql comand
                SqlCommand cmd = new SqlCommand(sql, conn);

                //param to get value
                cmd.Parameters.AddWithValue("@ID_client", c.ID_client);




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
