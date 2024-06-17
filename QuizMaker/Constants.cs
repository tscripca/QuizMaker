﻿using System;
using System.IO;
using QuizMaker;
using System.Xml;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace QuizMaker
{
    internal class Constants
    {
        public const string SAVED_PATH = @"QuizzGame.xml";
        public const int MINUS_ONE = 1;
        public const char BUILD_GAME = '1';
        public const char PLAY_GAME = '2';
    }
}
