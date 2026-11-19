using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicProgram
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int money = 0, count10 = 0, count5 = 0, count1 = 0, curMoney, i = 0;
            while (true)
            {
                Console.Write("Select your number : ");
                int.TryParse(Console.ReadLine(), out money);
                if (money % 100 == 0 && money != 0 && money >= 100)
                {
                    Console.WriteLine("Your money entry is : {0}", money);
                    break;
                }
                Console.WriteLine("Can't change tr again");
            }
            
            while (money % 100 <= 100)
            {
                curMoney = money;
                if (curMoney >= 1000)
                {
                    count10 = curMoney / 1000;
                    curMoney = curMoney - (count10 * 1000);
                }
                if (curMoney >= 500)
                {
                    count5 = curMoney / 500;
                    curMoney = curMoney - (count5 * 500);
                }
                if (curMoney >= 100)
                {
                    count1 = curMoney / 100;
                    curMoney = curMoney - (count1 * 100);
                }
                Console.Write("Your change 1000 is : {0} | 500 is : {1} | 100 is {2}", count10, count5, count1);
                break;
            }
            
            //แบบง่าย{เฉลย}

        }
    }
}
