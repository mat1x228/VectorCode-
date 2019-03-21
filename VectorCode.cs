using System;
using System.Collections.Generic;

namespace VectorCode
{
    class Elem
    {
        public int Pos { get; set; }
        public int Value { get; set; }
        public Elem Next { get; set; }

        public override string ToString()
        {
            return $"({Pos};{Value})";
        }
    }

    class VectorCode
    {
        public Elem Head { get; set; }
        public int Length { get; set; }

        public VectorCode() { }
        public VectorCode(int[] arr)
        {
            var temp = Head;
            var elem = new Elem();
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] != 0)
                {
                    elem = new Elem { Pos = i, Value = arr[i] };
                    if (Head == null)
                    {
                        Head = elem;
                        temp = Head;
                        continue;
                    }
                    else
                    {
                        temp.Next = elem;
                        temp = temp.Next;
                    }
                }
            }
            Length = arr.Length;
        }

        public int[] Decode()
        {
            var temp = Head;
            var result = new int[Length];
            while (temp != null)
            {
                result[temp.Pos] = temp.Value;
                temp = temp.Next;
            }
            return result;
        }

        public void Insert(int k, int pos)
        {
            var temp = Head;
            var elem = new Elem { Pos = pos, Value = k };
            if (temp.Pos > pos)//Является ли эл-т первым
            {
                elem.Next = Head;
                Head = elem;
                return;
            }
            while (temp != null)
            {
                if (temp.Next == null)//Является ли эл-т последним
                {
                    temp.Next = elem;
                    return;
                }
                if (pos == temp.Pos)//Есть ли уже эл-т на этой позиции 
                {
                    temp.Value = k;
                    return;
                }
                if (pos > temp.Pos && pos < temp.Next.Pos)//Находится ли эл-т между думя другими
                {
                    elem.Next = temp.Next;
                    temp.Next = elem;
                    return;
                }
                temp = temp.Next;
            }
        }

        public void Delete(int pos)
        {
            var temp = Head;
            if (Head.Pos == pos)//Является ли эл-т первым
            {
                Head = Head.Next;
                return;
            }
            while (temp.Next != null)//Поиск нужного эл-та
            {
                if (temp.Next.Pos == pos)
                {
                    temp.Next = temp.Next.Next;
                    return;
                }
                temp = temp.Next;
            }
        }

        public int ScalarProduct(VectorCode v)
        {
            if (Length != v.Length)//Вектора должны быть одного порядка
                throw new Exception("The lengths of the vectors are different");
            int result = 0;
            var v1 = Decode();
            var v2 = v.Decode();
            for (int i = 0; i < v1.Length; i++)
                result = result + v1[i] * v2[i];
            return result;
        }

        public VectorCode Sum(VectorCode v)
        {
            if (Length != v.Length)//Вектора должны быть одного порядка
                throw new Exception("The lengths of the vectors are different");
            var v1 = Decode();
            var v2 = v.Decode();
            for (int i = 0; i < Length; i++)
                v1[i] += v2[i];
            return new VectorCode(v1);
        }

        public VectorCode VectorSum()
        {
            var result = new int[Length];
            var arr = Decode();
            for (int i = 0; i < Length; i++)
            {
                var sum = 0;
                for (int j = Length - i; j < Length; j++)
                    sum += arr[j];
                result[i] = sum;
            }
            return new VectorCode(result);
        }

        public void Mult(int a, int c)
        {
            var temp = Head;
            while (temp != null)
            {
                if (temp.Value == a)
                    temp.Value *= c;
                temp = temp.Next;
            }
        }
        public override string ToString()
        {
            var el = Head;
            var list = new List<string>();
            while (el != null)
            {
                list.Add(el.ToString());
                el = el.Next;
            }
            return String.Join("\n", list);
        }
    }
}
