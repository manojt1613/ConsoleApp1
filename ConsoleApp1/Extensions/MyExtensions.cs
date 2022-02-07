using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Extensions
{
    static class MyExtensions
    {
        public static int[] ToIntArray(this string num)
        {
            ICollection<int> lst = new List<int>();

            if (num.All(char.IsDigit))
            {
                lst = num.ToString().Select(o => int.Parse(o.ToString())).ToArray();
            }
            else
            {
                char[] charArr = num.ToUpper().ToCharArray();

                foreach (var item in charArr)
                {
                    int index = 0;

                    if (char.IsLetter(item))
                        index = (char.ToUpper(item) - 64) + 9;
                    else
                        index = Convert.ToInt32(item.ToString());

                    lst.Add(index);
                }
            }

            return lst.ToArray();
        }
    }
}
