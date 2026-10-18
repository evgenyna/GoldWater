using System;
using Unit4.CollectionsLib;
using System.Text;
using static GoldWater.ListInt;   // פעולת עזר: Length

namespace GoldWater
{
    public class ListTriple
    {
        // פעולת עזר: מחזירה את מספר החוליות ברשימה (משתמשת ב-Length מ-ListInt)
        public static int Count(Node<int> l)
        {
            return Length(l);
        }

        // פעולת עזר: מחזירה את החוליה שמגיעים אליה אחרי k צעדים מ-l
        // (k = 0 מחזירה את l עצמה)
        public static Node<int> GetPos(Node<int> l, int k)
        {
            Node<int> pos = l;
            for (int i = 0; i < k && pos != null; i++)
                pos = pos.GetNext();
            return pos;
        }

        // דרך 1: שלושה מצביעים – לתחילת כל שליש
        // מחזירה
        // true
        // אם
        // l
        // היא רשימה משולשת, אחרת
        // false
        public static bool IsTripleChain(Node<int> l)
        {
            if (l == null || Count(l) % 3 != 0)
                return false;

            int part = Count(l) / 3;
            Node<int> pos2 = GetPos(l, part);       // תחילת השליש השני
            Node<int> pos3 = GetPos(l, part * 2);   // תחילת השליש השלישי

            while (pos3 != null)
            {                                 
                if (l.GetValue() != pos2.GetValue() ||
                    pos2.GetValue() != pos3.GetValue())
                    return false;
                l = l.GetNext();
                pos2 = pos2.GetNext();
                pos3 = pos3.GetNext();
            }                                  

            return true;
        }                                      

        // דרך 2:
        // מצביע אחד שמקדים ב
        // -part חוליות
        // משווה
        // כל איבר לאיבר שנמצא
        // part
        // מקומות אחריו:
        // כך השליש הראשון מושווה לשני, והשני לשלישי
        public static bool IsTripleChain2(Node<int> l)
        {
            if (l == null || Count(l) % 3 != 0)
                return false;

            int part = Count(l) / 3;
            Node<int> pos1 = l;
            for (int i = 0; i < part; i++)      // קידום
                                                // pos1
                                                // לתחילת השליש השני
                pos1 = pos1.GetNext();

            while (pos1 != null)
            {                                   
                if (l.GetValue() != pos1.GetValue())
                    return false;
                l = l.GetNext();
                pos1 = pos1.GetNext();
            }                                   

            return true;
        }
    }
}
