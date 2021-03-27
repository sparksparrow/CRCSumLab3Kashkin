using System;
using System.Collections.Generic;
using System.Linq;

namespace CRCSumLab3Kashkin
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Создаём случайное сообщение
            Message message = new Message();
            //Создаем CRC-обработчик
            CRCProcessor crcProcessor = new CRCProcessor(message);
            //Выводим полином
            Console.WriteLine("Полином: ");
            Array.ForEach(message.Polynome,x => Console.Write(Convert.ToInt32(x)));
            //Выводим исходное сообщение
            Console.WriteLine($"\nИсходное сообщение ({message.Count} элементов):");
            message.ForEach(x => Console.Write(Convert.ToInt32(x))) ;
            //Получаем и выводим CRC-сумму
            var CRC = crcProcessor.GetCRC() as List<bool>;
            Console.WriteLine("\nCRC-сумма:");
            CRC.ForEach(x => Console.Write(Convert.ToInt32(x)));
            //Получаем и выводим регистр после проверки CRC
            var CheckCRC = crcProcessor.CheckCRC(CRC.ToList()) as List<bool>;
            Console.WriteLine("\nПроверка сообщения:");
            CheckCRC.ForEach(x => Console.Write(Convert.ToInt32(x)));

        }
    }
}
