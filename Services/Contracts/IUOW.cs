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
        IProjectTypeRepositry ProjectType { get; }

        ISphereRepositry Sphere { get; }

        IProjectSphereRepository ProjectSphere { get; }
        IDiscussionRepository Discussion { get; }
        void Commit();
    }
}
