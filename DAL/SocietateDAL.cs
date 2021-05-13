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
    class SocietateDAL
    {
       

        #region Select
        
        public DataTable Select(SqlConnection conn)
        {
            

            DataTable dt = new DataTable();

            try
            {
                //sql Query
                string sql = "SELECT * FROM Societati";

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

        #region Count

        public bool Count(SqlConnection conn)
        {

            bool isSuccess = false;

          
            try
            {
                //sql Query
                string sql = "SELECT count(*) FROM Societati";

                //sql comand
                SqlCommand cmd = new SqlCommand(sql, conn);

                //sql adapter
                conn.Open();
                int a = (Int32) cmd.ExecuteScalar();

              
               

                //transfer data from adapter to table

                if (a == 0)
                {
                    isSuccess = false;
                }
                else
                {
                    isSuccess = true;
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


        #region Insert

        public bool Insert(SocietateBLL s, SqlConnection conn)
        {
            //set bool var
            bool isSuccess = false;


          
            try
            {
                //sql Query
                string sql = "INSERT INTO Societati(Punct_lucru, Societate, Adresa, Cod_fiscal, Cont, Banca, NrRegCom) VALUES (@Punct_lucru, @Societate, @Adresa, @Cod_fiscal, @Cont, @Banca, @NrRegCom)";

                //sql comand
                SqlCommand cmd = new SqlCommand(sql, conn);

                //param to get value
                cmd.Parameters.AddWithValue("@Punct_lucru", s.Punct_lucru);
                cmd.Parameters.AddWithValue("@Societate", s.Societate);
                cmd.Parameters.AddWithValue("@Adresa", s.Adresa);
                cmd.Parameters.AddWithValue("@Cod_fiscal", s.Cod_fiscal);
                cmd.Parameters.AddWithValue("@Cont", s.Cont);
                cmd.Parameters.AddWithValue("@Banca", s.Banca);
                cmd.Parameters.AddWithValue("@NrRegCom", s.NrRegCom);



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
        public bool Update(SocietateBLL s, SqlConnection conn)
        {
            //set bool var
            bool isSuccess = false;


            try
            {
                //sql Query
                string sql = "UPDATE Societati SET Punct_lucru=@Punct_lucru,  Adresa=@Adresa, Cod_fiscal=@Cod_fiscal, Cont=@Cont, Banca=@Banca, NrRegCom=@NrRegCom WHERE Societate=@Societate ";

                //sql comand
                SqlCommand cmd = new SqlCommand(sql, conn);

                //param to get value
                cmd.Parameters.AddWithValue("@Punct_lucru", s.Punct_lucru);
                cmd.Parameters.AddWithValue("@Societate", s.Societate);
                cmd.Parameters.AddWithValue("@Adresa", s.Adresa);
                cmd.Parameters.AddWithValue("@Cod_fiscal", s.Cod_fiscal);
                cmd.Parameters.AddWithValue("@Cont", s.Cont);
                cmd.Parameters.AddWithValue("@Banca", s.Banca);
                cmd.Parameters.AddWithValue("@NrRegCom", s.NrRegCom);



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
        public bool Delete(SocietateBLL a, SqlConnection conn)
        {

            //set bool var
            bool isSuccess = false;



            try
            {
                //sql Query
                string sql = "DELETE FROM Societati  ";

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
