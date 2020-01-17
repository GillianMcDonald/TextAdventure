using System;
using System.Collections.Generic;
using System.Text;

namespace TextAdventure
{
    class ConsoleChanges
    {
        public static void ConsoleDisplay()
        {
            var asciiArray = new[]
            {
                                        @"  ####### ####### #     # ######  ### #######  ",
                                        @"       #  #     # ##   ## #     #  #  #        ",
                                        @"      #   #     # # # # # #     #  #  #        ",
                                        @"     #    #     # #  #  # ######   #  #####    ",
                                        @"   #      #     # #     # #     #  #  #        ",
                                        @"  #       #     # #     # #     #  #  #        ",
                                        @"  ####### ####### #     # ######  ### #######  ",

                                            @"                   .....   ",
                                            @"                  C C  /   ",
                                            @"                /<   /         ",
                                            @" ___ __________/_#__=o            ",
                                            @"/(- /(\_\________   \         ",
                                            @"\ ) \ )_      \o     \         ",
                                            @"/|\ /|\       | '    |   ",
                                            @"              |     _|     ",
                                            @"              / o  __\    ",
                                            @"             / '     |     I WANT TO EAT YOUR BRAINS ",
                                            @"            / /      |     ",
                                            @"          /_ /\______|      ",
                                            @"         (    _(    <      ",
                                            @"           \    \    \     ",
                                            @"            \    \    |      ",
                                            @"             \____\____\    ",
                                            @"             ____\_\__\_\    ",


            };
           
            foreach (string line in asciiArray)
            {
                Console.WriteLine(line);
            }
           
        }
    }
}
