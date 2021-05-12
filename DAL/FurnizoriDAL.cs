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
    class FurnizoriDAL
    {
       

        #region Select
        
        public DataTable Select(SqlConnection conn)
        {
            

            DataTable dt = new DataTable();

            try
            {
                //sql Query
                string sql = "SELECT * FROM Furnizori";

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

        public bool Insert(FurnizoriBLL f, SqlConnection conn)
        {
            //set bool var
            bool isSuccess = false;


          
            try
            {
                //sql Query
                string sql = "INSERT INTO Furnizori( Nume, Adresa, Cod_fiscal) VALUES (@Nume, @Adresa, @Cod_fiscal)";

                //sql comand
                SqlCommand cmd = new SqlCommand(sql, conn);

                //param to get value
                
                cmd.Parameters.AddWithValue("@Nume", f.Nume);
                cmd.Parameters.AddWithValue("@Adresa", f.Adresa);
                cmd.Parameters.AddWithValue("@Cod_fiscal", f.Cod_fiscal);
                


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
        public bool Update(FurnizoriBLL c, SqlConnection conn)
        {
            //set bool var
            bool isSuccess = false;


            try
            {
                //sql Query
                string sql = "UPDATE Furnizori SET  Nume=@Nume, Adresa=@Adresa, Cod_fiscal=@Cod_fiscal  WHERE ID_furnizor=@ID_furnizor ";

                //sql comand
                SqlCommand cmd = new SqlCommand(sql, conn);

                //param to get value
                cmd.Parameters.AddWithValue("@ID_furnizor", c.ID_furnizor);
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
        public bool Delete(FurnizoriBLL c, SqlConnection conn)
        {

            //set bool var
            bool isSuccess = false;



            try
            {
                //sql Query
                string sql = "DELETE FROM Furnizori WHERE ID_furnizor=@ID_furnizor ";

                //sql comand
                SqlCommand cmd = new SqlCommand(sql, conn);

                //param to get value
                cmd.Parameters.AddWithValue("@ID_furnizor", c.ID_furnizor);




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
