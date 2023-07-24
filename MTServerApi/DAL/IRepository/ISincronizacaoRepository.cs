using mtvendors_api.Models.DAO;

namespace mtvendors_api.DAL.IRepository
{
    public interface ISincronizacaoRepository
    {
        string GetData(bool databaseFileExists);

        SysConfig? GetSysConfig();
    }
}
