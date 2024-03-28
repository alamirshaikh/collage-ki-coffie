using Microsoft.Extensions.Configuration;
using Dapper;
using System.Data.SqlClient;
using collage_ki_coffie.Models;
using collage_ki_coffie.Controllers;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace collage_ki_coffie.Backend;

public class MainEngine : IMainEngine
{
    private IConfiguration _configration;
    private readonly ILogger _logger;

    public MainEngine()
    {
    }

    public MainEngine(IConfiguration configuration, ILogger logger)
    {
        _configration = configuration;
        _logger = logger;
    }
    public async Task Add<T>(T model, string procedure)
    {

        using (var conn = new SqlConnection("Data Source = localhost\\SQLEXPRESS; Initial Catalog = caffe; Integrated Security = True"))
        {
            await conn.ExecuteAsync(procedure, model, commandType: System.Data.CommandType.StoredProcedure);
        }

    }
    public async void AddScrript<T>(string sql)
    {


        using (var conn = new SqlConnection(_configration.GetValue<string>("Default")))
        {
            await conn.ExecuteAsync(sql);
        }

    }



    public async Task<List<T>> GetData<T>(string proceduer)
    {

        using (var conn = new SqlConnection(_configration.GetConnectionString("Default")))
        {
            await conn.OpenAsync();
            var result = await conn.QueryAsync<T>(proceduer, commandType: System.Data.CommandType.StoredProcedure);
            return result.ToList();
        }

    }
     
}
