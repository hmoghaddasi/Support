using System.Data;
using System.Data.Entity;
using Framework.Core.UnitOfWork;

namespace Framework.EF
{
    public class EfUnitOfWork : IUnitOfWork
    {
        private DbContext _context;

            public EfUnitOfWork(DbContext context)
            {
                this._context = context;
            }

            public void Begin()
            {

                var currentTransaction = _context.Database.CurrentTransaction;
                if (currentTransaction == null)
                    _context.Database.BeginTransaction(IsolationLevel.ReadCommitted);
            }

            public void Commit()
            {
                var currentTransaction = _context.Database.CurrentTransaction;

                if (currentTransaction != null)
                {
                    _context.SaveChanges();
                    _context.Database.CurrentTransaction.Commit();
                }
            }

            public void Rollback()
            {
                if (_context.Database.CurrentTransaction != null)
                    _context.Database.CurrentTransaction.Rollback();
            }
        }

    }
