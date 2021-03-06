﻿using BugTracker.Data;
using RestSharp;
using RestSharp.Authenticators;
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
            LoginMenu();
        }

        public void LoginMenu()
        {
            bool userMenuLoop = true;
            while (userMenuLoop)
            {

                Console.WriteLine("  ****** Bug Tracker ******\n\n");

                Console.Write("  What would you like to do? Enter corresponding number:\n" +
                    "  (1) Login\n" +
                    "  (2) Register\n" +
                    "  (3) I have a Token to enter!\n" +
                    "  (4) Exit Program\n\n" +
                    "     Enter number here --> ");

                // Grab user input
                string input = Console.ReadLine();

                //Switch statement for user choice
                switch (input)
                {
                    case "1":
                        //Login();
                        break;
                    case "2":
                        Register();
                        break;
                    case "3":
                        //RegisterWithToken();
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
            bool userMenuLoop = true;
            while (userMenuLoop)
            {
                Console.WriteLine("You've reached the Projects menu");

                // Display our options to the user
                Console.WriteLine("Select a menu option:\n" +
                    "1. Create New Project\n" +
                    "2. View All Projects\n" +
                    "3. View Project By Title\n" +
                    "4. Update Existing Project\n" +
                    "5. Delete Existing Project\n" +
                    "6. Exit");

                // Get the user's input
                string input = Console.ReadLine();

                //Evaluate the user's input and act accordingly
                switch (input)
                {
                    case "1":
                        //Create new Project
                        CreateNewProject();
                        break;
                    case "2":
                        //View All Projects
                        DisplayAllProjects();
                        break;
                    case "3":
                        //View Project By Title
                       // DisplayProjectByTitle();
                        break;
                    case "4":
                        //Update Existing Project
                        //UpdateExistingProject();
                        break;
                    case "5":
                        //Delete Existing Project
                        //DeleteExistingProject();
                        break;
                    case "6":
                        //Exit
                        Console.WriteLine("Goodbye!");
                        userMenuLoop = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number.");
                        break;
                }
                Console.WriteLine("Please press any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
    }

        private void ErrorsMenu()
        {
            bool userMenuLoop = true;
            while (userMenuLoop)
            {
                Console.WriteLine("You've reached the Errors menu");

                // Display our options to the user
                Console.WriteLine("Select a menu option:\n" +
                    "1. Create New Error\n" +
                    "2. View All Errors\n" +
                    "3. View Error By Title\n" +
                    "4. Update Existing Error\n" +
                    "5. Delete Existing Error\n" +
                    "6. Exit");

                // Get the user's input
                string input = Console.ReadLine();

                //Evaluate the user's input and act accordingly
                switch (input)
                {
                    case "1":
                        //Create new Error
                        //CreateNewError();
                        break;
                    case "2":
                        //View All Errors
                        //DisplayAllErrors();
                        break;
                    case "3":
                        //View Error By Title
                        //DisplayErrorByTitle();
                        break;
                    case "4":
                        //Update Existing Error
                        //UpdateExistingError();
                        break;
                    case "5":
                        //Delete Existing Error
                        //DeleteExistingError();
                        break;
                    case "6":
                        //Exit
                        Console.WriteLine("Goodbye!");
                        userMenuLoop = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number.");
                        break;
                }
                Console.WriteLine("Please press any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
}

        private void CommentsMenu()
        {
            bool userMenuLoop = true;
            while (userMenuLoop) {
                Console.WriteLine("You've reached the Comments Menu");

                // Display our options to the user
                Console.WriteLine("Select a menu option:\n" +
                    "1. Create New Comment\n" +
                    "2. View All Comments\n" +
                    "3. View Comments By Title\n" +
                    "4. Update Existing Comment\n" +
                    "5. Delete Existing Comment\n" +
                    "6. Exit");

                // Get the user's input
                string input = Console.ReadLine();

                //Evaluate the user's input and act accordingly
                switch (input)
                {
                    case "1":
                        //Create new Comment
                        //CreateNewComment();
                        break;
                    case "2":
                        //View All Comments
                        //DisplayAllComments();
                        break;
                    case "3":
                        //View Comments By Title
                        //DisplayCommentByTitle();
                        break;
                    case "4":
                        //Update Existing Comment
                        //UpdateExistingComment();
                        break;
                    case "5":
                        //Delete Existing Comment
                        //DeleteExistingComment();
                        break;
                    case "6":
                        //Exit
                        Console.WriteLine("Goodbye!");
                        userMenuLoop= false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number.");
                        break;
                }
                Console.WriteLine("Please press any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }


        public void Login()
        {
            Console.Clear();
            var client = new RestClient();
            client.BaseUrl = new Uri("https://localhost:44336/");
            client.Authenticator = new HttpBasicAuthenticator("username", "password");

            var request = new RestRequest("api/Account/Register", Method.POST);
            request.AddParameter("username", "password");
            User newUser = new User();

            //Title
            Console.WriteLine("Enter the title for the Project:");
            newUser.Username = Console.ReadLine();

            //Description
            Console.WriteLine("Enter the description for the Project:");
            newUser.Password = Console.ReadLine();

            request.AddObject(newUser);
            IRestResponse response = client.Execute(request);
            var content = response.Content;
            newUser.Token = content;
            Console.WriteLine(content);
            UserMenu();
        }

        public void Register()
        {
            Console.Clear();
            var client = new RestClient();
            client.BaseUrl = new Uri("https://localhost:44336/");
            client.Authenticator = new HttpBasicAuthenticator("username", "password");

            var requestRegister = new RestRequest("api/Account/Register", Method.POST);
            requestRegister.AddParameter("username", "password");
            var requestToken = new RestRequest("Token", Method.POST);
            requestToken.AddParameter("username", "password");
            User newUser = new User();

            //Email
            Console.WriteLine("Enter your email:");
            newUser.Email = Console.ReadLine();

            //Username
            Console.WriteLine("Enter your username:");
            newUser.Username = Console.ReadLine();

            //Password
            Console.WriteLine("Enter your password:");
            newUser.Password = Console.ReadLine();

            //ConfirmPassword
            Console.WriteLine("Confirm your password:");
            newUser.ConfirmPassword = Console.ReadLine();

            requestRegister.AddObject(newUser);
            IRestResponse response = client.Execute(requestRegister);
            var content = response.Content;
            newUser.Token = content;
            Console.WriteLine(content);
            UserMenu();
        }

        public void RegisterWithToken()
        {
            Console.Clear();
            var client = new RestClient();
            client.BaseUrl = new Uri("https://localhost:44336/");
            client.Authenticator = new HttpBasicAuthenticator("username", "password");

            var request = new RestRequest("api/Account/Register", Method.POST);
            request.AddParameter("username", "password");
            User newUser = new User();

            //Title
            Console.WriteLine("Enter the title for the Project:");
            newUser.Username = Console.ReadLine();

            //Description
            Console.WriteLine("Enter the description for the Project:");
            newUser.Password = Console.ReadLine();

            request.AddObject(newUser);
            IRestResponse response = client.Execute(request);
            var content = response.Content;
            newUser.Token = content;
            Console.WriteLine(content);
            UserMenu();
        }


        public void CreateNewProject() 
        {
            Console.Clear();
            var client = new RestClient();
            client.BaseUrl = new Uri("https://localhost:44336/");
            client.Authenticator = new HttpBasicAuthenticator("username","password");

            var request = new RestRequest("api/Project", Method.POST);
            request.AddParameter("Title","Description");
            Project newProject = new Project();

            //Title
            Console.WriteLine("Enter the title for the Project:");
            newProject.Title = Console.ReadLine();

            //Description
            Console.WriteLine("Enter the description for the Project:");
            newProject.Description = Console.ReadLine();

            request.AddObject(newProject);
            IRestResponse response = client.Execute(request);
            var content = response.Content;
            Console.WriteLine(content);
        }

        public void DisplayAllProjects()
        {
            Console.Clear();
            var client = new RestClient();
            client.BaseUrl = new Uri("https://localhost:44336/");
            client.Authenticator = new HttpBasicAuthenticator("username", "password");

            var request = new RestRequest("api/Project", Method.GET);
            request.AddParameter("Title", "Description");

            IRestResponse response = client.Execute(request);
            var content = response.Content;
            Console.WriteLine(content);
        }
    }
}
