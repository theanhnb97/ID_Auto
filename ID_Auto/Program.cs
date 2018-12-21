using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ID_Auto
{
    class Program
    {
        static void Main(string[] args)
        {
            List<String> ID = new List<string>();
            ID.Add("kh000001");
            Console.Write("Nhap so ID muon tao: ");
            int count =Convert.ToInt32(Console.ReadLine());
            for(int i=0;i<count;i++) AutoID(ID);

            foreach(String item in ID) Console.Write("\n" + item);

            Console.ReadLine();
        }
        static void AutoID(List<String> ID)
        {
            #region D.Sach moi, chua co ID
            // ky tu truoc so trong ID
            String head = "NV";
            #endregion
            // neu ds trong, tao id moi
            if (ID.Count == 0)
            {
                ID.Add(head + "00001");
                return;
            }
            #region Da co trong D.Sach
            head = "";
            // lay Last ID from LastID
            String LastID = ID.Last();
            String LastIDNum = "";
            int count0 = 0;
            bool nextRound = false,check0 = true;
            foreach(char item in LastID)
            {
                try
                {
                    if (check0 && item == '0') count0++;
                    if (Char.IsNumber(item) && item != '0') check0 = false;
                    if (Char.IsNumber(item))LastIDNum += item;
                    if (!Char.IsNumber(item))head += item;
                }
                catch { }
            }
            // xet new id
            int LastIDNumber = Convert.ToInt32(LastIDNum);
            int newIDNumber=LastIDNumber+1;
            if (newIDNumber.ToString().Length > LastIDNumber.ToString().Length) nextRound = true;
            //create new id;
            if(nextRound) for (int i = 0; i < count0-1; i++)head += "0";
            else for (int i = 0; i < count0; i++)head += "0";
            head += newIDNumber.ToString();
            ID.Add(head);
            #endregion
        }
    }
}
