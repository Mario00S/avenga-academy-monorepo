# Loops and Arrays Homework

Practice homework for **C# Class 03: Loops and Arrays**

## Objective
This homework is designed to help you practice:
- `for` loops
- `while` loops
- `do-while` loops
- `foreach` loops
- arrays
- array methods
- combining loops with arrays
- console input and output

## Instructions
- Solve the tasks in order, from easier to harder.
- Try to solve each task without looking at solutions first.
- Write clean and readable code.
- Test your code with different inputs.
- You can create:
  - one project per task, or
  - one project with separate code blocks / methods for each task

## Suggested Naming
You can organize your files or folders like this:

- `Task01_CountToN`
- `Task02_CountBackwards`
- `Task03_EvenNumbers`
- `Task04_OddNumbers`
- `Task05_SkipDivisible`
- `Task06_StopAt100`
- `Task07_ValidInput`
- `Task08_SumToN`
- `Task09_MultiplicationTable`
- `Task10_NumberStatistics`
- `Task11_CreateArrays`
- `Task12_IntegerArrayInput`
- `Task13_SumArrayElements`
- `Task14_MaxValue`
- `Task15_MinValue`
- `Task16_CountEvenInArray`
- `Task17_ReversePrint`
- `Task18_SearchName`
- `Task19_ResizeArray`
- `Task20_CalculateAverage`
- `Task21_EnterNamesUntilStop`
- `Task22_CompareTwoArrays`
- `Task23_SeparateEvenOdd`
- `Task24_NameSearchUntilFound`
- `Task25_StarPattern`
- `Task26_ArrayPalindrome`
- `Task27_UniqueValues`

## Part 1: Basic Loops

- [ ] **Task 1: Count from 1 to N**  
Ask the user to enter a number. Print all numbers from `1` to that number.  
Use a `for` loop.

- [ ] **Task 2: Count Backwards**  
Ask the user to enter a number. Print all numbers from that number down to `1`.  
Use a `while` loop.

- [ ] **Task 3: Print Even Numbers**  
Ask the user to enter a number. Print all even numbers from `2` up to that number.

- [ ] **Task 4: Print Odd Numbers**  
Ask the user to enter a number. Print all odd numbers from `1` up to that number.

## Part 2: Loop Control

- [ ] **Task 5: Skip Divisible Numbers**  
Ask the user to enter a number. Print all numbers from `1` to that number, except numbers divisible by `3` or `7`.  
Use `continue`.

- [ ] **Task 6: Stop at 100**  
Ask the user to enter a number. Print numbers from `1` up to that number.  
If the counter reaches `100`, print `The limit is reached` and stop the loop.  
Use `break`.

- [ ] **Task 7: Valid Input with Do-While**  
Ask the user to enter a number between `1` and `10`.  
Keep asking until the user enters a valid number.  
Use a `do-while` loop.

## Part 3: More Loop Practice

- [ ] **Task 8: Sum of Numbers**  
Ask the user to enter a number. Calculate and print the sum of all numbers from `1` to that number.

- [ ] **Task 9: Multiplication Table**  
Ask the user to enter a number. Print the multiplication table for that number from `1` to `10`.

- [ ] **Task 10: Number Statistics**  
Ask the user to enter `5` numbers one by one. At the end, print:
  - how many are even
  - how many are odd
  - the total sum

Do not use an array in this task.

## Part 4: Arrays

- [ ] **Task 11: Create Arrays**  
Declare the following arrays:
  - an array of `5` words
  - an array of `5` decimal numbers
  - an array of `5` characters
  - an array of `5` boolean values

Then print all elements from each array.  
Use `foreach` at least once.

- [ ] **Task 12: Integer Array Input**  
Create an integer array with `5` elements.  
Ask the user to enter `5` integers and store them in the array.  
Then print all values.

- [ ] **Task 13: Sum Array Elements**  
Create an integer array with `5` elements.  
Fill it with values from the user.  
Calculate and print the sum of all elements.

- [ ] **Task 14: Find the Largest Value**  
Create an integer array with `5` elements.  
Fill it from user input.  
Find and print the largest value.

- [ ] **Task 15: Find the Smallest Value**  
Create an integer array with `5` elements.  
Fill it from user input.  
Find and print the smallest value.

## Part 5: Array Logic

- [ ] **Task 16: Count Even Numbers in an Array**  
Create an integer array with `6` elements.  
Fill it with user input.  
Count how many values are even.

- [ ] **Task 17: Reverse Printing**  
Create an array of names with `5` elements.  
Print the elements in reverse order.  
Use a `for` loop.

- [ ] **Task 18: Search for a Value**  
Create an array of names.  
Ask the user to enter a name.  
Check whether that name exists in the array.  
Print:
  - the index if found
  - `Name not found` if it does not exist

**Bonus:** solve it:
  - once with `Array.IndexOf()`
  - once manually with a loop

- [ ] **Task 19: Resize an Array**  
Create an array with `3` names.  
Resize it to `5`.  
Ask the user to enter `2` more names.  
Print all names at the end.  
Use `Array.Resize()`.

## Part 6: Loops and Arrays Together

- [ ] **Task 20: Calculate Average**  
Ask the user how many numbers they want to enter.  
Create an array with that size.  
Store all numbers in the array.  
Calculate and print:
  - the sum
  - the average

- [ ] **Task 21: Enter Names Until Stop**  
Create a string array with `10` elements.  
Ask the user to enter names one by one.  
After each name, ask: `Do you want to continue? Y/N`

Stop when:
  - the user enters `N`
  - or the array becomes full

Then print only the entered names.

- [ ] **Task 22: Compare Two Arrays**  
Create two integer arrays with `5` elements each.  
Ask the user to fill both arrays.  
Compare them and count how many elements at the same index are equal.

**Example:**
- First array: `1, 2, 3, 4, 5`
- Second array: `1, 9, 3, 8, 5`

Expected result:  
`Matching positions: 3`

- [ ] **Task 23: Separate Even and Odd Values**  
Ask the user to enter `5` integers into an array.  
Then print:
  - all even numbers
  - all odd numbers

- [ ] **Task 24: Name Search Until Found**  
Create an array with several names.  
Keep asking the user to enter a name until they enter one that exists in the array.  
Use a loop and stop only when the name is found.

## Part 7: Challenge Tasks

- [ ] **Task 25: Star Pattern**  
Ask the user for a number and print a pattern like this for input `5`:

```text
*
**
***
****
*****
