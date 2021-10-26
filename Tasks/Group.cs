using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Tasks
{
    class Group<T> :IEnumerable
    {
        public Group()
        {

        }
        private Hashtable table = new();
        public void Add(T o)
        {
            if (table.ContainsKey(o))
            {
                object value = table[o];
                if(value is IList)
                {
                    var list=(IList)value;
                    list.Add(o);
                }
                else
                {
                    IList list = new ArrayList();
                    list.Add(value);
                    list.Add(o);
                }
            }
            else
            {
                table.Add(o, o);
            }

        }
        public bool Remove(T o)
        {
            if (table.ContainsKey(o))
            {
                object value = table[o];
                if(value is IList)
                {
                    var list = (IList)value;
                    if (list.Contains(o))
                    {
                        list.Remove(o);
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    table.Remove(o);
                    return true;
                }
            }
            else
            {
                return false;
            }
        }
        public void Clear()
        {
            table.Clear();
        }
        public delegate void castMethod(T p);
        public void Cast( castMethod method)
        {
            foreach(DictionaryEntry i in table)
            {
                var v = i.Value;
                if (v is IList)
                {
                    var list = (IList)v;
                    foreach(var ii in list)
                    {
                        method((T)ii);
                    }
                }
                else
                {
                    method((T)v);
                }
            }
        }

        public IEnumerator GetEnumerator()
        {
            foreach (DictionaryEntry i in table)
            {
                var v = i.Value;
                if (v is IList)
                {
                    var list = (IList)v;
                    foreach (var ii in list)
                    {
                        yield return((T)ii);
                    }
                }
                else
                {
                    yield return((T)v);
                }
            }
        }
    }
}
