﻿using System;
using System.Collections.Generic;
using Terminal.Gui;
using Attribute = Terminal.Gui.Attribute;

namespace ConsoleApp.GameMenu
{
    public static class Global
    {
        

        public const int ButtonTextLength = 1;

        public const bool KaverVer = true;
        
        #region Rider test
        private static Action Test { get; set; }

        private static void SetTest(Action? action = null)
        {
            // IDE doesn't seem to highlight nullable to non-nullable assignment.
            Test = action;
        }
        #endregion
    }
}