using System;

namespace DAL.Data
{
  public interface IRepository<T>
  {
    T GetAll();
    T Get(Int64 id);
    T Save(T obj);
  }
}
