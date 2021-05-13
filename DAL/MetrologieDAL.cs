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
    class MetrologieDAL
    {
        

        #region Select
        public DataTable Select(SqlConnection conn)
        {
           

            DataTable dt = new DataTable();

            try
            {
                //sql Query
                string sql = "SELECT * FROM Metrologie";

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
        public bool Insert(MetrologieBLL b, SqlConnection conn)
        {
            bool isSuccess = false;
            
            try
            {
                //sql Query
                string sql = "INSERT INTO Metrologie (NrCantar, Serie_indicator, Buletin_metrologic, Clasa_precizie, Tip_cantarire, Tip_cantar) VALUES (@NrCantar, @Serie_indicator, @Buletin_metrologic, @Clasa_precizie, @Tip_cantarire, @Tip_cantar)";

                //sql comand
                SqlCommand cmd = new SqlCommand(sql, conn);

                //param to get value
                cmd.Parameters.AddWithValue("@NrCantar", b.NrCantar);
                cmd.Parameters.AddWithValue("@Serie_indicator", b.Serie_indicator);
                cmd.Parameters.AddWithValue("@Buletin_metrologic", b.Buletin_metrologic);
                cmd.Parameters.AddWithValue("@Clasa_precizie", b.Clasa_precizie);
                cmd.Parameters.AddWithValue("@Tip_cantarire", b.Tip_cantarire);
                cmd.Parameters.AddWithValue("@Tip_cantar", b.Tip_cantar);



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




        /*
        #region UpdateRaport
        public bool Update(MetrologieBLL b, SqlConnection conn,int Id_raport)
        {
            bool isSuccess = false;

            try
            {
                //sql Query
                string sql = "UPDATE Metrologie SET NR_inmatriculare=@NR_inmatriculare, Cod_produs=@Cod_produs, Cod_client=@Cod_client, Cod_furnizor=@Cod_furnizor, Greutate_IN=@Greutate_IN, Greutate_OUT=@Greutate_OUT WHERE ID_raport= '" + Id_raport + "'";

                //sql comand
                SqlCommand cmd = new SqlCommand(sql, conn);

                //param to get value
                cmd.Parameters.AddWithValue("@NR_inmatriculare", r.NR_inmatriculare);
                cmd.Parameters.AddWithValue("@Cod_produs", r.Cod_produs);
                cmd.Parameters.AddWithValue("@Cod_client", r.Cod_client);
                cmd.Parameters.AddWithValue("@Cod_furnizor", r.Cod_furnizor);
                cmd.Parameters.AddWithValue("@Greutate_IN", r.Greutate_IN);
                cmd.Parameters.AddWithValue("@Greutate_OUT", r.Greutate_OUT);
               



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
    */

        #region Delete
        public bool Delete(MetrologieBLL a, SqlConnection conn)
        {

            //set bool var
            bool isSuccess = false;



            try
            {
                //sql Query
                string sql = "DELETE FROM Metrologie  ";

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
