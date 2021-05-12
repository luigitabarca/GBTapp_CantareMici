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
    class RapoarteDAL
    {
        

        #region SelectTiket
        public DataTable SelectTiket(SqlConnection conn)
        {


            DataTable dt = new DataTable();

            try
            {
                //sql Query
                string sql = "SELECT Numar_bon FROM Rapoarte ";

                //sql comand
                SqlCommand cmd = new SqlCommand(sql, conn);

                //sql adapter

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                //open conection
                conn.Open();

                //transfer data from adapter to table

                adapter.Fill(dt);

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

            return dt;
        }
        #endregion

        #region Insert
        public bool Insert(RapoarteBLL r, SqlConnection conn)
        {
            bool isSuccess = false;
            
            try
            {
                //sql Query
                string sql = "INSERT INTO Rapoarte ( ID_produs, ID_client, ID_furnizor, Greutate_NET, Numar_bon) VALUES ( @ID_produs, @ID_client, @ID_furnizor, @Greutate_NET,  @Numar_bon, )";

                //sql comand
                SqlCommand cmd = new SqlCommand(sql, conn);

                //param to get value
                cmd.Parameters.AddWithValue("@ID_produs", r.Cod_produs);
                cmd.Parameters.AddWithValue("@ID_client", r.Cod_client);
                cmd.Parameters.AddWithValue("@ID_furnizor", r.Cod_furnizor);
                cmd.Parameters.AddWithValue("@Greutate_NET", r.Greutate_NET);
                cmd.Parameters.AddWithValue("@Numar_bon", r.Numar_bon);
               

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
            catch(Exception ex)
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


        #region Custom Select
        public DataTable CustomSelect(SqlConnection conn, int Id_raport)
        {


            DataTable dt = new DataTable();

            try
            {
                //sql Query
                string sql = "SELECT * FROM Rapoarte WHERE ID_raport = '" + Id_raport + "'";

                //sql comand
                SqlCommand cmd = new SqlCommand(sql, conn);

                //sql adapter

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                //open conection
                conn.Open();

                //transfer data from adapter to table

                adapter.Fill(dt);

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

            return dt;
        }
        #endregion

        #region Selectare Istoric
        
        
        public DataTable IstoricSelect(SqlConnection conn, string dataInceput, string dataSfarsit)
        {


         DataTable dt = new DataTable();

        try
        {
            //sql Query
            string sql = "SELECT * FROM Rapoarte WHERE DataTimpO BETWEEN '" + dataInceput + "'AND '" + dataSfarsit + "'";

            //sql comand
            SqlCommand cmd = new SqlCommand(sql, conn);

            //sql adapter

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);

            //open conection
            conn.Open();

            //transfer data from adapter to table

            adapter.Fill(dt);

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

        return dt;
        }

        
        #endregion

        

        
    }
}
