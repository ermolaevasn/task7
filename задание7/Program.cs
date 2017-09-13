﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace задание7
{
    class Program
    {
        static void Main(string[] args)
        {
            int k,kol=0;
            bool ok = true;
            Console.WriteLine(@"Введите булевую функцию, состоящую из 0,1 и *
Длина должна быть равна степени 2-ки");
            string s = Console.ReadLine();//ввод булевой функции
            Proverka("выражение", ref s);
            char[] mas = s.ToCharArray();//представление булевой функции в виде массива
            int[] array = new int[s.Length/2];
            k = s.Length - 1;

            for (int i = 0; i < (s.Length / 2); i++)//проверка на самодвойственность без *
            {
                if ((mas[i] != '*') && (mas[k] != '*') && (mas[i] == mas[k])) ok = false;
                k--;
            }
            if (ok == false) Console.WriteLine("Булева функция несамодвойственна");

            if (ok == true)//основной цикл
            {
                for (int i = 0; i < (s.Length / 2); i++)
                {
                    if ((mas[i] == '*') && (mas[k] == '*'))
                    {
                        array[i] = 1;
                        kol++;
                    }
                    if (array[i] == 0)
                    {
                        if ((mas[i] == '*') || (mas[k] == '*'))
                        {
                            if (mas[i] == '*')
                            {
                                if (mas[k] == '1') mas[i] = '0';
                                else mas[i] = '1';
                            }
                            if (mas[k] == '*')
                            {
                                if (mas[i] == '1') mas[k] = '0';
                                else mas[k] = '1';
                            }

                        }
                    }
                    k--;
                }
            }

            if (kol > 0)
            {
                k = s.Length - 1;
                for (int j = 0; j < Math.Pow(2, kol); j++)
                {
                    for (int i = 0; i < (s.Length / 2); i++)
                    {
                        if (array[i]==1)
                        {
                            mas[i] = '0';
                            mas[k] = '1';
                        }
                        k--;
                    }
                }
            }

                Console.WriteLine(mas);
            Console.ReadKey();
        }
        static void Proverka(string s, ref string a)//проверка ввода булевой функции
        {
            bool ok = false;
            do
            {
                int kol = 0,coin;
                char[] array = a.ToCharArray();
                for (int i = 0; i < a.Length; i++)
                {
                    if ((array[i] == '1') || (array[i] == '0') || (array[i] == '*')) kol++;
                }
                coin = a.Length;
                if ((kol == a.Length)&&((coin == 2) || (coin == 4)||(coin == 8) || (coin == 16))) ok = true;                
                else
                {
                    if (!ok) Console.WriteLine("\aВведите " + s + " заново");
                    Console.Write(s + " = ");
                    a = Console.ReadLine();
                    ok = false;
                }
            } while (!ok);
        }
    }
}
