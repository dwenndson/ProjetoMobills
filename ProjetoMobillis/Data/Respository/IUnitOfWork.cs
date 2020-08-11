using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoMobills.Data.Respository
{
    public interface IUnitOfWork
    {
        IDespesaRepository Despesa { get; }
    }
}
