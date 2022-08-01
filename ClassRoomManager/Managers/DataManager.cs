using ClassRoomManager.DAL;
using ClassRoomManager.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassRoomManager.Managers
{
    public class DataManager
    {
        private static DataManager _active;
        public static DataManager Active
        {
            get
            {
                if (_active is null)
                    _active = new DataManager();

                return _active;
            }
            set
            {
                _active = value;
            }
        }

        public DataManager()
        {
            var dbType = DBConnectionManager.Active.GetActiveDBType();

            if (dbType is null)
                throw new Exception("Error Init DataManager, Can't get DBType");

            switch (dbType)
            {
                case Additional.DBTypeEnum.Sql:
                    this.InitSqlDataManager();
                    break;
                case Additional.DBTypeEnum.PostgreSQL:
                    this.InitPostgreSqlDataManager();
                    break;
                default:
                    throw new Exception("Unknown DBType");
            }
        }

        private void InitSqlDataManager()
        {
            this.ClassRoom = new SqlRepository<ClassRoom>();
            //this.Building = new SqlRepository<Building>();
        }

        private void InitPostgreSqlDataManager()
        {
            this.ClassRoom = new PostgreSqlRepository<ClassRoom>();
            //this.Building = new PostgreSqlRepository<Building>();
        }

        public IBaseRepository<ClassRoom> ClassRoom { get; set; }
        //public IBaseRepository<Building> Building { get; set; }

    }
}
