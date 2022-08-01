using ClassRoomManager.Additional;
using Npgsql;
using System;
using System.Configuration;
using System.Data.Common;
using System.Data.SqlClient;

namespace ClassRoomManager.Managers
{
    public class DBConnectionManager
    {
        private static DBConnectionManager _active;
        public static DBConnectionManager Active
        {
            get
            {
                if (_active is null)
                    _active = new DBConnectionManager();

                return _active;
            }
            set
            {
                _active = value;
            }
        }

        private string _connectionString;
        private DBTypeEnum? _dbTypeEnum;
        private DbConnection _dbConnection;

        public DBConnectionManager()
        {
            this.ReadAppSettingDbConnectionData();
            this.SetConnectionToDB();
        }

        private void ReadAppSettingDbConnectionData()
        {
            try
            {
                this._connectionString = ConfigurationManager.ConnectionStrings["ClassRoomManager.Properties.Settings.ClassRoomManagerDbConnectionString"].ConnectionString;
                this._dbTypeEnum = (DBTypeEnum)Convert.ToInt32(ConfigurationManager.AppSettings.GetValues("DBType")[0]);
            }
            catch (Exception ex)
            {
                throw new Exception("Error on reading appConfig dbconnection data", ex);
            }
        }

        private void SetConnectionToDB()
        {
            try
            {
                switch (this._dbTypeEnum)
                {
                    case DBTypeEnum.Sql:
                        this.InitMSSqlConnection();
                        break;
                    case DBTypeEnum.PostgreSQL:
                        this.InitPostgreSQLConnection();
                        break;
                    default:
                        throw new Exception("Unknown Data Base Type");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error on Trying Set Connection to DB, Check ConnectionString And DBType in AppConfig", ex);
            }

        }

        public void InitMSSqlConnection()
        {
            this._dbConnection = new SqlConnection(this._connectionString);
        }

        public void InitPostgreSQLConnection()
        {
            this._dbConnection = new NpgsqlConnection(this._connectionString);
        }

        public DbConnection GetConnection()
        {
            return this._dbConnection;
        }

        public DBTypeEnum? GetActiveDBType()
        {
            return this._dbTypeEnum;
        }
    }
}
