using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Contracts
{
    public interface IUnitOfWork : IDisposable
    {
        //Agregar Los repositorios necesarios
        int Commit();
    }
}
