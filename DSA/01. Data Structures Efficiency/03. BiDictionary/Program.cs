using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BiDictionary;

class Program
{
    static void Main()
    {
        BiDictionary<string, string, string> dict = new BiDictionary<string, string, string>();
        dict.Add("gosho", "goshov", "jabata");
        dict.Add("gosho", "peshov", "konq");
        dict.Add("gosho", "nedkov", "babata");
        dict.Add("tosho", "goshov", "lopatata");
        dict.Add("toncho", "goshov", "malkiq");
        dict.Add("ceco", "peshov", "komara");

        var search = dict.SearchMultiKeys("gosho","goshov");

    }
}

