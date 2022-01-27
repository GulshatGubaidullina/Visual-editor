using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOP_Laba_6._5
{
    public class ContainerObserved
    {
        protected Container<TreeObserver> observers;
        public void Add(TreeObserver o)
        {
            if (observers != null)
            {
                observers.Add(o);
            }
            else
            {
                observers = new Container<TreeObserver>();
                observers.Add(o);
            }
        }
        public void Notify()
        {
            for (int i = 0; i < observers.getSize(); i++)
                observers[i].SubjectChanged();
        }
    }
    public class Container<T> : ContainerObserved       //хранилище
    {
        int size = 0;
        private T[] arr;
       
        public Container()
        {
            
            arr = new T[size];

        }
        public T this[int index]
        {

            get
            {
                return arr[index];
            }

            set
            {
                arr[index] = value;
            }

        }
        
        
        public bool IsFull()
        {
            return Count() == arr.Length;
        }
        private int FirstEmptyValue()
        {
            for (int i = 0; i < arr.Length; i++)
                if (arr[i] == null)
                    return i;

            return -1;
        }
        public void Add(T value)
        {
            // if (IsFull())
            // return false;
            if (size == 0)
            {
                size++;
                T[] new_arr = new T[size];
                new_arr[0] = value;
                arr = new_arr;
            }
            else if(size==arr.Length)
            {
                size++;
                T[] new_arr = new T[size];
                for(int i=0; i<arr.Length;i++)
                    new_arr[i] = arr[i];
                new_arr[arr.Length] = value;

                arr = new_arr;
            }
          
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index >= arr.Length)
                throw new Exception();

            if (arr[index] == null)
                throw new Exception();

            T[] new_arr = new T[arr.Length - 1];
            for (int i = 0; i < index; i++)
                new_arr[i] = arr[i];
            for (int i = index + 1; i < arr.Length; i++)
                new_arr[i - 1] = arr[i];
            arr = new_arr;
            size--;

        }
      

        public int Count()//функция, которая возвращает количество непустых ячеек массива
        {
            int result = 0;

            for (int i = 0; i < arr.Length; i++)
                if (arr[i] != null)
                    result += 1;

            return result;
        }

        public int getSize()                           //вернуть размер
        {
            return arr.Length;
        }

        public void Method()
        {
            throw new System.NotImplementedException();
        }
    }

}