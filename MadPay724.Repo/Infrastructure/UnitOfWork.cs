using MadPay724.Repo.Repositories.Interface;
using MadPay724.Repo.Repositories.repo;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MadPay724.Repo.Infrastructure
{
    public class UnitOfWork<TContext> : IUnitOfWork<TContext> where TContext : DbContext, new()
    {
        protected readonly DbContext _db;
        public UnitOfWork()
        {
            _db = new TContext();
        }

        private bool disposed = false;


        private IUserRepository userRepository;
        public IUserRepository UserRepository
        {
            get
            {
                if (userRepository == null)
                {
                    userRepository = new UserRepository(_db);
                }
                return userRepository;
            }
        }


        private IPhotoRepository photoRepository;
        public IPhotoRepository PhotoRepository
        {
            get
            {
                if (photoRepository == null)
                {
                    photoRepository = new PhotoRepository(_db);
                }
                return photoRepository;
            }
        }

        private ISettingRepository settingRepository;
        public ISettingRepository SettingRepository
        {
            get
            {
                if (settingRepository == null)
                {
                    settingRepository = new SettingRepository(_db);
                }
                return settingRepository;
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _db.Dispose();
                }
               
            }
            disposed = true;

        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public bool Save()
        {
            if ( _db.SaveChanges() > 0)
                return true;
            else
                return false;
            
        }

        public async Task<bool> saveAsync()
        {
            if (await _db.SaveChangesAsync() > 0)
                return true;
            else
                return false;
        }

        ~UnitOfWork()
        {
            Dispose(false);
        }
    }
}
