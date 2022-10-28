////////////////////////////////////////////////////////////////////////////////////////////////////////
//
// Project: Project 3 - Playlists
// File Name: PlaylistDriver.cs
// Description: Driver of the playlist project
// Course: CSCI 1260 – Introduction to Computer Science II
// Author: Sam Mitchell, mitchellse1@etsu.edu, East Tennessee State University
// Created: 10/26/2022
// Copyright: Sam Mitchell, 2022
//
////////////////////////////////////////////////////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project1MP3;

/// <summary>
/// Driver of the playlist project
/// </summary>
public class PlaylistDriver
{
    #region Create MP3
    /// <summary>
    /// Prompts the user for data regarding a MP3 and returns a created mpthree object
    /// </summary>
    /// <returns>returns a created mpthree object</returns>
    private static MPThree CreateMPThree()
    {
        Console.Write("Please enter the title of the song: "); //Song Title I/O
        string title = Console.ReadLine();

        Console.Write("Please enter the name of the artist: "); //Song Artist I/O
        string artist = Console.ReadLine();

        Console.Write("Please enter when the song released: "); //Song release date I/O
        string releaseDate = Console.ReadLine();

        Console.Write("Please write, in double form, how long the song is: "); //Song genre I/O
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

        Console.Write("Please write the cost of the song in decimal form: "); //Song Cost I/O
        decimal costOfDownload = Convert.ToDecimal(Console.ReadLine());

        Console.Write("Please write the size of the song in MBs: "); //Song file size I/O
        double fileSize = Convert.ToDouble(Console.ReadLine());

        Console.Write("Please write the file path to the song thumbnail: "); //Song file path I/O
        string jpgPath = Console.ReadLine();

        MPThree createdMPThree = new MPThree(title, artist, releaseDate, songPlaytime, genre, costOfDownload, fileSize, jpgPath);
        return createdMPThree;
    }
    #endregion



    /// <summary>
    /// Main Method of the playlist project
    /// </summary>
    /// <param name="args"></param>
    public static void Main(string[] args)
    {
        Console.WriteLine("Welcome to Program.");



        int userInput = 0; //initailizing variables
        bool menuValidChoice = false;
        Playlist playlist = new Playlist();
        int endMenu = 0;


        do
        {
            #region Menu Input Validation and Input

            do
            {

                Console.WriteLine("Menu options"); //Displays options
                Console.Write("Choice: ");
                menuValidChoice = int.TryParse(Console.ReadLine(), out userInput);
                if (!menuValidChoice || userInput > 11 || userInput < 1) //checks if valid input
                {
                    Console.WriteLine();
                    Console.WriteLine("Please enter a valid choice! Menu"); //displays if invaild
                    Console.WriteLine();
                }

            } while (!menuValidChoice); //runs while invalid

            #endregion

            #region Switch Case for Menu
            switch (userInput)
            {
                #region Creating Playlist
                case 1: //User selects to create a new playlist

                    Console.WriteLine("Ask for user's name");
                    string userName = Console.ReadLine();

                    Console.WriteLine("Ask for what to call playlist");
                    string playlistName = Console.ReadLine();

                    DateTime date = DateTime.Today;
                    string playlistDate = date.ToString("MM/dd/yyyy");


                    playlist = new Playlist(playlistName, userName, playlistDate);

                    break;
                #endregion

                #region Creating a MP3 and adding to Playlist
                case 2:
                    //MPThree userMPThree = CreateMPThree(); //create mp3
                    //playlist.AddMPThree(userMPThree); //add mp3 to the playlist
                    MPThree mPThree = new MPThree();
                    playlist.AddMPThree(mPThree);
                    break;
                #endregion

                #region Editing an existing MP3
                case 3:

                    break;
                #endregion

                #region Dropping an exisiting MP3 from the Playlist
                case 4:
                    Console.WriteLine(playlist.DisplayMP3s());
                    int removalChoice = 0;

                    #region Song Removal Verification
                    bool removalValidChoice = false;
                    do
                    {
                        Console.Write("Type the number of the song to remove: ");
                        
                        removalValidChoice = int.TryParse(Console.ReadLine(), out removalChoice);
                        if (!removalValidChoice || removalChoice > playlist.Length() || removalChoice < 1) //checks if valid input
                        {
                            Console.WriteLine();
                            Console.WriteLine("Please enter a valid choice! remove"); //displays if invaild
                            Console.WriteLine();
                        }
                    } while (!removalValidChoice);
                    #endregion

                    Console.WriteLine($"Removing {playlist.}");

                    break;
                #endregion

                #region Displaying all MP3s on the Playlist
                case 5:
                    Console.WriteLine(playlist.DisplayMP3s());
                    break;
                #endregion

                #region Finding a MP3 on the Playlist by song title
                case 6:
                    break;
                #endregion

                #region Display all MP3s based on genre
                case 7:
                    break;
                #endregion

                #region Display all MP3s based on artist
                case 8:
                    break;
                #endregion

                #region Sort MP3s by song title
                case 9:
                    break;
                #endregion

                #region Sort MP3s by song release date
                case 10:
                    break;
                #endregion

                #region End the program
                case 11:
                    Console.WriteLine("Thank you for using MP3 Tracker!");
                    endMenu++; 
                    break;
                    #endregion
            }
            #endregion


        } while (endMenu == 0);
    }
}
