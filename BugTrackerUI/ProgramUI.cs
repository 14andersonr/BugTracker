using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTrackerUI
{
    class ProgramUI
    {

        public void RunApp()
        {           
            UserMenu();
        }

        private void UserMenu()
        {
            bool userMenuLoop = true;
            while (userMenuLoop)
            {

                Console.WriteLine("  ****** Bug Tracker ******\n\n");

                Console.Write("  What would you like to do? Enter corresponding number:\n" +
                    "  (1) Projects menu\n" +
                    "  (2) Errors menu\n" +
                    "  (3) Comments menu\n" +
                    "  (4) Exit Program\n\n" +
                    "     Enter number here --> ");

                // Grab user input
                string input = Console.ReadLine();

                //Switch statement for user choice
                switch (input)
                {
                    case "1":                          
                        ProjectsMenu();

                        break;
                    case "2":        
                        ErrorsMenu();
                        break;
                    case "3":                              
                        CommentsMenu();
                        break;
                    case "4":                              
                        Console.WriteLine("\n EXIT PROGRAM");
                        userMenuLoop = false;
                        break;
                    default:                           
                        Console.WriteLine("\n Please choose a valid number option (1 - 4)");
                        break;
                }
                Console.WriteLine("\n Press any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }

        private void ProjectsMenu()
        {
            Console.WriteLine("You've reached the Projects menu");
        }

        private void ErrorsMenu()
        {
            Console.WriteLine("You've reached the Projects menu");
        }

        private void CommentsMenu()
        {
            Console.WriteLine("You've reached the Projects menu");
        }        
    }
}
