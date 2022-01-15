using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyEWalletApp.DataAccess.Interface
{
    public interface ICrudRepo
    {
        public Task<bool> Add<T>(T entity);
        public Task<bool> Delete<T>(T entity);
        public Task<bool> Update<T>(T entity);
    }
}
