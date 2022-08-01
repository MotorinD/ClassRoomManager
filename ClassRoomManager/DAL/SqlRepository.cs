using ClassRoomManager.Additional;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System;
using System.ComponentModel.DataAnnotations;
using ClassRoomManager.Managers;

namespace ClassRoomManager.DAL
{
    public class SqlRepository<TEntity> : IBaseRepository<TEntity>
        where TEntity : new() 
    {
        private SqlConnection _sqlConnection => (SqlConnection)DBConnectionManager.Active.GetConnection();
        public List<TEntity> GetList()
        {
            var res = new List<TEntity>();

            var entityName = typeof(TEntity).Name;
            var sqlCommandText = $"SELECT * FROM {entityName}";
            var cmd = new SqlCommand(sqlCommandText, this._sqlConnection);

            var adapter = new SqlDataAdapter(cmd);
            var ds = new DataSet();
            this.ExecuteCommand(() => adapter.Fill(ds));

            res = ds.Tables[0].ToList<TEntity>();

            return res;
        }

        private void ExecuteCommand(Action action)
        {
            try
            {
                this._sqlConnection.Open();
                action();
            }
            finally
            {
                this._sqlConnection.Close();
            }
        }

        public TEntity Get(int id)
        {
            TEntity res;

            var entityName = typeof(TEntity).Name;
            var sqlCommandText = $"SELECT * FROM {entityName} where Id = {id}";
            var cmd = new SqlCommand(sqlCommandText, this._sqlConnection);

            var adapter = new SqlDataAdapter(cmd);
            var ds = new DataSet();

            this.ExecuteCommand(() => adapter.Fill(ds));

            res = ds.Tables[0].ToList<TEntity>().FirstOrDefault();

            return res;
        }

        public void Add(TEntity entity)
        {
            var entityName = typeof(TEntity).Name;
            var propertyesArr = typeof(TEntity).GetProperties();

            var sqlParamNameArr = new string[propertyesArr.Length];
            var sqlValueNameArr = new string[propertyesArr.Length];

            int? i2 = null;

            for (int i = 0; i < propertyesArr.Length; i++)
            {
                if (Attribute.GetCustomAttribute(propertyesArr[i], typeof(KeyAttribute)) is KeyAttribute)
                {
                    i2 = i;
                    continue;
                }

                sqlParamNameArr[i] = propertyesArr[i].Name;
                sqlValueNameArr[i] = $"@{propertyesArr[i].Name}";
            }

            var sqlParamNameString = this.JoinWithKeyCheck(sqlParamNameArr, ", ", i2);
            var sqlValueNameString = this.JoinWithKeyCheck(sqlValueNameArr, ", ", i2);

            var sqlCommandText = $"INSERT INTO {entityName} ({sqlParamNameString}) values ({sqlValueNameString})";

            var cmd = new SqlCommand(sqlCommandText, this._sqlConnection);

            for (int i = 0; i < propertyesArr.Length; i++)
            {
                if (Attribute.GetCustomAttribute(propertyesArr[i], typeof(KeyAttribute)) is KeyAttribute)
                    continue;

                var property = entity.GetType().GetProperty(sqlParamNameArr[i]);

                if (property is null)
                    cmd.Parameters.AddWithValue(sqlValueNameArr[i], System.DBNull.Value);
                else
                    cmd.Parameters.AddWithValue(sqlValueNameArr[i], property.GetValue(entity));
            }

            this.ExecuteCommand(() => cmd.ExecuteNonQuery());
        }

        private string JoinWithKeyCheck(string[] a2, string a3, int? i2)
        {
            if (i2 is null)
                return string.Join(a3, a2);

            var a1 = new string[a2.Length - 1];
            var j = 0;

            for (var i1 = 0; i1 < a2.Length; i1++)
            {
                if (i1 == i2)
                    continue;

                a1[j] = a2[i1];
                j++;
            }

            return string.Join(a3, a1);
        }

        public void Edit(TEntity entity)
        {
            var entityName = typeof(TEntity).Name;
            var propertyesArr = typeof(TEntity).GetProperties();

            var sqlParamNameArr = new List<string>();
            var sqlValueNameArr = new List<string>();
            var sqlParamWithValueNameArr = new List<string>();

            System.Reflection.PropertyInfo keyProp = null;
            foreach (var property in propertyesArr)
            {
                if (Attribute.GetCustomAttribute(property, typeof(KeyAttribute)) is KeyAttribute)
                {
                    keyProp = property;
                    continue;
                }

                sqlParamNameArr.Add(property.Name);
                sqlValueNameArr.Add($"@{property.Name}");
                sqlParamWithValueNameArr.Add($"{property.Name} = @{property.Name}");
            }

            var sqlParamWithValueNameString = string.Join(", ", sqlParamWithValueNameArr);
            var sqlCommandText = $"UPDATE {entityName} Set {sqlParamWithValueNameString} where {keyProp.Name} = @{keyProp.Name}";
            var cmd = new SqlCommand(sqlCommandText, this._sqlConnection);

            for (int i = 0; i < propertyesArr.Length; i++)
            {
                var property = entity.GetType().GetProperty(propertyesArr[i].Name);

                if (property is null)
                    cmd.Parameters.AddWithValue($"@{propertyesArr[i].Name}", System.DBNull.Value);
                else
                    cmd.Parameters.AddWithValue($"@{propertyesArr[i].Name}", property.GetValue(entity));
            }

            this.ExecuteCommand(() => cmd.ExecuteNonQuery());
        }

        public void Delete(int id)
        {
            var entityName = typeof(TEntity).Name;
            var cmd = new SqlCommand($"Delete from {entityName} where Id = @Id", this._sqlConnection);

            cmd.Parameters.AddWithValue("@Id", id);
            this.ExecuteCommand(() => cmd.ExecuteNonQuery());
        }
    }
}
