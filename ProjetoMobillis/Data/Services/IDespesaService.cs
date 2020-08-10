using ProjetoMobills.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoMobills.Data.Services
{
    interface IAcompanhamentoService
    {
        Task<Despesa> IAcompanhamentoService(Despesa despesa, Receita receita);
    }
}
