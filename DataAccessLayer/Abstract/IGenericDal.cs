﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IGenericDal<T> where T : class //IGenericDal bir parametre alacak ve bu parametre T parametresi bir sınıf olacak
    {
        void Insert(T t);
        void Delete(T t);
        void Update(T t);
        List<T> GetList();
        T GetByID(int id);
        List<T> GetListByFilter(Expression<Func<T, bool>> filter);
    }
}
