using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{
    public class GenericRepository<T> : IGenericDal<T> where T : class
    {
        public void Delete(T t)
        {
            //Context c1 = new Context();
            using var c = new Context();          
            ///Yukarıda neden using kullandık ?
            ///Using anahtar sözcüğü otomatik olarak dispose metodunu uygular. Yani öge kullanıldıktan hemen sonra bellekten atılacaktır.
            ///Bu işlemin gerçekleşmesi içinm IDisposable interface'i ile kontrat imzalanması gerekir DbContext sınıfıda bu kontrat imzalanır, bizim Context sınıfımızda DbContex'ten kalıtıldı.
            ///Bu kotnart imzalandığı için using anahtar sözcüğünü kullanarak kaynaklar serbest bırakılma işlemi garbage collector'dan devralınır ve işin bitmesi sonucu yıkıcı metot tetiklenir.
            ///Udemy video soru cevaplarından alıntıdır bilgi olması amacıyla yazılmıştır.
        
            c.Remove(t);
            c.SaveChanges(); //db'ye yansıtma işlemi
        }

        //Şartlı Listeleme
        public List<T> GetListByFilter(Expression<Func<T, bool>> filter)
        {
            using var c = new Context();
            return c.Set<T>().Where(filter).ToList();
        }

        public T GetByID(int id)
        {
            using var c = new Context();
            return c.Set<T>().Find(id);
        }

        public List<T> GetList()
        {
            using var c = new Context();
            return c.Set<T>().ToList();
        }

        public void Insert(T t)
        {
            using var c = new Context();
            c.Add(t);
            c.SaveChanges();
        }

        public void Update(T t)
        {
            using var c = new Context();
            c.Update(t);
            c.SaveChanges();
        }
    }
}
