namespace TsDataStoreApi.Infra.Persistence;

public interface ITsDataStore
{
    Task<bool> Insert(DateTime dt, string measId, double val);
}
