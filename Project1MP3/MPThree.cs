using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Project1MP3
{
    internal class MPThree
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

        public override string ToString()
        {
            string msg = "";
            msg += $"MP3 Title:     {SongTitle}";
            msg += $"\nArtist:        {Artist}";
            msg += $"\nRelease Date:  {ReleaseDate}\tGenre: {Genre}";
            msg += $"\nDownload Cost: ${CostOfDownload}\t        File Size: {FileSize}MBs";
            msg += $"\nSong Playtime: {SongPlaytime} minutes\tAlbum Photo: {JPGPath}";
            return msg;
        }

    }
}
