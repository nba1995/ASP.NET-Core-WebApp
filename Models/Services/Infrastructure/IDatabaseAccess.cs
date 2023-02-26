using System.Data;

namespace Corsi.Models.Services.Infrastracture
{
    public interface IDatabaseAccess
    {
        DataSet Query(FormattableString query);
    }
}