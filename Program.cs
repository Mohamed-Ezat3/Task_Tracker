using System;
using System.Collections;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;

namespace Task_Tracker
{
    internal class Program
    {
        static List<ArrayList> AllTasks = new List<ArrayList>();

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome");
            Console.WriteLine("................................");
            while (true)
            {
                Console.WriteLine("Enter your choice from 1 to 5");
                Console.WriteLine("1. Add task \n2. Update Task \n3. View tasks \n4. Delete task \n5. Exit");
                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        AddTask();
                        break;
                    case 2:
                        UpdateTask();
                        break;
                    case 3:
                        if (AllTasks.Count == 0)
                        {
                            Console.WriteLine("There are no tasks to view.");
                        }
                        else
                        {
                            ViewAllTasks();
                        }

                        break;
                    case 4:
                        if (AllTasks.Count == 0)
                        {
                            Console.WriteLine("There are no tasks to delete.");
                        }
                        else
                        {
                            DeleteTask();
                        }
                        break;
                    case 5:
                        Console.WriteLine("Are you sure you want to exit? (Y/N)");
                        if (Console.ReadLine().ToUpper() == "Y")
                            Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Enter a number from 1 to 5 only.");
                        break;

                }
                Console.WriteLine("Press Enter to return to the menu.");
                Console.ReadLine();
            }
        }
        static void AddTask()
        {
            Console.Write("Enter Task Title: ");
            string title = Console.ReadLine();
            Console.Write("Enter Task Description: ");
            string description = Console.ReadLine();
            Console.Write("Enter Due Date (yyyy-MM-dd): ");
            DateTime dueDate = DateTime.Parse(Console.ReadLine());
            Console.Write("Enter Priority (Low, Medium, High): ");
            string priority = Console.ReadLine();

            var task = new ArrayList();
            task.Add(title);
            task.Add(description);
            task.Add(dueDate);
            task.Add(priority);
            // The default status of the task.
            task.Add("pending");
            AllTasks.Add(task);
            Console.WriteLine("Task added successfully!");
        }
        static void UpdateTask()
        {
            Console.WriteLine("Enter the number of the task you want to update.");
            ViewAllTasks();
            int choice = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter new status (pending, in progress, completed)");
            string newStatus = Console.ReadLine();
            var task = AllTasks[choice - 1];
            // index 4 = task status
            task[4] = newStatus;
        }
        static void ViewAllTasks()
        {
            int taskIndex = 1;
            foreach (ArrayList task in AllTasks)
            {
                // index 0 = task title , index 4 = task status
                Console.WriteLine($"Task {taskIndex}. {task[0]}  {task[4]}");
                taskIndex++;
            }
        }
        static void DeleteTask()
        {
            Console.WriteLine("Enter the number of the task you want to delete.");
            ViewAllTasks();
            int choice = int.Parse(Console.ReadLine());
            if (choice > 0 && choice <= AllTasks.Count)
            {
                AllTasks.RemoveAt(choice - 1);
                Console.WriteLine("Task deleted successfully!");
            }
            else
            {
                Console.WriteLine($"Invalid choice. Enter a number from {1} to {AllTasks.Count}");
                DeleteTask();
            }
        }
    }
}
