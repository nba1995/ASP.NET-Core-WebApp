using System.Data;

namespace Corsi.Models.Services.Infrastracture
{
    public interface IDatabaseAccess
    {
        Task<DataSet> QueryAsync(FormattableString formattableQuery);   
    }
}