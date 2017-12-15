using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkalProj_Datastrukturer_Minne
{
    class Program
    {
        /// <summary>
        /// The main method, vill handle the menues for the program
        /// </summary>
        /// <param name="args"></param>

        static void Main()
        {
            // bool run = true;

            while (true)
            {

                Console.WriteLine("Please navigate through the menu by inputting the number \n(1, 2, 3 ,4, 0) of your choice"
                    + "\n1. Examine a List"
                    + "\n2. Examine a Queue"
                    + "\n3. Examine a Stack"
                    + "\n4. CheckParanthesis"
                    + "\n0. Exit the application");
                char input = ' '; //Creates the character input to be used with the switch-case below.
                try
                {
                    input = Console.ReadLine()[0]; //Tries to set input to the first char in an input line
                }
                catch (IndexOutOfRangeException) //If the input line is empty, we ask the users for some input.
                {
                    Console.Clear();
                    Console.WriteLine("Please enter some input!");
                }
                switch (input)
                {
                    case '1':
                        ExamineList();
                        break;
                    case '2':
                        ExamineQueue();
                        break;
                    case '3':
                        ExamineStack();
                        break;
                    case '4':
                        CheckParanthesis();
                        break;
                    /*
                     * Extend the menu to include the recursive 
                     * and iterative exercises.
                     */
                    case '0':
                        return;
                    default:
                        Console.WriteLine("Please enter some valid input (0, 1, 2, 3, 4)");
                        break;
                }
            }
        }

        /// <summary>
        /// Examines the datastructure List
        /// </summary>
        static void ExamineList()
        {
            /*
             * Loop this method untill the user inputs something to exit to main menue.
             * Create a switch statement with cases '+' and '-'
             * '+': Add the rest of the input to the list (The user could write +Adam and "Adam" would be added to the list)
             * '-': Remove the rest of the input from the list (The user could write -Adam and "Adam" would be removed from the list)
             * In both cases, look at the count and capacity of the list
             * As a default case, tell them to use only + or -
             * Below you can see some inspirational code to begin working.
            */
            List<string> theList = new List<string>();
            string input;

            do
            {
                Console.WriteLine("\nAdd or Remove a name to/from the list by\n putting a \"+/-\"-sign \nin front of the name you want to add/remove and then press [ENTER], or press \"0\" to exit.");
                input = Console.ReadLine();
                char nav = input[0];
                string value = input.Substring(1);

                switch (nav)
                {
                    case '+':
                        {
                            theList.Add(value);
                            Console.WriteLine(value + "was added to the list.");
                            Console.WriteLine("List count: " + theList.Count + " .List capacity: " + theList.Capacity);
                            break;
                        }
                    case '-':
                        {
                            int p = theList.Count;

                            if (theList.Count > 0)
                            {
                                for (var i = 0; i < theList.Count; i++)
                                {
                                    if (theList[i] == value)
                                    {
                                        theList.Remove(theList[i]);
                                        Console.WriteLine(i + " is removed from the list.");
                                    }
                                }
                            }

                            if (theList.Count == p)
                            {
                                Console.WriteLine("The list does not contain the name: " + value + ".");
                            }

                            Console.WriteLine("List count: " + theList.Count + " .List capacity: " + theList.Capacity);


                            break;
                        }

                    case '0':
                        {
                            Console.WriteLine();
                            break;
                        }

                    default:
                        {
                            Console.WriteLine("Use only \"+\" or \"-\", or \"0\" to exit.");
                            break;
                        }

                }

            } while (input != "0");
        }

        /// <summary>
        /// Examines the datastructure Queue
        /// </summary>
        static void ExamineQueue()
        {
            /*
             * Loop this method untill the user inputs something to exit to main menue.
             * Create a switch with cases to enqueue items or dequeue items
             * Make sure to look at the queue after Enqueueing and Dequeueing to see how it behaves
            */

            Queue myQ = new Queue();

            Console.WriteLine("\n\nIca öppnar och kön till kassan är tom.\n");
            bool run = true;

            while (true)
            {
                int ant = 0;
                Console.Write("Skriv \"enqueue\" och [ENTER] för att ställa någon i kön,\neller \"dequeue\" och [ENTER] för att ta bort någon ur kön;\n\"exit\" och [ENTER] för att gå tillbaka till main menu: ");
                var ica = Console.ReadLine();

                ica = ica.ToLower();

                switch (ica)
                {

                    case "enqueue":
                        {
                            Console.Write("\nNamn: ");
                            string name = Console.ReadLine();

                            myQ.Enqueue(name);

                            ant++;
                            Console.WriteLine("\n" + name + " ställer sig i kön.\n");

                            break;
                        }

                    case "dequeue":
                        {
                            if (myQ.Count > 0)
                            {
                                Console.WriteLine("\n" + myQ.Peek() + " blir expedierad och lämnar kön.\n");
                                myQ.Dequeue();
                                ant--;
                            }
                            else
                            {
                                Console.WriteLine("\nListan är tom.\n");
                            }

                            break;
                        }
                    case "exit":
                        {
                            run = false;
                            break;
                        }

                    default:
                        {
                            Console.WriteLine("\nDu angav ingen operation. Försök igen.\n");
                            break;
                        }
                }

                if (run == false)
                {
                    Console.WriteLine("\n");
                    break;
                }


                if (myQ.Count == 0 && ant > 0)
                {
                    Console.WriteLine("Kön är tom och ICA stänger.\n");
                    break;
                }



            }
        }

        /// <summary>
        /// Examines the datastructure Stack
        /// </summary>
        static void ExamineStack()
        {
            /*
             * Loop this method until the user inputs something to exit to main menue.
             * Create a switch with cases to push or pop items
             * Make sure to look at the stack after pushing and and poping to see how it behaves
             */

            Stack myQ = new Stack();

            Console.WriteLine("\n\nIca öppnar och kön till kassan är tom.\n");
            bool run = true;
            int ant = 0;
            while (true)
            {

                Console.Write("Skriv \"push\" och [ENTER] för att ställa någon i kön,\neller \"pop\" och [ENTER] för att ta bort sista tillagda personen ur kön;\n\"ReverseText\" och [ENTER] - ReverseText;\n\"exit\" och [ENTER] för att gå tillbaka till main menu: ");
                var ica = Console.ReadLine();

                ica = ica.ToLower();

                switch (ica)
                {

                    case "push":
                        {
                            Console.Write("\nNamn: ");
                            string name = Console.ReadLine();

                            myQ.Push(name);

                            ant++;
                            Console.WriteLine("\n" + name + " ställer sig i kön.\n");

                            break;
                        }

                    case "pop":
                        {
                            if (myQ.Count > 0)
                            {
                                Console.WriteLine("\n" + myQ.Peek() + " blir expedierad och lämnar kön.\n");
                                myQ.Pop();
                                ant--;

                                if (ant == 0)
                                    Console.WriteLine("Listan är tom.\n");

                            }
                            else
                            {
                                Console.WriteLine("\nListan är tom.\n");
                            }

                            break;
                        }

                    case "reversetext":
                        {
                            ReverseText();
                            break;
                        }

                    case "exit":
                        {
                            run = false;
                            break;
                        }

                    default:
                        {
                            Console.WriteLine("\nDu angav ingen operation. Försök igen.\n");
                            break;
                        }
                }

                if (run == false)
                {
                    Console.WriteLine("\n");
                    break;
                }


                if (myQ.Count == 0 && ant > 0)
                {
                    Console.WriteLine("Kön är tom och ICA stänger.\n");
                    break;
                }

            }

        }


        static void ReverseText()
        {
            Console.Write("\nSkriv ett namn: ");
            var str = Console.ReadLine();

            Stack rts = new Stack();

            Console.WriteLine();
            foreach (var d in str)
                rts.Push(d);

            Console.Write("The reversed name of " + str + " is: ");
            foreach (var d in rts)
                Console.Write(d);

            Console.WriteLine("\n");

        }


        static void CheckParanthesis()
        {
            /*
             * Use this method to check if the paranthesis in a string is Correct or incorrect.
             * Example of correct: (()), {}, [({})]
             * Example of incorrect: (()]), [), {[()}]
             */

            // //  //  //
            string str;
            while (true)
            {
                Console.Write("\nAnge en sträng: ");                                                     // " [ { ( ) }  ( [ [ ]  ]   )  [  {     }  (   )  ]   ]"
                str = Console.ReadLine(); //" ( ( ) ) ) ( ( ( ) ) "; // Console.ReadLine();            

                if (string.IsNullOrWhiteSpace(str))
                    Console.Write("\nDu har angett en tom sträng. Försök igen.\n");
                else break;
            }

            List<char> St = new List<char>();
            bool bol = false;
           
            foreach (var z in str)   
            {
                    if (z == '(' || z == '[' || z == '{' || z == ')' || z == ']' || z == '}')
                    {
                        if (z == '(' || z == '[' || z == '{')
                       {
                            bol = true;
                            St.Add(z);
                       }
                        else if (bol == true)
                       {               
                        if (St.Count > 0) 
                          {
                            if (St[St.Count-1] == '(' && z == ')' || St[St.Count - 1] == '[' && z == ']' || St[St.Count - 1] == '{' && z == '}')
                                St.RemoveAt(St.Count - 1);
                          }
                        else
                          {
                            bol = false;
                            break;
                          }  
                        }
                        else break;
                    }
              }
          
            if (St.Count == 0 && bol == true)
                Console.WriteLine("\nSträngen är välformad!\n");
            else
                Console.WriteLine("\nSträngen är inte Välformad.\n");     
        }
    }
}