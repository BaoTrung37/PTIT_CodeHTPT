using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CovertDate
{
    class NTP
    {
        static void Main(string[] args)
        {
            byte[] bytes = {
                28,03,00,233,00,00,00,114,
                00,00,12,160,25,66,230,04,
                225,72,40,195,105,242,38,249,
                00,00,00,00,00,00,00,00,
                225,72,40,208,41,242,12,33,
                225,72,40,208,41,242,52,101
            };
            String FormatDate = "dd/MM/yyyy HH:mm:ss.fff";

            byte Position = 16;
            DateTime t1 = convertToDate(bytes, Position).ToLocalTime();
            Position = 32;
            DateTime t2 = convertToDate(bytes, Position).ToLocalTime();
            Position = 40;
            DateTime t3 = convertToDate(bytes, Position).ToLocalTime();
            DateTime t4 = new DateTime(2019, 10, 09, 16, 37, 29, 229);// cai nay la de bai cho, ae doc ki lai de bai
            
            long tick = ((t2.Ticks - t1.Ticks) + (t3.Ticks - t4.Ticks)) / 2;
            Console.WriteLine("T1: " + t1.ToString(FormatDate));
            Console.WriteLine("T2: " + t2.ToString(FormatDate));
            Console.WriteLine("T3: " + t3.ToString(FormatDate));
            Console.WriteLine("T4: " + t4.ToString(FormatDate));
            Console.WriteLine("Do lech thoi gian: " + tick);
            Console.WriteLine("Thoi gian moi cho may khach: " + t4.AddTicks(tick).ToString(FormatDate));
            Console.ReadKey();
        }

        static DateTime convertToDate(byte[] bytes, byte Position) {
            DateTime dt = new DateTime(1900,1,1,0,0,0,DateTimeKind.Utc);
            byte[] array = new byte[4];
            //for (int i = 0; i < 4; i++)
            //{
            //    array[i] = bytes[Position + i];
            //}
            Array.Copy(bytes, Position, array, 0, 4);
            Array.Reverse(array);
            ulong nguyen = BitConverter.ToUInt32(array, 0);

            for (int i = 0; i < 4; i++)
            {
                array[i] = bytes[Position + i + 4];
            }
            Array.Reverse(array);
            ulong du = BitConverter.ToUInt32(array, 0);

            ulong milisecond = nguyen * 1000 + (du * 1000) / UInt32.MaxValue;
            dt = dt.AddMilliseconds(milisecond);
            return dt;
        }
    }
}