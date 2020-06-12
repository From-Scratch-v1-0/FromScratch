using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Contracts
{
    public interface IUOW : IDisposable
    {
        IUserRepository User { get; }
        IProjectRepository ProjectProduct { get; }
        void Commit();
    }
}
