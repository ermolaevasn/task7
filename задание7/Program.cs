using System;
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
            int k;//переменная для обратной индексации в массиве символов из полученного выражения
            int kol = 0;//счетчик элементов <*>
            int n = 0;//для индексации массива пар элементов <*>
            int time =1;//переменная-счетчик для вывода конечных выражений
            bool ok = true;
            Console.WriteLine(@"Введите булевую функцию, состоящую из 0,1 и <*>
Длина должна быть равна степени 2-ки");
            string s = Console.ReadLine();//ввод булевой функции
            Proverka("выражение", ref s);//проверка ввода
            char[] mas = s.ToCharArray();//представление булевой функции в виде массива
            k = s.Length - 1;

            for (int i = 0; i < (s.Length / 2); i++)//проверка на самодвойственность без <*>
            {
                if ((mas[i] != '*') && (mas[k] != '*') && (mas[i] == mas[k])) ok = false;
                k--;
            }
            if (ok == false) Console.WriteLine("Булева функция несамодвойственна");

            //START если длина, явл. степенью двойки и функция без <*> на данный момент самодвойственна

            if (ok == true)//MAIN PROGRAMM
            {
                k = s.Length - 1; //длина выражения
                for (int i = 0; i < (s.Length / 2); i++)
                {
                    if ((mas[i] == '*') && (mas[k] == '*')) kol++; //вычисляем количество парных звездочек                  
                    k--;
                }

                if (kol > 0)//создание массива с номерами пар, где есть пары <*>
                {
                    int[] array = new int[kol];//массив с индексами элементов, у которых пара <*>
                    k = s.Length - 1;

                    for (int i = 0; i < (s.Length / 2); i++)
                    {
                        if ((mas[i] == '*') && (mas[k] == '*'))//заполнение массива
                        {
                            array[n] = i;
                            n++;
                        }
                        k--;
                    }

                    switch(kol)
                    {
                        case 1:
                            k = s.Length - 1;
                            for (int i = 0; i < (s.Length / 2); i++)
                            {
                                if (((mas[i] == '*') || (mas[k] == '*'))&&(i!=array[0]))//проверка символа, <*> или нет
                                {
                                    if (mas[i] == '*')//заполение по принципу самодвойственности
                                    {
                                        if (mas[k] == '1') mas[i] = '0'; else mas[i] = '1';
                                    }
                                    if (mas[k] == '*')
                                    {
                                        if (mas[i] == '1') mas[k] = '0'; else mas[k] = '1';
                                    }
                                    k--;
                                }
                            }
                            for (int i = 48; i < 50; i++)//для 1 пары <*>
                            {                              
                                    mas[array[0]] = (char)i;//комбинируем все возможные варианты
                                    k = s.Length - 1;
                                    for (int m = 0; m < s.Length / 2; m++)
                                    {
                                        if (mas[m] == '0') mas[k] = '1';
                                        else mas[k] = '0';
                                        k--;
                                    }                               
                                    Console.Write(mas);//вывод выражения на экран
                                    Console.WriteLine(" ("+time+")");
                                time++;                      
                            }
                            break;
                        case 2:
                            k = s.Length - 1;
                            for (int i = 0; i < (s.Length / 2); i++)
                            {
                                if ((mas[i] == '*') || (mas[k] == '*')&&((i != array[0]) && (i != array[1])))//проверка символа, <*> или нет
                                {
                                    if (mas[i] == '*')//заполение по принципу самодвойственности
                                    {
                                        if (mas[k] == '1') mas[i] = '0'; else mas[i] = '1';
                                    }
                                    if (mas[k] == '*')
                                    {
                                        if (mas[i] == '1') mas[k] = '0'; else mas[k] = '1';
                                    }
                                    k--;
                                }
                            }
                            for (int i = 48; i < 50; i++)//для 2 пар <*>
                            {
                                for (int j = 48; j < 50; j++)//комбинируем все возможные варианты
                                {
                                    mas[array[0]] = (char)i;
                                    mas[array[1]] = (char)j;
                                    k = s.Length - 1;
                                    for (int m = 0; m < s.Length / 2; m++)
                                    {
                                        if (mas[m] == '0') mas[k] = '1';
                                        else mas[k] = '0';
                                        k--;
                                    }
                                    Console.Write(mas);//вывод выражения на экран
                                    Console.WriteLine(" (" + time + ")");
                                    time++;
                                }
                            }
                            break;
                        case 3:
                            k = s.Length - 1;
                            for (int i = 0; i < (s.Length / 2); i++)
                            {
                                if (((mas[i] == '*') || (mas[k] == '*'))&&((i!=array[0])&&(i != array[1])&&(i != array[2])))//проверка символа, <*> или нет
                                {
                                    if (mas[i] == '*')//заполение по принципу самодвойственности
                                    {
                                        if (mas[k] == '1') mas[i] = '0'; else mas[i] = '1';
                                    }
                                    if (mas[k] == '*')
                                    {
                                        if (mas[i] == '1') mas[k] = '0'; else mas[k] = '1';
                                    }
                                    k--;
                                }
                            }
                            for (int i = 48; i < 50; i++)//для 3 пар <*>
                            {
                                for (int j = 48; j < 50; j++)//комбинируем все возможные варианты
                                {
                                    for (int z = 48; z < 50; z++)
                                    {
                                        mas[array[0]] = (char)i;
                                        mas[array[1]] = (char)j;
                                        mas[array[2]] = (char)z;
                                        k = s.Length - 1;
                                        for (int m = 0; m < s.Length / 2; m++)
                                        {
                                            if (mas[m] == '0') mas[k] = '1';
                                            else mas[k] = '0';
                                            k--;
                                        }
                                        Console.Write(mas);//вывод выражения на экран
                                        Console.WriteLine(" (" + time + ")");
                                        time++;
                                    }
                                }
                            }
                            break;
                        case 4:
                            k = s.Length - 1;
                            for (int i = 0; i < (s.Length / 2); i++)
                            {
                                if (((mas[i] == '*') || (mas[k] == '*')) && ((i != array[0]) && (i != array[1]) && (i != array[2]) && (i != array[3])))//проверка символа, <*> или нет
                                {
                                    if (mas[i] == '*')//заполение по принципу самодвойственности
                                    {
                                        if (mas[k] == '1') mas[i] = '0'; else mas[i] = '1';
                                    }
                                    if (mas[k] == '*')
                                    {
                                        if (mas[i] == '1') mas[k] = '0'; else mas[k] = '1';
                                    }
                                    k--;
                                }
                            }
                            for (int i = 48; i < 50; i++)//для 4 пар <*>
                            {
                                for (int j = 48; j < 50; j++)//комбинируем все возможные варианты
                                {
                                    for (int z = 48; z < 50; z++)
                                    {
                                        for (int y = 48; y < 50; y++)
                                        {
                                            mas[array[0]] = (char)i;
                                            mas[array[1]] = (char)j;
                                            mas[array[2]] = (char)z;
                                            mas[array[3]] = (char)y;
                                            k = s.Length - 1;
                                            for (int m = 0; m < s.Length / 2; m++)
                                            {
                                                if (mas[m] == '0') mas[k] = '1';
                                                else mas[k] = '0';
                                                k--;
                                            }
                                            Console.Write(mas);//вывод выражения на экран
                                            Console.WriteLine(" (" + time + ")");
                                            time++;
                                        }
                                    }
                                }
                            }
                            break;
                    }
                    }

                if (kol == 0)//если в выражение БЕЗ парных <*>
                {
                    k = s.Length - 1;
                    for (int i = 0; i < (s.Length / 2); i++)
                    {
                        if ((mas[i] == '*') || (mas[k] == '*'))//проверка символа, <*> или нет
                        {
                            if (mas[i] == '*')//заполение по принципу самодвойственности
                            {
                                if (mas[k] == '1') mas[i] = '0'; else mas[i] = '1';
                            }
                            if (mas[k] == '*')
                            {
                                if (mas[i] == '1') mas[k] = '0'; else mas[k] = '1';
                            }
                            k--;
                        }
                    }
                    Console.WriteLine(mas);//вывод выражения на экран
                }
            }//END(MAIN)
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
