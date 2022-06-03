using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour
{
    int lvl;
    string password;
    const string menuText = "Type 'menu' to back to main menu!";
    string playerName;
    string[] lvl1pass = { "font", "book", "view", "edit", "file" };
    string[] lvl2pass = { "skill", "read", "dead", "shoot" };    

    enum Screen { MainMenu, Password, Win, Name };
    Screen currentScreen;

    // Start is called before the first frame update
    void Start()
    {
        Terminal.WriteLine("Please enter your name: ");
        currentScreen = Screen.Name;
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
            ShowMainMenu(playerName);
            currentScreen = Screen.MainMenu;
        }
        else if (currentScreen == Screen.MainMenu && input != "veruszkha")
        {
            RunMainMenu(input);
        }
        else if (currentScreen == Screen.Password)
        {
            CheckPassword(input);
        }
        else if (currentScreen == Screen.Name)
        {            
            playerName = input;
            currentScreen = Screen.MainMenu;
            ShowMainMenu(playerName);
        }
        else if (currentScreen == Screen.MainMenu && input == "veruszkha")
        {
            RunMainMenu("99");
        }

        void RunMainMenu(string input)
        {
            bool isValidNumber = (input == "1" || input == "2");
            if (isValidNumber)
            {
                lvl = int.Parse(input);
                AskPassword();
            }
            else if (input == "99")
            {
                lvl = 99;
                currentScreen = Screen.Password;
                Terminal.ClearScreen();
                Terminal.WriteLine("Weh ketemu easter eggnya!");
                Terminal.WriteLine("khusus ini aku bakalan pake Bahasa");
                Terminal.WriteLine("");
                RandPassword();
                Terminal.WriteLine(@"Siapa penyanyi favorit saya?
hint: " + password.Anagram());



                Terminal.WriteLine(menuText);
            }
            else
            {
                Terminal.WriteLine("Please input valid number");
                Terminal.WriteLine(menuText);
            }
        }

    }

    void AskPassword ()
    {
        currentScreen = Screen.Password;
        Terminal.ClearScreen();
        RandPassword();
        Terminal.WriteLine("You have chosen level " + lvl);
        Terminal.WriteLine("Please Enter password, hint: " + password.Anagram());
        Terminal.WriteLine(menuText);
    }

    void RandPassword()
    {
        int index;
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
            case 99:
                password = "paul";
                break;
        }
    }

    void CheckPassword (string input)
    {
        if (input == password)
        {
            WinScreen();
        }
        else
        {
            AskPassword();
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
                Terminal.WriteLine("     ------- ");
                Terminal.WriteLine("   / - - - /");
                Terminal.WriteLine("  / - - - /");
                Terminal.WriteLine(" / - - - /");
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
            case 99:
                Terminal.WriteLine("Aku tau lagunya dari si v");
                Terminal.WriteLine("kalo kenal v blg makasih");
                Terminal.WriteLine("kalo kamu v, foto ini");
                Terminal.WriteLine("dadahh! dan terima kasih");
                Terminal.WriteLine("-W");
                Terminal.WriteLine("");
                break;
        }
        Terminal.WriteLine(menuText);
    }
}
