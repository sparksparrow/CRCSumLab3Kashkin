using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CRCSumLab3Kashkin
{
    public class CRCProcessor
    {
        private readonly int[] polynomeBytes = new int[] { 0, 1, 3, 4, 5, 6, 7, 10, 11, 14, 17, 18, 23, 24 };
        private readonly bool[] balance;

        public CRCProcessor()
        {
            balance = new bool[polynomeBytes.Last()];
        }

        public CRCProcessor(int[] polynomeBytes)
        {
            this.polynomeBytes = polynomeBytes;
            balance = new bool[polynomeBytes.Last()];
        }
        //Получаем случаный список двоичных зачений
        public IList<bool> GetRandomList(int k = 1000)
        {
            IList<bool> resultList = new List<bool>(1000);
            Random rand = new Random();
            for (int i = 0; i < k; i++)
            {
                resultList.Add(rand.Next(2) == 1 ? true : false);
            }
            return resultList;
        }
        //Строим генераторный полином по образующему полиному
        public bool[] BuildPolynome()
        {
            var polynome = new bool[polynomeBytes.Last() + 1];
            for (int i = 0; i < polynomeBytes.Length; i++)
            {
                polynome[polynomeBytes[i]] = true;
            }
            return polynome.Reverse().ToArray();
        }
        //Вычисляем CRC-сумму
        public IEnumerable<bool> GetCRC(IList<bool> message)
        {
            bool[] polynome = BuildPolynome();
            var balancedMessage = new List<bool>(message.Count + balance.Length);
            balancedMessage.AddRange(message);
            balancedMessage.AddRange(balance);

            for (int i = 0; i < message.Count; i++)
            {
                if (balancedMessage[i])
                {
                    for (int k = 0; k < polynome.Length; k++)
                    {
                        balancedMessage[i + k] ^= polynome[k];
                    }
                }
            }

            IEnumerable<bool> CRC = balancedMessage.TakeLast(polynome.Length);
            return CRC;
        }
    }
}
