namespace TsDataStoreApi.Infra.Persistence;
using Npgsql;

public class TsDataStore : ITsDataStore
{
    private readonly string _connStr;
    public TsDataStore(IConfiguration configuration)
    {
        _connStr = configuration.GetConnectionString("DefaultConnection");
    }
    public async Task<bool> Insert(DateTime dt, string measId, double val)
    {
        // Connect to a PostgreSQL database
        await using NpgsqlConnection conn = new(_connStr);
        await conn.OpenAsync();

        // Define query
        await using var cmd = new NpgsqlCommand(@"INSERT INTO public.meas_ts_data(m_id,m_val,ts) 
        VALUES (@m_id,@m_val,@ts) on conflict (m_id, ts) 
        do update set m_val = excluded.m_val", conn)
        {
            Parameters =
            {
                new("m_id", measId),
                new("m_val", val),
                new("ts", dt)
            }
        };
        int numInserted = await cmd.ExecuteNonQueryAsync();
        if (numInserted == 1)
        {
            return true;
        }
        return false;
    }
}
