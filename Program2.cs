using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CovertDate
{
    class Program2
    {
        static void Main(){
            byte[] bytes = {
                28,03,00,233,00,00,00,114,
                00,00,12,160,25,66,230,04,
                225,72,40,195,105,242,38,249,
                00,00,00,00,00,00,00,00,
                225,72,40,208,41,242,12,33,
                225,72,40,208,41,242,52,101
            };
            string formatDate = "yyyy:MM:dd HH:mm:ss.fff";

            byte position = 16;
            DateTime T1 = ConverToTime(bytes,position).ToLocalTime();
            position = 32;
            DateTime T2 = ConverToTime(bytes,position).ToLocalTime();
            position = 40;
            DateTime T3 = ConverToTime(bytes,position).ToLocalTime();
            DateTime T4 = new DateTime(2019,10,09,16,37,29,229);

            long ticks = ((T2.Ticks - T1.Ticks) + (T3.Ticks - T4.Ticks)) / 2;
            Console.WriteLine("T1 :" + T1.ToString(formatDate));
            Console.WriteLine("T2 :" + T2.ToString(formatDate));
            Console.WriteLine("T3 :" + T3.ToString(formatDate));
            Console.WriteLine("T4 :" + T4.ToString(formatDate));
            Console.WriteLine("Lech :" + ticks);
            Console.WriteLine("T4 :" + T4.AddTicks(ticks).ToString(formatDate));
            Console.ReadKey();
            
            
        }
        static DateTime ConverToTime(byte[] bytes, byte position){
            DateTime dateTime = new DateTime(1900,1,1,0,0,0, DateTimeKind.Utc);
            byte[] data = new byte[4];
            for(int i = 0; i < 4; i++){
                data[i] = bytes[i + position];
            }
            Array.Reverse(data);
            ulong nguyen = BitConverter.ToUInt32(data,0);
            for(int i = 0; i < 4; i++){
                data[i] = bytes[i + position + 4];
            }
            Array.Reverse(data);
            ulong du = BitConverter.ToUInt32(data,0);            
            ulong milis = (nguyen * 1000) + (du * 1000) / UInt32.MaxValue;
            dateTime = dateTime.AddMilliseconds(milis);
            return dateTime;
        }
    }
}