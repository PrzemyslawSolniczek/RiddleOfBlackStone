using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ChooseYourAdventure.Model
{
    public static class PrintingAscii
    {
        public static void DrawAt(int x, int y, object obc)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(obc.ToString());
        }
        public static void DrawAt(int x, int y, object obc, ConsoleColor clr)
        {
            Console.ForegroundColor = clr;
            DrawAt(x, y, obc);
            Console.ResetColor();
        }
        public static void DrawAtBG(int x, int y, object obc, int lenght, ConsoleColor consoleColor)
        {
            Console.BackgroundColor = consoleColor;
            DrawAt(x, y, obc);
            Console.ResetColor();
        }
        public static void DrawLineV(int x, int y, int lenght, object obc, ConsoleColor consoleColor = ConsoleColor.White)
        {
            for (int i = 0; i < lenght; i++)
            {
                DrawAt(x, y, obc, consoleColor);
                y++;
            }
        }
        public static void DrawLineH(int x, int y, int lenght, object obc, ConsoleColor consoleColor = ConsoleColor.White)
        {
            for (int i = 0; i < lenght; i++)
            {
                DrawAt(x, y, obc, consoleColor);
                x++;
            }
        }
        public static void DrawLineByLine(int x, int y, ConsoleColor consoleColor)
        {

        }
        public static void DrawLineAtH(int x, int y, int lenght, object obj, ConsoleColor clr = ConsoleColor.White)
        {
            for (int i = 0; i < lenght; i++)
            {
                DrawAt(x, y, obj, clr);
                x++;
            }
        }
        public static void DrawLineAtH(int x, int y, int lenght, object obc, int sleep, bool reverse, ConsoleColor consoleColor = ConsoleColor.White)
        {
            for (int i = 0; i < lenght; i++)
            {
                DrawAt(x, y, obc, consoleColor);
                if (reverse)
                {
                    x--;
                }
                else
                {
                    x++;
                }
                Thread.Sleep(sleep);
            }
        }
        public static void DrawLineAtV(int x, int y, int lenght, object obc, int sleep, bool reverse, ConsoleColor consoleColor = ConsoleColor.White)
        {
            for (int i = 0; i < lenght; i++)
            {
                DrawAt(x, y, obc, consoleColor);
                if (reverse)
                {
                    x--;
                }
                else
                {
                    x++;
                }
                Thread.Sleep(sleep);
            }
        }
        /*
        x - kolumna
        y - rząd
        str - string do wyświetlenia
        sleep - odstep czasu miedzy wypisywaniem
        reverse - opcja gdyby uzytkownik chcial aby wypisalo od prawej do lewej
        */
        public static void DrawStringCharByChar(int x, int y, string str, int sleep, bool reverse, ConsoleColor clr = ConsoleColor.White)
        {
            if (reverse)
            {
                x = x + str.Length - 1;
                for (int i = str.Length - 1; i >= 0; i--)
                {
                    DrawAt(x, y, str[i], clr);
                    x--;
                    Thread.Sleep(sleep);
                }
            }
            else
            {
                for (int i = 0; i < str.Length; i++)
                {
                    DrawAt(x, y, str[i], clr);
                    x++;
                    Thread.Sleep(sleep);
                }
            }
        }
        public static void IncorrectAnswer()
        {
            DrawAt(22, 1, "| __ )| | ___  __| |_ __   __ _                     ", ConsoleColor.Red);
            DrawAt(22, 2, "|  _ \\|/// _ \\/ _` | '_ \\ / _` |                    ", ConsoleColor.Red);
            DrawAt(22, 3, "| |_) //|  __/ (_| | | | | (_| |                    ", ConsoleColor.Red);
            DrawAt(22, 4, "|____/|_|\\___|\\__,_|_| |_|\\__,_|                    ", ConsoleColor.Red);
            DrawAt(22, 5, "           (_(                   _          _   _ _ ", ConsoleColor.Red);
            DrawAt(22, 6, "  ___   __| |_ __   _____      _(_) ___  __| |_/_/ |", ConsoleColor.Red);
            DrawAt(22, 7, " / _ \\ / _` | '_ \\ / _ \\ \\ /\\ / / |/ _ \\/ _` |_  / |", ConsoleColor.Red);
            DrawAt(22, 8, "| (_) | (_| | |_) | (_) \\ V  V /| |  __/ (_| |/ /|_|", ConsoleColor.Red);
            DrawAt(22, 9, " \\___/ \\__,_| .__/ \\___/ \\_/\\_/ |_|\\___|\\__,_/___(_)", ConsoleColor.Red);
            DrawAt(22, 10, "            |_|                                     ", ConsoleColor.Red);
            DrawStringCharByChar(22, 11, @"Otrzymujesz uderzenie od przeciwnika", 1, false, ConsoleColor.DarkGray);
        }

        public static void CorrectAnswer()
        {
            DrawAt(22, 1, @" ____                     _     _ _                    ", ConsoleColor.Green);
            DrawAt(22, 2, @"|  _ \ _ __ __ ___      _(_) __| | | _____      ____ _ ", ConsoleColor.Green);
            DrawAt(22, 3, @"| |_) | '__/ _` \ \ /\ / / |/ _` |/// _ \ \ /\ / / _` |", ConsoleColor.Green);
            DrawAt(22, 4, @"|  __/| | | (_| |\ V  V /| | (_| //| (_) \ V  V / (_| |", ConsoleColor.Green);
            DrawAt(22, 5, @"|_|   |_|  \__,_| \_/\_/ |_|\__,_|_|\___/ \_/\_/_\__,_|", ConsoleColor.Green);
            DrawAt(22, 6, @"  ___   __| |_ __   _____      _(_) ___  __| |_/_/        ", ConsoleColor.Green);
            DrawAt(22, 7, @" / _ \ / _` | '_ \ / _ \ \ /\ / / |/ _ \/ _` |_  / ", ConsoleColor.Green);
            DrawAt(22, 8, @"| (_) | (_| | |_) | (_) \ V  V /| |  __/ (_| |/ /    ", ConsoleColor.Green);
            DrawAt(22, 9, @" \___/ \__,_| .__/ \___/ \_/\_/ |_|\___|\__,_/___|  ", ConsoleColor.Green);
            DrawAt(22, 10, @"           |_|                   ", ConsoleColor.Green);

        }
        public static void GameOver()
        {
            DrawAt(22, 1, "+=========================================================+", ConsoleColor.Red);
            DrawAt(22, 2, "|                                                         |", ConsoleColor.Red);
            DrawAt(22, 3, "|                                                         |", ConsoleColor.Red);
            DrawAt(22, 4, "|                                                         |", ConsoleColor.Red);
            DrawAt(22, 5, "|  ____    _    __  __ _____    _____     _______ ____  _ |", ConsoleColor.Red);
            DrawAt(22, 6, "| / ___|  / \\  |  \\/  | ____|  / _ \\ \\   / / ____|  _ \\| ||", ConsoleColor.Red);
            DrawAt(22, 7, "|| |  _  / _ \\ | |\\/| |  _|   | | | \\ \\ / /|  _| | |_) | ||", ConsoleColor.Red);
            DrawAt(22, 8, "|| |_| |/ ___ \\| |  | | |___  | |_| |\\ V / | |___|  _ <|_||", ConsoleColor.Red);
            DrawAt(22, 9, "| \\____/_/   \\_\\_|  |_|_____|  \\___/  \\_/  |_____|_| \\_(_)|", ConsoleColor.Red);
            DrawAt(22, 10, "|                                                         |", ConsoleColor.Red);
            DrawAt(22, 11, "|                                                         |", ConsoleColor.Red);
            DrawAt(22, 12, "|                                                         |", ConsoleColor.Red);
            DrawAt(22, 13, "+=========================================================+", ConsoleColor.Red);
            DrawStringCharByChar(22, 25, @"Gra rozpocznie się od nowa", 10, false, ConsoleColor.Red);


        }
        public static void DrawCave()
        {
            DrawAt(22, 2, @"|.'.'',                                 ,''.'.|", ConsoleColor.Yellow);
            DrawAt(22, 3, @"|.'.'.'',                             ,''.'.'.|", ConsoleColor.Yellow);
            DrawAt(22, 4, @"|.'.'.'.'',                         ,''.'.'.'.|", ConsoleColor.Yellow);
            DrawAt(22, 5, @"|.'.'.'.'.|                         |.'.'.'.'.|", ConsoleColor.Yellow);
            DrawAt(22, 6, @"|.'.'.'.'.|===;                 ;===|.'.'.'.'.|", ConsoleColor.Yellow);
            DrawAt(22, 7, @"|.'.'.'.'.|:::|',             ,'|:::|.'.'.'.'.|", ConsoleColor.Yellow);
            DrawAt(22, 8, @"|.'.'.'.'.|---|'.|, _______ ,|.'|---|.'.'.'.'.|", ConsoleColor.Yellow);
            DrawAt(22, 9, @"|.'.'.'.'.|:::|'.|'|.......|'|.'|:::|.'.'.'.'.|", ConsoleColor.Yellow);
            DrawAt(22, 10, @"|,',',',',|---|',|'|.......|'|,'|---|,',',',',|", ConsoleColor.Yellow);
            DrawAt(22, 11, @"|.'.'.'.'.|:::|'.|'|.......|'|.'|:::|.'.'.'.'.|", ConsoleColor.Yellow);
            DrawAt(22, 12, @"|.'.'.'.'.|---|','   /%%%\   ','|---|.'.'.'.'.|", ConsoleColor.Yellow);
            DrawAt(22, 13, @"|.'.'.'.'.|===:'    /%%%%%\    ':===|.'.'.'.'.|", ConsoleColor.Yellow);
            DrawAt(22, 14, @"|.'.'.'.'.|%%%%%%%%%%%%%%%%%%%%%%%%%|.'.'.'.'.|", ConsoleColor.Yellow);
            DrawAt(22, 15, @"|.'.'.'.','       /%%%%%%%%%\       ','.'.'.'.|", ConsoleColor.Yellow);
            DrawAt(22, 16, @"|.'.'.','        /%%%%%%%%%%%\        ','.'.'.|", ConsoleColor.Yellow);
            DrawAt(22, 17, @"|.'.','         /%%%%%%%%%%%%%\         ','.'.|", ConsoleColor.Yellow);
            DrawAt(22, 18, @"|.','          /%%%%%%%%%%%%%%%\          ','.|", ConsoleColor.Yellow);
            DrawAt(22, 19, @"|;____________/%%%%%%%%%%%%%%%%%\____________;|", ConsoleColor.Yellow);
            //DrawAt()
        }

        public static void DrawSkeleton()
        {
            DrawAt(22, 1, @"     .-.", ConsoleColor.Yellow);
            DrawAt(22, 2, @"    (o.o)", ConsoleColor.Yellow);
            DrawAt(22, 3, @"     |=|", ConsoleColor.Yellow);
            DrawAt(22, 4, @"    __|__", ConsoleColor.Yellow);
            DrawAt(22, 5, @"  //.=|=.\\", ConsoleColor.Yellow);
            DrawAt(22, 6, @" // .=|=. \\", ConsoleColor.Yellow);
            DrawAt(22, 7, @" \\ .=|=. //", ConsoleColor.Yellow);
            DrawAt(22, 8, @"  \\(_=_)//", ConsoleColor.Yellow);
            DrawAt(22, 9, @"   (:| |:)", ConsoleColor.Yellow);
            DrawAt(22, 10, @"    || ||", ConsoleColor.Yellow);
            DrawAt(22, 11, @"    () ()", ConsoleColor.Yellow);
            DrawAt(22, 12, @"    || ||", ConsoleColor.Yellow);
            DrawAt(22, 13, @"    || ||", ConsoleColor.Yellow);
            DrawAt(22, 14, @"   ==' '==", ConsoleColor.Yellow);
        }
        public static void DrawDragon()
        {
            DrawAt(22, 1, @"       ,     \\     //      ,        ");
            DrawAt(22, 2, @"      / \\    )\\__//(     / \\       ");
            DrawAt(22, 3, @"     /   \\  (_\\  //_)   /   \\      ");
            DrawAt(22, 4, @"____/_____\\__\\@  @/___/_____\\____ ");
            DrawAt(22, 5, @"|             |\\..//|              |");
            DrawAt(22, 6, @"|              \\VV//               |");
            DrawAt(22, 7, @"|        ----------------         |");
            DrawAt(22, 8, @"|_________________________________|");
            DrawAt(22, 9, @" |    /\\ /      \\\\       \\ /\\ | ");
            DrawAt(22, 10, @" |  /   V        ))       V   \\  | ");
            DrawAt(22, 11, @" |/     `       //        '     \\| ");
            DrawAt(22, 12, @" `              V                ' ");
        }

        public static void DrawStone()
        {
            DrawAt(10, 1, @"                                                 ##                                                 ", ConsoleColor.DarkGray);
            DrawAt(10, 2, @"                                  ##+            ##            ##+                                  ", ConsoleColor.DarkGray);
            DrawAt(10, 3, @"                                    ##-                      +##                                    ", ConsoleColor.DarkGray);
            DrawAt(10, 6, @"                                                                                                    ", ConsoleColor.DarkGray);
            DrawAt(10, 7, @"                         ###-         ########################         +##.                         ", ConsoleColor.DarkGray);
            DrawAt(10, 8, @"                             ###   ###   ##      ##      ##   ###   ###                             ", ConsoleColor.DarkGray);
            DrawAt(10, 9, @"                                -##.   -#-       ##       ##.     ..                                ", ConsoleColor.DarkGray);
            DrawAt(10, 10, @"                               ##     ##.        ##        -#+     ###                              ", ConsoleColor.DarkGray);
            DrawAt(10, 11, @"                           ###       ##          ##          ##      .###                           ", ConsoleColor.DarkGray);
            DrawAt(10, 12, @"                         ##-        ##           ##           ##        +##                         ", ConsoleColor.DarkGray);
            DrawAt(10, 13, @"                        ##############+++++++++++####+  +####+##+++++++++###                        ", ConsoleColor.DarkGray);
            DrawAt(10, 14, @"                          ##         ##          ##          ##         ##                          ", ConsoleColor.DarkGray);
            DrawAt(10, 15, @"                           .##        #+         ##         ##        ##                            ", ConsoleColor.DarkGray);
            DrawAt(10, 16, @"                             ##+      .#-        ##        +#       ###                             ", ConsoleColor.DarkGray);
            DrawAt(10, 17, @"                               ##.     -#.       ##       +#      .##                               ", ConsoleColor.DarkGray);
            DrawAt(10, 18, @"                                 ##     -#       ##      .#.     ##                                 ", ConsoleColor.DarkGray);
            DrawAt(10, 19, @"                                  -#+    +#      ##     .#-    ##-                                  ", ConsoleColor.DarkGray);
            DrawAt(10, 20, @"                                     #+   ##     ##    .#+   ###                                    ", ConsoleColor.DarkGray);
            DrawAt(10, 21, @"                                      #    ##    ##    ##  .##                                      ", ConsoleColor.DarkGray);
            DrawAt(10, 22, @"                                        ##  ##   ##   ##  ##                                        ", ConsoleColor.DarkGray);
            DrawAt(10, 23, @"                                         -## ##  ##  ## ##-                                         ", ConsoleColor.DarkGray);
            DrawAt(10, 24, @"                                           ##+## ## ##+##                                           ", ConsoleColor.DarkGray);
            DrawAt(10, 25, @"                                             ##########                                             ", ConsoleColor.DarkGray);
            DrawAt(10, 26, @"                                                -##+                                                ", ConsoleColor.DarkGray);
            Console.SetCursorPosition(0, 28);
        }
        public static void drawArchaeologist()
        {
            DrawAt(10, 1, @".. .. ..########+###### .  .  . ..", ConsoleColor.DarkGray);
            DrawAt(10, 2, @".. .  .#  ---------------#.. .. .. ", ConsoleColor.DarkGray);
            DrawAt(10, 3, @".. .  #-------------------#. .. .. ", ConsoleColor.DarkGray);
            DrawAt(10, 4, @" .. ..#------------------++#.  . ..", ConsoleColor.DarkGray);
            DrawAt(10, 5, @".. .  #---------------+++++# .. .. ", ConsoleColor.DarkGray);
            DrawAt(10, 6, @" .. ..#+++++++++++++++++########+..", ConsoleColor.DarkGray);
            DrawAt(10, 7, @".#####+++++++++++++++##------++++#", ConsoleColor.DarkGray);
            DrawAt(10, 8, @"#+---------------------++++++++++##", ConsoleColor.DarkGray);
            DrawAt(10, 9, @" .####+++++++++++++++++++++++++##..", ConsoleColor.DarkGray);
            DrawAt(10, 10, @".. .  .#...............#####... .. ", ConsoleColor.DarkGray);
            DrawAt(10, 11, @".. .  .+.#+.......#....#..##... .. ", ConsoleColor.DarkGray);
            DrawAt(10, 12, @" .. .. +...............-####.  . ..", ConsoleColor.DarkGray);
            DrawAt(10, 13, @".. .  .#...............####. .. .. ", ConsoleColor.DarkGray);
            DrawAt(10, 14, @" .. .. #...............##.  .  . ..", ConsoleColor.DarkGray);
            DrawAt(10, 15, @" .. .. .#............-## .  .  . ..", ConsoleColor.DarkGray);
            DrawAt(10, 16, @".. .  .  -##########-######. .. .. ", ConsoleColor.DarkGray);
            DrawAt(10, 17, @" .. .. ..#-##   ##--##--#++#.  . ..", ConsoleColor.DarkGray);
            DrawAt(10, 18, @".. .  . ###-#  ##-#+##--++++#.. .. ", ConsoleColor.DarkGray);
            DrawAt(10, 19, @".. .  .#-+--#.#---#--#---+++#.. .. ", ConsoleColor.DarkGray);
            DrawAt(10, 20, @" .. .. #-#--#---##---#---++++# . ..", ConsoleColor.DarkGray);
            DrawAt(10, 21, @".. .  #--##--##.-#----#---++##. .. ", ConsoleColor.DarkGray);
            DrawAt(10, 22, @" .. ..+..-#########----......# . ..", ConsoleColor.DarkGray);
            DrawAt(10, 23, @" .. .. #.-+##----#----##+..+#  . ..", ConsoleColor.DarkGray);
            DrawAt(10, 24, @".. .  .  .+---####----++++#. .. .. ", ConsoleColor.DarkGray);
            DrawAt(10, 25, @" .. .. ...+---+++#----++++# .  . ..", ConsoleColor.DarkGray);
            DrawAt(10, 26, @".. .  .  .########----++++#. .. .. ", ConsoleColor.DarkGray);
            DrawAt(10, 27, @".. .  . -#------##--------#. .. .. ", ConsoleColor.DarkGray);
            DrawAt(10, 28, @" .. .. ..-......########### .  . ..", ConsoleColor.DarkGray);
            DrawAt(10, 29, @" .. .. ..########+###### .  .  . ..", ConsoleColor.DarkGray);

        }
        public static void drawDeath()
        {
            DrawAt(10, 4, @"                   ..###############                  ", ConsoleColor.DarkGray);
            DrawAt(10, 5, @"                 .####+. .......-#######-.            ", ConsoleColor.DarkGray);
            DrawAt(10, 6, @"                +#..+#.........-##  .####             ", ConsoleColor.DarkGray);
            DrawAt(10, 7, @"              .#.#.    .######.     +###-             ", ConsoleColor.DarkGray);
            DrawAt(10, 8, @"             .##.    .##########..  .#...             ", ConsoleColor.DarkGray);
            DrawAt(10, 9, @"            .#     .##############. .-..              ", ConsoleColor.DarkGray);
            DrawAt(10, 10, @"                  .#####..  ..#####...#.              ", ConsoleColor.DarkGray);
            DrawAt(10, 11, @"                  ###.       .  .###+.#.              ", ConsoleColor.DarkGray);
            DrawAt(10, 12, @"                  ###.#### .####.##-#.#.              ", ConsoleColor.DarkGray);
            DrawAt(10, 13, @"                  ###.####..###-.##.#..               ", ConsoleColor.DarkGray);
            DrawAt(10, 14, @"                  ####-...... .###-..-.               ", ConsoleColor.DarkGray);
            DrawAt(10, 15, @"                  ###############-...#                ", ConsoleColor.DarkGray);
            DrawAt(10, 16, @"                .########.  -###   #.#                ", ConsoleColor.DarkGray);
            DrawAt(10, 17, @"                ..-+-.##########   #.#                ", ConsoleColor.DarkGray);
            DrawAt(10, 18, @"                    .+###########..#.-                ", ConsoleColor.DarkGray);
            DrawAt(10, 19, @"                    .###############.#.               ", ConsoleColor.DarkGray);
            DrawAt(10, 20, @"                   .##############.....               ", ConsoleColor.DarkGray);
            DrawAt(10, 21, @"                   .###############..#                ", ConsoleColor.DarkGray);
            DrawAt(10, 22, @"                    ###############.#                 ", ConsoleColor.DarkGray);
            DrawAt(10, 23, @"                   ..############.#.#                 ", ConsoleColor.DarkGray);
            DrawAt(10, 24, @"                   .+##############.-                 ", ConsoleColor.DarkGray);
            DrawAt(10, 25, @"                   .###############..                 ", ConsoleColor.DarkGray);
            DrawAt(10, 26, @"                  .#################                  ", ConsoleColor.DarkGray);
            DrawAt(10, 27, @"                    .############-.                   ", ConsoleColor.DarkGray);

        }

        public static void HighScore()
        {
            DrawAt(1, 2, @".                                                               +         ", ConsoleColor.Cyan);
            DrawAt(1, 3, @"      .           +                 ,             *                       ", ConsoleColor.Cyan);
            DrawAt(1, 4, @"   .                             .     .                         .        ", ConsoleColor.Cyan);
            DrawAt(1, 5, @"     ,              *                     .                '        *     ", ConsoleColor.Cyan);
            DrawAt(1, 6, @"                                .                                       ' ", ConsoleColor.Cyan);
            DrawAt(1, 7, @"                                                +                        ", ConsoleColor.Cyan);
            DrawAt(1, 8, @"                                                              .          ", ConsoleColor.Cyan);
            DrawAt(1, 9, @"             *                                                           ", ConsoleColor.Cyan);
            DrawAt(1, 10, @"                           '                                             ", ConsoleColor.Cyan);
            DrawAt(1, 11, @"   .                               +                          .           ", ConsoleColor.Cyan);
            DrawAt(1, 12, @"                  *         .                       +                     ", ConsoleColor.Cyan);
            DrawAt(1, 13, @"      .                                                                 ", ConsoleColor.Cyan);
            DrawAt(1, 14, @"              ,                                                           ", ConsoleColor.Cyan);
            DrawAt(1, 15, @"                                                        +               ", ConsoleColor.Cyan);
            DrawAt(1, 16, @"                 *                                                      ", ConsoleColor.Cyan);
            DrawAt(1, 17, @"     .                                               *                  ", ConsoleColor.Cyan);
            DrawAt(1, 18, @"                                                *                      ", ConsoleColor.Cyan);
            DrawAt(1, 19, @".                    *                                                    ", ConsoleColor.Cyan);
            DrawAt(1, 20, @".                            *                                     +      ", ConsoleColor.Cyan);
            DrawAt(1, 21, @"                                                *                         ", ConsoleColor.Cyan);
            DrawAt(1, 22, @"                                                        ,                   ", ConsoleColor.Cyan);
            DrawAt(1, 23, @"         +                                 *                               ", ConsoleColor.Cyan);
            DrawAt(1, 24, @"                                                                           ", ConsoleColor.Cyan);
            DrawAt(1, 25, @".                    *                                                    ", ConsoleColor.Cyan);
            DrawAt(1, 26, @".                            *                                     +      ", ConsoleColor.Cyan);
            DrawAt(1, 27, @"                                                *                         ", ConsoleColor.Cyan);
            DrawAt(1, 28, @"                                                        ,                   ", ConsoleColor.Cyan);
            DrawStringCharByChar(18, 5, @" _  _ _      _      ___", 5, false, ConsoleColor.Magenta);
            DrawStringCharByChar(18, 6, @"| || (_)__ _| |_   / __| __ ___ _ _ ___", 3, true, ConsoleColor.Magenta);
            DrawStringCharByChar(18, 7, @"| __ | / _` | ' \  \__ \/ _/ _ \ '_/ -_)", 3, false, ConsoleColor.Magenta);
            DrawStringCharByChar(18, 8, @"|_||_|_\__, |_||_| |___/\__\___/_| \___|", 3, true, ConsoleColor.Magenta);
            DrawStringCharByChar(25, 9, @"|___/", 5, false, ConsoleColor.Magenta);
            Thread.Sleep(550);
        }

        public static void WelcomeScreen()
        {
            DrawAt(26, 2, "██╗    ██╗███████╗██╗      ██████╗ ██████╗ ███╗   ███╗███████╗██╗");
            Thread.Sleep(200);
            DrawAt(26, 3, "██║    ██║██╔════╝██║     ██╔════╝██╔═══██╗████╗ ████║██╔════╝██║");
            Thread.Sleep(200);
            DrawAt(26, 4, "██║ █╗ ██║█████╗  ██║     ██║     ██║   ██║██╔████╔██║█████╗  ██║");
            Thread.Sleep(200);
            DrawAt(26, 5, "██║███╗██║██╔══╝  ██║     ██║     ██║   ██║██║╚██╔╝██║██╔══╝  ╚═╝");
            Thread.Sleep(200);
            DrawAt(26, 6, "╚███╔███╔╝███████╗███████╗╚██████╗╚██████╔╝██║ ╚═╝ ██║███████╗██╗");
            Thread.Sleep(200);
            DrawAt(26, 7, " ╚══╝╚══╝ ╚══════╝╚══════╝ ╚═════╝ ╚═════╝ ╚═╝     ╚═╝╚══════╝╚═╝");
            Thread.Sleep(800);
            DrawAt(40, 10, @".. .. ..########+###### .  .  . ..", ConsoleColor.DarkGray);
            Thread.Sleep(100);
            DrawAt(40, 11, @".. .  .#  ---------------#.. .. .. ", ConsoleColor.DarkGray);
            Thread.Sleep(100);
            DrawAt(40, 12, @".. .  #-------------------#. .. .. ", ConsoleColor.DarkGray);
            Thread.Sleep(100);
            DrawAt(40, 13, @" .. ..#------------------++#.  . ..", ConsoleColor.DarkGray);
            Thread.Sleep(100);
            DrawAt(40, 14, @".. .  #---------------+++++# .. .. ", ConsoleColor.DarkGray);
            Thread.Sleep(100);
            DrawAt(40, 15, @" .. ..#+++++++++++++++++########+..", ConsoleColor.DarkGray);
            Thread.Sleep(100);
            DrawAt(40, 16, @".#####+++++++++++++++##------++++#", ConsoleColor.DarkGray);
            Thread.Sleep(100);
            DrawAt(40, 17, @"#+---------------------++++++++++##", ConsoleColor.DarkGray);
            Thread.Sleep(100);
            DrawAt(40, 18, @" .####+++++++++++++++++++++++++##..", ConsoleColor.DarkGray);
            Thread.Sleep(100);
            DrawAt(40, 19, @".. .  .#...............#####... .. ", ConsoleColor.DarkGray);
            Thread.Sleep(100);
            DrawAt(40, 20, @".. .  .+.#+.......#....#..##... .. ", ConsoleColor.DarkGray);
            Thread.Sleep(100);
            DrawAt(40, 21, @" .. .. +...............-####.  . ..", ConsoleColor.DarkGray);
            Thread.Sleep(100);
            DrawAt(40, 22, @".. .  .#...............####. .. .. ", ConsoleColor.DarkGray);
            Thread.Sleep(100);
            DrawAt(40, 23, @" .. .. #...............##.  .  . ..", ConsoleColor.DarkGray);
            Thread.Sleep(100);
            DrawAt(40, 24, @" .. .. .#............-## .  .  . ..", ConsoleColor.DarkGray);
            Thread.Sleep(100);
            DrawAt(40, 25, @" .. .. ..########+###### .  .  . ..", ConsoleColor.DarkGray);
            Thread.Sleep(2000);

        }

        public static void FirstScreen()
        {

            DrawAt(1, 2, @"                     .                                               +                         +          * ", ConsoleColor.Cyan);
            DrawAt(1, 3, @"                          .                    +              ,              *                     ", ConsoleColor.Cyan);
            DrawAt(1, 4, @"                    .                               .          .                         .        ", ConsoleColor.Cyan);
            DrawAt(1, 5, @"                      ,                *                        .                   '        *     ", ConsoleColor.Cyan);
            DrawAt(1, 6, @"                                             .                                              '       ", ConsoleColor.Cyan);
            DrawAt(1, 7, @"                                                         +                                           ", ConsoleColor.Cyan);
            DrawAt(1, 8, @"                                                                   .                                         ", ConsoleColor.Cyan);
            DrawAt(1, 9, @"             *                                                                                             +  ", ConsoleColor.Cyan);
            DrawAt(1, 10, @"                           '                                                                 +           .       ", ConsoleColor.Cyan);
            DrawAt(1, 11, @"   .                               +                          .                         +                   ", ConsoleColor.Cyan);
            DrawAt(1, 12, @"                  *         .                       +                                               ", ConsoleColor.Cyan);
            DrawAt(1, 13, @"      .                                                                  .                        ", ConsoleColor.Cyan);
            DrawAt(1, 14, @"              ,                                                                                    ", ConsoleColor.Cyan);
            DrawAt(1, 15, @"                                                        +                           +            ", ConsoleColor.Cyan);
            DrawAt(1, 16, @"                 *                                                                               ", ConsoleColor.Cyan);
            DrawAt(1, 17, @"     .                                               *                                      +     ", ConsoleColor.Cyan);
            DrawAt(1, 18, @"                                                *                                               ", ConsoleColor.Cyan);
            DrawAt(1, 19, @".                    *                                                                   ,          ", ConsoleColor.Cyan);
            DrawAt(1, 20, @".                            *                                     +                               ", ConsoleColor.Cyan);
            DrawAt(1, 21, @"                                                *                                               ", ConsoleColor.Cyan);
            DrawAt(1, 22, @"                                                        ,                         ,                ", ConsoleColor.Cyan);
            DrawAt(1, 23, @"         +                                 *                                                     ", ConsoleColor.Cyan);
            DrawAt(1, 24, @"                                                                                           ,        ", ConsoleColor.Cyan);
            DrawAt(1, 25, @".                    *                                                                             ", ConsoleColor.Cyan);
            DrawAt(1, 26, @".                            *                                     +                          +     ", ConsoleColor.Cyan);
            DrawAt(1, 27, @"                                                *                                               ", ConsoleColor.Cyan);
            DrawAt(1, 28, @"                                                        ,                                         ", ConsoleColor.Cyan);



            DrawStringCharByChar(22, 2, @"            ____  ___ ____  ____  _     _____    ___  _____      ", 1, false, ConsoleColor.DarkGray);
            DrawStringCharByChar(22, 3, @"           |  _ \|_ _|  _ \|  _ \| |   | ____|  / _ \|  ___|      ", 1, true, ConsoleColor.DarkGray);
            DrawStringCharByChar(22, 4, @"           | |_) || || | | | | | | |   |  _|   | | | | |       ", 1, false, ConsoleColor.DarkGray);
            DrawStringCharByChar(22, 5, @"           |  _ < | || |_| | |_| | |___| |___  | |_| |  _|      ", 1, true, ConsoleColor.DarkGray);
            DrawStringCharByChar(22, 6, @"           |_|_\_\___|____/|____/|_____|_____|__\___/|_|       ", 1, false, ConsoleColor.DarkGray);
            DrawStringCharByChar(22, 7, @"           | __ )| |      / \  / ___| |/ / / ___|_   _/ _ \| \ | | ____|       ", 1, false, ConsoleColor.DarkGray);
            DrawStringCharByChar(22, 8, @"           |  _ \| |     / _ \| |   | ' /  \___ \ | || | | |  \| |  _|        ", 1, false, ConsoleColor.DarkGray);
            DrawStringCharByChar(22, 9, @"           | |_) | |___ / ___ \ |___| . \   ___) || || |_| | |\  | |_       ", 1, false, ConsoleColor.DarkGray);
            DrawStringCharByChar(22, 10, @"           |____/|_____/_/   \_\____|_|\_\ |____/ |_| \___/|_| \_|_____|       ", 1, false, ConsoleColor.DarkGray);
            Console.WriteLine("\n\n\n");
        }
        public static void Title()
        {
            Console.Clear();
            DrawAt(1, 2, @"                     .                                               +                         +          * ", ConsoleColor.Cyan);
            DrawAt(1, 3, @"                          .                    +              ,              *                     ", ConsoleColor.Cyan);
            DrawAt(1, 4, @"                    .                               .          .                         .        ", ConsoleColor.Cyan);
            DrawAt(1, 5, @"                      ,                *                        .                   '        *     ", ConsoleColor.Cyan);
            DrawAt(1, 6, @"                                             .                                              '       ", ConsoleColor.Cyan);
            DrawAt(1, 7, @"                                                         +                                           ", ConsoleColor.Cyan);
            DrawAt(1, 8, @"                                                                   .                                         ", ConsoleColor.Cyan);
            DrawAt(1, 9, @"             *                                                                                             +  ", ConsoleColor.Cyan);
            DrawAt(1, 10, @"                           '                                                                 +           .       ", ConsoleColor.Cyan);
            DrawAt(1, 11, @"   .                               +                          .                         +                   ", ConsoleColor.Cyan);
            DrawAt(1, 12, @"                  *         .                       +                                               ", ConsoleColor.Cyan);
            DrawAt(1, 13, @"      .                                                                  .                        ", ConsoleColor.Cyan);
            DrawAt(1, 14, @"              ,                                                                                    ", ConsoleColor.Cyan);
            DrawAt(1, 15, @"                                                        +                           +            ", ConsoleColor.Cyan);
            DrawAt(1, 16, @"                 *                                                                               ", ConsoleColor.Cyan);
            DrawAt(1, 17, @"     .                                               *                                      +     ", ConsoleColor.Cyan);
            DrawAt(1, 18, @"                                                *                                               ", ConsoleColor.Cyan);
            DrawAt(1, 19, @".                    *                                                                   ,          ", ConsoleColor.Cyan);
            DrawAt(1, 20, @".                            *                                     +                               ", ConsoleColor.Cyan);
            DrawAt(1, 21, @"                                                *                                               ", ConsoleColor.Cyan);
            DrawAt(1, 22, @"                                                        ,                         ,                ", ConsoleColor.Cyan);
            DrawAt(1, 23, @"         +                                 *                                                     ", ConsoleColor.Cyan);
            DrawAt(1, 24, @"                                                                                           ,        ", ConsoleColor.Cyan);
            DrawAt(1, 25, @".                    *                                                                             ", ConsoleColor.Cyan);
            DrawAt(1, 26, @".                            *                                     +                          +     ", ConsoleColor.Cyan);
            DrawAt(1, 27, @"                                                *                                               ", ConsoleColor.Cyan);
            DrawAt(1, 28, @"                                                        ,                                         ", ConsoleColor.Cyan);


            DrawAt(22, 2, @"            ____  ___ ____  ____  _     _____    ___  _____      ", ConsoleColor.DarkGray);
            DrawAt(22, 3, @"           |  _ \|_ _|  _ \|  _ \| |   | ____|  / _ \|  ___|      ", ConsoleColor.DarkGray);
            DrawAt(22, 4, @"           | |_) || || | | | | | | |   |  _|   | | | | |       ", ConsoleColor.DarkGray);
            DrawAt(22, 5, @"           |  _ < | || |_| | |_| | |___| |___  | |_| |  _|      ", ConsoleColor.DarkGray);
            DrawAt(22, 6, @"           |_|_\_\___|____/|____/|_____|_____|__\___/|_|       ", ConsoleColor.DarkGray);
            DrawAt(22, 7, @"           | __ )| |      / \  / ___| |/ / / ___|_   _/ _ \| \ | | ____|       ", ConsoleColor.DarkGray);
            DrawAt(22, 8, @"           |  _ \| |     / _ \| |   | ' /  \___ \ | || | | |  \| |  _|        ", ConsoleColor.DarkGray);
            DrawAt(22, 9, @"           | |_) | |___ / ___ \ |___| . \   ___) || || |_| | |\  | |_       ", ConsoleColor.DarkGray);
            DrawAt(22, 10, @"           |____/|_____/_/   \_\____|_|\_\ |____/ |_| \___/|_| \_|_____|       ", ConsoleColor.DarkGray);
            Console.WriteLine("\n\n\n");

        }

        public static void Authors()
        {
            DrawAt(1, 2, @".                                                               +         ", ConsoleColor.Cyan);
            DrawAt(1, 3, @"      .           +                 ,             *                       ", ConsoleColor.Cyan);
            DrawAt(1, 4, @"   .                             .     .                         .        ", ConsoleColor.Cyan);
            DrawAt(1, 5, @"     ,              *                     .                '        *     ", ConsoleColor.Cyan);
            DrawAt(1, 6, @"                                .                                       ' ", ConsoleColor.Cyan);
            DrawAt(1, 7, @"                                                +                        ", ConsoleColor.Cyan);
            DrawAt(1, 8, @"                                                              .          ", ConsoleColor.Cyan);
            DrawAt(1, 9, @"             *                                                           ", ConsoleColor.Cyan);
            DrawAt(1, 10, @"                           '                                             ", ConsoleColor.Cyan);
            DrawAt(1, 11, @"   .                               +                          .           ", ConsoleColor.Cyan);
            DrawAt(1, 12, @"                  *         .                       +                     ", ConsoleColor.Cyan);
            DrawAt(1, 13, @"      .                                                                 ", ConsoleColor.Cyan);
            DrawAt(1, 14, @"              ,                                                           ", ConsoleColor.Cyan);
            DrawAt(1, 15, @"                                                        +               ", ConsoleColor.Cyan);
            DrawAt(1, 16, @"                 *                                                      ", ConsoleColor.Cyan);
            DrawAt(1, 17, @"     .                                               *                  ", ConsoleColor.Cyan);
            DrawAt(1, 18, @"                                                *                      ", ConsoleColor.Cyan);
            DrawAt(1, 19, @".                    *                                                    ", ConsoleColor.Cyan);
            DrawAt(1, 20, @".                            *                                     +      ", ConsoleColor.Cyan);
            DrawAt(1, 21, @"                                                *                         ", ConsoleColor.Cyan);
            DrawAt(1, 22, @"                                                        ,                   ", ConsoleColor.Cyan);
            DrawAt(1, 23, @"         +                                 *                               ", ConsoleColor.Cyan);
            DrawAt(1, 24, @"                                                                           ", ConsoleColor.Cyan);
            DrawAt(1, 25, @".                    *                                                    ", ConsoleColor.Cyan);
            DrawAt(1, 26, @".                            *                                     +      ", ConsoleColor.Cyan);
            DrawAt(1, 27, @"                                                *                         ", ConsoleColor.Cyan);
            DrawAt(1, 28, @"                                                        ,                   ", ConsoleColor.Cyan);
            Thread.Sleep(650);
            DrawAt(23, 6, @"   _____           ___ __   ", ConsoleColor.Yellow);
            DrawAt(23, 7, @"  / ___/______ ___/ (_) /____", ConsoleColor.Yellow);
            DrawAt(23, 8, @" / /__/ __/ -_) _  / / __(_-<", ConsoleColor.Yellow);
            DrawAt(23, 9, @" \___/_/  \__/\_,_/_/\__/___/", ConsoleColor.Yellow);
            Thread.Sleep(1500);
            DrawAt(23, 13, @"         AUTORZY:", ConsoleColor.Yellow);
            Thread.Sleep(650);
            DrawAt(23, 15, @"         Przemysław Solniczek", ConsoleColor.Gray);
            Thread.Sleep(500);
            DrawAt(23, 16, @"         Albert Stefanowski", ConsoleColor.Gray);
            Thread.Sleep(500);
            DrawAt(5, 26, @"Naciśnij dowolny klasiwsz by wrócić", ConsoleColor.Yellow);

        }
        public static async void LoadStory()
        {
            DrawAt(1, 2, @".                                                               +         ", ConsoleColor.Cyan);
            DrawAt(1, 3, @"      .           +                 #             *                       ", ConsoleColor.Cyan);
            DrawAt(1, 4, @"   .                             .     .                         .        ", ConsoleColor.Cyan);
            DrawAt(1, 5, @"     ,              *                     .                '        *     ", ConsoleColor.Cyan);
            DrawAt(1, 6, @"                                .                                       ' ", ConsoleColor.Cyan);
            DrawAt(1, 7, @"                                                +                        ", ConsoleColor.Cyan);
            DrawAt(1, 8, @"                                                              .          ", ConsoleColor.Cyan);
            DrawAt(1, 9, @"             *                                                           ", ConsoleColor.Cyan);
            DrawAt(1, 10, @"                           '                                             ", ConsoleColor.Cyan);
            DrawAt(1, 11, @"   .                               +                          .           ", ConsoleColor.Cyan);
            DrawAt(1, 12, @"                  *         .                       +                     ", ConsoleColor.Cyan);
            DrawAt(1, 13, @"      .                                                                 ", ConsoleColor.Cyan);
            DrawAt(1, 14, @"              ,                                                           ", ConsoleColor.Cyan);
            DrawAt(1, 15, @"                                                        +               ", ConsoleColor.Cyan);
            DrawAt(1, 16, @"                 *                                                      ", ConsoleColor.Cyan);
            DrawAt(1, 17, @"     .                                               *                  ", ConsoleColor.Cyan);
            DrawAt(1, 18, @"                                                *                      ", ConsoleColor.Cyan);
            DrawAt(1, 19, @".                    *                                                    ", ConsoleColor.Cyan);
            DrawAt(1, 20, @".                            *                                     +      ", ConsoleColor.Cyan);
            DrawAt(1, 21, @"       /\\", ConsoleColor.Green);
            DrawAt(1, 22, @"      /**\\", ConsoleColor.Green);
            DrawAt(1, 23, @"     /****\\   /\\", ConsoleColor.Green);
            DrawAt(1, 24, @"    /      \\ /**\\", ConsoleColor.Green);
            DrawAt(1, 25, @"   /  /\\    /    \\        /\\    /\\  /\\      /\\            /\\/\\/\\  /\\", ConsoleColor.Green);
            DrawAt(1, 26, @"  /  /  \\  /      \\      /  \\/\\/  \\/  \\  /\\/  \\/\\  /\\  /\\/ / /  \\/  \\", ConsoleColor.Green);
            DrawAt(1, 27, @" /  /    \\/ /\\     \\    /    \\ \\  /    \\/ /   /  \\/  \\/  \\  /    \\   \\", ConsoleColor.Green);
            DrawAt(1, 28, @"/  /      \\/  \\/\\   \\  /      \\    /   /    \\", ConsoleColor.Green);
            DrawAt(1, 29, @"__/__/_______/___/__\\___\\__________________________________________________", ConsoleColor.Green);
            Thread.Sleep(1500);
            DrawAt(16, 5, @"W malowniczej dolinie, otoczonej majestatycznymi szczytami pokrytymi wiecznym śniegiem.", ConsoleColor.DarkRed);
            Thread.Sleep(2500);
            DrawAt(16, 6, @"Młody archeolog trafił na nowy trop.", ConsoleColor.DarkRed);
            Thread.Sleep(2000);
            DrawAt(16, 7, @"Jego oczy błyszczały odwagą, a serce płonęło pragnieniem odkrywania zaginionych artefaktów.", ConsoleColor.DarkRed);
            Thread.Sleep(2500);
            DrawAt(16, 8, @"Wędrując przez kręte ścieżki, nagle nasz archeolog spostrzegł tajemnicze wejście.", ConsoleColor.DarkRed);
            Thread.Sleep(2500);
            DrawAt(16, 9, @"Było to wejście do jaskini, gdzie w oddali widniał tylko mrok.", ConsoleColor.DarkRed);
            Thread.Sleep(2000);
            DrawAt(16, 11, @"Strach jednak nie powstrzymał go Nie wiedział, jednak, że to co w niej ujrzy może zmienić obliczę Ziemi.", ConsoleColor.DarkRed);
            Thread.Sleep(2500);
            Console.Clear();
            Torch();
            Console.WriteLine("\n");
            DrawAt(1, 29, @"Zapalił świecę aby lepiej widzieć wszystko ...", ConsoleColor.Yellow);
            Thread.Sleep(2000);
        }
        public static void Torch()
        {
            // int x = Console.WindowWidth / 2;
            DrawAt(1, 3, @"                       ...", ConsoleColor.Yellow);
            DrawAt(1, 4, @"                     .......", ConsoleColor.Yellow);
            DrawAt(1, 5, @"                  .....:::.....", ConsoleColor.Yellow);
            DrawAt(1, 6, @"              ....:::::::::::::....", ConsoleColor.Yellow);
            DrawAt(1, 7, @"            ....:::::::::::::::::....", ConsoleColor.Yellow);
            DrawAt(1, 8, @"        ..::::::::::::  =  ::::::::::....", ConsoleColor.Yellow);
            DrawAt(1, 9, @"        ..::::::::::   ===   ::::::::::....", ConsoleColor.Yellow);
            DrawAt(1, 10, @"    ..::::::::::::    ======    ::::::::::....", ConsoleColor.Yellow);
            DrawAt(1, 11, @"    ..::::::::::    ===========    ::::::::...", ConsoleColor.Yellow);
            DrawAt(1, 12, @"  ..::::::::::   ================    ::::::::..", ConsoleColor.Yellow);
            DrawAt(1, 13, @"  ..::::::::::  ======= . =========   ::::::::...", ConsoleColor.Yellow);
            DrawAt(1, 14, @"..::::::::::  ========  |\  ========  :::::::::...", ConsoleColor.Yellow);
            DrawAt(1, 15, @"..::::::::::  ========  |#\ ========  :::::::::...", ConsoleColor.Yellow);
            DrawAt(1, 16, @".::::::::::  ========  /%#|  =======   :::::::::..", ConsoleColor.Yellow);
            DrawAt(1, 17, @".::::::::::  =======  /#%#|  =======   :::::::::..", ConsoleColor.Yellow);
            DrawAt(1, 18, @".::::::::::  ======  |#%#/  ========  :::::::::..", ConsoleColor.Yellow);
            DrawAt(1, 19, @"..:::::::::  ======   \%/  ========  :::::::::..", ConsoleColor.Yellow);
            DrawAt(1, 20, @" ..:::::::::   ======  %  =======  ::::::::::..", ConsoleColor.Yellow);
            DrawAt(1, 21, @"  ..:::::::::    ===___%____===   ::::::::::..", ConsoleColor.Yellow);
            DrawAt(1, 22, @"   ..::::::::::    |  .::.  |   ::::::::::...", ConsoleColor.White);
            DrawAt(1, 23, @"    .::::::::::    |  .::.  |   ::::::::::..", ConsoleColor.White);
            DrawAt(1, 24, @"     ..::::::::    |  .::.  |   ::::::::...", ConsoleColor.White);
            DrawAt(1, 25, @"      .::::::::    |  .::.  |   ::::::::..", ConsoleColor.White);
            DrawAt(1, 26, @"        ...::::    |  .::.  |   ::::....", ConsoleColor.White);
            DrawAt(1, 27, @"         ..::::    |  .::.  |   ::::...", ConsoleColor.White);
            DrawAt(1, 28, @"           ....    |  .::.  |   ....", ConsoleColor.White);
            DrawAt(1, 29, @"             ..    |  .::.  |   ..", ConsoleColor.White);
            Thread.Sleep(2000);
        }
        //METODY CZYSZCZĄCE
        public static void ClearAtPosition(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(' ');
        }
        public static void clearX(int x)
        {
            for (int i = 0; i < Console.WindowHeight; i++)
            {
                DrawAt(x, i, ' ');
            }
        }
        public static void clearY(int y)
        {
            for (int i = 0; i < Console.WindowWidth; i++)
            {
                DrawAt(y, i, ' ');
            }
        }
    }

}
