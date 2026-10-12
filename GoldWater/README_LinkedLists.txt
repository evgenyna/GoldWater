// ============================================================================
// תרגילי שרשרת חוליות - הילה קדמן - 1
// Linked List Exercises - Hila Kadman - 1
// ============================================================================

// קובץ: GoldWater\Linked_Lists.cs
// File: GoldWater\Linked_Lists.cs

// ============================================================================
// תיאור התרגילים שיושמו:
// Description of Implemented Exercises:
// ============================================================================

תרגיל 1 - Length (אורך השרשרת)
Exercise 1 - Length
- חישוב מספר הנודים בשרשרת
- Calculate the number of nodes in the linked list
- שימוש: int length = Length(head);

תרגיל 2 - Contains (בדיקה קיום ערך)
Exercise 2 - Contains
- בדיקה האם ערך מסוים קיים בשרשרת
- Check if a specific value exists in the linked list
- שימוש: bool exists = Contains(head, 3);

תרגיל 3 - PrintList (הדפסת השרשרת)
Exercise 3 - PrintList
- הדפסה יפה של כל הערכים בשרשרת
- Pretty print all values in the linked list
- שימוש: PrintList(head);

תרגיל 4 - InsertAtBeginning (הוספה בתחילה)
Exercise 4 - InsertAtBeginning
- הוספת ערך בתחילת השרשרת
- Add value at the beginning of the list
- שימוש: head = InsertAtBeginning(head, 0);

תרגיל 5 - InsertAtEnd (הוספה בסוף)
Exercise 5 - InsertAtEnd
- הוספת ערך בסוף השרשרת
- Add value at the end of the list
- שימוש: head = InsertAtEnd(head, 6);

תרגיל 6 - DeleteFirst (מחיקת ראשון)
Exercise 6 - DeleteFirst
- מחיקת הנוד הראשון בשרשרת
- Delete the first node in the list
- שימוש: head = DeleteFirst(head);

תרגיל 7 - DeleteLast (מחיקת אחרון)
Exercise 7 - DeleteLast
- מחיקת הנוד האחרון בשרשרת
- Delete the last node in the list
- שימוש: head = DeleteLast(head);

תרגיל 8 - FindMax (מציאת מקסימום)
Exercise 8 - FindMax
- מציאת הערך המקסימלי בשרשרת
- Find the maximum value in the list
- שימוש: int max = FindMax(head);

תרגיל 9 - FindMin (מציאת מינימום)
Exercise 9 - FindMin
- מציאת הערך המינימלי בשרשרת
- Find the minimum value in the list
- שימוש: int min = FindMin(head);

תרגיל 10 - SumAll (סכום כל הערכים)
Exercise 10 - SumAll
- חישוב סכום כל הערכים בשרשרת
- Calculate the sum of all values in the list
- שימוש: int sum = SumAll(head);

תרגיל 11 - DeleteAllOccurrences (מחיקת כל ההופעות)
Exercise 11 - DeleteAllOccurrences
- מחיקת כל הנודים בעלי ערך מסוים
- Delete all nodes with a specific value
- שימוש: head = DeleteAllOccurrences(head, 1);

תרגיל 12 - Reverse (הפוך את השרשרת)
Exercise 12 - Reverse
- הפיכת סדר הנודים בשרשרת
- Reverse the order of nodes in the list
- שימוש: head = Reverse(head);

תרגיל 13 - GetValueAtIndex (קבלת ערך ב-index)
Exercise 13 - GetValueAtIndex
- קבלת הערך בנודה במיקום מסוים
- Get the value of the node at a specific index
- שימוש: int value = GetValueAtIndex(head, 2);

תרגיל 14 - IsSorted (בדיקה סידור)
Exercise 14 - IsSorted
- בדיקה האם השרשרת מסודרת בסדר עולה
- Check if the list is sorted in ascending order
- שימוש: bool sorted = IsSorted(head);

תרגיל 15 - FindMedian (מציאת חציון)
Exercise 15 - FindMedian
- מציאת הערך החציוני בשרשרת
- Find the median value in the list
- שימוש: double median = FindMedian(head);

תרגיל 16 - GetNodeAtIndex (קבלת Node ב-index)
Exercise 16 - GetNodeAtIndex
- קבלת הנוד תוך העמדה במיקום מסוים
- Get the node at a specific index
- שימוש: Node<object> node = GetNodeAtIndex(head, 2);

תרגיל 17 - InsertAtIndex (הוספה ב-index)
Exercise 17 - InsertAtIndex
- הוספת ערך במיקום מסוים בשרשרת
- Insert a value at a specific index
- שימוש: head = InsertAtIndex(head, 3, 99);

תרגיל 18 - DeleteAtIndex (מחיקה ב-index)
Exercise 18 - DeleteAtIndex
- מחיקת הנוד במיקום מסוים
- Delete the node at a specific index
- שימוש: head = DeleteAtIndex(head, 2);

// ============================================================================
// איך להריץ את התרגילים:
// How to Run the Exercises:
// ============================================================================

1. הרץ את הפרוגרמה:
   Run the program:
   dotnet run --project GoldWater\GoldWater.csproj

2. או קרא ישירות ל-RunExercises() מהקוד שלך:
   Or call RunExercises() directly from your code:
   Linked_Lists.RunExercises();

3. כל תרגיל יוצג עם דוגמה עם פלט מפורט
   Each exercise is demonstrated with detailed output examples

// ============================================================================
// שימוש בספריה:
// Using the Library:
// ============================================================================

// יצירת שרשרת ריק או עם ערך ראשון
// Create an empty or initial list
Node<object> head = new Node<object>(1);

// הוספה של נתונים נוספים
// Add more data
head.SetNext(new Node<object>(2));
head.GetNext().SetNext(new Node<object>(3));

// שימוש בפונקציות
// Using functions
int length = Linked_Lists.Length(head);
bool contains = Linked_Lists.Contains(head, 2);
Linked_Lists.PrintList(head);
head = Linked_Lists.InsertAtEnd(head, 4);

// וכו'...

// ============================================================================
// הערות חשובות:
// Important Notes:
// ============================================================================

- JSNode<object> משמש ניהול של ערכים מסוג object
  The Node<object> stores values as object type
  תמיד צריך ל-cast לערך הנכון (למשל (int) בדוגמאות שלנו)
  Always cast to the correct type (e.g., (int) in our examples)

- כל הפונקציות הן static ניתן להן לגשת ישירות מהמחלקה
  All functions are static, accessible directly from the class
  לא צריך ליצור instance של Linked_Lists
  No need to create an instance of Linked_Lists

- בדוגמאות התרגיל, זה יוצר שרשרת עם ערכים: 1, 2, 3, 4, 5
  In the exercise demo, it creates a list with values: 1, 2, 3, 4, 5

