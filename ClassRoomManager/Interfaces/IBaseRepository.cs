using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassRoomManager
{
    public interface IBaseRepository<TEntity>
    {
        List<TEntity> GetList();

        TEntity Get(int id);

        void Add(TEntity entity);

        void Edit(TEntity entity);

        void Delete(int id);
    }
}
