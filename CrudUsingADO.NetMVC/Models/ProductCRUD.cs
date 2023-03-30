using System.Data.SqlClient;
using System.Drawing;

namespace CrudUsingADO.NetMVC.Models
{
    public class ProductCRUD
    {

        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        private readonly IConfiguration configuration;

        public ProductCRUD(IConfiguration configuration)
        {
            this.configuration = configuration;
            con = new SqlConnection(this.configuration.GetConnectionString("DefaultConnection"));
        }

        public List<Product> GetAllProducts()
        {
            List<Product> prolist = new List<Product>();
            string qry = "select * from tblEmployee where ProductId=@ProductId";
            cmd = new SqlCommand(qry, con);
            con.Open();
            dr = cmd.ExecuteReader();
        }

        if (dr.HasRows)
        {
                while (dr.Read())
                {
                    Product pro = new Product();
        pro.ProductId = Convert.ToInt32(dr["ProductId"]);
        pro.ProductName = dr["ProductName"].ToString();
        pro.ProductComapny = dr["ProductCompany"].ToString();

        pro.ProductPrice = Convert.ToDouble(dr["ProductPrice"]);
                   
        pro.CategoryId = Convert.ToInt32(dr["CategoryId"]);
        prolist.Add(Pro);
                }
         }
        con.Close();
        return prolist;

        }
}
