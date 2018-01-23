using System;
using System.Collections;
using UnityEngine;

public class Hacker : MonoBehaviour
{
    // Game Config Data
    string[] level1Passwords = { "hello", "trees", "dumps", "parks", "snake", };
    string[] level2Passwords = { "handcuffs", "arrest", "guns", "911", "badboys"};
    string[] level3Passwords = { "qui-gon_jin", "yoda", "darth_vader", "luke", "obi-wan_kenobi" };
    

    // Game State
    int currentLevel;
    enum Screen { MainMenu, Welcome, Password, Win };
    Screen currentScreen = Screen.MainMenu;
    public string password;
    string[] rewards = {"You Have No Rewards Yet!","","", "Enter menu at any time"};
    
    // Use this for initialization
    void Start ()
    {
        //Login();
        ShowMainMenu();
	}
    
    // TODO create login and password screen
    
    void ShowMainMenu ()
    {
        currentScreen = Screen.MainMenu;
        Terminal.ClearScreen();
        //Terminal.WriteLine("Hello, " + username + ".");
        Terminal.WriteLine("What do you want to hack?");   
        Terminal.WriteLine("Press 1 for the Park's computer.");
        Terminal.WriteLine("Press 2 for Police Dept.");
        Terminal.WriteLine("Press 3 for LucasArts Studio.");
        Terminal.WriteLine("Enter rewards to view your prizes.");
        Terminal.WriteLine("Enter your selection: ");
    }

    void OnUserInput(string input)
    {
               
        if (input == "menu" || input == "exit")
        {
            ShowMainMenu();
        }
        else if (input == "rewards")
        {
            ShowRewards();
        }
        else if (currentScreen == Screen.MainMenu)
        {
            RunMainMenu(input);
        }
        else if (currentScreen == Screen.Password)
        {
            CheckPassword(input);
        }
    }

    // Does things based on user input
    void RunMainMenu(string input)
    {
        string name = input;
        
        switch (name)
        {
            case "1":
                SelectLevel(name);
                break;
            case "2":
                SelectLevel(name);
                break;
            case "3":
                SelectLevel(name);
                break;
            case "007":
                Terminal.WriteLine("Welcome Mr. Bont. Select a level.");
                break;
            case "sudo":
                Terminal.WriteLine("Welcome, Master.");
                break;
            case "Cassidy":
                Terminal.WriteLine("Hey hot stuff!");
                break;
            case "Tesch":
                Terminal.WriteLine("What? No. Stop.");
                break;
            case "Jack":
                Terminal.WriteLine("fucking kill yourself.");
                break;
            default:
                Terminal.WriteLine("Please select a valid level.");
                break;
        }

    }

    private void SelectLevel(string input)
    {
        currentLevel = int.Parse(input);
        RandomizePassword();
        currentScreen = Screen.Password;
        print("Current Level: " + currentLevel);
    }

    void RandomizePassword()
    {
        int rand = UnityEngine.Random.Range(0, 5);

        Terminal.ClearScreen();
        switch (currentLevel)
        {
            case 1:
                Terminal.WriteLine(level1);
                password = level1Passwords[rand];
                break;
            case 2:
                Terminal.WriteLine(level2);
                password = level2Passwords[rand];
                break;
            case 3:
                Terminal.WriteLine(level3);
                password = level3Passwords[rand];
                break;
        }
        StartCoroutine(Wait(2));
    }

    private void SayThings()
    {
        Terminal.ClearScreen();
        Terminal.WriteLine("You can type 'menu' at any time.");
        Terminal.WriteLine("          Welcome to Level " + currentLevel);
        Terminal.WriteLine("       Please enter the password.");
        Terminal.WriteLine("Hint: " + password.Anagram());
    }

    void CheckPassword(string input)
    {
        
        if (input == password)
        {
            Success(input);
        }
        else
        {
            RandomizePassword();
        }
       
    }

    void Success(string input)
    {
        currentScreen = Screen.Win;
        Terminal.ClearScreen();
        StartCoroutine(MyCoroutine(2,input));
    }

    private IEnumerator MyCoroutine(float duration, string input)
    {
        Terminal.WriteLine("Correct! The password was: " + password);
        yield return new WaitForSeconds(duration);
        Terminal.ClearScreen();
        ShowLevelReward();
        Terminal.WriteLine("You can type 'exit' at any time");
    }

    IEnumerator Wait(float duration)
    {
        yield return new WaitForSeconds(duration);

        SayThings();
    }

    private void ShowLevelReward()
    {
        switch (currentLevel)
        {
            case 1:
                Terminal.WriteLine("Here is your reward!");
                Terminal.WriteLine(reward1);
                rewards[0] = reward1;
                break;
            case 2:
                Terminal.WriteLine("Here is your reward!");
                Terminal.WriteLine(reward2);
                rewards[1] = reward2;
                break;
            case 3:
                Terminal.WriteLine("Here is your reward!");
                Terminal.WriteLine(reward3);
                rewards[2] = reward3;
                break;
        }

        
    }

    private void ShowRewards()
    {
        Terminal.ClearScreen();
        for (int i = 0; i < rewards.Length; i++)
        {
            Terminal.WriteLine(rewards[i]);
        }
    }

    // Show Welcome Screen
 

    // Welcome Screens
    string level1 = @"
            ---Level 1---
            __   _    _
            |_| /_\  |_| |/ 
            |  /   \ | \ |\";

    string level2 = @"
            ---Level 2---
         _   _         __  __
        |_| | | |   | |   |_
        |   |_| |__ | |__ |__";

    string level3 = @"
            ---Level 3---
         _    _   _    _   __  ___  _
|   | | |    /_\ |_   /_\ |__|  |  |_
|__ |_| |_  /   \ _| /   \| \   |   _|";
    
    // Rewards Cache
    string reward1 = @"
              ___  
             _|_|_
            <('.')>
              '''
             /|_|\
              | |
              d b

      --You Found a Doll--";
    string reward2 = @"
      _
    /0 0\_________
    \0_0/='=='=='||

  ---Skeleton Key---";
    string reward3 = @"
    
            |  _  |
            |=(_)=|
            |     |

 --You stole a TIE Fighter--";

}
