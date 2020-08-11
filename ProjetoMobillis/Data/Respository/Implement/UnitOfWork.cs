using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoMobills.Data.Respository.Implement
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(IDespesaRepository despesaRepository)
        {
            Despesa = despesaRepository;
        }

        public IDespesaRepository Despesa { get; }
    }
}
