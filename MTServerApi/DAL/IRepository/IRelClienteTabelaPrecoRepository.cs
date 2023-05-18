﻿using mtvendors_api.Models.DAO;
using mtvendors_api.Models.Helpers;
using mtvendors_api.Models.parameters;

namespace mtvendors_api.DAL.IRepository
{
    public interface IRelClienteTabelaPrecoRepository : IDisposable
    {
        void Insert(RelClienteTabelaPreco relacao);

        PagedResult<RelClienteTabelaPreco> Get(RelacaoParameters parameters);

        RelClienteTabelaPreco? GetByKey(RelClienteTabelaPreco relacao);

        void Remove(RelClienteTabelaPreco relacao);

        void Save();
    }
}
