using DataHandler.Data;
using Microsoft.EntityFrameworkCore;

namespace DataHandler.Services
{
    public class BaseService : IBaseService
    {
        public BaseService()
        {
        }

        public void Add(object value)
        {
            if (value == null) return;

            using (var context = new HomeautomationContext())
            {
                var obj = value as object;
                context.Entry(obj).State = EntityState.Added;

                context.SaveChanges();
            }
        }

        public void Add<T>(List<T> values)
        {
            if (values == null) return;

            using (var context = new HomeautomationContext())
            {
                foreach (var value in values)
                {
                    var obj = value as object;
                    context.Entry(obj).State = EntityState.Added;
                }

                context.SaveChanges();
            }
        }

        public void Delete(object value)
        {
            if (value == null) return;

            using (var context = new HomeautomationContext())
            {
                var obj = value as object;
                context.Entry(obj).State = EntityState.Deleted;

                context.SaveChanges();
            }
        }

        public void Delete<T>(List<T> values)
        {
            if (values == null) return;

            using (var context = new HomeautomationContext())
            {
                foreach (var value in values)
                {
                    var obj = value as object;
                    context.Entry(obj).State = EntityState.Deleted;
                }

                context.SaveChanges();
            }
        }

        public void Save(object value)
        {
            if (value == null) return;

            using (var context = new HomeautomationContext())
            {
                var obj = value as object;
                context.Entry(obj).State = EntityState.Modified;

                context.SaveChanges();
            }
        }

        public void Save<T>(List<T> values)
        {
            if (values == null) return;

            using (var context = new HomeautomationContext())
            {
                foreach (var value in values)
                {
                    var obj = value as object;
                    context.Entry(obj).State = EntityState.Modified;
                }

                context.SaveChanges();
            }
        }
    }
}