using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeTask2
{
    internal class CitizenCollection : IEnumerable
    {
        private Citizen[] citizenArray;

        public CitizenCollection()
        {
            citizenArray = new Citizen[0];
        }
        public Citizen this[int index] { get => citizenArray[index]; set => citizenArray[index] = value; }

        public int Count => citizenArray.Length;

        public int Add(Citizen citizen)
        {
            if(Count == 0)
            {
                Insert(citizen, 0);
                return 1;
            }

            if (Contains(citizen, out int index))
            {
                Console.WriteLine("Такой человек уже есть под номером " + ++index);
                return index;
            }


            if (citizen is Pensioner)
            {
                for (int i = Count - 1; i >= 0; i--)
                    if (this[i] is Pensioner)
                    {
                        Insert(citizen, i + 1);
                        return i + 1;
                    }
                Insert(citizen, 0);
                return 1;
            }


            Insert(citizen, Count);
            return Count + 1;
        }

        public void Insert(Citizen citizen, int index)
        {
            Citizen[] newArray = new Citizen[Count + 1];

            for (int i = 0; i < index; i++)
                newArray[i] = this[i];

            newArray[index] = citizen;

            for (int i = index + 1; i < newArray.Length; i++)
                newArray[i] = this[i - 1];

            citizenArray = newArray;
        }

        public bool Contains(Citizen citizen, out int index)
        {
            index = 0;

            for(int i = 0; i < Count; i++)
                if (citizen == this[i])
                {
                    index = i;
                    return true;
                }

            return false;
        }

        public string ReturnLast()
        {
            return Count + " " + this[Count - 1].ToString();
        }
        public IEnumerator GetEnumerator() => citizenArray.GetEnumerator();

        public override string ToString()
        {
            string collection = "\n";
            for (int i = 0; i < Count; i++)
                collection += $"{i + 1} {this[i]}\n";
            return collection;
        }

        public void Remove(Citizen citizen = null)
        {
            citizen ??= this[0];
            if (Contains(citizen, out int index))
            {
                Citizen[] newArray = new Citizen[Count - 1];

                for(int i = 0; i < index; i++)
                    newArray[i] = this[i];

                for (int i = index; i < newArray.Length; i++)
                    newArray[i] = this[i + 1];

                citizenArray = newArray;
            }

        }
    }
}
