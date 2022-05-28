using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        ShowMainMenu("[NAME]");
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
        }
        else if(input == "1")
        {
            print("you chose "+ input);
        }
        else
        {
            print("false");
        }

    }
}
