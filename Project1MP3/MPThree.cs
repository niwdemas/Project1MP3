////////////////////////////////////////////////////////////////////////////////////////////////////////
//
// Project: Project1MP3
// File Name: MPThree.cs
// Description: Describes and builds the ability to store and display data about MP3's
// Course: CSCI 1260 – Introduction to Computer Science II
// Author: Sam Mitchell, mitchellse1@etsu.edu, East Tennessee State University
// Created: 9/14/22
// Copyright: Sam Mitchell, 2022
//
////////////////////////////////////////////////////////////////////////////////////////////////////////
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Project1MP3
{
    /// <summary>
    /// Describes and builds the ability to store and display data about MP3's
    /// </summary>
    public class MPThree
    {
        public string SongTitle { get; set; }
        public string Artist { get; set; }
        public string ReleaseDate { get; set; }
        public double SongPlaytime { get; set; } //in minutes
        public Genre Genre { get; set; }
        public decimal CostOfDownload { get; set; } //in dollars
        public double FileSize { get; set; } //in MBs
        public string JPGPath { get; set; }

        /// <summary>
        /// Default Constructor
        /// </summary>
        public MPThree()
        {   
            SongTitle = "Never Gonna Give You Up";
            Artist = "Rick Astley";
            ReleaseDate = "07/27/1987";
            SongPlaytime = 3.33;
            Genre = Genre.Pop;
            CostOfDownload = 1.29M;
            FileSize = 2.7;
            JPGPath = "NeverGonnaGiveYouUpThumbnail.jpg";
        }
        /// <summary>
        /// Paramaterizerd Constructor
        /// </summary>
        /// <param name="songTitle">Name of the song</param>
        /// <param name="artist">Name of the song's artist</param>
        /// <param name="releaseDate">When the song came out</param>
        /// <param name="songPlaytime">How long the song lasts</param>
        /// <param name="genre">What the genre of the song is</param>
        /// <param name="costOfDownload">How much the song costs to download</param>
        /// <param name="fileSize">How big the song is</param>
        /// <param name="jPGPath">Path to the thumbnail of the song</param>
        public MPThree(string songTitle, string artist, string releaseDate, double songPlaytime, Genre genre, decimal costOfDownload, double fileSize, string jPGPath)
        {
            SongTitle = songTitle;
            Artist = artist;
            ReleaseDate = releaseDate;
            SongPlaytime = songPlaytime;
            Genre = genre;
            CostOfDownload = costOfDownload;
            FileSize = fileSize;
            JPGPath = jPGPath;
        }
        /// <summary>
        /// Override of the base ToString statement
        /// </summary>
        /// <returns>returns a formatted string of the MP3</returns>
        public override string ToString()
        {
            string msg = "";
            msg += $"MP3 Title:\t{SongTitle}";
            msg += $"\nArtist:\t{Artist}";
            msg += $"\nRelease Date:\t{ReleaseDate}\tGenre: {Genre}";
            msg += $"\nDownload Cost:\t${CostOfDownload}\t\tFile Size: {FileSize}MBs";
            msg += $"\nSong Playtime:\t{SongPlaytime} minutes\tAlbum Photo: {JPGPath}";
            return msg;
        }

    }
}
