using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace EncryptKeyClient.EncryptHelper
{
    public class GetRandomStr
    {
        public GetRandomStr()
        {
        }
        public string GetRandoms()
        {
            Random rd = new Random();
            IList<string> nums = new List<string>{ "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
            string[] strs = {"a","b","c","d","e","f","g","h","i","j","k","l","m","n","o","p","q","r","s",
            "t","u","v","w","s","y","z"};
            foreach (var item in strs)
            {
                nums.Add(item);
                nums.Add(item.ToUpper());
            }
            List<string> result = new List<string>();
            int int_nums = 0;
            // 随机得到的四位字符，要求有且仅有一位数字
            do
            {
                int_nums = 0;
                result.Clear();
                for (int i = 0; i < 4; i++)
                {
                    var r = nums[rd.Next(0, nums.Count)];
                    result.Add(r);
                }
                
                foreach (var item in result)
                {
                    if (int.TryParse(item, out int num))
                    {
                        int_nums += 1;
                    }
                }
            } while (int_nums != 1);
            string result_str = default(string);
            result.ForEach(r => result_str += r);
            return result_str;
        }
    }
}
