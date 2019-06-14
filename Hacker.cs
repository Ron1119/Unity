// using System.Collections;
// using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour
{

    // game configuarion
    const string menuHint = "Please type menu at anytime.";
    string[] level1password={ "lv1", "lc1","ron1"};
    string[] level2password = { "lv2", "lc2", "ron2" };
    string[] level3password = { "lv3", "lc3", "ron3" };
    // Game state
    int level; // global variable
    enum Screen { MainScreen, Password, Win};
    Screen CurrentScreen ;
    string password;

    // Start is called before the first frame update
    void Start()
    {
        //print("Hello Console!!!");
        ShowMainMenu();
        // CookCurry("Lamb");
        // ShowBool();
    }

    /* void ShowBool()
    {
        bool condition = true;
        if (condition)
        {
            Terminal.WriteLine("The variable is true");
         }
        else
        { Terminal.WriteLine("Unkonwn input!"); }  }*/

    
    void ShowMainMenu()
    {
        // var greeting = "Hello Ron";  // can use string to specify
        CurrentScreen = Screen.MainScreen;  // when comes to this step, initialization is needed!
        Terminal.ClearScreen();
        Terminal.WriteLine("What would you like to hack into?");
        Terminal.WriteLine("Print 1 for the local library");
        Terminal.WriteLine("Print 2 for the police station");
        Terminal.WriteLine("Print 3 for the NASA");
        Terminal.WriteLine("Enter your selection");
        
    }

 
    void OnUserInput(string input)
    {

        if (input == "menu")
        {
            ShowMainMenu();

        } //TODO handle differently later
        else if (CurrentScreen == Screen.MainScreen)
        {
            RunMainMenu(input);
        }
        else if (CurrentScreen == Screen.Password)
        {
            CheckPassword(input);
        }

    }



    void RunMainMenu(string input)
    {
        bool isValidNubmer = (input =="1" || input =="2"|| input =="3");
        if (isValidNubmer)
        {
            level = int.Parse(input); // convert string to number
            AskPwd();
            
        }
        /*if (input == "1")
        {
          
            password = level1password[2];
            
        }
        else if (input == "2")
        {
            
            password = level1password[1];
            
        } */

        else if (input == "007")
        {
            Terminal.WriteLine("Please select a level Mr Bond!");
        }
        else
        {
            Terminal.WriteLine("Please choose a valid level");
        }
    }

    void AskPwd()
    {
        CurrentScreen = Screen.Password;
        Terminal.ClearScreen();
        SetRandomPwd();
        Terminal.WriteLine("You have chosen level " + level);
        Terminal.WriteLine("Please choose your password (hint): " + password.Anagram());  // show password in random order
        Terminal.WriteLine(menuHint);
    }

    void SetRandomPwd()
    {
        switch (level)
        {
            case 1:
                int index1 = Random.Range(0, level1password.Length);
                print(index1);
                password = level1password[index1];
                break;
            case 2:
                int index2 = Random.Range(0, level2password.Length);
                print(index2);
                password = level2password[index2];
                break;
            case 3:
                int index3 = Random.Range(0, level3password.Length);
                print(index3);
                password = level3password[index3];
                break;
            default:
                Debug.LogError("Invalid number");
                break;
        }
    }

    void CheckPassword(string input)
    {
        if (input == password)
        {
            DisplayWinScreen();
        }
        else
        {
            // Terminal.WriteLine("Wrong Password! Please try again.");
            AskPwd();
        }
    }

     void DisplayWinScreen()
    {
        CurrentScreen = Screen.Win;
        Terminal.ClearScreen();
        ShowLevelReward();
        Terminal.WriteLine(menuHint);
    }

    void ShowLevelReward()
    {
        switch (level)
        {
            case 1:
                Terminal.WriteLine("You get  a book");
                Terminal.WriteLine(@"
                     __________________
                    /               / /
                   /               / /
                  /_______________/ /  
                 (________________)/"   );
                break;
            case 2:
                Terminal.WriteLine("You get a poison key");
                Terminal.WriteLine(@"
             _____
            |     \_________/|
            |      __________|
            |_____/
            

                ");
                break;
            case 3:
                Terminal.WriteLine("Welcome to NASA ");
                Terminal.WriteLine(@"
               _____      ____
             /       \___/    \
            | |     _/    \  /
            |_____/        \/
            

                ");
                break;
            default:
                Debug.LogError("Invalida number");
                break;

         

        }
    
        
    }
    // Update is called once per frame

}
