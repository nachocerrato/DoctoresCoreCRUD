using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using DoctoresCoreCRUD.Models;

namespace DoctoresCoreCRUD.Data
{
    public class DoctoresContext
    {
        SqlConnection cn;
        SqlCommand com;
        SqlDataReader reader;

        public DoctoresContext(string cadenaconexion)
        {
            this.cn = new SqlConnection(cadenaconexion);
            this.com = new SqlCommand();
            this.com.Connection = this.cn;
            this.com.CommandType = System.Data.CommandType.Text;
        }

        public List<Doctor> GetDoctores()
        {
            String sql = "select * from doctor";
            this.com.CommandText = sql;
            this.cn.Open();
            this.reader = this.com.ExecuteReader();

            List<Doctor> doctores = new List<Doctor>();

            while (this.reader.Read())
            {
                Doctor doctor = new Doctor();
                doctor.Apellido = this.reader["APELLIDO"].ToString();
                doctor.Especialidad = this.reader["ESPECIALIDAD"].ToString();
                doctor.DoctorNo = int.Parse(this.reader["DOCTOR_NO"].ToString());
                doctor.Salario = int.Parse(this.reader["SALARIO"].ToString());

                doctores.Add(doctor);
            }

            this.cn.Close();
            this.reader.Close();

            return doctores;
        }

        public Doctor GetDoctor(int doctorno)
        {
            String sql = "select * from doctor where doctor_no=@doctorno";
            this.com.CommandText = sql;
            SqlParameter pamdoctorno = new SqlParameter("@doctorno", doctorno);
            this.com.Parameters.Add(pamdoctorno);

            this.cn.Open();
            this.reader = this.com.ExecuteReader();

            Doctor doctor = new Doctor();

            this.reader.Read();

            doctor.Apellido = this.reader["APELLIDO"].ToString();
            doctor.Especialidad = this.reader["ESPECIALIDAD"].ToString();
            doctor.DoctorNo = int.Parse(this.reader["DOCTOR_NO"].ToString());
            doctor.Salario = int.Parse(this.reader["SALARIO"].ToString());


            this.cn.Close();
            this.reader.Close();
            this.com.Parameters.Clear();

            return doctor;
        }

        public int InsertDoctor(int doctorno, int salario, string apellido, string especialidad)
        {
            String sql = "insert into doctor values (@doctorno, @salario, @apellido, @especialidad)";
            this.com.CommandText = sql;

            SqlParameter pamdoctorno = new SqlParameter("@doctorno", doctorno);
            SqlParameter pamsalario = new SqlParameter("@salario", salario);
            SqlParameter pamapellido = new SqlParameter("@apellido", apellido);
            SqlParameter pamespecialidad = new SqlParameter("@especialidad", especialidad);

            this.com.Parameters.Add(pamdoctorno);
            this.com.Parameters.Add(pamsalario);
            this.com.Parameters.Add(pamapellido);
            this.com.Parameters.Add(pamespecialidad);

            this.cn.Open();

            this.cn.Close();
            this.com.Parameters.Clear();

            int resultado = this.com.ExecuteNonQuery();

            return resultado;
        }

        public int UpdateDoctor(int doctorno, int salario, string apellido, string especialidad)
        {
            String sql = "update doctor set salario =@salario, " +
                         "apellido =@apellido, especialidad =@especialidad " +
                         "where doctor_no=@doctorno";
            this.com.CommandText = sql;

            SqlParameter pamdoctorno = new SqlParameter("@doctorno", doctorno);
            SqlParameter pamsalario = new SqlParameter("@salario", salario);
            SqlParameter pamapellido = new SqlParameter("@apellido", apellido);
            SqlParameter pamespecialidad = new SqlParameter("@especialidad", especialidad);

            this.com.Parameters.Add(pamdoctorno);
            this.com.Parameters.Add(pamsalario);
            this.com.Parameters.Add(pamapellido);
            this.com.Parameters.Add(pamespecialidad);

            this.cn.Open();

            int resultado = this.com.ExecuteNonQuery();

            this.cn.Close();
            this.com.Parameters.Clear();


            return resultado;
        }

        public int DeleteDoctor(int doctorno)
        {
            String sql = "delete from doctor where doctor_no =@doctorno";
            this.com.CommandText = sql;

            SqlParameter pamdoctorno = new SqlParameter("@doctorno", doctorno);
            this.com.Parameters.Add(pamdoctorno);

            this.cn.Open();

            int resultado = this.com.ExecuteNonQuery();

            this.cn.Close();
            this.com.Parameters.Clear();

            return resultado;
        }
    }
}
