using System;

namespace TJS.VIMS.DAL
{
    public interface IUnitOfWork : IDisposable
    {
        int Complete();
    }
}