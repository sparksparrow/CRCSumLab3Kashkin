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
            //Выводим исходное сообщение
            Console.WriteLine("Исходное сообщение:");
            message.ForEach(x => Console.Write(Convert.ToInt32(x))) ;
            //Получаем и выводим CRC-сумму
            List<bool> CRC = crcProcessor.GetCRC() as List<bool>;
            Console.WriteLine("\nCRC-сумма:");
            CRC.ForEach(x => Console.Write(Convert.ToInt32(x)));
            //Получаем и выводим регистр после проверки CRC
            List<bool> CheckCRC = crcProcessor.CheckCRC(CRC.ToList()) as List<bool>;
            Console.WriteLine("\nПроверка сообщения:");
            CheckCRC.ForEach(x => Console.Write(Convert.ToInt32(x)));

        }
    }
}
