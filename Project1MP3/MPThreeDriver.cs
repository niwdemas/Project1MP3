////////////////////////////////////////////////////////////////////////////////////////////////////////
//
// Project: .
// File Name: .
// Description: .
// Course: CSCI 1260 – Introduction to Computer Science II
// Author: Sam Mitchell, mitchellse1@etsu.edu, East Tennessee State University
// Created: .
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

class MPThreeDriver
{
    private static void RealisticType(string text)
    {
        string textIndex = "";
        for (int i = 0; i < text.Length; i++)
        {
            textIndex += text[i];
            Console.Write(textIndex);
            Console.Write("\r");
            if (text[i] == '\n')
            {
                Thread.Sleep(333);
                textIndex = "";

            }
            else
            {
                Thread.Sleep(3);
            }
        }
    }
    public static void Main(string[] args)
    {
        MPThree mpDefault = new MPThree();
        RealisticType(mpDefault.ToString());
        Console.WriteLine("\nFinish!");

        string name = "";

        Console.WriteLine("Name.");
        name = Console.ReadLine();
    }
}

