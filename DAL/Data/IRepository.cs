using System;
using System.Collections.Generic;

namespace DAL.Data
{
  public interface IRepository<T> where T : Entity
  {
    List<T> GetAll();
    T Get(Int64 id);
    T Save(T obj);
  }
}
