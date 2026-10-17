using System;
using Unit4.CollectionsLib;
using System.Text;

namespace GoldWater
{
    /// <summary>
    /// מחלקת שירות לטיפול בשרשרת חוליות (רשימה) - פתרונות לדף התרגול של הילה קדמן
    /// הערה: פעולות שעלולות לשנות את ראש הרשימה (מחיקה, הכנסה ממויינת, שרשור)
    /// מחזירות את ראש הרשימה החדש, וצריך לקלוט אותו: lst = ListInt.Delete(lst, 5);
    /// </summary>
    public class ListInt
    {
        private static Random rnd = new Random();

        // =====================================================================
        //                        בנייה והצגת רשימה
        // =====================================================================

        // תרגיל 1 - בנייה מקלט של המשתמש (לפחות 10 איברים)
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

        // תרגיל 2 - בנייה של len מספרים אקראיים בין from ל-to (כולל)
        // לדוגמה: Build(12, 5, 20)
        public static Node<int> Build(int len, int from, int to)
        {
            Node<int> first = null;
            for (int i = 0; i < len; i++)
                first = new Node<int>(rnd.Next(from, to + 1), first); // הוספה בראש - הסדר אקראי ממילא
            return first;
        }

        // תרגיל 3 - בנייה ממערך, באותו סדר
        public static Node<int> Build(int[] arr)
        {
            Node<int> first = null;
            for (int i = arr.Length - 1; i >= 0; i--)   // מהסוף להתחלה + הוספה בראש = אותו סדר
                first = new Node<int>(arr[i], first);
            return first;
        }

        // תרגיל 4 - הצגה בפורמט [x0, x1, ..., xn]
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

        // תרגיל 6 - האם x קיים ברשימה. סיבוכיות: O(n)
        public static bool Exist(Node<int> lst, int x)
        {
            return GetPosition(lst, x) != null;
        }

        // תרגיל 7 - הפניה לחוליה הראשונה שערכה x, או null. סיבוכיות: O(n)
        public static Node<int> GetPosition(Node<int> lst, int x)
        {
            Node<int> pos = lst;
            while (pos != null && pos.GetValue() != x)
                pos = pos.GetNext();
            return pos;
        }

        // תרגיל 8 - עדכון המופע הראשון של x להיות y. סיבוכיות: O(n)
        public static void Update(Node<int> lst, int x, int y)
        {
            Node<int> pos = GetPosition(lst, x);
            if (pos != null)
                pos.SetValue(y);
        }

        // תרגיל 9 - הפניה לאיבר המקסימלי (הראשון מביניהם). סיבוכיות: O(n)
        public static Node<int> GetMax(Node<int> lst)
        {
            if (lst == null)
                return null;
            Node<int> max = lst;
            Node<int> pos = lst.GetNext();
            while (pos != null)
            {
                if (pos.GetValue() > max.GetValue())   // > ולא >= כדי לשמור על הראשון
                    max = pos;
                pos = pos.GetNext();
            }
            return max;
        }

        // תרגיל 10א - אורך רשימה
        // 10ב - סיבוכיות: O(n), עוברים פעם אחת על כל n האיברים
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

        // תרגיל 10א - החלפת האיבר במקום p עם העוקב לו. אם אין עוקב - לא קורה דבר
        // 10ב - סיבוכיות: O(1), מספר קבוע של פעולות שאינו תלוי באורך הרשימה
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

        // תרגיל 11 - מחיקת המופע הראשון של x. מחזירה את ראש הרשימה (אולי השתנה)
        // סיבוכיות: O(n) - במקרה הגרוע עוברים על כל הרשימה
        public static Node<int> Delete(Node<int> lst, int x)
        {
            if (lst == null)
                return null;
            if (lst.GetValue() == x)          // מחיקת הראש
                return lst.GetNext();

            Node<int> prev = lst;
            while (prev.HasNext() && prev.GetNext().GetValue() != x)
                prev = prev.GetNext();
            if (prev.HasNext())               // נמצא - מדלגים על החוליה
                prev.SetNext(prev.GetNext().GetNext());
            return lst;
        }

        // תרגיל 12 - מחיקת כל המופעים של x. מחזירה את ראש הרשימה
        // סיבוכיות: O(n) - מעבר אחד על הרשימה
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
                    prev.SetNext(prev.GetNext().GetNext()); // לא מתקדמים - אולי גם הבא למחיקה
                else
                    prev = prev.GetNext();
            }
            return lst;
        }

        // תרגיל 14 - צמצום רצפים: [2,3,3,3,4,5,5,2,2,2,7,3,3] -> [2,3,4,5,2,7,3]
        // הראש לעולם לא נמחק, לכן אין צורך להחזיר אותו
        // סיבוכיות: O(n) - מעבר אחד, כל איבר נבדק מול העוקב שלו
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

        // תרגיל 15 - השארת המופע הראשון בלבד של כל ערך
        // [3,6,2,9,2,6,5,3,2,5] -> [3,6,2,9,5]
        // סיבוכיות: O(n^2) - עבור כל איבר מבצעים DelX על המשך הרשימה, O(n) כל אחד
        public static void NoRepeat(Node<int> lst)
        {
            Node<int> pos = lst;
            while (pos != null)
            {
                // מוחקים את הערך הנוכחי מכל המשך הרשימה (אחריו)
                pos.SetNext(DelX(pos.GetNext(), pos.GetValue()));
                pos = pos.GetNext();
            }
        }

        // =====================================================================
        //                           שרשור רשימות
        // =====================================================================

        // פעולת עזר - העתקה של רשימה (חוליות חדשות). O(n)
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

        // פעולת עזר - החוליה האחרונה ברשימה. O(n)
        public static Node<int> GetLast(Node<int> lst)
        {
            if (lst == null)
                return null;
            while (lst.HasNext())
                lst = lst.GetNext();
            return lst;
        }

        // תרגיל 20 - רשימה שלישית חדשה, שתי הרשימות ללא שינוי. O(n+m)
        public static Node<int> ConcatNew(Node<int> lst1, Node<int> lst2)
        {
            Node<int> copy1 = Copy(lst1);
            Node<int> copy2 = Copy(lst2);
            if (copy1 == null)
                return copy2;
            GetLast(copy1).SetNext(copy2);
            return copy1;
        }

        // תרגיל 21 (שרשור) - הראשונה מכילה הכל, השנייה ללא שינוי.
        // מחזירה את ראש הרשימה הראשונה (אם היא הייתה ריקה - הראש משתנה). O(n+m)
        public static Node<int> ConcatToFirst(Node<int> lst1, Node<int> lst2)
        {
            Node<int> copy2 = Copy(lst2);       // העתק - כדי שהשנייה לא תשותף ולא תשתנה
            if (lst1 == null)
                return copy2;
            GetLast(lst1).SetNext(copy2);
            return lst1;
        }

        // תרגיל 22 (שרשור) - הראשונה מכילה הכל, השנייה ריקה.
        // לא יוצרים חוליות חדשות: מחברים את החוליות של השנייה לסוף הראשונה,
        // ו-lst2 של הקורא מתאפס (ref) - כך הרשימה השנייה ריקה.
        // סיבוכיות: O(n) - רק מעבר עד סוף הרשימה הראשונה
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
        //                          רשימות ממויינות
        // =====================================================================

        // תרגיל 21א - הכנסה ממויינת (סדר עולה). מחזירה את ראש הרשימה. O(n)
        public static Node<int> InsertSorted(Node<int> lst, int x)
        {
            if (lst == null || x <= lst.GetValue())    // הכנסה בראש
                return new Node<int>(x, lst);

            Node<int> prev = lst;
            while (prev.HasNext() && prev.GetNext().GetValue() < x)
                prev = prev.GetNext();
            prev.SetNext(new Node<int>(x, prev.GetNext()));
            return lst;
        }

        // תרגיל 21א - בניית רשימה ממויינת ממערך. O(n^2)
        public static Node<int> BuildSorted(int[] arr)
        {
            Node<int> lst = null;
            for (int i = 0; i < arr.Length; i++)
                lst = InsertSorted(lst, arr[i]);
            return lst;
        }

        // תרגיל 21א - בניית רשימה ממויינת ממספרים אקראיים. O(n^2)
        public static Node<int> BuildSorted(int len, int from, int to)
        {
            Node<int> lst = null;
            for (int i = 0; i < len; i++)
                lst = InsertSorted(lst, rnd.Next(from, to + 1));
            return lst;
        }

        // תרגיל 21ב - רשימת מחרוזות.
        // השינויים: הטיפוס הופך מ-Node<int> ל-Node<string>,
        // וההשוואה (< , <=) מוחלפת ב-CompareTo, כי אין אופרטור < על מחרוזות.
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

        // תרגיל 22א - האם הרשימה ממויינת בסדר עולה. O(n)
        public static bool IsSorted(Node<int> lst)
        {
            if (lst == null)
                return true;                       // רשימה ריקה - ממויינת
            while (lst.HasNext())
            {
                if (lst.GetValue() > lst.GetNext().GetValue())
                    return false;
                lst = lst.GetNext();
            }
            return true;                           // כולל רשימה בת איבר אחד
        }

        // תרגיל 22ב - אותו דבר למחרוזות: Node<string> והשוואה בעזרת CompareTo
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

        // תרגיל 23א - איחוד ממויין עם חזרות (רשימה חדשה). O(n+m)
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
            // העתקת השארית (רק אחת מהן לא ריקה)
            last.SetNext(lst1 != null ? Copy(lst1) : Copy(lst2));
            return dummy.GetNext();
        }

        // תרגיל 23ב - איחוד ממויין ללא חזרות (רשימה חדשה). O(n+m)
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
                else                                // שווים - מכניסים פעם אחת ומתקדמים בשתיהן
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

        // תרגיל 24 - חיתוך של שתי רשימות ממויינות (רשימה חדשה). O(n+m)
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

        // תרגיל 25 - איחוד של שתי רשימות לא ממויינות, ללא חזרות (רשימה חדשה)
        // סיבוכיות: O(n*m) - לכל איבר של lst2 בודקים קיום ב-lst1
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
        // תרגיל 26: רצפים של מספרים חיוביים, כל רצף מסתיים במספר שלילי.
        // המספר השלילי מסמן את סוף הרצף ואינו נספר בו.
        // עבור [2,5,1,7,-4,6,-1,12,3,9,11,4,7,-2,11,-2]:
        // אורכים [4,1,6,1] (בדף כתוב 5 בראשון - נראה כטעות הקלדה), סכומים [15,6,46,11]
        // כל הפעולות בסעיפים א-ד: O(n), מעבר אחד על הרשימה.

        // 26א - מספר הרצפים = מספר המספרים השליליים
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

        // 26ב - אורך הרצף הארוך ביותר
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

        // 26ג - רשימת אורכי הרצפים
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

        // 26ד - רשימת סכומי הרצפים
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

        // תרגיל 27 - אורך הרצף העולה (ממש) הארוך ביותר. O(n)
        // [2,5,7,8,-3,-1,0,2,4,6,5,5,6,7,12] -> 6  (הרצף -3,-1,0,2,4,6)
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

        // תרגיל 26 (השני) א - רשימת-המספרים-העוקבים-המקסימלית (רשימה חדשה)
        // [3,5,6,7,8,-1,0,1,2,3,4,6,7,13,1,2] -> [-1,0,1,2,3,4]
        // 26ב - סיבוכיות: O(n). מעבר אחד למציאת תחילת הרצף ואורכו,
        // ועוד מעבר על הרצף עצמו (לכל היותר n) להעתקתו. O(n)+O(n)=O(n)
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

            // העתקת הרצף הטוב ביותר לרשימה חדשה
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

        // תרגיל 27 (השני) - רשימת תווים, כל מילה מסתיימת ב-'*'.
        // מחזירה הפניה לתחילת המילה הארוכה ביותר (הראשונה אם יש כמה). O(n)
        // לדוגמה: a b * a b c * a *  -> הפניה ל-a של "abc*"
        public static Node<char> LongestWord(Node<char> lst)
        {
            Node<char> best = null, start = lst;
            int bestLen = 0, len = 0;
            Node<char> pos = lst;
            while (pos != null)
            {
                len++;                                 // סופרים כולל הכוכבית
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

        // תרגיל 28 - האם lst1 היא תת-רשימה של lst2 (אותו סדר, לא חייב ברצף)
        // יעילות: O(m) כאשר m אורך lst2 - כל אחד מהמצביעים מתקדם רק קדימה,
        // ו-lst2 נסרקת לכל היותר פעם אחת.
        public static bool IsSubList(Node<int> lst1, Node<int> lst2)
        {
            Node<int> p1 = lst1, p2 = lst2;
            while (p1 != null && p2 != null)
            {
                if (p1.GetValue() == p2.GetValue())
                    p1 = p1.GetNext();               // נמצא - עוברים לאיבר הבא שמחפשים
                p2 = p2.GetNext();
            }
            return p1 == null;                      // כל איברי lst1 נמצאו
        }

        // פעולת עזר: האם lst1 מופיעה ברצף החל מהחוליה start ב-lst2
        private static bool StartsWith(Node<int> start, Node<int> lst1)
        {
            while (lst1 != null && start != null && lst1.GetValue() == start.GetValue())
            {
                lst1 = lst1.GetNext();
                start = start.GetNext();
            }
            return lst1 == null;
        }

        // תרגיל 29 - האם lst1 היא תת-רשימה-מוכלת (ברצף) של lst2
        // יעילות: O(n*m) - לכל אחת מ-m נקודות ההתחלה ב-lst2 משווים עד n איברים של lst1
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

        // תרגיל 30 - האם lst1 מכילה את lst2: כל איבר של lst2 קיים ב-lst1 (הסדר לא חשוב)
        // יעילות: O(n*m) - לכל אחד מ-m איברי lst2 מבצעים Exist על lst1 באורך n
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
