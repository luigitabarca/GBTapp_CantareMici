using System;
using GBTapp_CantareMici.BLL;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace GBTapp_CantareMici.DAL
{
    class BonuriDAL
    {
        #region Select

        public DataTable Select(SqlConnection conn)
        {


            DataTable dt = new DataTable();

            try
            {
                //sql Query
                string sql = "SELECT * FROM Bonuri";

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

        public bool Insert(BonuriBLL b, SqlConnection conn)
        {
            //set bool var
            bool isSuccess = false;



            try
            {
                //sql Query
                string sql = "INSERT INTO Bonuri(Primul_bon, Bonuri_printate) VALUES (@Primul_bon, @Bonuri_printate)";

                //sql comand
                SqlCommand cmd = new SqlCommand(sql, conn);

                //param to get value
                cmd.Parameters.AddWithValue("@Primul_bon", b.Primul_bon);
                cmd.Parameters.AddWithValue("@Bonuri_printate", b.Bonuri_printate);




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

        #region Update datain DB
        public bool Update(BonuriBLL b, SqlConnection conn)
        {
            //set bool var
            bool isSuccess = false;


            try
            {
                //sql Query
                string sql = "UPDATE Bonuri SET Primul_bon=@Primul_bon, Bonuri_printate=@Bonuri_printate  ";

                //sql comand
                SqlCommand cmd = new SqlCommand(sql, conn);

                //param to get value
                cmd.Parameters.AddWithValue("@Primul_bon", b.Primul_bon);
                cmd.Parameters.AddWithValue("@Bonuri_printate", b.Bonuri_printate);



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
