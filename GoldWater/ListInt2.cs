using System;
using Unit4.CollectionsLib;
using System.Text;

namespace GoldWater
{
    /// <summary>
    /// פתרונות לדף תרגילים תרגול שרשרת - הילה קדמן - 2
    /// פעולות שעלולות לשנות את ראש הרשימה מחזירות את הראש החדש
    /// ויש לקלוט את הערך המוחזר, לדוגמה
    /// lst = ListInt2.DeleteEven(lst);
    /// </summary>
    public class ListInt2
    {
        // =====================================================================
        //                          פעולות עזר
        // =====================================================================

        // בניית רשימה ממערך, באותו סדר
        public static Node<int> Build(int[] arr)
        {
            Node<int> first = null;
            for (int i = arr.Length - 1; i >= 0; i--)
                first = new Node<int>(arr[i], first);
            return first;
        }

        // הצגת רשימה כמחרוזת
        // Format: [x0, x1, ..., xn]
        public static string ToStr(Node<int> lst)
        {
            if (lst == null)
                return "[ ]";
            string str = "[";
            Node<int> pos = lst;
            while (pos != null)
            {
                str += pos.GetValue();
                if (pos.HasNext())
                    str += ", ";
                pos = pos.GetNext();
            }
            str += "]";
            return str;
        }

        // אורך הרשימה
        // Complexity: O(n)
        public static int Length(Node<int> lst)
        {
            int count = 0;
            while (lst != null)
            {
                count++;
                lst = lst.GetNext();
            }
            return count;
        }

        // =====================================================================
        // תרגיל 1
        // כמה פעמים מופיע הרצף אחד אפס אחד ברשימה בינארית
        // רצפים חופפים נספרים כל אחד בנפרד
        // לכל חוליה בודקים אותה ואת שתי החוליות שאחריה
        // Example: [1,0,1,0,1] -> 2
        // Complexity: O(n)
        // =====================================================================
        public static int Count101(Node<int> lst)
        {
            int count = 0;
            Node<int> pos = lst;
            while (pos != null && pos.HasNext() && pos.GetNext().HasNext())
            {
                if (pos.GetValue() == 1 &&
                    pos.GetNext().GetValue() == 0 &&
                    pos.GetNext().GetNext().GetValue() == 1)
                    count++;
                pos = pos.GetNext();
            }
            return count;
        }

        // =====================================================================
        // תרגיל 2
        // רשימת החיתוך של שתי רשימות ממוינות, כרשימה חדשה
        // מתקדמים על שתי הרשימות במקביל ותמיד מקדמים את הקטן מבין השניים
        // כשהם שווים מוסיפים לתוצאה ומקדמים את שניהם
        // Complexity: O(n+m)
        // =====================================================================
        public static Node<int> IntersectionList(Node<int> lst1, Node<int> lst2)
        {
            Node<int> dummy = new Node<int>(0);    // חוליית דמה שמקלה על ההוספה לסוף
            Node<int> last = dummy;
            Node<int> p1 = lst1, p2 = lst2;
            while (p1 != null && p2 != null)
            {
                int a = p1.GetValue(), b = p2.GetValue();
                if (a < b)
                    p1 = p1.GetNext();
                else if (b < a)
                    p2 = p2.GetNext();
                else                                // משותף לשתי הרשימות
                {
                    last.SetNext(new Node<int>(a));
                    last = last.GetNext();
                    p1 = p1.GetNext();
                    p2 = p2.GetNext();
                }
            }
            return dummy.GetNext();
        }

        // =====================================================================
        // תרגיל 3
        // רשימת האיחוד של שתי רשימות ממוינות, כרשימה חדשה וממוינת
        // מספר שמופיע בשתי הרשימות יופיע בתוצאה פעם אחת בלבד
        // מתקדמים על שתי הרשימות במקביל
        // Complexity: O(n+m)
        // =====================================================================
        public static Node<int> UnionList(Node<int> lst1, Node<int> lst2)
        {
            Node<int> dummy = new Node<int>(0);
            Node<int> last = dummy;
            Node<int> p1 = lst1, p2 = lst2;
            while (p1 != null && p2 != null)
            {
                int a = p1.GetValue(), b = p2.GetValue();
                if (a < b)
                {
                    last.SetNext(new Node<int>(a));
                    p1 = p1.GetNext();
                }
                else if (b < a)
                {
                    last.SetNext(new Node<int>(b));
                    p2 = p2.GetNext();
                }
                else                                // שווים, מוסיפים פעם אחת ומקדמים את שניהם
                {
                    last.SetNext(new Node<int>(a));
                    p1 = p1.GetNext();
                    p2 = p2.GetNext();
                }
                last = last.GetNext();
            }

            // רק אחת מהרשימות עוד לא נגמרה, מעתיקים את שארית האיברים שלה
            Node<int> rest = (p1 != null) ? p1 : p2;
            while (rest != null)
            {
                last.SetNext(new Node<int>(rest.GetValue()));
                last = last.GetNext();
                rest = rest.GetNext();
            }
            return dummy.GetNext();
        }

        // =====================================================================
        // תרגיל 4
        // השארת מופע אחד בלבד, הראשון, של כל מספר
        // הפעולה עובדת על הרשימה עצמה
        // ראש הרשימה לעולם לא נמחק כי הוא תמיד המופע הראשון, לכן הפעולה לא מחזירה ערך
        // לכל איבר סורקים את כל המשך הרשימה
        // Example: [1, 5, 3, 1, 2, 5, 1, 2] -> [1, 5, 3, 2]
        // Complexity: O(n^2)
        // =====================================================================
        public static void RemoveDuplicates(Node<int> lst)
        {
            Node<int> pos = lst;
            while (pos != null)
            {
                // עוברים על כל החוליות שאחרי החוליה הנוכחית
                // ומוחקים את אלה שהערך שלהן זהה לערך שלה
                Node<int> prev = pos;
                while (prev.HasNext())
                {
                    if (prev.GetNext().GetValue() == pos.GetValue())
                        prev.SetNext(prev.GetNext().GetNext()); // מחיקה, ולכן לא מתקדמים
                    else
                        prev = prev.GetNext();
                }
                pos = pos.GetNext();
            }
        }

        // =====================================================================
        // תרגיל 5
        // מחזירה את האיבר האמצעי ברשימה
        // אם מספר האיברים זוגי, מחזירה את הממוצע של שני האמצעיים
        // הנחה שהרשימה אינה ריקה
        // מעבר אחד לחישוב האורך, ועוד חצי מעבר עד האמצע
        // Example: [7, 8, 9, 10] -> 8.5
        // Example: [10, 20, 30]  -> 20.0
        // Complexity: O(n)
        // =====================================================================
        public static double Middle(Node<int> lst)
        {
            int len = Length(lst);
            Node<int> pos = lst;
            for (int i = 0; i < (len - 1) / 2; i++)   // התקדמות לאמצעי, השמאלי מבין שניים
                pos = pos.GetNext();

            if (len % 2 == 1)
                return pos.GetValue();
            return (pos.GetValue() + pos.GetNext().GetValue()) / 2.0;   // חילוק ממשי ולא חילוק שלם
        }

        // =====================================================================
        // תרגיל 6
        // מחיקת כל האיברים שערכם זוגי
        // מחזירה את ראש הרשימה, שאולי השתנה
        // מעבר אחד על הרשימה
        // Complexity: O(n)
        // =====================================================================
        public static Node<int> DeleteEven(Node<int> lst)
        {
            // מחיקה מהראש כל עוד הראש זוגי
            while (lst != null && lst.GetValue() % 2 == 0)
                lst = lst.GetNext();
            if (lst == null)
                return null;

            Node<int> prev = lst;                  // החוליה הזו תמיד אי זוגית
            while (prev.HasNext())
            {
                if (prev.GetNext().GetValue() % 2 == 0)
                    prev.SetNext(prev.GetNext().GetNext());
                else
                    prev = prev.GetNext();
            }
            return lst;
        }

        // =====================================================================
        // תרגיל 7
        // היפוך רשימה
        // Example: [2, 4, 6, 8, 10, 12] -> [12, 10, 8, 6, 4, 2]
        // =====================================================================

        // דרך א
        // מחזירה רשימה חדשה הפוכה, והרשימה המקורית לא משתנה
        // עוברים על הרשימה מההתחלה ומוסיפים כל ערך לראש הרשימה החדשה
        // כך האיבר הראשון מגיע לסוף והאחרון מגיע לראש
        // Complexity: O(n)
        public static Node<int> ReverseNew(Node<int> lst)
        {
            Node<int> result = null;
            Node<int> pos = lst;
            while (pos != null)
            {
                result = new Node<int>(pos.GetValue(), result);
                pos = pos.GetNext();
            }
            return result;
        }

        // דרך ב
        // היפוך הרשימה המקורית עצמה, בלי ליצור חוליות חדשות
        // עוברים על החוליות ומפנים כל חוליה אל החוליה שלפניה
        // משתנה ראשון שומר את החוליה הקודמת, שכבר הופנתה אחורה
        // משתנה שני שומר את החוליה הנוכחית
        // משתנה שלישי שומר את ההמשך לפני שמשנים את החוליה הנוכחית
        // בסוף, החוליה שהייתה אחרונה היא הראש החדש, ולכן מחזירים אותה
        // prev = previous node, curr = current node, next = rest of the list
        // Usage: lst = ListInt2.Reverse(lst);
        // Complexity: O(n)
        public static Node<int> Reverse(Node<int> lst)
        {
            Node<int> prev = null;
            Node<int> curr = lst;
            while (curr != null)
            {
                Node<int> next = curr.GetNext();  // שמירת ההמשך
                curr.SetNext(prev);               // הפניית החוליה אחורה
                prev = curr;                      // התקדמות
                curr = next;
            }
            return prev;
        }

        // =====================================================================
        //                          תכנית בדיקה
        // Usage from Main: ListInt2.Test();
        // =====================================================================
        public static void Test()
        {
            Console.WriteLine("===== Sheet 2 =====");

            // תרגיל 1
            Node<int> bin = Build(new int[] { 1, 0, 1, 0, 1, 1, 0, 0, 1, 0, 1 });
            Console.WriteLine("1. " + ToStr(bin) + "  count of 101: " + Count101(bin));   // Expected: 3

            // תרגילים 2 ו 3
            Node<int> lst1 = Build(new int[] { 3, 7, 9, 12, 15, 17 });
            Node<int> lst2 = Build(new int[] { 2, 7, 10, 12, 16, 17 });
            Console.WriteLine("2. intersection: " + ToStr(IntersectionList(lst1, lst2)));  // Expected: [7, 12, 17]
            Console.WriteLine("3. union:        " + ToStr(UnionList(lst1, lst2)));         // Expected: [2, 3, 7, 9, 10, 12, 15, 16, 17]

            // תרגיל 4
            Node<int> dup = Build(new int[] { 1, 5, 3, 1, 2, 5, 1, 2 });
            Console.Write("4. " + ToStr(dup) + " -> ");
            RemoveDuplicates(dup);
            Console.WriteLine(ToStr(dup));                                                 // Expected: [1, 5, 3, 2]

            // תרגיל 5
            Console.WriteLine("5. middle [7, 8, 9, 10]: " + Middle(Build(new int[] { 7, 8, 9, 10 })));  // Expected: 8.5
            Console.WriteLine("5. middle [10, 20, 30]:  " + Middle(Build(new int[] { 10, 20, 30 })));   // Expected: 20

            // תרגיל 6
            Node<int> ev = Build(new int[] { 2, 4, 5, 6, 7, 8, 9, 10 });
            Console.Write("6. " + ToStr(ev) + " -> ");
            ev = DeleteEven(ev);
            Console.WriteLine(ToStr(ev));                                                  // Expected: [5, 7, 9]

            // תרגיל 7
            Node<int> r = Build(new int[] { 2, 4, 6, 8, 10, 12 });
            Node<int> rNew = ReverseNew(r);
            Console.WriteLine("7a. new: " + ToStr(rNew) + "  original: " + ToStr(r));
            r = Reverse(r);
            Console.WriteLine("7b. in place: " + ToStr(r));                                // Expected: [12, 10, 8, 6, 4, 2]
        }
    }
}
