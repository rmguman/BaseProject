using Project.DataTier.Model.ORM.Context;
using Project.DataTier.Model.ORM.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Business.Manager.Repository
{
    public class UnitOfWork : IDisposable
    {
        private ProjectContext context = new ProjectContext();
        public UnitOfWork()
        {
            context = new ProjectContext();
        }
        public UnitOfWork(ProjectContext db)
        {
            context = db;
        }

        private GenericRepository<WebUser> webuserrepo;

        public GenericRepository<WebUser> WebUserRepo
        {
            get
            {
                if (this.webuserrepo == null)
                {
                    this.webuserrepo = new GenericRepository<WebUser>(context);
                }
                return webuserrepo;
            }
        }

        private GenericRepository<AdminUser> adminuserrepo;

        public GenericRepository<AdminUser> AdminUserRepo
        {
            get
            {
                if (this.adminuserrepo == null)
                {
                    this.adminuserrepo = new GenericRepository<AdminUser>(context);
                }
                return adminuserrepo;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}
