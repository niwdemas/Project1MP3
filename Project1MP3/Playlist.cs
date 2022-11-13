////////////////////////////////////////////////////////////////////////////////////////////////////////
//
// Project: Project3 - Playlists
// File Name: Playlist.cs
// Description: Playlist Class, a collection of mpthree's
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

namespace Project1MP3
{
    /// <summary>
    /// Playlist Class, a collection of mp3s in a list
    /// </summary>
    public class Playlist
    {
        private List<MPThree> MPThreeList { get; set; }
        public string NameOfPlaylist { get; set; }
        public string NameOfCreator { get; set; }
        public string DateCreated { get; set; }
        public bool SaveNeeded { get; set; }    
        
        /// <summary>
        /// default constructor
        /// </summary>
        public Playlist()
        {
            MPThreeList = new List<MPThree>();
            NameOfCreator = "N/A";
            NameOfPlaylist = "N/A";
            DateCreated = "N/A";
        }

        /// <summary>
        /// paramaterized constructor
        /// </summary>
        /// <param name="mpThreeList">list of mp3s</param>
        /// <param name="nameOfPlaylist">user given name of the playlist</param>
        /// <param name="nameOfCreator">user name who created playlist</param>
        /// <param name="dateCreated">time the playlist was made</param>
        public Playlist(string nameOfPlaylist, string nameOfCreator, string dateCreated)
        {
            MPThreeList = new List<MPThree>();
            NameOfPlaylist = nameOfPlaylist;
            NameOfCreator = nameOfCreator;
            DateCreated = dateCreated;
        }

        /// <summary>
        /// copy constructor
        /// </summary>
        /// <param name="otherPlaylist">playlist to copy</param>
        public Playlist(Playlist otherPlaylist)
        {
            if (otherPlaylist.MPThreeList.Count() > 0)
            {
                for (int i = 0; i < otherPlaylist.MPThreeList.Count(); i++) //only deep copies if playlist has something
                {
                    MPThreeList[i] = otherPlaylist.MPThreeList[i];
                }
            }
            else
            {
                MPThreeList = new List<MPThree>();
            }
            
            NameOfPlaylist = otherPlaylist.NameOfPlaylist;
            NameOfCreator = otherPlaylist.NameOfCreator;
            DateCreated = otherPlaylist.DateCreated;
        }

        /// <summary>
        /// Adds a mp3 file to the list
        /// </summary>
        /// <param name="mpThree">mp3 file to be added</param>
        public string AddMPThree(MPThree mpThree)
        {
            SaveNeeded = true;
            string msg = "";
            MPThreeList.Add(mpThree);
            msg = $"{mpThree.SongTitle} added to {NameOfPlaylist}"; //updated to return string instead of print intantly
            return msg;

        }

        /// <summary>
        /// adds all mp3s in the playlist to a string
        /// </summary>
        /// <returns>returns a string of all the songs</returns>
        public string DisplayMP3s()
        {
            string msg = $"\t\t{NameOfPlaylist}|Created By: {NameOfCreator}|{DateCreated}";
            int i = 1;
            foreach(var mp3 in MPThreeList)
            {
                msg += ("\n--------------------");
                msg += $"\n\tSong {i}:";
                msg += $"\n{mp3}";
                msg += "\n--------------------";
                i++;
            }
            return msg;
        }

        /// <summary>
        /// returns an int value of the length of the playlist
        /// </summary>
        /// <returns>returns an int value of the length</returns>
        public int Length()
        {
            return MPThreeList.Count;
        }

        /// <summary>
        /// removes mp3 at the selected int
        /// </summary>
        /// <param name="choice">user inputed integer from driver</param>
        public string RemoveMP3(int choice)
        {
            SaveNeeded = true;
            string msg = "";
            msg = $"{MPThreeList[choice - 1].SongTitle} removed from {NameOfPlaylist}"; //updated to return string instead of print intantly          
            MPThreeList.RemoveAt(choice - 1); // -1 to account for computer counting
            return msg;
        }

        /// <summary>
        /// returns a string of the song title
        /// </summary>
        /// <param name="choice">user inputed integer from driver</param>
        /// <returns>string with the title</returns>
        public string GetSongTitle(int choice)
        {
            string title = MPThreeList[choice - 1].SongTitle; // -1 to account for computer counting

            return title;
        }

        /// <summary>
        /// returns songs based on song title
        /// </summary>
        /// <param name="inputTitle">user inputed string from driver</param>
        /// <returns>returns formatted string</returns>
        public string TitleSearch(string inputTitle)
        {
            string msg = "";
            int i = 0;

            foreach(var mp3 in MPThreeList)
            {
                if (mp3.SongTitle == inputTitle)
                {
                    msg += ("\n--------------------"); //entry add
                    msg += $"\n{mp3}";
                    msg += "\n--------------------";
                    i++;
                }
            }

            if (i > 0)
            {
                msg += $"\nFound {i} songs with that title!";
            }
            else
            {
                msg += "\nCouldn't find any songs with that title!";
            }

            return msg;
        }

        /// <summary>
        /// Displays all of a specific genre
        /// </summary>
        /// <param name="userGenre">user inputed genre from the driver</param>
        /// <returns>returns formatted string with all the songs listed</returns>
        public string GenreFind(Genre userGenre)
        {
            string msg = "";
            int i = 0;

            foreach (var mp3 in MPThreeList)
            {
                if (mp3.Genre == userGenre)
                {
                    msg += ("\n--------------------"); //entry add
                    msg += $"\n{mp3}";
                    msg += "\n--------------------";
                    i++;
                }
            }

            if (i > 0)
            {
                msg += $"\nFound {i} songs with that genre!";
            }
            else
            {
                msg += "\nCouldn't find any songs with that genre!";
            }

            return msg;
        }

        /// <summary>
        /// Display all of a specific artist
        /// </summary>
        /// <param name="userArtist">user inputted string from the driver</param>
        /// <returns>formatted string with the list of songs</returns>
        public string ArtistFind(string userArtist)
        {
            string msg = "";
            int i = 0;

            foreach (var mp3 in MPThreeList)
            {
                if (mp3.Artist == userArtist)
                {
                    msg += ("\n--------------------"); //entry add
                    msg += $"\n{mp3}";
                    msg += "\n--------------------";
                    i++;
                }
            }

            if (i > 0)
            {
                msg += $"\nFound {i} songs by that artist!";
            }
            else
            {
                msg += "\nCouldn't find any songs by that artist!";
            }

            return msg;
        }

        /// <summary>
        /// method takes a string parameter representing the file path of an existing text file from which the
        /// method should populate the Playlis
        /// </summary>
        /// <param name="path">file path of the existing text file</param>
        public void FillFromFile(string path)
        {
            int lineNum = 0;
            Playlist playlist = new Playlist();

            // get info from file
            StreamReader reader = new StreamReader(path);

            try
            {


                
                while (reader.Peek() != -1)
                {
                    string ln = reader.ReadLine();
                    string[] input = ln.Split("|");
                    if (lineNum == 0)
                    {
                        NameOfPlaylist = input[0];
                        NameOfCreator = input[1];
                        DateCreated = input[2];
                    }
                    else
                    {
                        Genre genre = (Genre)Enum.Parse(typeof(Genre), input[4], true);

                        MPThree mp3 = new MPThree(input[0], input[1], input[2], Convert.ToDouble(input[3]), genre, Convert.ToDecimal(input[5]), Convert.ToDouble(input[6]), input[7]);

                        MPThreeList.Add(mp3);
                    }
                    lineNum++;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Failed to read from the path, please try again.");
            }
            finally
            {
                if(reader != null)
                    reader.Close();
            }
        }

        /// <summary>
        ///  method takes a string parameter representing the text file name and path where the Playlist
        /// information is to be saved, replacing anything currently in that file
        /// </summary>
        /// <param name="path">file path of the existing text file</param>
        public void SaveToFile(string path)
        {
            SaveNeeded = false;
            StreamWriter writer = new StreamWriter(path);
            try
            {
                writer.WriteLine($"{NameOfPlaylist}|{NameOfCreator}|{DateCreated}");
                for (int i = 0; i < MPThreeList.Count; i++)
                {
                    writer.WriteLine($"{MPThreeList[i].SongTitle}|{MPThreeList[i].Artist}|{MPThreeList[i].ReleaseDate}|{MPThreeList[i].SongPlaytime}|{MPThreeList[i].Genre}|{MPThreeList[i].CostOfDownload}|{MPThreeList[i].FileSize}|{MPThreeList[i].JPGPath}");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Failed to write to path, please try again.");
            }
            finally
            {
                if (writer != null)
                    writer.Close();
            }




            ///write playlist to first line
            ///write mp3 separated by |
            ///save file to ../../../PLaylistData/Songs.txt
            ///
            ///
        }

        /// <summary>
        /// overrides the default tostring method
        /// </summary>
        /// <returns>string</returns>
        public override string ToString()
        {
            string msg = "";
            msg += $"{NameOfPlaylist}|{NameOfCreator}|{DateCreated}";
            msg += DisplayMP3s();
            return msg;
        }
    }
}
