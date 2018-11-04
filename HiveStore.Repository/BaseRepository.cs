using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace HiveStore.Repository
{
    public abstract class BaseRepository
    {
        private readonly DbContext _dataContext;

        protected BaseRepository(DbContext dataContext)
        {
            _dataContext = dataContext;

        }

        public string SaveChanges()
        {
            var errMsg = string.Empty;
            try
            {
                var result = _dataContext.SaveChanges();

                if (result > 0)
                {
                    return "Success";
                }
            }
            catch (DbUpdateException dbUpdateExceptionEx)
            {
                var err = dbUpdateExceptionEx.InnerException.InnerException.Message;
                errMsg = err.Replace("\r\n", "").Replace("The statement has been terminated.", "");
            }

            return errMsg;
        }

    }
}
