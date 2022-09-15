////////////////////////////////////////////////////////////////////////////////////////////////////////
//
// Project: Project1MP3
// File Name: MPThreeDriver.cs
// Description: The driver file for the MP3 Tracker Program
// Course: CSCI 1260 – Introduction to Computer Science II
// Author: Sam Mitchell, mitchellse1@etsu.edu, East Tennessee State University
// Created: 9/7/22
// Copyright: Sam Mitchell, 2022
//
////////////////////////////////////////////////////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Project1MP3;
/// <summary>
/// The driver file for the MP3 Tracker Program
/// </summary>
public class MPThreeDriver
{
    /// <summary>
    /// Prompts the user for data regarding a MP3 and returns a created mpthree object
    /// </summary>
    /// <returns>returns a created mpthree object</returns>
    private static MPThree CreateMPThree()
    {
        Console.Write("Please enter the title of the song: ");
        string title = Console.ReadLine();

        Console.Write("Please enter the name of the artist: ");
        string artist = Console.ReadLine();

        Console.Write("Please enter when the song released: ");
        string releaseDate = Console.ReadLine();

        Console.Write("Please write, in double form, how long the song is: ");
        double songPlaytime = Convert.ToDouble(Console.ReadLine());

        Console.Write("Please select a genre from this list" +
            "\n\t1. Rock" +
            "\n\t2. Pop" +
            "\n\t3. Jazz" +
            "\n\t4. Country" +
            "\n\t5. Classical" +
            "\n\t6. Other" +
            "\n\tChoice: ");
        int genreChoice = 0;
        int doWhileValid = 0;
        bool valid = int.TryParse(Console.ReadLine(), out genreChoice); //Validation for specified input, outputs to genreChoice
        do
        {
            if (!valid || genreChoice > 6 || genreChoice < 1) //checks if the user input is anything but the allowed input
            {
                Console.Write("Please enter a number 1 - 6: ");
                valid = int.TryParse(Console.ReadLine(), out genreChoice);
            }
            else
            {
                doWhileValid++; //Breaks out of while loop if input is valid
            }
        } while (doWhileValid == 0);
        Genre genre = (Genre)Enum.GetValues(typeof(Genre)).GetValue(genreChoice);

        Console.Write("Please write the cost of the song in decimal form: ");
        decimal costOfDownload = Convert.ToDecimal(Console.ReadLine());

        Console.Write("Please write the size of the song in MBs: ");
        double fileSize = Convert.ToDouble(Console.ReadLine());

        Console.Write("Please write the file path to the song thumbnail: ");
        string jpgPath = Console.ReadLine();

        MPThree createdMPThree = new MPThree(title, artist, releaseDate, songPlaytime, genre, costOfDownload, fileSize, jpgPath);
        return createdMPThree;
    }
    /// <summary>
    /// the main method of the driver class
    /// </summary>
    public static void Main(string[] args)
    {
        int endProgram = 0;
        int hasCreatedMPThree = 0;
        MPThree userCreatedMPThree = new MPThree();

        Console.WriteLine("Welcome to MP3 Tracker!\n" + //Greeting message
            "Written By: Sam Mitchell.");
        Console.WriteLine("\nThis program displays information based on the MP3's that you put in!"); //Description of program

        Console.Write("\nWhat is your name? "); //takes the users name and saves it in userName
        string userName = Console.ReadLine();

        Console.Clear(); //Clears console for better readability

        do
        {
            Console.WriteLine($"Welcome to MP3 Tracker {userName}!");
            Console.Write("\tMenu" +
                "\n\t----------------" +
                "\n\t1. Create a new MP3 file" +
                "\n\t2. Display a MP3 file" +
                "\n\t3. End the Program" +
                "\n" +
                "\n\tPlease enter your choice: ");

            int doWhileValidMenu = 0;

            bool valid = int.TryParse(Console.ReadLine(), out int menuChoice); //Validation for specified input, outputs to menuChoice
            do
            {
                if (!valid || menuChoice > 3 || menuChoice < 1) //checks if the user input is anything but the allowed input
                {
                    Console.Write("Please enter a number 1 - 3: ");
                    valid = int.TryParse(Console.ReadLine(), out menuChoice);
                }
                else
                {
                    doWhileValidMenu++; //Breaks out of while loop if input is valid
                }
            } while (doWhileValidMenu == 0);


            switch (menuChoice)
            {
                case 1: //Create mp3
                    userCreatedMPThree = CreateMPThree();
                    hasCreatedMPThree++;
                    break;
                case 2: //Display mp3
                    if(hasCreatedMPThree == 0)
                    {
                        Console.WriteLine("Please create a MP3 file first!");
                    }
                    else
                    {
                        Console.WriteLine(userCreatedMPThree);
                    }
                    break;

                case 3: //End program
                    endProgram++;
                    break;

            }

        } while (endProgram == 0);
        Console.WriteLine($"Thank you {userName} for using my program!"); //Goodbye message
    }
}

