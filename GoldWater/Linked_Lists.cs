using System;
using Unit4.CollectionsLib;
using System.Text;

namespace GoldWater
{
    // תרגול שרשרת חוליות - הילה קדמן - 1
    // Linked List Exercises - Hila Kadman - 1
    internal class Linked_Lists
    {
        /// <summary>
        /// תרגיל 1: חישוב אורך השרשרת
        /// Exercise 1: Calculate linked list length
        /// </summary>
        public static int Length(Node<object> head)
        {
            int count = 0;
            Node<object> current = head;
            while (current != null)
            {
                count++;
                current = current.GetNext();
            }
            return count;
        }

        /// <summary>
        /// תרגיל 2: בדיקה האם ערך קיים בשרשרת
        /// Exercise 2: Check if value exists in linked list
        /// </summary>
        public static bool Contains(Node<object> head, int value)
        {
            Node<object> current = head;
            while (current != null)
            {
                if ((int)current.GetValue() == value)
                    return true;
                current = current.GetNext();
            }
            return false;
        }

        /// <summary>
        /// תרגיל 3: הדפסת כל הערכים בשרשרת
        /// Exercise 3: Print all values in linked list
        /// </summary>
        public static void PrintList(Node<object> head)
        {
            Node<object> current = head;
            StringBuilder sb = new StringBuilder();
            while (current != null)
            {
                sb.Append(current.GetValue());
                current = current.GetNext();
                if (current != null)
                    sb.Append(" -> ");
            }
            sb.Append(" -> null");
            Console.WriteLine(sb.ToString());
        }

        /// <summary>
        /// תרגיל 4: הוספת ערך בתחילת השרשרת
        /// Exercise 4: Add value at the beginning of linked list
        /// </summary>
        public static Node<object> InsertAtBeginning(Node<object> head, int value)
        {
            Node<object> newNode = new Node<object>(value);
            newNode.SetNext(head);
            return newNode;
        }

        /// <summary>
        /// תרגיל 5: הוספת ערך בסוף השרשרת
        /// Exercise 5: Add value at the end of linked list
        /// </summary>
        public static Node<object> InsertAtEnd(Node<object> head, int value)
        {
            Node<object> newNode = new Node<object>(value);

            if (head == null)
                return newNode;

            Node<object> current = head;
            while (current.GetNext() != null)
            {
                current = current.GetNext();
            }
            current.SetNext(newNode);
            return head;
        }

        /// <summary>
        /// תרגיל 6: מחיקת הערך הראשון בשרשרת
        /// Exercise 6: Delete first value in linked list
        /// </summary>
        public static Node<object> DeleteFirst(Node<object> head)
        {
            if (head == null)
                return null;
            return head.GetNext();
        }

        /// <summary>
        /// תרגיל 7: מחיקת הערך האחרון בשרשרת
        /// Exercise 7: Delete last value in linked list
        /// </summary>
        public static Node<object> DeleteLast(Node<object> head)
        {
            if (head == null)
                return null;

            if (head.GetNext() == null)
                return null;

            Node<object> current = head;
            while (current.GetNext().GetNext() != null)
            {
                current = current.GetNext();
            }
            current.SetNext(null);
            return head;
        }

        /// <summary>
        /// תרגיל 8: חיפוש ערך מקסימלי בשרשרת
        /// Exercise 8: Find maximum value in linked list
        /// </summary>
        public static int FindMax(Node<object> head)
        {
            if (head == null)
                throw new ArgumentException("Cannot find max in empty list");

            int max = (int)head.GetValue();
            Node<object> current = head.GetNext();

            while (current != null)
            {
                int value = (int)current.GetValue();
                if (value > max)
                    max = value;
                current = current.GetNext();
            }
            return max;
        }

        /// <summary>
        /// תרגיל 9: חיפוש ערך מינימלי בשרשרת
        /// Exercise 9: Find minimum value in linked list
        /// </summary>
        public static int FindMin(Node<object> head)
        {
            if (head == null)
                throw new ArgumentException("Cannot find min in empty list");

            int min = (int)head.GetValue();
            Node<object> current = head.GetNext();

            while (current != null)
            {
                int value = (int)current.GetValue();
                if (value < min)
                    min = value;
                current = current.GetNext();
            }
            return min;
        }

        /// <summary>
        /// תרגיל 10: סכום כל הערכים בשרשרת
        /// Exercise 10: Sum all values in linked list
        /// </summary>
        public static int SumAll(Node<object> head)
        {
            int sum = 0;
            Node<object> current = head;
            while (current != null)
            {
                sum += (int)current.GetValue();
                current = current.GetNext();
            }
            return sum;
        }

        /// <summary>
        /// תרגיל 11: מחיקת כל הערכים השווים לערך נתון
        /// Exercise 11: Delete all values equal to given value
        /// </summary>
        public static Node<object> DeleteAllOccurrences(Node<object> head, int value)
        {
            while (head != null && (int)head.GetValue() == value)
            {
                head = head.GetNext();
            }

            if (head == null)
                return null;

            Node<object> current = head;
            while (current.GetNext() != null)
            {
                if ((int)current.GetNext().GetValue() == value)
                {
                    current.SetNext(current.GetNext().GetNext());
                }
                else
                {
                    current = current.GetNext();
                }
            }
            return head;
        }

        /// <summary>
        /// תרגיל 12: הפוך את השרשרת (Reverse)
        /// Exercise 12: Reverse the linked list
        /// </summary>
        public static Node<object> Reverse(Node<object> head)
        {
            Node<object> prev = null;
            Node<object> current = head;

            while (current != null)
            {
                Node<object> next = current.GetNext();
                current.SetNext(prev);
                prev = current;
                current = next;
            }
            return prev;
        }

        /// <summary>
        /// תרגיל 13: קבלת ערך ב-index מסוים
        /// Exercise 13: Get value at specific index
        /// </summary>
        public static int GetValueAtIndex(Node<object> head, int index)
        {
            if (index < 0)
                throw new ArgumentException("Index cannot be negative");

            Node<object> current = head;
            int currentIndex = 0;

            while (current != null)
            {
                if (currentIndex == index)
                    return (int)current.GetValue();

                current = current.GetNext();
                currentIndex++;
            }
            throw new ArgumentException("Index out of bounds");
        }

        /// <summary>
        /// תרגיל 14: בדיקה האם השרשרת מסודרת בסדר עולה
        /// Exercise 14: Check if linked list is sorted in ascending order
        /// </summary>
        public static bool IsSorted(Node<object> head)
        {
            Node<object> current = head;
            while (current != null && current.GetNext() != null)
            {
                int current_val = (int)current.GetValue();
                int next_val = (int)current.GetNext().GetValue();

                if (current_val > next_val)
                    return false;

                current = current.GetNext();
            }
            return true;
        }

        /// <summary>
        /// תרגיל 15: מציאת חציון בשרשרת
        /// Exercise 15: Find median value in linked list
        /// </summary>
        public static double FindMedian(Node<object> head)
        {
            int length = Length(head);
            if (length == 0)
                throw new ArgumentException("Cannot find median in empty list");

            if (length % 2 == 1)
            {
                // Odd length - return middle element
                return GetValueAtIndex(head, length / 2);
            }
            else
            {
                // Even length - return average of two middle elements
                int val1 = GetValueAtIndex(head, length / 2 - 1);
                int val2 = GetValueAtIndex(head, length / 2);
                return (val1 + val2) / 2.0;
            }
        }

        /// <summary>
        /// תרגיל 16: מציאת Node ב-index מסוים
        /// Exercise 16: Get node at specific index
        /// </summary>
        public static Node<object> GetNodeAtIndex(Node<object> head, int index)
        {
            if (index < 0)
                throw new ArgumentException("Index cannot be negative");

            Node<object> current = head;
            int currentIndex = 0;

            while (current != null)
            {
                if (currentIndex == index)
                    return current;

                current = current.GetNext();
                currentIndex++;
            }
            throw new ArgumentException("Index out of bounds");
        }

        /// <summary>
        /// תרגיל 17: הוספת ערך ב-index מסוים
        /// Exercise 17: Insert value at specific index
        /// </summary>
        public static Node<object> InsertAtIndex(Node<object> head, int index, int value)
        {
            if (index < 0)
                throw new ArgumentException("Index cannot be negative");

            if (index == 0)
                return InsertAtBeginning(head, value);

            Node<object> prev = GetNodeAtIndex(head, index - 1);
            Node<object> newNode = new Node<object>(value);
            newNode.SetNext(prev.GetNext());
            prev.SetNext(newNode);

            return head;
        }

        /// <summary>
        /// תרגיל 18: מחיקת ערך ב-index מסוים
        /// Exercise 18: Delete value at specific index
        /// </summary>
        public static Node<object> DeleteAtIndex(Node<object> head, int index)
        {
            if (index < 0)
                throw new ArgumentException("Index cannot be negative");

            if (index == 0)
                return DeleteFirst(head);

            Node<object> prev = GetNodeAtIndex(head, index - 1);
            if (prev.GetNext() != null)
            {
                prev.SetNext(prev.GetNext().GetNext());
            }
            return head;
        }

        // ============= Demo/Test Method =============
        /// <summary>
        /// להרצה - קרא ל- RunExercises() מתוך Main או כל מקום אחר
        /// To run - call RunExercises() from Main or any other place
        /// </summary>
        public static void RunExercises()
        {
            Console.OutputEncoding = Encoding.UTF8;

            // יצירת שרשרת דוגמה: 1 -> 2 -> 3 -> 4 -> 5
            // Create example list: 1 -> 2 -> 3 -> 4 -> 5
            Node<object> head = new Node<object>(1);
            head.SetNext(new Node<object>(2));
            head.GetNext().SetNext(new Node<object>(3));
            head.GetNext().GetNext().SetNext(new Node<object>(4));
            head.GetNext().GetNext().GetNext().SetNext(new Node<object>(5));

            Console.WriteLine("\n========== תרגילי שרשרת חוליות ==========");
            Console.WriteLine("========== Linked List Exercises ==========\n");

            // תרגיל 1: אורך השרשרת
            Console.WriteLine("תרגיל 1 - אורך השרשרת:");
            Console.WriteLine("Exercise 1 - List Length:");
            Console.WriteLine($"Length: {Length(head)}\n");

            // תרגיל 2: בדיקה קיום ערך
            Console.WriteLine("תרגיל 2 - בדיקה קיום ערך:");
            Console.WriteLine("Exercise 2 - Contains Value:");
            Console.WriteLine($"Contains 3: {Contains(head, 3)}");
            Console.WriteLine($"Contains 10: {Contains(head, 10)}\n");

            // תרגיל 3: הדפסת השרשרת
            Console.WriteLine("תרגיל 3 - הדפסת השרשרת:");
            Console.WriteLine("Exercise 3 - Print List:");
            Console.Write("Original list: ");
            PrintList(head);
            Console.WriteLine();

            // תרגיל 4: הוספה בתחילה
            Console.WriteLine("תרגיל 4 - הוספה בתחילה:");
            Console.WriteLine("Exercise 4 - Insert at Beginning:");
            head = InsertAtBeginning(head, 0);
            Console.Write("After inserting 0 at beginning: ");
            PrintList(head);
            Console.WriteLine();

            // תרגיל 5: הוספה בסוף
            Console.WriteLine("תרגיל 5 - הוספה בסוף:");
            Console.WriteLine("Exercise 5 - Insert at End:");
            head = InsertAtEnd(head, 6);
            Console.Write("After inserting 6 at end: ");
            PrintList(head);
            Console.WriteLine();

            // תרגיל 10: סכום
            Console.WriteLine("תרגיל 10 - סכום כל הערכים:");
            Console.WriteLine("Exercise 10 - Sum All Values:");
            Console.WriteLine($"Sum: {SumAll(head)}\n");

            // תרגיל 8 ו-9: מקס ומינימום
            Console.WriteLine("תרגיל 8 & 9 - מקסימום ומינימום:");
            Console.WriteLine("Exercise 8 & 9 - Max and Min:");
            Console.WriteLine($"Max: {FindMax(head)}");
            Console.WriteLine($"Min: {FindMin(head)}\n");

            // תרגיל 14: בדיקה סידור
            Console.WriteLine("תרגיל 14 - בדיקה סידור:");
            Console.WriteLine("Exercise 14 - Is Sorted:");
            Console.WriteLine($"Is sorted: {IsSorted(head)}\n");

            // תרגיל 15: חציון
            Console.WriteLine("תרגיל 15 - חציון:");
            Console.WriteLine("Exercise 15 - Median:");
            Console.WriteLine($"Median: {FindMedian(head)}\n");

            // תרגיל 12: הפוך
            Console.WriteLine("תרגיל 12 - הפוך את השרשרת:");
            Console.WriteLine("Exercise 12 - Reverse List:");
            head = Reverse(head);
            Console.Write("After reversing: ");
            PrintList(head);
            Console.WriteLine();

            // תרגיל 17: הוספה ב-index
            Console.WriteLine("תרגיל 17 - הוספה ב-index:");
            Console.WriteLine("Exercise 17 - Insert at Index:");
            head = InsertAtIndex(head, 3, 99);
            Console.Write("After inserting 99 at index 3: ");
            PrintList(head);
            Console.WriteLine();

            // תרגיל 11: מחיקת כל ההופעות
            Console.WriteLine("תרגיל 11 - מחיקת כל ההופעות:");
            Console.WriteLine("Exercise 11 - Delete All Occurrences:");
            head = InsertAtBeginning(head, 1);
            head = InsertAtBeginning(head, 1);
            Console.Write("List with duplicates (1,1,...): ");
            PrintList(head);
            head = DeleteAllOccurrences(head, 1);
            Console.Write("After deleting all 1's: ");
            PrintList(head);
            Console.WriteLine();

            // תרגיל 1: אורך סופי
            Console.WriteLine("תרגיל 1 - אורך סופי:");
            Console.WriteLine("Exercise 1 - Final Length:");
            Console.WriteLine($"Final length: {Length(head)}\n");

            Console.WriteLine("\n========== סיום התרגילים ==========");
            Console.WriteLine("========== End of Exercises ==========");
        }
    }
}
