using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour
{
    int lvl;
    string password;
    string[] lvl1pass = { "font", "book", "view", "edit", "file" };
    string[] lvl2pass = { "skill", "read", "dead", "shoot" };    

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
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }

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
            bool isValidNumber = (input == "1" || input == "2");
            if (isValidNumber)
            {
                lvl = int.Parse(input);
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
        int index;
        currentScreen = Screen.Password;
        Terminal.ClearScreen();
        switch (lvl)
        {
            case 1:
                index = Random.Range(0, lvl1pass.Length);
                password = lvl1pass[index];
                break;
            case 2:
                index = Random.Range(0, lvl2pass.Length);
                password = lvl2pass[index];
                break;
        }
        Terminal.WriteLine("You have chosen level " + lvl);
        Terminal.WriteLine("Please Enter password: ");
    }

    void CheckPassword (string input)
    {
        if (input == password)
        {
            WinScreen();
        }
        else
        {
            Terminal.WriteLine("ups, that's wrong!");
        }
    }

    void WinScreen()
    {
        currentScreen = Screen.Win;
        Terminal.ClearScreen();
        switch (lvl)
        {
            case 1:
                Terminal.WriteLine("Well Done! Have A Book ??");
                Terminal.WriteLine(" ------- ");
                Terminal.WriteLine("/ - - - /");
                Terminal.WriteLine("/ - - - /");
                Terminal.WriteLine("/ - - - /");
                Terminal.WriteLine(" ------- ");
                Terminal.WriteLine("");
                break;
            case 2:
                Terminal.WriteLine("Well Done! Have A Key! ?????");
                Terminal.WriteLine(@" 
  __        _
 /  \______| |
|    ________|
 \__/
                ");
                
                Terminal.WriteLine("");
                break;
        }
        Terminal.WriteLine("Type 'menu' to back to main menu!");
    }
}
