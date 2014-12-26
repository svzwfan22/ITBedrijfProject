using ITBedrijfProject.Models;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Web;

namespace ITBedrijfProject.DataAcces
{
    public class DAOrganisationRegister
    {
        private const string CONNECTIONSTRING = "DefaultConnection";

        public static List<Organisation> GetOrganisations()
        {
            string sql = "SELECT * FROM Organisations";
            DbDataReader reader = Database.GetData(CONNECTIONSTRING, sql);
            List<Organisation> Organisations = new List<Organisation>();
            while (reader.Read())
            {
                Organisation organisation = new Organisation();
                organisation.Id = (int)reader["ID"];
                organisation.Login = reader["Login"].ToString();
                organisation.Password = reader["Password"].ToString();
                organisation.DbName = reader["DbName"].ToString();
                organisation.DbLogin = reader["DbLogin"].ToString();
                organisation.DbPassword = reader["DbPassword"].ToString();
                organisation.OrganisationName = reader["OrganisationName"].ToString();
                organisation.Address = reader["Address"].ToString();
                organisation.Email = reader["Email"].ToString();
                organisation.Phone = reader["Phone"].ToString();

                Organisations.Add(organisation);
            }
            return Organisations;
        }

        public static int InsertOrganisation(string Login, string Password, string DbName, string DbLogin, string DbPassword, string OrganisationName, string Address, string Email, string Phone)
        {
            string sql = "INSERT INTO Organisations VALUES(@Login,@Password,@DbName,@DbLogin,@DbPassword,@OrganisationName,@Address,@Email,@Phone)";
            DbParameter par1 = Database.AddParameter(CONNECTIONSTRING, "@Login", Login);
            DbParameter par2 = Database.AddParameter(CONNECTIONSTRING, "@Password", Password);
            DbParameter par3 = Database.AddParameter(CONNECTIONSTRING, "@DbName", DbName);
            DbParameter par4 = Database.AddParameter(CONNECTIONSTRING, "@DbLogin", DbLogin);
            DbParameter par5 = Database.AddParameter(CONNECTIONSTRING, "@DbPassword", DbPassword);
            DbParameter par6 = Database.AddParameter(CONNECTIONSTRING, "@OrganisationName", OrganisationName);
            DbParameter par7 = Database.AddParameter(CONNECTIONSTRING, "@Address", Address);
            DbParameter par8 = Database.AddParameter(CONNECTIONSTRING, "@Email", Email);
            DbParameter par9 = Database.AddParameter(CONNECTIONSTRING, "@Phone", Phone);

            return Database.InsertData(CONNECTIONSTRING, sql, par1, par2, par3, par4, par5, par6, par7, par8, par9);
        }

        public static Organisation GetOrganisationById(int id)
        {
            string sql = "SELECT * FROM Organisations WHERE ID=@ID";
            DbParameter par1 = Database.AddParameter(CONNECTIONSTRING, "@ID", id);
            DbDataReader reader = Database.GetData(CONNECTIONSTRING, sql, par1);
            Organisation organisation = new Organisation();
            while (reader.Read())
            {
                organisation.Id = (int)reader["ID"];
                organisation.Login = reader["Login"].ToString();
                organisation.Password = reader["Password"].ToString();
                organisation.DbName = reader["DbName"].ToString();
                organisation.DbLogin = reader["DbLogin"].ToString();
                organisation.DbPassword = reader["DbPassword"].ToString();
                organisation.OrganisationName = reader["OrganisationName"].ToString();
                organisation.Address = reader["Address"].ToString();
                organisation.Email = reader["Email"].ToString();
                organisation.Phone = reader["Phone"].ToString();
            }
            return organisation;
        }

        public static int UpdateOrganisation(int id, string Login, string Password, string DbName, string DbLogin, string DbPassword, string OrganisationName, string Address, string Email, string Phone)
        {
            string sql = "UPDATE Organisations SET OrganisationName=@OrganisationName, Login=@Login, Password=@Password, DbName=@DbName, DbLogin=@DbLogin, DbPassword=@DbPassword, Address=@Address, Email=@Email, Phone=@Phone WHERE ID=@ID";
            DbParameter par1 = Database.AddParameter(CONNECTIONSTRING, "@ID", id);
            DbParameter par2 = Database.AddParameter(CONNECTIONSTRING, "@OrganisationName", OrganisationName);
            DbParameter par3 = Database.AddParameter(CONNECTIONSTRING, "@Login", Login);
            DbParameter par4 = Database.AddParameter(CONNECTIONSTRING, "@Password", Password);
            DbParameter par5 = Database.AddParameter(CONNECTIONSTRING, "@DbName", DbName);
            DbParameter par6 = Database.AddParameter(CONNECTIONSTRING, "@DbLogin", DbLogin);
            DbParameter par7 = Database.AddParameter(CONNECTIONSTRING, "@DbPassword", DbPassword);
            DbParameter par8 = Database.AddParameter(CONNECTIONSTRING, "@Address", Address);
            DbParameter par9 = Database.AddParameter(CONNECTIONSTRING, "@Email", Email);
            DbParameter par10 = Database.AddParameter(CONNECTIONSTRING, "@Phone", Phone);

            return Database.ModifyData(CONNECTIONSTRING, sql, par1, par2, par3, par4, par5, par6, par7, par8, par9, par10);
        }

        public static List<Register> GetRegisters()
        {
            string sql = "SELECT * FROM Registers";
            DbDataReader reader = Database.GetData(CONNECTIONSTRING, sql);
            List<Register> Registers = new List<Register>();
            while (reader.Read())
            {
                Register register = new Register();
                register.Id = (int)reader["ID"];
                register.RegisterName = reader["RegisterName"].ToString();
                register.Device = reader["Device"].ToString();
                register.PurchaseDate = (DateTime)reader["PurchaseDate"];
                register.ExpiresDate = (DateTime)reader["ExpiresDate"];
              

                Registers.Add(register);
            }
            return Registers;
        }

        public static List<OrganisationRegister> GetOrganisationRegisters()
        {
            string sql = "SELECT * FROM Organisation_Register";
            DbDataReader reader = Database.GetData(CONNECTIONSTRING, sql);
            List<OrganisationRegister> OrganisationRegisters = new List<OrganisationRegister>();
            while (reader.Read())
            {
                OrganisationRegister organisationregister = new OrganisationRegister();
                organisationregister.OrganisationID = (int)reader["OrganisationID"];
                organisationregister.RegisterID = (int)reader["RegisterID"];
                organisationregister.FromDate = (DateTime)reader["FromDate"];
                organisationregister.UntilDate = (DateTime)reader["UntilDate"];


                OrganisationRegisters.Add(organisationregister);
            }
            return OrganisationRegisters;
        }


        internal static int InsertRegister(string RegisterName, string Device, DateTime PurchaseDate, DateTime ExpiresDate)
        {
            string sql = "INSERT INTO Registers VALUES(@RegisterName,@Device,@PurchaseDate,@ExpiresDate)";
            DbParameter par1 = Database.AddParameter(CONNECTIONSTRING, "@RegisterName", RegisterName);
            DbParameter par2 = Database.AddParameter(CONNECTIONSTRING, "@Device", Device);
            DbParameter par3 = Database.AddParameter(CONNECTIONSTRING, "@PurchaseDate", PurchaseDate);
            DbParameter par4 = Database.AddParameter(CONNECTIONSTRING, "@ExpiresDate", ExpiresDate);
            

            return Database.InsertData(CONNECTIONSTRING, sql, par1, par2, par3, par4);
        }

        public static Register GetRegisterById(int id)
        {
            string sql = "SELECT * FROM Registers WHERE ID=@ID";
            DbParameter par1 = Database.AddParameter(CONNECTIONSTRING, "@ID", id);
            DbDataReader reader = Database.GetData(CONNECTIONSTRING, sql, par1);
            Register register = new Register();
            while (reader.Read())
            {
                register.Id = (int)reader["ID"];
                register.RegisterName = reader["RegisterName"].ToString();
                register.Device = reader["Device"].ToString();
                register.PurchaseDate = (DateTime)reader["PurchaseDate"];
                register.ExpiresDate = (DateTime)reader["ExpiresDate"];
               
            }
            return register;
        }

        public static List<Errorlog> GetErrorlog()
        {
            string sql = "SELECT * FROM Errorlog";
            DbDataReader reader = Database.GetData(CONNECTIONSTRING, sql);
            List<Errorlog> Errorlog = new List<Errorlog>();
            while (reader.Read())
            {
                Errorlog errorlog = new Errorlog();
                errorlog.RegisterID = (int)reader["RegisterID"];
                errorlog.Timestamp = (DateTime)reader["Timestamp"];
                errorlog.Message = reader["Message"].ToString();
                errorlog.Stacktrace = reader["Stacktrace"].ToString();


                Errorlog.Add(errorlog);
            }
            return Errorlog;
        }
    }
}