using System.Data;

namespace Aura.Model
{
    public interface ILoggable
    {
        string LogObjectName { get; }
        //строка для запроса логов объекта
        string GetSqlStringForLog();
    }
}
