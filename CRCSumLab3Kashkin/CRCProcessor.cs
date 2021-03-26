using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CRCSumLab3Kashkin
{
    public class CRCProcessor
    {             
        public Message Message { get; private set; }
        //Инициализировать сообщение (Обязательно непустое!)
        public CRCProcessor(Message message)
        {
            SetMessage(message);
        }
        //Установить сообщение (Обязательно непустое!)
        public void SetMessage (Message message)
        {
            if (message == null || !message.Any())
            {
                throw new Exception("No message data");
            }
            else
            {
                Message = message;
            }
        }
        //Вычисляем CRC-сумму
        public IList<bool> GetCRC(IList<bool> message = default)
        {
            //Полином
            bool[] polynome = Message.Polynome.Skip(1).ToArray();
            //Сбалансированное сообщение
            IList<bool> balancedMessage;
            if (message == default)
            {
                balancedMessage = Message.BalanceMessage;
            }
            else
            {
                balancedMessage = message;
            }
            //Степень полинома
            int polynomDegree = Message.GetPolynomialDegree();
            //Имитируем регистр, заполняем его первыми W количеством элементов сообщения
            Queue<bool> register = new Queue<bool>(balancedMessage.Take(polynomDegree));

            for (int i = polynomDegree; i < balancedMessage.Count; i++)
            {
                if (register.Dequeue())
                {
                    register.Enqueue(balancedMessage[i]);
                    IList<bool> tempRegister = new List<bool>(register);
                    for (int k = 0; k < register.Count; k++)
                    {
                        tempRegister[k] ^= polynome[k];
                    }
                    register = new Queue<bool>(tempRegister);
                }
                else
                {
                    register.Enqueue(balancedMessage[i]);
                }
            }

            return register.ToList();
        }

        //Вычисляем CRC-сумму без балансировки сообщения (проверка)
        public IList<bool> CheckCRC(IList<bool> crc)
        {
            List<bool> messageData = Message;
            messageData.AddRange(crc);
            return GetCRC(messageData);
        }
    }
}
