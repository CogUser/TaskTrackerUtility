using System.Threading;
using System;
namespace TaskTrackerUtilityApp.API.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        public DataContext Context {get;}

        public UnitOfWork(DataContext context)
        {
            Context = context;
        }   

        public void Commit()
        {
            Context.SaveChanges();
        }

        public void Dispose()
        {
            Context.Dispose();
        }

    }
}