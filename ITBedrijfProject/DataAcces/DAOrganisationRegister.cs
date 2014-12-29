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
        //private const string CONNECTIONSTRING = "DefaultConnection";

        public static List<Organisation> GetOrganisations()
        {
            string sql = "SELECT * FROM Organisations";
            DbDataReader reader = Database.GetData(Database.GetConnection("AdminDB"), sql);
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

        public static int InsertOrganisation(Organisation organisation)
        {
            string sql = "INSERT INTO Organisations VALUES(@Login,@Password,@DbName,@DbLogin,@DbPassword,@OrganisationName,@Address,@Email,@Phone)";
            DbParameter par1 = Database.AddParameter("AdminDB", "@Login", organisation.Login);
            DbParameter par2 = Database.AddParameter("AdminDB", "@Password", organisation.Password);
            DbParameter par3 = Database.AddParameter("AdminDB", "@DbName", organisation.DbName);
            DbParameter par4 = Database.AddParameter("AdminDB", "@DbLogin", organisation.DbLogin);
            DbParameter par5 = Database.AddParameter("AdminDB", "@DbPassword", organisation.DbPassword);
            DbParameter par6 = Database.AddParameter("AdminDB", "@OrganisationName", organisation.OrganisationName);
            DbParameter par7 = Database.AddParameter("AdminDB", "@Address", organisation.Address);
            DbParameter par8 = Database.AddParameter("AdminDB", "@Email", organisation.Email);
            DbParameter par9 = Database.AddParameter("AdminDB", "@Phone", organisation.Phone);

            int Id = Database.InsertData(Database.GetConnection("AdminDB"), sql, par1, par2, par3, par4, par5, par6, par7, par8, par9);
            CreateDb.CreateDatabase(organisation);
            return Id;
        }

        public static Organisation GetOrganisationById(int id)
        {
            string sql = "SELECT * FROM Organisations WHERE ID=@ID";
            DbParameter par1 = Database.AddParameter("AdminDB", "@ID", id);
            DbDataReader reader = Database.GetData(Database.GetConnection("AdminDB"), sql, par1);
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
            DbParameter par1 = Database.AddParameter("AdminDB", "@ID", id);
            DbParameter par2 = Database.AddParameter("AdminDB", "@OrganisationName", OrganisationName);
            DbParameter par3 = Database.AddParameter("AdminDB", "@Login", Login);
            DbParameter par4 = Database.AddParameter("AdminDB", "@Password", Password);
            DbParameter par5 = Database.AddParameter("AdminDB", "@DbName", DbName);
            DbParameter par6 = Database.AddParameter("AdminDB", "@DbLogin", DbLogin);
            DbParameter par7 = Database.AddParameter("AdminDB", "@DbPassword", DbPassword);
            DbParameter par8 = Database.AddParameter("AdminDB", "@Address", Address);
            DbParameter par9 = Database.AddParameter("AdminDB", "@Email", Email);
            DbParameter par10 = Database.AddParameter("AdminDB", "@Phone", Phone);

            return Database.ModifyData(Database.GetConnection("AdminDB"), sql, par1, par2, par3, par4, par5, par6, par7, par8, par9, par10);
        }

        public static List<Register> GetRegisters()
        {
            string sql = "SELECT * FROM Registers";
            DbDataReader reader = Database.GetData(Database.GetConnection("AdminDB"), sql);
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
            DbDataReader reader = Database.GetData(Database.GetConnection("AdminDB"), sql);
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
            DbParameter par1 = Database.AddParameter("AdminDB", "@RegisterName", RegisterName);
            DbParameter par2 = Database.AddParameter("AdminDB", "@Device", Device);
            DbParameter par3 = Database.AddParameter("AdminDB", "@PurchaseDate", PurchaseDate);
            DbParameter par4 = Database.AddParameter("AdminDB", "@ExpiresDate", ExpiresDate);


            return Database.InsertData(Database.GetConnection("AdminDB"), sql, par1, par2, par3, par4);
        }

        public static Register GetRegisterById(int id)
        {
            string sql = "SELECT * FROM Registers WHERE ID=@ID";
            DbParameter par1 = Database.AddParameter("AdminDB", "@ID", id);
            DbDataReader reader = Database.GetData(Database.GetConnection("AdminDB"), sql, par1);
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
            DbDataReader reader = Database.GetData(Database.GetConnection("AdminDB"), sql);
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

        public static List<Errorlog> GetLogsById(int id)
        {
            string sql = "SELECT * FROM Errorlog WHERE RegisterID=@ID";
            DbParameter par1 = Database.AddParameter("AdminDB", "@ID", id);
            DbDataReader reader = Database.GetData(Database.GetConnection("AdminDB"), sql, par1);
            List<Errorlog> log = new List<Errorlog>();
            while (reader.Read())
            {
                Errorlog errorlog = new Errorlog();
                errorlog.RegisterID = (int)reader["RegisterID"];
                errorlog.Timestamp = (DateTime)reader["Timestamp"];
                errorlog.Message = reader["Message"].ToString();
                errorlog.Stacktrace = reader["Stacktrace"].ToString();

                log.Add(errorlog);
            }
            return log;
        }

        public static List<OrganisationRegister> GetOrganisationRegisterById(int id)
        {
            string sql = "SELECT Organisations.OrganisationName, Organisations.Login, Organisation_Register.OrganisationID, Registers.RegisterName, Registers.Device, Organisation_Register.RegisterID, Organisation_Register.FromDate, Organisation_Register.UntilDate";
            sql += " FROM Organisation_Register";
            sql += " INNER JOIN Organisations";
            sql += " ON Organisation_Register.OrganisationID=Organisations.ID";
            sql += " INNER JOIN Registers";
            sql += " ON Organisation_Register.RegisterID=Registers.ID";
            sql += " WHERE OrganisationID=@OrganisationID";
            DbParameter par1 = Database.AddParameter("AdminDB", "@OrganisationID", id);
            DbDataReader reader = Database.GetData(Database.GetConnection("AdminDB"), sql, par1);
            List<OrganisationRegister> organisationRegisters = new List<OrganisationRegister>();
            while (reader.Read())
            {
                OrganisationRegister organisationRegister = new OrganisationRegister();
                organisationRegister.OrganisationID = (int)reader["OrganisationID"];
                organisationRegister.RegisterID = (int)reader["RegisterID"];
                organisationRegister.FromDate = (DateTime)reader["FromDate"];
                organisationRegister.UntilDate = (DateTime)reader["UntilDate"];
                organisationRegister.RegisterName = reader["RegisterName"].ToString();
                organisationRegister.OrganisationName = reader["OrganisationName"].ToString();
                organisationRegister.Login = reader["Login"].ToString();
                organisationRegister.Device = reader["Device"].ToString();
                organisationRegisters.Add(organisationRegister);
            }
            return organisationRegisters;
        }

        public static OrganisationRegister GetOrganisationRegisterByIds(int OrganisationID, int RegisterID)
        {
            string sql = "SELECT Organisations.OrganisationName, Organisations.Login, Organisation_Register.OrganisationID, Registers.RegisterName, Registers.Device, Organisation_Register.RegisterID, Organisation_Register.FromDate, Organisation_Register.UntilDate";
            sql += " FROM Organisation_Register";
            sql += " INNER JOIN Organisations";
            sql += " ON Organisation_Register.OrganisationID=Organisations.ID";
            sql += " INNER JOIN Registers";
            sql += " ON Organisation_Register.RegisterID=Registers.ID";
            sql += " WHERE OrganisationID=@OrganisationID AND RegisterID=@RegisterID";
            DbParameter par1 = Database.AddParameter("AdminDB", "@OrganisationID", OrganisationID);
            DbParameter par2 = Database.AddParameter("AdminDB", "@RegisterID", RegisterID);
            DbDataReader reader = Database.GetData(Database.GetConnection("AdminDB"), sql, par1, par2);
            OrganisationRegister organisationRegister = new OrganisationRegister();
            while (reader.Read())
            {
                organisationRegister.OrganisationID = (int)reader["OrganisationID"];
                organisationRegister.RegisterID = (int)reader["RegisterID"];
                organisationRegister.FromDate = (DateTime)reader["FromDate"];
                organisationRegister.UntilDate = (DateTime)reader["UntilDate"];
                organisationRegister.RegisterName = reader["RegisterName"].ToString();
                organisationRegister.OrganisationName = reader["OrganisationName"].ToString();
                organisationRegister.Login = reader["Login"].ToString();
                organisationRegister.Device = reader["Device"].ToString();
            }
            return organisationRegister;
        }

        public static int InsertOrganisationRegister(OrganisationRegister organisationRegister)
        {
            string sql = "INSERT INTO Organisation_Register VALUES(@OrganisationID,@RegisterID,@FromDate,@UntilDate)";
            DbParameter par1 = Database.AddParameter("AdminDB", "@OrganisationID", organisationRegister.OrganisationID);
            DbParameter par2 = Database.AddParameter("AdminDB", "@RegisterID", organisationRegister.RegisterID);
            DbParameter par3 = Database.AddParameter("AdminDB", "@FromDate", organisationRegister.FromDate);
            DbParameter par4 = Database.AddParameter("AdminDB", "@UntilDate", organisationRegister.UntilDate);

            return Database.InsertData(Database.GetConnection("AdminDB"), sql, par1, par2, par3, par4);
        }

        public static int UpdateOrganisationRegister(int oldOrganisationID, OrganisationRegister organisationRegister)
        {
            string sql = "UPDATE Organisation_Register SET OrganisationID=@OrganisationID, RegisterID=@RegisterID, FromDate=@FromDate, UntilDate=@UntilDate WHERE OrganisationID=@OrganisationIDold AND RegisterID=@RegisterID";
            DbParameter par1 = Database.AddParameter("AdminDB", "@OrganisationID", organisationRegister.OrganisationID);
            DbParameter par2 = Database.AddParameter("AdminDB", "@RegisterID", organisationRegister.RegisterID);
            DbParameter par3 = Database.AddParameter("AdminDB", "@FromDate", organisationRegister.FromDate);
            DbParameter par4 = Database.AddParameter("AdminDB", "@UntilDate", organisationRegister.UntilDate);
            DbParameter par5 = Database.AddParameter("AdminDB", "@OrganisationIDold", oldOrganisationID);

            return Database.ModifyData(Database.GetConnection("AdminDB"), sql, par1, par2, par3, par4, par5);
        }
    }
}