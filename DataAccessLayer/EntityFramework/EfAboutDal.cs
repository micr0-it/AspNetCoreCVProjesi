using DataAccessLayer.Abstract;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfAboutDal : GenericRepository<About>, IAboutDal
    {
        ///Kalıtımda bulunan GenericRepository<About> yeterli değil mi neden IAbouDal'da ekledik ?
        ///Şimdi generic repositoryde ıgenericrepositoryden kalıtılıyor ve temel crud işlemleri var
        ///Biz IAboutDal'ı kaldırabiliriz bir problem olmaz fakat
        ///İleride sadece About'a özel bir işledm yapılacağı zaman IAboutDal'a eklersek burada onu dolduracağız orada da imzaladıktan sonra burada dolduracağız
    }
}
