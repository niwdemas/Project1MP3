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
        public void AddMPThree(MPThree mpThree)
        {
            MPThreeList.Add(mpThree);
            Console.WriteLine($"{mpThree.SongTitle} added to {NameOfPlaylist}");
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
        public void RemoveMP3(int choice)
        {
            MPThreeList.RemoveAt(choice - 1); // -1 to account for computer counting
        }


        /// <summary>
        /// returns a string of the song title
        /// </summary>
        /// <param name="choice">user inputed integer from driver</param>
        /// <returns></returns>
        public string getSongTitle(int choice)
        {
            string title = MPThreeList[choice - 1].SongTitle; // -1 to account for computer counting

            return title;
        }

        /// <summary>
        /// overrides the default tostring method
        /// </summary>
        /// <returns>string</returns>
        public override string ToString()
        {
            string msg = "";
            msg += $"{NameOfPlaylist}|{NameOfCreator}|{DateCreated}";
            for (int i = 0; i < MPThreeList.Count; i++)
            {
                MPThree mpThree = MPThreeList.ElementAt(i);
                Console.WriteLine($"{mpThree.SongTitle}|{mpThree.Artist}|{mpThree.SongPlaytime}");
            }
            return msg;
        }
    }
}
