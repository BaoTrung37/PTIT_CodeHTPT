// using System;
// using System.Collections.Generic;

// namespace Bey{
//     class Beckeyley{
//         static void Main(){
//             string dp = "2018-09-27 09:32:29.960";
//             List<string> tv = new List<string>();
// 			tv.Add("2018-09-27 09:32:28.659");
// 			tv.Add("2018-09-27 09:32:31.581");
// 			// tv.Add("2021-07-12 14:22:30.446");
			
// 			string FormatDateTime = "yyyy-MM-dd HH:mm:ss.fff";
//             List<DateTime> thanhvien = new List<DateTime>();
//             DateTime dieuphoi = DateTime.ParseExact(dp,FormatDateTime,System.Globalization.CultureInfo.InvariantCulture);
//             for(int i = 0; i < tv.Count; i++){
//                 DateTime myDate = DateTime.ParseExact(tv[i],FormatDateTime,System.Globalization.CultureInfo.InvariantCulture);  
//                 thanhvien.Add(myDate); 
//             }
//             long dem = 0; 
//             List<long> chinh = new List<long>();
//             for(int i = 0; i < thanhvien.Count; i++){
//                 dem += thanhvien[i].Ticks - dieuphoi.Ticks;
//                 chinh.Add((thanhvien[i].Ticks - dieuphoi.Ticks) / 10000);
//             }
//             double num = tv.Count + 1;
//             long theta = (long) Math.Round((dem/10000) / num, 0,MidpointRounding.AwayFromZero);

//             Console.WriteLine("Dieu phoi :" + theta);
//             for(int i = 0; i < chinh.Count; i++){
//                 Console.WriteLine("Thanhvien "+ (i + 1) + ": " + (theta - chinh[i]));
//             }
//             DateTime dongbo = dieuphoi.AddTicks(theta * 10000);
//             Console.WriteLine("Sau khi dong bo: " + dongbo.ToString(FormatDateTime));
//         }
//     }
// }