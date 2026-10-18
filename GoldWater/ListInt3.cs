using System;
using Unit4.CollectionsLib;
using System.Text;

namespace GoldWater
{
    /// <summary>
    /// פתרונות לדף התרגילים תרגול שרשרת - הילה קדמן - 3 
    /// רשימה מוכלת ותת רשימה
    /// פעולות העזר נלקחות מהמחלקה של דף תרגול מספר 1
    /// </summary>
    // Helpers used: ListInt.Build, ListInt.ToStr, ListInt.Exist, ListInt.StartsWith
    // n = length of lst1, m = length of the second list
    public class ListInt3
    {
        // =====================================================================
        // תרגיל 1
        // תת רשימה
        // כל איבר של הרשימה הראשונה קיים בשנייה
        // האיברים נמצאים ברצף בשנייה
        // סדר האיברים בשתי הרשימות זהה
        //
        // לכל חוליה ברשימה השנייה בודקים אם הרשימה הראשונה מתחילה בה
        // חשוב להתחיל כל בדיקה מחדש מהחוליה הבאה, ולא מהמקום שבו נכשלנו
        // אחרת מפספסים רצף שמתחיל באמצע ניסיון שנכשל
        //
        // Helper: ListInt.StartsWith(start, lst1)
        // Example: lst1 = [3, 12, 5, 32, 1]
        //          lst2 = [6, 3, 12, 34, 3, 3, 12, 5, 32, 1, 4]  -> true
        // Complexity: O(n*m)
        // =====================================================================
        public static bool IsSubList(Node<int> lst1, Node<int> lst2)
        {
            if (lst1 == null)
                return true;             // רשימה ריקה היא תת רשימה של כל רשימה

            Node<int> pos = lst2;
            while (pos != null)
            {
                if (ListInt.StartsWith(pos, lst1))
                    return true;
                pos = pos.GetNext();
            }
            return false;
        }

        // =====================================================================
        // תרגיל 2
        // רשימה מוכלת
        // כל איבר של הרשימה הראשונה קיים בשנייה
        // סדר האיברים בשתי הרשימות זהה, אבל לא חייב להיות ברצף
        //
        // מתקדמים על שתי הרשימות במקביל
        // ברשימה השנייה מתקדמים תמיד
        // ברשימה הראשונה מתקדמים רק כשמוצאים את האיבר שמחפשים
        // כל רשימה נסרקת לכל היותר פעם אחת
        //
        // Example: lst1 = [3, 12, 5, 32, 1]
        //          lst3 = [6, 3, 9, 34, 12, 8, 5, 32, 6, 4, 1, 12]  -> true
        // Complexity: O(m)
        // =====================================================================
        public static bool IsContains(Node<int> lst1, Node<int> lst3)
        {
            Node<int> p1 = lst1, p3 = lst3;
            while (p1 != null && p3 != null)
            {
                if (p1.GetValue() == p3.GetValue())
                    p1 = p1.GetNext();   // נמצא, עוברים לאיבר הבא שמחפשים
                p3 = p3.GetNext();
            }
            return p1 == null;           // אמת אם כל איברי הרשימה הראשונה נמצאו
        }

        // =====================================================================
        // תרגיל 3
        // רשימה שנמצאת בתוך רשימה
        // כל איבר של הרשימה הראשונה קיים בשנייה
        // הסדר לא חשוב
        //
        // בדף כתובה כותרת הפעולה עם פרמטר בשם שונה, כנראה טעות הקלדה
        // Sheet: IsInList(lst1, lst3)   Here: IsInList(lst1, lst4)
        //
        // לכל איבר של הרשימה הראשונה מחפשים אותו בכל הרשימה השנייה
        // ברגע שאיבר אחד לא נמצא, מחזירים שקר
        //
        // Helper: ListInt.Exist(lst, x)
        // Example: lst1 = [3, 12, 5, 32, 1]
        //          lst4 = [6, 9, 5, 34, 12, 8, 32, 6, 3, 4, 1, 12]  -> true
        // Complexity: O(n*m)
        // =====================================================================
        public static bool IsInList(Node<int> lst1, Node<int> lst4)
        {
            Node<int> pos = lst1;
            while (pos != null)
            {
                if (!ListInt.Exist(lst4, pos.GetValue()))
                    return false;
                pos = pos.GetNext();
            }
            return true;
        }

        // =====================================================================
        //                          תכנית בדיקה
        // Usage from Main: ListInt3.Test();
        // =====================================================================
        public static void Test()
        {
            Console.WriteLine("===== Sheet 3 - SubList / Contains / InList =====");

            Node<int> lst1 = ListInt.Build(new int[] { 3, 12, 5, 32, 1 });
            Node<int> lst2 = ListInt.Build(new int[] { 6, 3, 12, 34, 3, 3, 12, 5, 32, 1, 4 });
            Node<int> lst3 = ListInt.Build(new int[] { 6, 3, 9, 34, 12, 8, 5, 32, 6, 4, 1, 12 });
            Node<int> lst4 = ListInt.Build(new int[] { 6, 9, 5, 34, 12, 8, 32, 6, 3, 4, 1, 12 });
            Console.WriteLine("lst1 = " + ListInt.ToStr(lst1));
            Console.WriteLine("lst2 = " + ListInt.ToStr(lst2));
            Console.WriteLine("lst3 = " + ListInt.ToStr(lst3));
            Console.WriteLine("lst4 = " + ListInt.ToStr(lst4));
            Console.WriteLine();

            // תרגיל 1
            Console.WriteLine("1. IsSubList(lst1, lst2):  " + IsSubList(lst1, lst2));   // Expected: True
            Console.WriteLine("1. IsSubList(lst1, lst3):  " + IsSubList(lst1, lst3));   // Expected: False

            // תרגיל 2
            Console.WriteLine("2. IsContains(lst1, lst3): " + IsContains(lst1, lst3));  // Expected: True
            Console.WriteLine("2. IsContains(lst1, lst2): " + IsContains(lst1, lst2));  // Expected: True
            Console.WriteLine("2. IsContains(lst1, lst4): " + IsContains(lst1, lst4));  // Expected: False

            // תרגיל 3
            Console.WriteLine("3. IsInList(lst1, lst4):   " + IsInList(lst1, lst4));    // Expected: True
            Node<int> lst5 = ListInt.Build(new int[] { 3, 12, 7 });
            Console.WriteLine("3. IsInList(" + ListInt.ToStr(lst5) + ", lst4): " + IsInList(lst5, lst4));   // Expected: False
        }
    }
}
