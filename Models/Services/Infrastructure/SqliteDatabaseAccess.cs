using System.Data;
using Corsi.Models.Services.Infrastracture;
using Microsoft.Data.Sqlite;

namespace Corsi.Models.Services.Infrastructure
{
    // Implemento i meotdi generici utilizzando i specifici metodi del provider
    public class SqliteDatabaseAccess : IDatabaseAccess
    {
        public DataSet Query(string query)
        {
            // https://www.connectionstrings.com/
            using(var conn = new SqliteConnection("Data Source=Data/MyCourse.db"))
            {
                conn.Open();

                using(var cmd = new SqliteCommand(query,conn))
                {
                    using(var reader = cmd.ExecuteReader())
                    {
                        var dataSet = new DataSet();
                        var dataTable = new DataTable();
                        
                        dataSet.Tables.Add(dataTable);
                        dataTable.Load(reader);

                        return dataSet;
                    }
                }
            }
        }
    }
}