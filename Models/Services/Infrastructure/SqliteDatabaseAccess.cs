using System.Data;
using Corsi.Models.Services.Infrastracture;
using Microsoft.Data.Sqlite;

namespace Corsi.Models.Services.Infrastructure
{
    // Implemento i meotdi generici utilizzando i specifici metodi del provider
    public class SqliteDatabaseAccess : IDatabaseAccess
    {
        public async Task<DataSet> QueryAsync(FormattableString formattableQuery)
        {
            var queryArguments = formattableQuery.GetArguments();
            var sqlParameters = new List<SqliteParameter>();
            for(var i = 0; i < queryArguments.Length; i++)
            {
                var parameter = new SqliteParameter(i.ToString(),queryArguments[i]);
                sqlParameters.Add(parameter);
                queryArguments[i] = "@" + i;
            }

            string query = formattableQuery.ToString();

            // https://www.connectionstrings.com/
            using(var conn = new SqliteConnection("Data Source=Data/MyCourse.db"))
            {
                await conn.OpenAsync();

                using(var cmd = new SqliteCommand(query,conn))
                {
                    cmd.Parameters.AddRange(sqlParameters);
                    
                    using(var reader = await cmd.ExecuteReaderAsync())
                    {
                        var dataSet = new DataSet();
                        do
                        {
                            var dataTable = new DataTable();                
                            dataSet.Tables.Add(dataTable);
                            dataTable.Load(reader);
                        }while(!reader.IsClosed);
                        
                        return dataSet;
                    }
                }
            }
        }
    }
}