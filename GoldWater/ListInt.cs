using System;
using Unit4.CollectionsLib;
using System.Text;

namespace GoldWater
{
    /// <summary>
    /// מחלקת שירות לטיפול בשרשרת חוליות
    /// פתרונות לדף תרגול מספר 1
    /// פעולות שעלולות לשנות את ראש הרשימה מחזירות את הראש החדש
    /// ויש לקלוט את הערך המוחזר, לדוגמה
    /// lst = ListInt.Delete(lst, 5);
    /// </summary>
    public class ListInt
    {
        private static Random rnd = new Random();

        // =====================================================================
        //                        בנייה והצגת רשימה
        // =====================================================================

        // תרגיל 1
        // בניית רשימה מקלט של המשתמש, לפחות 10 איברים
        public static Node<int> Build()
        {
            int len;
            do
            {
                Console.Write("How many numbers (at least 10)? ");
                len = int.Parse(Console.ReadLine());
            } while (len < 10);

            Node<int> first = null, last = null;
            for (int i = 0; i < len; i++)
            {
                Console.Write("Enter number #" + (i + 1) + ": ");
                int x = int.Parse(Console.ReadLine());
                Node<int> node = new Node<int>(x);
                if (first == null)
                    first = node;
                else
                    last.SetNext(node);
                last = node;
            }
            return first;
        }

        // תרגיל 2
        // בניית רשימה של מספרים אקראיים בטווח הנתון כולל הקצוות
        // Example: Build(12, 5, 20)
        public static Node<int> Build(int len, int from, int to)
        {
            Node<int> first = null;
            for (int i = 0; i < len; i++)
                first = new Node<int>(rnd.Next(from, to + 1), first); // הוספה בראש הרשימה
            return first;
        }

        // תרגיל 3
        // בניית רשימה ממערך, באותו סדר
        public static Node<int> Build(int[] arr)
        {
            Node<int> first = null;
            for (int i = arr.Length - 1; i >= 0; i--)   // מעבר מהסוף להתחלה והוספה בראש
                first = new Node<int>(arr[i], first);
            return first;
        }

        // תרגיל 4
        // הצגת הרשימה
        // Format: [x0, x1, ..., xn]
        public static void Show(Node<int> lst)
        {
            Console.WriteLine(ToStr(lst));
        }

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

        // =====================================================================
        //                        חיפוש ועדכון ברשימה
        // =====================================================================

        // תרגיל 6
        // האם המספר קיים ברשימה
        // Complexity: O(n)
        public static bool Exist(Node<int> lst, int x)
        {
            return GetPosition(lst, x) != null;
        }

        // תרגיל 7
        // מחזירה הפניה לחוליה הראשונה שמכילה את המספר, או ריק אם אין כזו
        // Complexity: O(n)
        public static Node<int> GetPosition(Node<int> lst, int x)
        {
            Node<int> pos = lst;
            while (pos != null && pos.GetValue() != x)
                pos = pos.GetNext();
            return pos;
        }

        // תרגיל 8
        // עדכון המופע הראשון של המספר לערך החדש
        // Complexity: O(n)
        public static void Update(Node<int> lst, int x, int y)
        {
            Node<int> pos = GetPosition(lst, x);
            if (pos != null)
                pos.SetValue(y);
        }

        // תרגיל 9
        // מחזירה הפניה לאיבר המקסימלי, הראשון מביניהם אם יש כמה
        // Complexity: O(n)
        public static Node<int> GetMax(Node<int> lst)
        {
            if (lst == null)
                return null;
            Node<int> max = lst;
            Node<int> pos = lst.GetNext();
            while (pos != null)
            {
                if (pos.GetValue() > max.GetValue())   // גדול ממש, כדי לשמור על הראשון
                    max = pos;
                pos = pos.GetNext();
            }
            return max;
        }

        // תרגיל 10
        // אורך הרשימה
        // סיבוכיות לינארית, עוברים פעם אחת על כל האיברים
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

        // תרגיל 10
        // החלפת הערך בחוליה הנתונה עם הערך בחוליה העוקבת לה
        // אם אין חוליה עוקבת, לא קורה דבר
        // מספר קבוע של פעולות שאינו תלוי באורך הרשימה
        // Complexity: O(1)
        public static void Swap(Node<int> lst, Node<int> p)
        {
            if (p == null || !p.HasNext())
                return;
            Node<int> next = p.GetNext();
            int temp = p.GetValue();
            p.SetValue(next.GetValue());
            next.SetValue(temp);
        }

        // =====================================================================
        //                           מחיקה ברשימה
        // =====================================================================

        // תרגיל 11
        // מחיקת המופע הראשון של המספר
        // מחזירה את ראש הרשימה, שאולי השתנה
        // במקרה הגרוע עוברים על כל הרשימה
        // Complexity: O(n)
        public static Node<int> Delete(Node<int> lst, int x)
        {
            if (lst == null)
                return null;
            if (lst.GetValue() == x)          // מחיקת הראש
                return lst.GetNext();

            Node<int> prev = lst;
            while (prev.HasNext() && prev.GetNext().GetValue() != x)
                prev = prev.GetNext();
            if (prev.HasNext())               // נמצא, מדלגים על החוליה
                prev.SetNext(prev.GetNext().GetNext());
            return lst;
        }

        // תרגיל 12
        // מחיקת כל המופעים של המספר
        // מחזירה את ראש הרשימה, שאולי השתנה
        // Complexity: O(n)
        public static Node<int> DelX(Node<int> lst, int x)
        {
            while (lst != null && lst.GetValue() == x)   // מחיקה מהראש כל עוד צריך
                lst = lst.GetNext();
            if (lst == null)
                return null;

            Node<int> prev = lst;
            while (prev.HasNext())
            {
                if (prev.GetNext().GetValue() == x)
                    prev.SetNext(prev.GetNext().GetNext()); // לא מתקדמים, אולי גם הבא למחיקה
                else
                    prev = prev.GetNext();
            }
            return lst;
        }

        // תרגיל 14
        // צמצום רצפים של מספרים זהים למופע אחד
        // ראש הרשימה לעולם לא נמחק, לכן אין צורך להחזיר אותו
        // כל איבר נבדק מול העוקב שלו במעבר אחד
        // Example: [2,3,3,3,4,5,5,2,2,2,7,3,3] -> [2,3,4,5,2,7,3]
        // Complexity: O(n)
        public static void Compress(Node<int> lst)
        {
            Node<int> pos = lst;
            while (pos != null && pos.HasNext())
            {
                if (pos.GetValue() == pos.GetNext().GetValue())
                    pos.SetNext(pos.GetNext().GetNext());
                else
                    pos = pos.GetNext();
            }
        }

        // תרגיל 15
        // השארת המופע הראשון בלבד של כל ערך
        // עבור כל איבר מוחקים את הערך שלו מכל המשך הרשימה
        // Example: [3,6,2,9,2,6,5,3,2,5] -> [3,6,2,9,5]
        // Complexity: O(n^2)
        public static void NoRepeat(Node<int> lst)
        {
            Node<int> pos = lst;
            while (pos != null)
            {
                // מוחקים את הערך הנוכחי מכל החוליות שאחריו
                pos.SetNext(DelX(pos.GetNext(), pos.GetValue()));
                pos = pos.GetNext();
            }
        }

        // =====================================================================
        //                           שרשור רשימות
        // =====================================================================

        // פעולת עזר
        // העתקת רשימה לחוליות חדשות
        // Complexity: O(n)
        public static Node<int> Copy(Node<int> lst)
        {
            Node<int> dummy = new Node<int>(0);   // חוליית דמה שמקלה על הבנייה
            Node<int> last = dummy;
            while (lst != null)
            {
                last.SetNext(new Node<int>(lst.GetValue()));
                last = last.GetNext();
                lst = lst.GetNext();
            }
            return dummy.GetNext();
        }

        // פעולת עזר
        // מחזירה את החוליה האחרונה ברשימה
        // Complexity: O(n)
        public static Node<int> GetLast(Node<int> lst)
        {
            if (lst == null)
                return null;
            while (lst.HasNext())
                lst = lst.GetNext();
            return lst;
        }

        // תרגיל 20
        // שרשור לרשימה שלישית חדשה, שתי הרשימות נשארות ללא שינוי
        // Complexity: O(n+m)
        public static Node<int> ConcatNew(Node<int> lst1, Node<int> lst2)
        {
            Node<int> copy1 = Copy(lst1);
            Node<int> copy2 = Copy(lst2);
            if (copy1 == null)
                return copy2;
            GetLast(copy1).SetNext(copy2);
            return copy1;
        }

        // תרגיל 21 בשרשור
        // הרשימה הראשונה מכילה את הכל, השנייה נשארת ללא שינוי
        // מחזירה את ראש הרשימה הראשונה, שמשתנה אם היא הייתה ריקה
        // Complexity: O(n+m)
        public static Node<int> ConcatToFirst(Node<int> lst1, Node<int> lst2)
        {
            Node<int> copy2 = Copy(lst2);       // העתק, כדי שהרשימה השנייה לא תשותף ולא תשתנה
            if (lst1 == null)
                return copy2;
            GetLast(lst1).SetNext(copy2);
            return lst1;
        }

        // תרגיל 22 בשרשור
        // הרשימה הראשונה מכילה את הכל, והשנייה נשארת ריקה
        // לא יוצרים חוליות חדשות, אלא מחברים את החוליות של השנייה לסוף הראשונה
        // המשתנה של הרשימה השנייה אצל הקורא מתאפס בעזרת פרמטר הפניה
        // רק מעבר אחד עד סוף הרשימה הראשונה
        // Usage: lst1 = ListInt.ConcatMove(lst1, ref lst2);
        // Complexity: O(n)
        public static Node<int> ConcatMove(Node<int> lst1, ref Node<int> lst2)
        {
            Node<int> result;
            if (lst1 == null)
                result = lst2;
            else
            {
                GetLast(lst1).SetNext(lst2);
                result = lst1;
            }
            lst2 = null;
            return result;
        }

        // =====================================================================
        //                          רשימות ממוינות
        // =====================================================================

        // תרגיל 21 סעיף א
        // הכנסה ממוינת בסדר עולה
        // מחזירה את ראש הרשימה, שאולי השתנה
        // Complexity: O(n)
        public static Node<int> InsertSorted(Node<int> lst, int x)
        {
            if (lst == null || x <= lst.GetValue())    // הכנסה בראש הרשימה
                return new Node<int>(x, lst);

            Node<int> prev = lst;
            while (prev.HasNext() && prev.GetNext().GetValue() < x)
                prev = prev.GetNext();
            prev.SetNext(new Node<int>(x, prev.GetNext()));
            return lst;
        }

        // תרגיל 21 סעיף א
        // בניית רשימה ממוינת ממערך
        // Complexity: O(n^2)
        public static Node<int> BuildSorted(int[] arr)
        {
            Node<int> lst = null;
            for (int i = 0; i < arr.Length; i++)
                lst = InsertSorted(lst, arr[i]);
            return lst;
        }

        // תרגיל 21 סעיף א
        // בניית רשימה ממוינת ממספרים אקראיים
        // Complexity: O(n^2)
        public static Node<int> BuildSorted(int len, int from, int to)
        {
            Node<int> lst = null;
            for (int i = 0; i < len; i++)
                lst = InsertSorted(lst, rnd.Next(from, to + 1));
            return lst;
        }

        // תרגיל 21 סעיף ב
        // רשימה של מחרוזות
        // השינוי הראשון הוא בטיפוס של החוליות
        // השינוי השני הוא בהשוואה, כי אין אופרטור קטן מ על מחרוזות
        // int  ->  string
        // a < b  ->  a.CompareTo(b) < 0
        public static Node<string> InsertSorted(Node<string> lst, string s)
        {
            if (lst == null || s.CompareTo(lst.GetValue()) <= 0)
                return new Node<string>(s, lst);

            Node<string> prev = lst;
            while (prev.HasNext() && prev.GetNext().GetValue().CompareTo(s) < 0)
                prev = prev.GetNext();
            prev.SetNext(new Node<string>(s, prev.GetNext()));
            return lst;
        }

        public static Node<string> BuildSorted(string[] arr)
        {
            Node<string> lst = null;
            for (int i = 0; i < arr.Length; i++)
                lst = InsertSorted(lst, arr[i]);
            return lst;
        }

        public static string ToStr(Node<string> lst)
        {
            if (lst == null)
                return "[ ]";
            string str = "[";
            while (lst != null)
            {
                str += lst.GetValue();
                if (lst.HasNext())
                    str += ", ";
                lst = lst.GetNext();
            }
            str += "]";
            return str;
        }

        // תרגיל 22 סעיף א
        // האם הרשימה ממוינת בסדר עולה
        // Complexity: O(n)
        public static bool IsSorted(Node<int> lst)
        {
            if (lst == null)
                return true;                       // רשימה ריקה נחשבת ממוינת
            while (lst.HasNext())
            {
                if (lst.GetValue() > lst.GetNext().GetValue())
                    return false;
                lst = lst.GetNext();
            }
            return true;                           // כולל רשימה בת איבר אחד
        }

        // תרגיל 22 סעיף ב
        // אותו דבר עבור מחרוזות, עם השוואה בעזרת הפעולה המתאימה
        // a > b  ->  a.CompareTo(b) > 0
        public static bool IsSorted(Node<string> lst)
        {
            if (lst == null)
                return true;
            while (lst.HasNext())
            {
                if (lst.GetValue().CompareTo(lst.GetNext().GetValue()) > 0)
                    return false;
                lst = lst.GetNext();
            }
            return true;
        }

        // =====================================================================
        //                           מיזוג רשימות
        // =====================================================================

        // תרגיל 23 סעיף א
        // איחוד ממוין עם חזרות, לרשימה חדשה
        // Complexity: O(n+m)
        public static Node<int> MergeWithDup(Node<int> lst1, Node<int> lst2)
        {
            Node<int> dummy = new Node<int>(0);
            Node<int> last = dummy;
            while (lst1 != null && lst2 != null)
            {
                if (lst1.GetValue() <= lst2.GetValue())
                {
                    last.SetNext(new Node<int>(lst1.GetValue()));
                    lst1 = lst1.GetNext();
                }
                else
                {
                    last.SetNext(new Node<int>(lst2.GetValue()));
                    lst2 = lst2.GetNext();
                }
                last = last.GetNext();
            }
            // העתקת השארית, רק אחת מהרשימות עוד לא נגמרה
            last.SetNext(lst1 != null ? Copy(lst1) : Copy(lst2));
            return dummy.GetNext();
        }

        // תרגיל 23 סעיף ב
        // איחוד ממוין ללא חזרות, לרשימה חדשה
        // Complexity: O(n+m)
        public static Node<int> MergeNoDup(Node<int> lst1, Node<int> lst2)
        {
            Node<int> dummy = new Node<int>(0);
            Node<int> last = dummy;
            while (lst1 != null && lst2 != null)
            {
                int a = lst1.GetValue(), b = lst2.GetValue();
                if (a < b)
                {
                    last.SetNext(new Node<int>(a));
                    lst1 = lst1.GetNext();
                }
                else if (b < a)
                {
                    last.SetNext(new Node<int>(b));
                    lst2 = lst2.GetNext();
                }
                else                                // שווים, מכניסים פעם אחת ומתקדמים בשתיהן
                {
                    last.SetNext(new Node<int>(a));
                    lst1 = lst1.GetNext();
                    lst2 = lst2.GetNext();
                }
                last = last.GetNext();
            }
            last.SetNext(lst1 != null ? Copy(lst1) : Copy(lst2));
            return dummy.GetNext();
        }

        // תרגיל 24
        // חיתוך של שתי רשימות ממוינות, לרשימה חדשה
        // Complexity: O(n+m)
        public static Node<int> Intersect(Node<int> lst1, Node<int> lst2)
        {
            Node<int> dummy = new Node<int>(0);
            Node<int> last = dummy;
            while (lst1 != null && lst2 != null)
            {
                int a = lst1.GetValue(), b = lst2.GetValue();
                if (a < b)
                    lst1 = lst1.GetNext();
                else if (b < a)
                    lst2 = lst2.GetNext();
                else
                {
                    last.SetNext(new Node<int>(a));
                    last = last.GetNext();
                    lst1 = lst1.GetNext();
                    lst2 = lst2.GetNext();
                }
            }
            return dummy.GetNext();
        }

        // תרגיל 25
        // איחוד של שתי רשימות לא ממוינות ללא חזרות, לרשימה חדשה
        // לכל איבר של הרשימה השנייה בודקים אם הוא קיים בראשונה
        // Complexity: O(n*m)
        public static Node<int> UnionUnsorted(Node<int> lst1, Node<int> lst2)
        {
            Node<int> result = Copy(lst1);
            Node<int> last = GetLast(result);
            while (lst2 != null)
            {
                int x = lst2.GetValue();
                if (!Exist(lst1, x))
                {
                    Node<int> node = new Node<int>(x);
                    if (last == null)
                        result = node;
                    else
                        last.SetNext(node);
                    last = node;
                }
                lst2 = lst2.GetNext();
            }
            return result;
        }

        // =====================================================================
        //                                רצפים
        // =====================================================================
        // תרגיל 26
        // רצפים של מספרים חיוביים, וכל רצף מסתיים במספר שלילי
        // המספר השלילי מסמן את סוף הרצף ואינו נספר בו
        // בדף כתוב שאורך הרצף הראשון הוא 5, אבל יש בו 4 איברים
        // כנראה טעות הקלדה בדף
        // List:    [2,5,1,7,-4,6,-1,12,3,9,11,4,7,-2,11,-2]
        // Lengths: [4,1,6,1]
        // Sums:    [15,6,46,11]
        // כל הפעולות בסעיפים א עד ד עוברות פעם אחת על הרשימה
        // Complexity: O(n)

        // תרגיל 26 סעיף א
        // מספר הרצפים שווה למספר המספרים השליליים
        public static int CountSeq(Node<int> lst)
        {
            int count = 0;
            while (lst != null)
            {
                if (lst.GetValue() < 0)
                    count++;
                lst = lst.GetNext();
            }
            return count;
        }

        // תרגיל 26 סעיף ב
        // אורך הרצף הארוך ביותר
        public static int MaxSeqLength(Node<int> lst)
        {
            int max = 0, len = 0;
            while (lst != null)
            {
                if (lst.GetValue() < 0)        // סוף רצף
                {
                    if (len > max)
                        max = len;
                    len = 0;
                }
                else
                    len++;
                lst = lst.GetNext();
            }
            return max;
        }

        // תרגיל 26 סעיף ג
        // רשימת אורכי הרצפים
        public static Node<int> SeqLengths(Node<int> lst)
        {
            Node<int> dummy = new Node<int>(0);
            Node<int> last = dummy;
            int len = 0;
            while (lst != null)
            {
                if (lst.GetValue() < 0)
                {
                    last.SetNext(new Node<int>(len));
                    last = last.GetNext();
                    len = 0;
                }
                else
                    len++;
                lst = lst.GetNext();
            }
            return dummy.GetNext();
        }

        // תרגיל 26 סעיף ד
        // רשימת סכומי הרצפים
        public static Node<int> SeqSums(Node<int> lst)
        {
            Node<int> dummy = new Node<int>(0);
            Node<int> last = dummy;
            int sum = 0;
            while (lst != null)
            {
                if (lst.GetValue() < 0)
                {
                    last.SetNext(new Node<int>(sum));
                    last = last.GetNext();
                    sum = 0;
                }
                else
                    sum += lst.GetValue();
                lst = lst.GetNext();
            }
            return dummy.GetNext();
        }

        // תרגיל 27
        // אורך הרצף העולה ממש הארוך ביותר
        // Example: [2,5,7,8,-3,-1,0,2,4,6,5,5,6,7,12] -> 6
        // The sequence is: -3,-1,0,2,4,6
        // Complexity: O(n)
        public static int MaxAscendingLength(Node<int> lst)
        {
            if (lst == null)
                return 0;
            int max = 1, len = 1;
            while (lst.HasNext())
            {
                if (lst.GetNext().GetValue() > lst.GetValue())
                    len++;
                else
                    len = 1;
                if (len > max)
                    max = len;
                lst = lst.GetNext();
            }
            return max;
        }

        // תרגיל 26 השני סעיף א
        // רשימת המספרים העוקבים הארוכה ביותר, כרשימה חדשה
        // Example: [3,5,6,7,8,-1,0,1,2,3,4,6,7,13,1,2] -> [-1,0,1,2,3,4]
        // תרגיל 26 השני סעיף ב
        // מעבר אחד למציאת תחילת הרצף ואורכו
        // ועוד מעבר על הרצף עצמו כדי להעתיק אותו
        // Complexity: O(n) + O(n) = O(n)
        public static Node<int> MaxConsecutive(Node<int> lst)
        {
            if (lst == null)
                return null;

            Node<int> bestStart = lst, start = lst;
            int bestLen = 1, len = 1;
            Node<int> pos = lst;
            while (pos.HasNext())
            {
                if (pos.GetNext().GetValue() == pos.GetValue() + 1)
                    len++;
                else
                {
                    start = pos.GetNext();
                    len = 1;
                }
                if (len > bestLen)
                {
                    bestLen = len;
                    bestStart = start;
                }
                pos = pos.GetNext();
            }

            // העתקת הרצף הארוך ביותר לרשימה חדשה
            Node<int> dummy = new Node<int>(0);
            Node<int> last = dummy;
            for (int i = 0; i < bestLen; i++)
            {
                last.SetNext(new Node<int>(bestStart.GetValue()));
                last = last.GetNext();
                bestStart = bestStart.GetNext();
            }
            return dummy.GetNext();
        }

        // תרגיל 27 השני
        // רשימת תווים שבה כל מילה מסתיימת בכוכבית
        // מחזירה הפניה לתחילת המילה הארוכה ביותר, הראשונה אם יש כמה
        // Example: a b * a b c * a *  ->  points to the 'a' of "abc*"
        // Complexity: O(n)
        public static Node<char> LongestWord(Node<char> lst)
        {
            Node<char> best = null, start = lst;
            int bestLen = 0, len = 0;
            Node<char> pos = lst;
            while (pos != null)
            {
                len++;                                 // סופרים גם את הכוכבית
                if (pos.GetValue() == '*')
                {
                    if (len > bestLen)
                    {
                        bestLen = len;
                        best = start;
                    }
                    len = 0;
                    start = pos.GetNext();             // המילה הבאה מתחילה אחרי הכוכבית
                }
                pos = pos.GetNext();
            }
            return best;
        }

        // פעולות עזר לרשימת תווים
        public static Node<char> BuildChars(string s)
        {
            Node<char> first = null;
            for (int i = s.Length - 1; i >= 0; i--)
                if (s[i] != ' ')
                    first = new Node<char>(s[i], first);
            return first;
        }

        public static string ToStr(Node<char> lst)
        {
            if (lst == null)
                return "[ ]";
            string str = "[";
            while (lst != null)
            {
                str += lst.GetValue();
                if (lst.HasNext())
                    str += ", ";
                lst = lst.GetNext();
            }
            str += "]";
            return str;
        }

        // =====================================================================
        //                          תת רשימות
        // =====================================================================

        // תרגיל 28
        // האם הרשימה הראשונה היא תת רשימה של השנייה
        // כלומר כל איבריה מופיעים בשנייה באותו סדר, לא בהכרח ברצף
        // כל אחד משני המצביעים מתקדם רק קדימה
        // ולכן הרשימה השנייה נסרקת לכל היותר פעם אחת
        // m = length of lst2
        // Complexity: O(m)
        public static bool IsSubList(Node<int> lst1, Node<int> lst2)
        {
            Node<int> p1 = lst1, p2 = lst2;
            while (p1 != null && p2 != null)
            {
                if (p1.GetValue() == p2.GetValue())
                    p1 = p1.GetNext();               // נמצא, עוברים לאיבר הבא שמחפשים
                p2 = p2.GetNext();
            }
            return p1 == null;                      // כל האיברים של הרשימה הראשונה נמצאו
        }

        // פעולת עזר
        // האם הרשימה מופיעה ברצף החל מהחוליה הנתונה
        private static bool StartsWith(Node<int> start, Node<int> lst1)
        {
            while (lst1 != null && start != null && lst1.GetValue() == start.GetValue())
            {
                lst1 = lst1.GetNext();
                start = start.GetNext();
            }
            return lst1 == null;
        }

        // תרגיל 29
        // האם הרשימה הראשונה מוכלת ברצף בתוך השנייה
        // לכל נקודת התחלה ברשימה השנייה משווים את כל איברי הראשונה
        // n = length of lst1, m = length of lst2
        // Complexity: O(n*m)
        public static bool IsIncludedList(Node<int> lst1, Node<int> lst2)
        {
            if (lst1 == null)
                return true;                         // רשימה ריקה מוכלת בכל רשימה
            Node<int> pos = lst2;
            while (pos != null)
            {
                if (StartsWith(pos, lst1))
                    return true;
                pos = pos.GetNext();
            }
            return false;
        }

        // תרגיל 30
        // האם הרשימה הראשונה מכילה את השנייה
        // כלומר כל איבר של השנייה קיים בראשונה, והסדר לא חשוב
        // לכל איבר של השנייה מחפשים אותו בכל הראשונה
        // n = length of lst1, m = length of lst2
        // Complexity: O(n*m)
        public static bool IsListContains(Node<int> lst1, Node<int> lst2)
        {
            while (lst2 != null)
            {
                if (!Exist(lst1, lst2.GetValue()))
                    return false;
                lst2 = lst2.GetNext();
            }
            return true;
        }
    }
}
