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
        Genre genre = (Genre)Enum.GetValues(typeof(Genre)).GetValue(genreChoice - 1);

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
        Console.WriteLine("Welcome to MP3 Tracker!.");
        Console.WriteLine();



        int userInput = 0; //initailizing variables
        bool menuValidChoice = false;
        Playlist playlist = new Playlist();
        int endMenu = 0;
        int madePlaylist = 0;


        do
        {
            #region Menu Input Validation and Input

            do
            {

                Console.WriteLine("\t\tMenu" +
                    "\n\t\t----" +
                    "\n\t1.  Create a Playlist" +
                    "\n\t2.  Create a MP3 and add to Playlist" +
                    "\n\t3.  Edit an exisiting MP3" +
                    "\n\t4.  Remove a MP3 from the Playlist" +
                    "\n\t5.  Display all MP3s on the Playlist" +
                    "\n\t6.  Find a MP3 based on song title" +
                    "\n\t7.  Display all MP3s based on genre" +
                    "\n\t8.  Display all MP3s based on artist" +
                    "\n\t9.  Sort MP3s based on song title" +
                    "\n\t10. Sort MP3s based on song release date" +
                    "\n\t11. Populate playlist from file" +
                    "\n\t12. Save playlist to file" +
                    "\n\t13. Exit"); //Displays options


                Console.Write("\tChoice: ");
                menuValidChoice = int.TryParse(Console.ReadLine(), out userInput);
                if (!menuValidChoice || userInput > 13 || userInput < 1) //checks if valid input
                {
                    Console.WriteLine();
                    Console.WriteLine("Please enter a valid choice!"); //displays if invaild
                    Console.WriteLine();
                }

            } while (!menuValidChoice); //runs while invalid

            #endregion



            #region Switch Case for Menu
            switch (userInput)
            {
                #region Creating Playlist
                case 1: //User selects to create a new playlist
                    if (madePlaylist == 0)
                    {
                        Console.Write("What is your name: ");
                        string userName = Console.ReadLine();

                        Console.Write("Name of the playlist: ");
                        string playlistName = Console.ReadLine();

                        DateTime date = DateTime.Today; //uses the systems date/time get function
                        string playlistDate = date.ToString("MM/dd/yyyy");


                        playlist = new Playlist(playlistName, userName, playlistDate);


                        madePlaylist++;
                    }
                    else
                    {
                        Console.WriteLine("You've already made a playlist! Please save it to make another one!");
                    }

                    break;
                #endregion

                #region Creating a MP3 and adding to Playlist
                case 2:
                    if (madePlaylist == 1) //checks if a playlist has been made
                    {

                        MPThree userMPThree = CreateMPThree(); //create mp3
                        Console.WriteLine(playlist.AddMPThree(userMPThree)); //add mp3 to the playlist
                                                                             //MPThree mPThree = new MPThree("Sudden Urge", "Rise Against", "2021", 3.46, Genre.Rock, 1.29M, 2.7, "albums/riseagainst/nowheregeneration.jpg");
                                                                             //MPThree mPThree2 = new MPThree("Blinding Lights", "The Weekend", "2020", 3.20, Genre.Pop, 1.29M, 2.7, "albums/theweekend/afterhours.jpg");
                                                                             //playlist.AddMPThree(mPThree);
                                                                             //playlist.AddMPThree(mPThree2);
                    }
                    else
                    {
                        Console.WriteLine("Please make a playlist first!");
                    }
                    break;
                #endregion

                #region Editing an existing MP3
                case 3:

                    break;
                #endregion

                #region Dropping an exisiting MP3 from the Playlist
                case 4:
                    if (madePlaylist == 1) //checks if a playlist has been made
                    {
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
                                Console.WriteLine("Please enter a valid choice!"); //displays if invaild
                                Console.WriteLine();
                            }
                        } while (!removalValidChoice);
                        #endregion

                        Console.WriteLine($"Removing {playlist.GetSongTitle(removalChoice)} from {playlist.NameOfPlaylist}.");
                        Console.WriteLine(playlist.RemoveMP3(removalChoice)); //removes mp3 at specified index
                    }
                    else
                    {
                        Console.WriteLine("Please make a playlist first!");
                    }
                    break;
                #endregion

                #region Displaying all MP3s on the Playlist
                case 5:
                    if (madePlaylist == 1) //checks if a playlist has been made
                    {
                        Console.WriteLine(playlist.DisplayMP3s());
                    }
                    else
                    {
                        Console.WriteLine("Please make a playlist first!");
                    }
                    break;
                #endregion

                #region Finding a MP3 on the Playlist by song title
                case 6:
                    if (madePlaylist == 1) //checks if a playlist has been made
                    {
                        Console.WriteLine("What is the title you would like to search?");

                        Console.Write("Title: ");
                        string userTitle = Console.ReadLine();

                        Console.WriteLine(playlist.TitleSearch(userTitle));
                    }
                    else
                    {
                        Console.WriteLine("Please make a playlist first!");
                    }
                    break;
                #endregion

                #region Display all MP3s based on genre
                case 7:
                    if (madePlaylist == 1) //checks if a playlist has been made
                    {
                        Console.Write("Please select a genre from this list" + //stolen from MPThreeCreate
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
                        Genre userGenre = (Genre)Enum.GetValues(typeof(Genre)).GetValue(genreChoice - 1);

                        Console.WriteLine(playlist.GenreFind(userGenre));
                    }
                    else
                    {
                        Console.WriteLine("Please make a playlist first!");
                    }
                    break;
                #endregion

                #region Display all MP3s based on artist
                case 8:
                    if (madePlaylist == 1) //checks if a playlist has been made
                    {
                        Console.WriteLine("What is the artist you would like to search?");

                        Console.Write("Artist: ");
                        string userArtist = Console.ReadLine();

                        Console.WriteLine(playlist.ArtistFind(userArtist));
                    }
                    else
                    {
                        Console.WriteLine("Please make a playlist first!");
                    }
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

                #region Populate the playlist from a file
                case 11:
                    Console.WriteLine("Please input the file path to your playlist.");
                    
                    
                    string userPathRead = Console.ReadLine();


                    playlist.FillFromFile(userPathRead);

                    madePlaylist = 1;
                    break;
                #endregion

                #region Save playlist to a file
                case 12:
                    if(madePlaylist == 1)
                    {
                        Console.WriteLine("Please input the file path you want your playlist to be saved at.");


                        string userPathSave = Console.ReadLine();


                        playlist.SaveToFile(userPathSave);

                        madePlaylist = 0;
                    }
                    else
                    {
                        Console.WriteLine("Please make a playlist first!");
                    }
                    break;
                #endregion

                #region End the program
                case 13:
                    if (playlist.SaveNeeded)
                    {
                        Console.WriteLine("You have unsaved changes to you playlist. Please save to file before ending the program.");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Thank you for using MP3 Tracker!");
                        endMenu++;
                        break;
                    }                    
                    #endregion
            }
            #endregion


        } while (endMenu == 0);
    }
}
