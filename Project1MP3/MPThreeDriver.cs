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
public class MPThreeDriver
{
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

        Console.Write("Please select a genre from this list: " +
            "\n\t1. Rock" +
            "\n\t2. Pop" +
            "\n\t3. Jazz" +
            "\n\t4. Country" +
            "\n\t5. Classical" +
            "\n\t6. Other");
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
                doWhileValid++;
            }
        } while(doWhileValid == 0);
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

    public static void Main(string[] args)
    {
        Console.WriteLine("Welcome to MP3 Tracker!\n" + //Greeting message
            "Written By: Sam Mitchell.");
        Console.WriteLine("\nThis program displays information based on the MP3's that you put in!");

        Console.Write("\nWhat is your name? "); //takes the users name
        string userName = Console.ReadLine();



        

    }
}

