using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CRCSumLab3Kashkin
{
    public class Message : List<bool>
    {
        //Степени "X" полинома
        private readonly int[] polynomeBytes = new int[] { 0, 1, 3, 4, 5, 6, 7, 10, 11, 14, 17, 18, 23, 24 };
        //Количесво бит для балансировки сообщения
        private readonly bool[] balance;
        //Строим генераторный полином по образующему полиному и возвращаем (Свойство)
        public bool[] Polynome
        {
            get
            {
                var polynome = new bool[GetPolynomialDegree() + 1];
                for (int i = 0; i < polynomeBytes.Length; i++)
                {
                    polynome[polynomeBytes[i]] = true;
                }
                return polynome.Reverse().ToArray();
            }
        }
        //Добавляем к сообщению W количесво бит (нолей) и возвращаем (Свойство)
        public IList<bool> BalanceMessage
        {
            get
            {
                var balancedMessage = new List<bool>(Count + balance.Length);
                balancedMessage.AddRange(this);
                balancedMessage.AddRange(balance);
                return balancedMessage;
            }
        }
        //Получить максимальную степень полинома
        public int GetPolynomialDegree()
        {
            return polynomeBytes.Last();
        }
        //Сгенерировать случайное сообщение
        public Message()
        {
            SetRandomMessage();
            balance = new bool[GetPolynomialDegree()];
        }
        //Задать свое сообщение
        public Message(IList<bool> messageData)
        {
            balance = new bool[GetPolynomialDegree()];
            this.AddRange(messageData);
        }
        //Задать полином и сгенерировать случайное сообщение
        public Message(int[] polynomeBytes)
        {
            this.polynomeBytes = polynomeBytes;
            balance = new bool[GetPolynomialDegree()];
            SetRandomMessage();
        }
        //Задать полином и сообщение
        public Message(int[] polynomeBytes, IList<bool> messageData)
        {
            this.polynomeBytes = polynomeBytes;
            balance = new bool[GetPolynomialDegree()];
            this.AddRange(messageData);
        }
        //Получаем случаный список двоичных зачений
        public void SetRandomMessage(int k = 1000)
        {
            var RandomList = new List<bool>(k);
            Random rand = new Random();
            for (int i = 0; i < k; i++)
            {
                RandomList.Add(rand.Next(2) == 1 ? true : false);
            }
            this.Clear();
            this.AddRange(RandomList);
        }       
    }
}
