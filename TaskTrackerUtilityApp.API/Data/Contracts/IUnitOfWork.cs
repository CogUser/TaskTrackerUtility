using System;

namespace TaskTrackerUtilityApp.API.Data
{
    public interface IUnitOfWork : IDisposable
    {
         DataContext Context {get;}
         void Commit();        
    }
}