﻿#region Using Statements
using System;
using System.Collections.Generic;
using System.Linq;

using AppKit;
using Foundation;
#endregion


static class Program
{
    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    static void Main(string[] args)
    {
        NSApplication.Init();

        using (var game = new MainGame())
        {
            game.Run();
        }
    }
}
