using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Reflection.Emit;
using System.Text;
using System.IO;
using System.Web.Services.Description;
using System.Windows.Controls;
using System.Web.Security;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Drawing;
using System.Windows;

namespace BookStore
{
    public partial class BookStore : System.Web.UI.Page
    {
        public SqlConnection cnn;
        public SqlCommand cmd;
        StringBuilder StrSb = new StringBuilder();
        SqlDataAdapter da = new SqlDataAdapter();
        public String StrQuery = "";
        public DataTable Dt;
        public string  Strmessage="";
        private LinkButton sender;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                GetConnection();
                if (!Page.IsPostBack)
                {
                    BindData();

                }
            }catch(Exception ex)
            {
                ErrorLog("Page_Load", ex.ToString());
            }

        }
        public void GetConnection()
        {
            try
            {
                String StrConnection = "";
                StrConnection = "Data source=LAPTOP-BDL7RB39;Initial Catalog=BookStore;user id=sa;password=swspg";
                cnn = new SqlConnection(StrConnection);
                cnn.Open();

            }
            catch(Exception ex)
            {
                ErrorLog("GetConnection", ex.ToString());
            }
        }
        protected void Add_onclick(object sender, EventArgs e)
        {
            try
            {
                GetBooksDetails();
               
            }
            catch(Exception ex)
            {
                ErrorLog("Add_onclick", ex.ToString());
            }

        }
        public void BindData()
        {
            try
            {
                StrQuery = "select Bkid,BookName,AuthorName,NoofBooks from BookStore..mstbookstore";
                cmd = new SqlCommand(StrQuery, cnn);
                da = new SqlDataAdapter(cmd);
                Dt = new DataTable();
                da.Fill(Dt);
                if (Dt.Rows.Count > 0)
 {
                    BkStore.DataSource = Dt;
                    BkStore.DataBind();
                }
                else
                {
                    BkStore.DataSource = null;
                }
               
            }
            catch(Exception ex)
            {
                ErrorLog("BindData", ex.ToString());
            }

            
        }
        
        public void GetBooksDetails()
        {
            try
            {
                string Booknameid = Request.Form["BookName"];
                string authorname = Request.Form["Authorid"];
                string Noofbooks = Request.Form["NoBoks"];

                
                StrQuery = "";
                StrQuery = "select * from BookStore..mstbookstore where BookName='" + Booknameid.ToString()+ "' and AuthorName='"+ authorname.ToString ()+"'";
                cmd = new SqlCommand(StrQuery, cnn);
                da = new SqlDataAdapter(cmd);
                Dt = new DataTable();
                da.Fill(Dt);

                if (Dt.Rows.Count > 0)
                {
                    if (Submit.Text != "Delete")
                    {
                        StrQuery = "";
                        StrQuery = "update BookStore..mstbookstore set NoofBooks=" + Noofbooks.ToString() + " where BookName='" + Booknameid.ToString() + "' and AuthorName='" + authorname.ToString() + "' and Bkid="+Dt.Rows [0]["Bkid"].ToString();
                        cmd = new SqlCommand(StrQuery, cnn);
                        cmd.ExecuteNonQuery();
                        Strmessage = "Updated BookStock Successfully";
                        ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + Strmessage + "');", true);
                        BindData();
                        BookName.Text = "";
                        Authorid.Text = "";
                        NoBoks.Text = "";
                    }
                    else
                    {
                        

                        StrQuery = "";
                        StrQuery = "delete BookStore..mstbookstore where Bkid = "+Dt.Rows [0]["Bkid"].ToString();;
                        cmd = new SqlCommand(StrQuery, cnn);
                        cmd.ExecuteNonQuery();
                        Strmessage = "Successfully Deleted";
                        ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + Strmessage + "');", true);
                        BindData();
                        BookName.Text = "";
                        Authorid.Text = "";
                        NoBoks.Text = "";

                    }
                }
                else
                {
                    StrQuery = "";
                    StrQuery = "Insert into BookStore..mstbookstore values('" + Booknameid.ToString() + "','" + authorname.ToString() + "'," + Noofbooks.ToString() + ",getdate())";
                    cmd = new SqlCommand(StrQuery, cnn);
                    cmd.ExecuteNonQuery();
                    Strmessage = "Successfully Inserted BooK details";
                    ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + Strmessage + "');", true);
                    BindData();
                    BookName.Text = "";
                    Authorid.Text = "";
                    NoBoks.Text = "";
                }


            }
            catch(Exception ex)
            {
                ErrorLog("GetBooksDetails", ex.ToString());
            }
        }
       

        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                Submit.Text = "Delete";
                int Book_id = Convert.ToInt32((sender as LinkButton).CommandArgument.ToString());
                StrQuery = "";
                StrQuery = "select * from BookStore..mstbookstore where Bkid=" + Book_id.ToString();
                cmd = new SqlCommand(StrQuery, cnn);
                da = new SqlDataAdapter(cmd);
                Dt = new DataTable();
                da.Fill(Dt);

                if (Dt.Rows.Count > 0)
                {
                    BookName.Text = Dt.Rows[0]["BookName"].ToString();
                    Authorid.Text = Dt.Rows[0]["AuthorName"].ToString();
                    NoBoks.Text = Dt.Rows[0]["NoofBooks"].ToString();
 
                }

            }
            catch (Exception ex)
            {
                ErrorLog("BtnDelete_Click", ex.ToString());
            }

        }

        protected void BookName_TextChanged(object sender, EventArgs e)
        {

        }

        protected void btnUpdate_Click1(object sender, EventArgs e)
        {
            try
            {
                Submit.Text = "Update";
                int Book_id = Convert.ToInt32((sender as LinkButton).CommandArgument.ToString());
                StrQuery = "";
                StrQuery = "select * from BookStore..mstbookstore where BkId=" + Book_id.ToString();
                cmd = new SqlCommand(StrQuery, cnn);
                da = new SqlDataAdapter(cmd);
                Dt = new DataTable();
                da.Fill(Dt);

                if (Dt.Rows.Count > 0)
                {
                    BookName.Text = Dt.Rows[0]["BookName"].ToString();
                    Authorid.Text = Dt.Rows[0]["AuthorName"].ToString();
                    NoBoks.Text = Dt.Rows[0]["NoofBooks"].ToString();
                }


                }
            catch (Exception ex)
            {
                ErrorLog("btnUpdate_Click1", ex.ToString());
            }
        }

        protected void btnclear_Click(object sender, EventArgs e)
        {
            try
            {
                BookName.Text = "";
                Authorid.Text = "";
                NoBoks.Text = "";
            }
            catch(Exception ex)
            {
                ErrorLog("btnclear_Click", ex.ToString());
            }
        }
        private void ErrorLog(string strmsg,string strerror)
        {
            try
            {
                
                string strlog= AppDomain.CurrentDomain.BaseDirectory + "/bin";

                if (!Directory.Exists(strlog + "/Log"))
                {
                    Directory.CreateDirectory(strlog + "/Log");
                }
                string filename = strlog + "/Log" + "-" + DateTime.Now.ToString();
                File.CreateText(filename);
                File.WriteAllText(strlog, strmsg);
            
            }
            catch(Exception ex)
            {

            }
        }
    }
}