using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace AssetManager
{
    public class FakeDBSet<T> :DbSet<T> where T : class//, IDbSet<T> where T: class
    {
        List<T> _listOfData;
        ObservableCollection<T> _data;
        IQueryable _query;

        public FakeDBSet()
        {
            _data = new ObservableCollection<T>();
        }

        public virtual T Find(params object[] keyValues)
        {
            throw new NotImplementedException("Derive from FakeDbSet<T> and override Find");
        }

        public  T Add(T item)
        {
            _data.Add(item);
            return item;
        }

        public  T Remove(T item)
        {
            _data.Remove(item);
            return item;
        }

        public  T Attach(T item)
        {
            _data.Add(item);
            return item;
        }

        public T Detach(T item)
        {
            _data.Remove(item);
            return item;
        }

        public T Create()
        {
            return Activator.CreateInstance<T>();
        }

        public TDerivedEntity Create<TDerivedEntity>() where TDerivedEntity : class, T
        {
            return Activator.CreateInstance<TDerivedEntity>();
        }

        public ObservableCollection<T> Local
        {
            get { return _data; }
        }

        Type ElementType
        {
            get { return _query.ElementType; }
        }

        System.Linq.Expressions.Expression Expression
        {
            get { return _query.Expression; }
        }

        IQueryProvider Provider
        {
            get { return _query.Provider; }
        }

        IEnumerator<T> GetEnumerator()
        {
            return _data.GetEnumerator();
        }
    }

}
