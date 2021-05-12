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
    class ProduseDAL
    {
       

        #region Select
        
        public DataTable Select(SqlConnection conn)
        {
            

            DataTable dt = new DataTable();

            try
            {
                //sql Query
                string sql = "SELECT * FROM Produse";

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

        public bool Insert(ProduseBLL p, SqlConnection conn)
        {
            //set bool var
            bool isSuccess = false;


          
            try
            {
                //sql Query
                string sql = "INSERT INTO Produse(Nume, Natura, Cod, Lot, DataExpirare) VALUES (@Nume, @Natura, @Cod, @Lot, @DataExpirare)";

                //sql comand
                SqlCommand cmd = new SqlCommand(sql, conn);

                //param to get value
                cmd.Parameters.AddWithValue("@Cod",p.Cod);
                cmd.Parameters.AddWithValue("@Natura", p.Natura);
                cmd.Parameters.AddWithValue("@Lot", p.Lot);
                cmd.Parameters.AddWithValue("@DataExpirare", p.DataExpirare);
                cmd.Parameters.AddWithValue("@Nume", p.Nume);

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
        public bool Update(ProduseBLL p, SqlConnection conn)
        {
            //set bool var
            bool isSuccess = false;


            try
            {
                //sql Query
                string sql = "UPDATE Produse SET  Nume=@Nume, Natura=@Natura, Cod=@Cod, Lot=@Lot, DataExpirare=@DataExpirare WHERE ID_produs=@ID_produs ";

                //sql comand
                SqlCommand cmd = new SqlCommand(sql, conn);

                //param to get value
                cmd.Parameters.AddWithValue("@ID_produs", p.ID_produs);
                cmd.Parameters.AddWithValue("@Cod", p.Cod);
                cmd.Parameters.AddWithValue("@Natura", p.Natura);
                cmd.Parameters.AddWithValue("@Lot", p.Lot);
                cmd.Parameters.AddWithValue("@DataExpirare", p.DataExpirare);
                cmd.Parameters.AddWithValue("@Nume", p.Nume);



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
        public bool Delete(ProduseBLL p, SqlConnection conn)
        {

            //set bool var
            bool isSuccess = false;



            try
            {
                //sql Query
                string sql = "DELETE FROM Produse  WHERE ID_produs=@ID_produs ";

                //sql comand
                SqlCommand cmd = new SqlCommand(sql, conn);

                //param to get value
                cmd.Parameters.AddWithValue("@ID_produs", p.ID_produs);




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
