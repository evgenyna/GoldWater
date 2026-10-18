using System;
using Unit4.CollectionsLib;
using System.Text;

namespace GoldWater
{
    public class ListSedarot
    {
        // הפעולה מקבלת שרשרת חוליות לא ריקה של מספרים שלמים
        // ומחזירה שרשרת חדשה: עבור כל תת-רשימה עולה ב-list יופיע סכום איבריה
        public static Node<int> Sedarot(Node<int> list)
        {
            Node<int> pos = list;   // לסריקה  list אפשר להשתמש
            int sum = 0;
            Node<int> newN = null, last = null;

            while (pos.HasNext())
            {
                sum += pos.GetValue();

                // תוקן: היה <=  — הסדרה מסתיימת כשהמספר הבא קטן או שווה לנוכחי
                if (pos.GetValue() >= pos.GetNext().GetValue())   // הסדרה הסתיימה
                {                                                  // תוקן: חסר סוגר פותח
                    if (newN == null)   // הוספה לשרשרת ריקה
                    {
                        newN = new Node<int>(sum);
                        last = newN;
                        sum = 0;
                    }
                    else                //  הוספה אחרי האחרון
                    {
                        last.SetNext(new Node<int>(sum));
                        last = last.GetNext();
                        sum = 0;
                    }
                }

                pos = pos.GetNext();      //   קידום לחוליה הבאה
            }

            //// טיפול באיבר האחרון או הסכום
            sum += pos.GetValue();
            if (newN == null)
                newN = new Node<int>(sum);
            else
                last.SetNext(new Node<int>(sum));

            return newN;
        }
    }
}
