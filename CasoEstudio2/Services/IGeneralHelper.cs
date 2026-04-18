using System.Data;

namespace CasoEstudio2.Services
{
    public interface IGeneralHelper
    {
        public IDbConnection CreateConnection();
    }
}
