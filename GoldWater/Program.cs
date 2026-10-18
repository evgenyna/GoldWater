using System;
using Unit4.CollectionsLib;
using System.Text;
using ls1 = GoldWater.ListInt;
using ls2 =  GoldWater.ListInt2;
using ls3 = GoldWater.ListInt3;
using sd =  GoldWater.ListSedarot;
using lt = GoldWater.ListTriple;

namespace GoldWater
{
    class Program
    {
        static Random rnd = new Random();

        static void Main(string[] args)
        {
            Node<int> lst = ls1.Build(12, 5, 20);
            ls1.Show(lst);

            //Ex5_BuildAndShow();
            ExSearchAndUpdate();
            //Ex16();
            //Ex17();
            //Ex18();
            //Ex19();
            //ExDeleteExamples();
            //ExConcat();
            //ExSorted();
            //ExMerge();
            Ex26();
            //ExSequences();
            ExSubLists();
            //Console.ReadLine();
            ls2.Test();

            // בניית הרשימה מהדוגמה: 7, 2, 4, 8, 20, 18, 19, 20, 20, 5, -3, 0, 9
            int[] arr = { 7, 2, 4, 8, 20, 18, 19, 20, 20, 5, -3, 0, 9 };
            Node<int> list = ls1.Build(arr);
            Node<int> result = sd.Sedarot(list);
            Title("Sedarot");
            Console.WriteLine("Sidra: " + ls1.ToStr(list));
            Console.WriteLine("Sedarot result: " + ls1 .ToStr(result));

            TestTripleChain();
            ls3.Test();
        }

        static void Title(string s)
        {
            Console.WriteLine();
            Console.WriteLine("===== " + s + " =====");
        }

        //// תרגיל 5
        //// תכנית בדיקה לבנייה ולהצגה
        //static void Ex5_BuildAndShow()
        //{
        //    Title("Ex 5 - Build & Show");

        //    // בנייה מקלט של המשתמש, יש להסיר את סימן ההערה כדי לנסות
        //    // Node<int> fromUser = ListInt.Build();
        //    // ListInt.Show(fromUser);

        //    Node<int> rand = ListInt.Build(12, 5, 20);
        //    Console.Write("Random (12, 5..20): ");
        //    ListInt.Show(rand);

        //    Node<int> fromArr = ListInt.Build(new int[] { 4, 8, 15, 16, 23, 42 });
        //    Console.Write("From array:         ");
        //    ListInt.Show(fromArr);

        //    Console.Write("Empty list:         ");
        //    ListInt.Show(null);
        //}

        // תרגילים 6 עד 10
        // חיפוש ועדכון
        static void ExSearchAndUpdate()
        {
            Title("Ex 6-10 - Search & Update");
            Node<int> lst = ListInt.Build(new int[] { 3, 7, 1, 9, 4, 9, 2 });
            ListInt.Show(lst);

            Console.WriteLine("Exist 4? " + ListInt.Exist(lst, 4));
            Console.WriteLine("Exist 8? " + ListInt.Exist(lst, 8));

            Node<int> pos = ListInt.GetPosition(lst, 1);
            Console.WriteLine("GetPosition(1) -> node value: " + (pos == null ? "null" : pos.GetValue().ToString()));

            ListInt.Update(lst, 7, 70);
            Console.Write("Update 7 -> 70: ");
            ListInt.Show(lst);

            Console.WriteLine("Max: " + ListInt.GetMax(lst).GetValue());
            Console.WriteLine("Length: " + ListInt.Length(lst));

            ListInt.Swap(lst, ListInt.GetPosition(lst, 1));
            Console.Write("Swap node of 1 with next: ");
            ListInt.Show(lst);
        }

        //// תרגיל 16
        //// מחיקת המופע הראשון של מספר אקראי
        //static void Ex16()
        //{
        //    Title("Ex 16 - Delete first occurrence");
        //    Node<int> lst = ListInt.Build(15, 0, 9);
        //    ListInt.Show(lst);
        //    int x = rnd.Next(0, 10);
        //    Console.WriteLine("Delete first " + x + ":");
        //    lst = ListInt.Delete(lst, x);
        //    ListInt.Show(lst);
        //}

        //// תרגיל 17
        //// מחיקת כל המופעים של מספר אקראי
        //static void Ex17()
        //{
        //    Title("Ex 17 - Delete all occurrences");
        //    Node<int> lst = ListInt.Build(15, 0, 9);
        //    ListInt.Show(lst);
        //    int x = rnd.Next(0, 10);
        //    Console.WriteLine("Delete all " + x + ":");
        //    lst = ListInt.DelX(lst, x);
        //    ListInt.Show(lst);
        //}

        //// תרגיל 18
        //// צמצום רצפים
        //static void Ex18()
        //{
        //    Title("Ex 18 - Compress");
        //    Node<int> lst = ListInt.Build(15, 0, 9);
        //    ListInt.Show(lst);
        //    ListInt.Compress(lst);
        //    ListInt.Show(lst);
        //}

        //// תרגיל 19
        //// ללא חזרות
        //static void Ex19()
        //{
        //    Title("Ex 19 - No repeat");
        //    Node<int> lst = ListInt.Build(15, 0, 9);
        //    ListInt.Show(lst);
        //    ListInt.NoRepeat(lst);
        //    ListInt.Show(lst);
        //}

        //// תרגילים 14 ו 15
        //// הדוגמאות מהדף
        //static void ExDeleteExamples()
        //{
        //    Title("Ex 14-15 - Examples from the sheet");
        //    Node<int> a = ListInt.Build(new int[] { 2, 3, 3, 3, 4, 5, 5, 2, 2, 2, 7, 3, 3 });
        //    ListInt.Compress(a);
        //    Console.Write("Compress:  ");
        //    ListInt.Show(a);                 // Expected: [2, 3, 4, 5, 2, 7, 3]

        //    Node<int> b = ListInt.Build(new int[] { 3, 6, 2, 9, 2, 6, 5, 3, 2, 5 });
        //    ListInt.NoRepeat(b);
        //    Console.Write("NoRepeat:  ");
        //    ListInt.Show(b);                 // Expected: [3, 6, 2, 9, 5]
        //}

        //// תרגילים 20 עד 22
        //// שרשור רשימות
        //static void ExConcat()
        //{
        //    Title("Ex 20-22 - Concat");
        //    Node<int> l1 = ListInt.Build(new int[] { 1, 2, 3 });
        //    Node<int> l2 = ListInt.Build(new int[] { 4, 5 });

        //    Node<int> l3 = ListInt.ConcatNew(l1, l2);
        //    Console.WriteLine("20: new = " + ListInt.ToStr(l3) + "  l1 = " + ListInt.ToStr(l1) + "  l2 = " + ListInt.ToStr(l2));

        //    l1 = ListInt.ConcatToFirst(l1, l2);
        //    Console.WriteLine("21: l1 = " + ListInt.ToStr(l1) + "  l2 = " + ListInt.ToStr(l2));

        //    Node<int> m1 = ListInt.Build(new int[] { 10, 20 });
        //    Node<int> m2 = ListInt.Build(new int[] { 30, 40 });
        //    m1 = ListInt.ConcatMove(m1, ref m2);
        //    Console.WriteLine("22: l1 = " + ListInt.ToStr(m1) + "  l2 = " + ListInt.ToStr(m2));
        //}

        //// תרגילים 21 ו 22
        //// רשימות ממוינות
        //static void ExSorted()
        //{
        //    Title("Sorted lists");
        //    Node<int> s = ListInt.BuildSorted(new int[] { 7, 2, 9, 2, 5, 1 });
        //    Console.WriteLine("BuildSorted (array):  " + ListInt.ToStr(s) + "  IsSorted: " + ListInt.IsSorted(s));

        //    Node<int> r = ListInt.BuildSorted(10, 1, 50);
        //    Console.WriteLine("BuildSorted (random): " + ListInt.ToStr(r) + "  IsSorted: " + ListInt.IsSorted(r));

        //    Node<int> u = ListInt.Build(new int[] { 1, 3, 2 });
        //    Console.WriteLine(ListInt.ToStr(u) + "  IsSorted: " + ListInt.IsSorted(u));

        //    Node<string> names = ListInt.BuildSorted(new string[] { "Dana", "Avi", "Yossi", "Ben", "Noa" });
        //    Console.WriteLine("Names: " + ListInt.ToStr(names) + "  IsSorted: " + ListInt.IsSorted(names));
        //}

        //// תרגילים 23 עד 25
        //// מיזוג רשימות
        //static void ExMerge()
        //{
        //    Title("Ex 23-25 - Merge");
        //    Node<int> a = ListInt.Build(new int[] { 1, 3, 5, 7, 9 });
        //    Node<int> b = ListInt.Build(new int[] { 2, 3, 4, 9, 10, 12 });
        //    Console.WriteLine("A = " + ListInt.ToStr(a) + "  B = " + ListInt.ToStr(b));
        //    Console.WriteLine("23a with dup: " + ListInt.ToStr(ListInt.MergeWithDup(a, b)));
        //    Console.WriteLine("23b no dup:   " + ListInt.ToStr(ListInt.MergeNoDup(a, b)));
        //    Console.WriteLine("24 intersect: " + ListInt.ToStr(ListInt.Intersect(a, b)));

        //    Node<int> c = ListInt.Build(new int[] { 8, 1, 6, 3 });
        //    Node<int> d = ListInt.Build(new int[] { 3, 9, 8, 2 });
        //    Console.WriteLine("25 union " + ListInt.ToStr(c) + " + " + ListInt.ToStr(d) + " = " + ListInt.ToStr(ListInt.UnionUnsorted(c, d)));
        //}

        // תרגיל 26 סעיף ה
        // תכנית בדיקה לרצפים
        static void Ex26()
        {
            Title("Ex 26 - Sequences");
            Node<int> lst = ListInt.Build(new int[] { 2, 5, 1, 7, -4, 6, -1, 12, 3, 9, 11, 4, 7, -2, 11, -2 });
            Console.WriteLine("List:    " + ListInt.ToStr(lst));
            Console.WriteLine("Count:   " + ListInt.CountSeq(lst));
            Console.WriteLine("Longest: " + ListInt.MaxSeqLength(lst));
            Console.WriteLine("Lengths: " + ListInt.ToStr(ListInt.SeqLengths(lst)));
            Console.WriteLine("Sums:    " + ListInt.ToStr(ListInt.SeqSums(lst)));
        }

        //// תרגיל 27, תרגיל 26 השני ותרגיל 27 השני
        //// רצף עולה, מספרים עוקבים ומילה ארוכה
        //static void ExSequences()
        //{
        //    Title("Ascending / Consecutive / Longest word");
        //    Node<int> a = ListInt.Build(new int[] { 2, 5, 7, 8, -3, -1, 0, 2, 4, 6, 5, 5, 6, 7, 12 });
        //    Console.WriteLine("Max ascending length: " + ListInt.MaxAscendingLength(a));   // Expected: 6

        //    Node<int> b = ListInt.Build(new int[] { 3, 5, 6, 7, 8, -1, 0, 1, 2, 3, 4, 6, 7, 13, 1, 2 });
        //    Console.WriteLine("Max consecutive: " + ListInt.ToStr(ListInt.MaxConsecutive(b))); // Expected: [-1, 0, 1, 2, 3, 4]

        //    Node<char> w = ListInt.BuildChars("a b * a b c * a *");
        //    Node<char> p = ListInt.LongestWord(w);
        //    Console.WriteLine("Words: " + ListInt.ToStr(w) + "  longest starts at: " + ListInt.ToStr(p));
        //}

        // תרגילים 28 עד 30
        // תת רשימות
        static void ExSubLists()
        {
            Title("Ex 28-30 - Sub lists");
            Node<int> l1 = ListInt.Build(new int[] { 3, 12, 5, 32, 1 });

            Node<int> l2 = ListInt.Build(new int[] { 6, 3, 34, 1, 1, 12, 5, 8, 32, 5, 1 });
            //Console.WriteLine("28 IsSubList:       " + ListInt.IsSubList(l1, l2));          // Expected: True

            //Node<int> l3 = ListInt.Build(new int[] { 3, 12, 5, 1, 6, 3, 12, 5, 32, 1, 11, 5 });
            //Console.WriteLine("29 IsIncludedList:  " + ListInt.IsIncludedList(l1, l3));     // Expected: True
            Console.Write("l1: "); ls1.Show(l1);
            Console.Write("l2: "); ls1.Show(l2);
            Console.WriteLine("29 IsIncludedList:  " + ListInt.IsIncludedList(l1, l2));     // Expected: False

            Node<int> l4 = ListInt.Build(new int[] { 6, 32, 1, 1, 12, 5, 8, 34, 3, 5, 1 });
            Console.Write("l4: "); ls1.Show(l4);
            Console.Write("l1: "); ls1.Show(l1);
            Console.WriteLine("30 IsListContains:  " + ListInt.IsListContains(l4, l1));     // Expected: True
        }

        static void TestTripleChain()
        {
            // בניית L1 מהדוגמה: 2,5,3,7, 2,5,3,7, 2,5,3,7
            int[] arr1 = { 2, 5, 3, 7, 2, 5, 3, 7, 2, 5, 3, 7 };
            Node<int> l1 = new Node<int>(arr1[0]);
            Node<int> last1 = l1;
            for (int i = 1; i < arr1.Length; i++)
            {
                last1.SetNext(new Node<int>(arr1[i]));
                last1 = last1.GetNext();
            }

            // רשימה לבדיקה שאינה משולשת (הספרה 9 שוברת את השליש השלישי)
            int[] arr2 = { 2, 5, 3, 7, 2, 5, 3, 7, 2, 5, 9, 7 };
            Node<int> l2 = new Node<int>(arr2[0]);
            Node<int> last2 = l2;
            for (int i = 1; i < arr2.Length; i++)
            {
                last2.SetNext(new Node<int>(arr2[i]));
                last2 = last2.GetNext();
            }
            Title("Is tripple chain test");
            Console.WriteLine("Sidra L1: " + ls1.ToStr(l1));
            Console.WriteLine("Sidra L2: " + ls1.ToStr(l2));
            Console.WriteLine("L1 - way 1: " + lt.IsTripleChain(l1));   // True
            Console.WriteLine("L1 - way 2: " + lt.IsTripleChain2(l1));  // True
            Console.WriteLine("L2 - way 1: " + lt.IsTripleChain(l2));   // False
            Console.WriteLine("L2 - way 2: " + lt.IsTripleChain2(l2));  // False
        }
    }
}
