using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Contracts
{
    public interface IUOW : IDisposable
    {
        IUserRepository User { get; }
        IProjectProductRepository ProjectProduct { get; }
        IProjectRepository Project { get; }
        void Commit();
    }
}
