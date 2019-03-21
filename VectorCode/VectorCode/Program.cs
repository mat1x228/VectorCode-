using System;

namespace VectorCode
{
    class Program
    {
        static void Main(string[] args)
        {
            //Cоздание списка ненулевых элементов по массиву arr
            var arr1 = new int[] { 2, 5, 3, 4, 8, 0 };
            var vec1 = new VectorCode(arr1);
            Console.WriteLine(vec1);
            Console.WriteLine();
            var arr2 = new int[] { 4, 0, 3, 0, 4, 9 };
            var vec2 = new VectorCode(arr2);
            Console.WriteLine(vec2);
            Console.WriteLine();

            //Возвратить исходный массив, содержащий нулевые элементы
            var arr = vec1.Decode();
            string arrStr = string.Join(", ", arr);
            Console.WriteLine($"{{ {arrStr} }}");
            Console.WriteLine();

            //Dставка ненулевого элемента k в некоторую позицию pos
            vec1.Insert(2, 1);
            Console.WriteLine(vec1);
            Console.WriteLine();

            //Удаление эл-та из списка
            vec1.Delete(1);
            Console.WriteLine(vec1);
            Console.WriteLine();

            //Нахождение скалярного произведения векторов
            var scalar = vec1.ScalarProduct(vec2);
            Console.WriteLine(scalar);
            Console.WriteLine();

            //Нахождение суммы векторов
            var sum = vec1.Sum(vec2);
            Console.WriteLine(sum);
            Console.WriteLine();

            //Построить новый вектор, i-я компонента которого является суммой
            //последних i компонент исходного вектора
            var vecSum = vec1.VectorSum();
            Console.WriteLine(vecSum);
            Console.WriteLine();

            //Умножение всех элементов, равных а на константу с
            vec2.Mult(4, 2);
            Console.WriteLine(vec2);
        }
    }
}
