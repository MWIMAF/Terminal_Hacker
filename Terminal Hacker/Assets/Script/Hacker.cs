using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour
{
    int lvl;
    string password;

    enum Screen { MainMenu, Password, Win };
    Screen currentScreen;

    // Start is called before the first frame update
    void Start()
    {
        ShowMainMenu("[NAME]");
        currentScreen = Screen.MainMenu;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ShowMainMenu(string greeting)
    {
        Terminal.ClearScreen();
        Terminal.WriteLine("Hello "+greeting);
        Terminal.WriteLine("What would you like to hack into?");
        Terminal.WriteLine("Press 1 to the local library");
        Terminal.WriteLine("Press 2 to the police station");
        Terminal.WriteLine("");
        Terminal.WriteLine("Input here: ");
    }

    void OnUserInput (string input)
    {
        if (input == "menu")
        {
            ShowMainMenu("[NAME]");
            currentScreen = Screen.MainMenu;
        }
        else if (currentScreen == Screen.MainMenu)
        {
            RunMainMenu(input);
        }
        else if (currentScreen == Screen.Password)
        {
            CheckPassword(input);
        }

        void RunMainMenu(string input)
        {
            if (input == "1")
            {
                lvl = 1;
                password = "0000";
                StartGame();
            }
            else if (input == "2")
            {
                lvl = 2;
                password = "2103";
                StartGame();
            }
            else
            {
                Terminal.WriteLine("Please input valid number");
            }
        }

    }

    void StartGame ()
    {
        currentScreen = Screen.Password;
        Terminal.ClearScreen();
        Terminal.WriteLine("You have chosen level " + lvl);
        Terminal.WriteLine("Please Enter password: ");
    }

    void CheckPassword (string input)
    {
        if (input == password)
        {
            Terminal.ClearScreen();
            Terminal.WriteLine("Well done! You're in!");
            Terminal.WriteLine("");
            Terminal.WriteLine("Type 'menu' to back to main menu!");
        }
        else
        {
            Terminal.WriteLine("ups, that's wrong!");
        }
    }
}
