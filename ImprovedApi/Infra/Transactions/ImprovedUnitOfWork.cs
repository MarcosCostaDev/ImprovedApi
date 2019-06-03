using ImprovedApi.Domain.Repositories.Interfaces;
using ImprovedApi.Infra.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ImprovedApi.Infra.Transactions
{
    public class ImprovedUnitOfWork : IImprovedUnitOfWork, IDisposable
    {
        public bool IsDeal { get; private set; } = false;
        private IList<ImprovedDbFirstContext> contexts = new List<ImprovedDbFirstContext>();
        private Dictionary<string, IDbContextTransaction> dbContextTransations = new Dictionary<string, IDbContextTransaction>();

        public void Begin(IImprovedRepository repository)
        {
            Begin(repository.GetContext());
        }

        public void Begin(ImprovedDbFirstContext baseDbContext)
        {
            if (!contexts.Any(p => p.GetType().FullName == baseDbContext.GetType().FullName))
            {
                var conection = dbContextTransations.FirstOrDefault(p => p.Key == baseDbContext.Database.GetDbConnection().ConnectionString);
                if (conection.Value != null)
                {
                    baseDbContext.Database.UseTransaction(conection.Value.GetDbTransaction());
                }
                else
                {
                    dbContextTransations.Add(baseDbContext.Database.GetDbConnection().ConnectionString, baseDbContext.Database.BeginTransaction());
                }
                contexts.Add(baseDbContext);
            }

        }

        public void Commit()
        {
            if (dbContextTransations.Any())
            {
                foreach (var context in contexts)
                {
                    context.SaveChanges();
                }

                foreach (var transation in dbContextTransations)
                {
                    transation.Value.Commit();
                }
                contexts.Clear();
                dbContextTransations.Clear();
            }

        }


        public void Rollback()
        {
            if (dbContextTransations.Any())
            {
                foreach (var transation in dbContextTransations)
                {
                    transation.Value.Rollback();
                }
                contexts.Clear();
                dbContextTransations.Clear();
            }
        }

        public void Dispose()
        {

            if (dbContextTransations.Any())
            {
                foreach (var transation in dbContextTransations)
                {
                    transation.Value.Dispose();
                }
                dbContextTransations.Clear();
                contexts.Clear();
            }

            IsDeal = true;
        }


    }


    public static class ImprovedUnitOfWorkExtension
    {
        public static void IncludeInTrasation(this IImprovedRepository repository, IImprovedUnitOfWork unitOfWork)
        {
            unitOfWork.Begin(repository);
        }

    }

    public interface IImprovedUnitOfWork
    {
        void Begin(ImprovedDbFirstContext baseDbContext);
        void Begin(IImprovedRepository repository);
        void Commit();
        void Rollback();
    }
}
