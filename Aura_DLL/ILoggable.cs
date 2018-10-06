using System.Data;

namespace Aura.Model
{
    public interface ILoggable
    {
        string LogObjectName { get; }
        string ItemID { get; }
    }
}
