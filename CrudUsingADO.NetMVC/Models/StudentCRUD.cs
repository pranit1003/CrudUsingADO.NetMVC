using System.Data.SqlClient;

namespace CrudUsingADO.NetMVC.Models
{
    public class StudentCRUD
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        private readonly IConfiguration configuration;

        public StudentCRUD(IConfiguration configuration)
        {
            this.configuration = configuration;
            con = new SqlConnection(this.configuration.GetConnectionString("DefaultConnection"));
        }

        public List<Student> GetallStudents() 
        {
            List<Student> stulist = new List<Student>();
            string qry = "select * from tblStudent where IsActive=1";
            cmd = new SqlCommand(qry, con);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Student stu = new Student();
                    stu.Id = Convert.ToInt32(dr["id"]);
                    stu.Name = dr["Name"].ToString();
                    stu.Mobile = dr["Mobile"].ToString();
                    stu.City = dr["City"].ToString();
                    stu.Email = dr["Email"].ToString();
                    stu.Gender = dr["Gender"].ToString();
                    stu.Marks = Convert.ToDouble(dr["Marks"]);
                    stu.IsActive = Convert.ToInt32(dr["IsActive"]);
                    stulist.Add(stu);
                }
            }
            con.Close();
            return stulist;

        }
        public Student GetStudentbyId(int id) 
        {
            Student stu = new Student();
            string qry = "select * from tblStudent where id=@id";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@id", id);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    stu.Id = Convert.ToInt32(dr["id"]);
                    stu.Name = dr["Name"].ToString();
                    stu.Mobile = dr["Mobile"].ToString();
                    stu.City = dr["City"].ToString();
                    stu.Email = dr["Email"].ToString();
                    stu.Gender = dr["Gender"].ToString();
                    stu.Marks = Convert.ToDouble(dr["Marks"]);
                    stu.IsActive = Convert.ToInt32(dr["IsActive"]);
                }
            }
            con.Close();
            return stu;
        }

        public int AddStudent(Student stu)
        {
            int result = 0;
            stu.IsActive = 1;
            string qry = "insert into tblStudent values(@name,@mobile,@email,@city,@gender,@Marks,@isactive)";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@name", stu.Name);
            cmd.Parameters.AddWithValue("@mobile", stu.Mobile);
            cmd.Parameters.AddWithValue("@email", stu.Email);
            cmd.Parameters.AddWithValue("@city", stu.City);
            cmd.Parameters.AddWithValue("@gender", stu.Gender);
            cmd.Parameters.AddWithValue("@Marks", stu.Marks);
            cmd.Parameters.AddWithValue("@isactive", stu.IsActive);
            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;

        }
        public int UpdateStudent(Student stu)
        {
            int result = 0;
            stu.IsActive = 1;
            string qry = "update tblStudent set Name=@name,Mobile=@mobile,Email=@email,City=@city,Gender=@gender,Marks=@Marks,IsActive=@isactive where id=@id";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@id", stu.Id);
            cmd.Parameters.AddWithValue("@name", stu.Name);
            cmd.Parameters.AddWithValue("@mobile", stu.Mobile);
            cmd.Parameters.AddWithValue("@email", stu.Email);
            cmd.Parameters.AddWithValue("@city", stu.City);
            cmd.Parameters.AddWithValue("@gender", stu.Gender);
            cmd.Parameters.AddWithValue("@Marks", stu.Marks);
            cmd.Parameters.AddWithValue("@isactive", stu.IsActive);
            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }
        public int DeleteStudent(int id)
        {
            int result = 0;
            string qry = "delete from tblStudent where id=@id";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@id", id);
            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }


    }
}

