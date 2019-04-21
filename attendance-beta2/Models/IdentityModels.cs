using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace attendance_beta2.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {

        public DbSet<Faculty> Faculties { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Routine> Routines { get; set; }
        public DbSet<Routine_Student> Routine_Students { get; set; } 
        public DbSet<Semester> semesters { get; set; }
        public DbSet<Semester_Routine> Semester_Routines { get; set; }
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<Student_Course> Student_Courses { get; set; }
        public DbSet<teacher_course> Teacher_Courses { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<attendance_beta2.Models.Attendance> Attendances { get; set; }

        public System.Data.Entity.DbSet<attendance_beta2.Models.Routine> Routines { get; set; }

        public System.Data.Entity.DbSet<attendance_beta2.Models.Student> Students { get; set; }

        public System.Data.Entity.DbSet<attendance_beta2.Models.Course> Courses { get; set; }

        public System.Data.Entity.DbSet<attendance_beta2.Models.Faculty> Faculties { get; set; }

        public System.Data.Entity.DbSet<attendance_beta2.Models.Semester> Semesters { get; set; }

        public System.Data.Entity.DbSet<attendance_beta2.Models.Staff> Staffs { get; set; }

        public System.Data.Entity.DbSet<attendance_beta2.Models.Routine_Student> Routine_Student { get; set; }

        public System.Data.Entity.DbSet<attendance_beta2.Models.Semester_Routine> Semester_Routine { get; set; }

        public System.Data.Entity.DbSet<attendance_beta2.Models.Student_Course> Student_Course { get; set; }

        public System.Data.Entity.DbSet<attendance_beta2.Models.teacher_course> teacher_course { get; set; }

        public void Create(string sql)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);

            SqlCommand cmd = new SqlCommand(sql, con);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
            }
            finally
            {
                con.Close();
            }

        }

        public void Edit(string sql)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);

            SqlCommand cmd = new SqlCommand(sql, con);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
            }
            finally
            {
                con.Close();
            }

        }

        public void Update(string sql)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);

            SqlCommand cmd = new SqlCommand(sql, con);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
            }
            finally
            {
                con.Close();
            }

        }

        public void Delete(string sql)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);

            SqlCommand cmd = new SqlCommand(sql, con);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
            }
            finally
            {
                con.Close();
            }

        }

        public void Find(string sql)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            SqlCommand cmd = new SqlCommand(sql, con);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();


            }
            finally
            {
                con.Close(); 
            }
        }

        public DataTable List(string sql)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            SqlCommand cmd = new SqlCommand(sql, con);

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();


            }
            finally
            {
                con.Close();
            }
            return dt;


        }

    }
}