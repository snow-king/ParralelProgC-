Создание параллельных процессов в операционной системе Linux, Windows
======
Группа А: Выполнить вычисления в однопоточном и многопоточном режиме и сравнить времена выполнения. Количество потоков задаётся пользователем. Количество исходных данных не кратно в общем случае количеству потоков. Исходные данные для задания генерируются с помощью генератора псевдослучайных чисел, где 100000<n<1000000, 100<An<10000000. Результаты сравниваются по времени выполнения при разном числе процессов и объёме данных и оформляются в виде таблицы. В отчёте приводятся снимки экрана, программный код, таблицы тестов и замеров времени выполнения, формулируется вывод. Количество потоков по-умолчанию при необходимости получать из Environment.ProcessorCount.

Задания:
======
1. Даны последовательности чисел А = {а0…аn–1} и С = {с0…сn–1}. Создать многопоточное приложение, определяющее, совпадают ли поэлементно строки А и С. 
2. Дана последовательность чисел С = {с0…сn–1}. Дан набор из N пар кодирующих чисел (ai,bi), т.е. все ai заменяются на  bi. Создать многопоточное приложение, кодирующее последовательность С следующим образом: массив разделяется на подмассивы и каждый поток осуществляет кодирование своего подмассива. 
3. Дана последовательность чисел С = {с0…сn–1} и число b. Создать многопоточное приложение для определения количество вхождений числа b в массив C
4. Дана последовательность натуральных чисел {a0…an–1}. Создать многопоточное приложение для поиска произведения чисел a0*а1*…*an–1. 
5. Дана последовательность натуральных чисел {a0…an–1}. Создать многопоточное приложение для поиска максимального ai.
6. Дана последовательность натуральных чисел {a0…an–1}. Создать многопоточное приложение для поиска всех ai, являющихся простыми числами. 
7. Дана последовательность натуральных чисел {a0…an–1}. Создать многопоточное приложение для поиска всех ai, являющихся квадратами, любого натурального числа
8. Дана последовательность натуральных чисел {a0…an–1}. Создать многопоточное приложение для вычисления выражения a0-а1+a2-а3+a4-а5+...
9. Дана последовательность натуральных чисел {a0…an–1}. Создать многопоточное приложение для вычисления выражения a0-а1+a2-а3+a4-а5+...
10. Дана последовательность натуральных чисел {a0…an–1}. Создать многопоточное приложение для поиска суммы ∑ai, где ai – четные числа
