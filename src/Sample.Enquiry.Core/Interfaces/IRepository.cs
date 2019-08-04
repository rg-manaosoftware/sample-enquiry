using Sample.Enquiry.Core.SharedKernel;
using System.Collections.Generic;

namespace Sample.Enquiry.Core.Interfaces
{
    public interface IRepository
    {
        T GetById<T>(ulong id) where T : BaseEntity;
        List<T> List<T>() where T : BaseEntity;
        T Add<T>(T entity) where T : BaseEntity;
        void Update<T>(T entity) where T : BaseEntity;
        void Delete<T>(T entity) where T : BaseEntity;
    }
}
