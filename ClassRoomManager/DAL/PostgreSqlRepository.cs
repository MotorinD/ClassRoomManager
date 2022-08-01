using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassRoomManager.DAL
{
    public class PostgreSqlRepository<TEntity> : IBaseRepository<TEntity>
    {
        public void Add(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Edit(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public TEntity Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<TEntity> GetList()
        {
            throw new NotImplementedException();
        }
    }
}
