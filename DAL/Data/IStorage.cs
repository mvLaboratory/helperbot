namespace DAL.Data
{
  public interface IStorage
  {
    T ReadAll<T>();

    void Write<T>(T objectForSave);
  }
}
