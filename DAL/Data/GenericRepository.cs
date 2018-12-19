using Models.Bot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.Data
{
  public class GenericRepository<T> : IRepository<T> where T : Entity
  {
    public GenericRepository(BotSqlStorage storage)
    {
      _storage = storage;
    }

    public T Get(long id)
    {
      return _storage.Set<T>().FirstOrDefault(entity => entity.Id == id);
    }

    public List<T> GetAll()
    {
      return _storage.Set<T>().ToList();
    }

    public T Save(T obj)
    {
      _storage.Set<T>().Add(obj);
      _storage.SaveChanges();
      return obj;
    }

    private BotSqlStorage _storage;
  }
}
