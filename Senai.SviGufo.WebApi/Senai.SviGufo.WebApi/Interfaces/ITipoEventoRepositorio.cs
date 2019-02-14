using Senai.SviGufo.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.SviGufo.WebApi.Interfaces
{
    public interface ITipoEventoRepositorio
    {
        /// <summary>
        /// Lista todos os tipos de eventos
        /// </summary>
        /// <returns>Lista de tipo de evento</returns>
        List<TipoEventoDomain> Listar();

        /// <summary>
        /// Cadastra um tipo de evento
        /// </summary>
        /// <param name="tipoEvento">Objeto do tipo evento domain</param>
        void Cadastrar(TipoEventoDomain tipoEvento);

        void Deletar(int ID);

        void Alterar(TipoEventoDomain tipoEvento);
    }
}
