using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ChooseYourAdventure.Model
{
    internal class StoryInitializer
    {
        public static Scene InitializeStory()
        {
            Scene GameOver = new Scene
            {
                Description = "",
                AsciiArt = @"

+=========================================================+
|                                                         |
|                                                         |
|                                                         |
|  ____    _    __  __ _____    _____     _______ ____  _ |
| / ___|  / \  |  \/  | ____|  / _ \ \   / / ____|  _ \| ||
|| |  _  / _ \ | |\/| |  _|   | | | \ \ / /|  _| | |_) | ||
|| |_| |/ ___ \| |  | | |___  | |_| |\ V / | |___|  _ <|_||
| \____/_/   \_\_|  |_|_____|  \___/  \_/  |_____|_| \_(_)|
|                                                         |
|                                                         |
|                                                         |
+=========================================================+ ",
                Choices = new List<Choice>(),
                SceneColor = ConsoleColor.Red
            };
            // tworzenie zakonczen
            Scene endingA = new Scene
            {
                Description = "Zakończenie A: Okazuje się, że kamień był przeklęty.\nPrzez Twoje decyzje świat pogrąża się w chaosie, a tajemnicza moc kamienia jest teraz nie do opanowania.",
                            AsciiArt = @"   
              z""           ""$          $""""       *F         **e.
             z""             ""c        d""          *.           ""$.
            .F                        ""            ""            'F
            d                                                   J%
            3         .                                        e""
            4r       e""              .                        d""
             $     .d""     .        .F             z ..zeeeeed""
             ""*beeeP""      P        d      e.      $**""""    ""
                 ""*b.     Jbc.     z*%e.. .$**eeeeP""
                    ""*beee* ""$$eeed""  ^$$$""""    ""
                               ""$$..$$P"" '$$r
                                ""$$$$""    ""$$.           .d
                    z.          .$$$""      ""$$.        .dP""
                    ^*e        e$$""         ""$$.     .e$""
                      *b.    .$$P""           ""$$.   z$""
                       ""$c  e$$""              ""$$.z$*""
                        ^*e$$P""                ""$$$""
                          *$$                   ""$$r
                          '$$F                 .$$P
                           $$$                z$$""
                           4$$               d$$b.
                           .$$%            .$$*""*$$e.
                        e$$$*""            z$$""    ""*$$e.
                       4$$""              d$P""        ""*$$e.
                       $P              .d$$$c           ""*$$e..
                      d$""             z$$"" *$b.            ""*$L
                     4$""             e$P""   ""*$c            ^$$
                     $""            .d$""       ""$$.           ^$r

",
                Choices = new List<Choice>(), // lista bedzie pusta
                SceneColor = ConsoleColor.Red
            };

            Scene endingB = new Scene
            {
                Description = "Zakończenie B: Dzięki Twoim badaniom i decyzjom, \nstarożytna technologia przywraca równowagę środowiskową na Ziemi.\nŚwiat odnawia się i wchodzi w nową erę dobrobytu.",
                AsciiArt = @"
                              .... 
                           ,;;'''';;,                    ,;;;;, 
                 ,        ;;'      `;;,               .,;;;'   ; 
              ,;;;       ;;          `;;,';;;,.     ,%;;'     ' 
            ,;;,;;       ;;         ,;`;;;, `;::.  %%;' 
           ;;;,;;;       `'       ,;;; ;;,;;, `::,%%;' 
           ;;;,;;;,          .,%%%%%'% ;;;;,;;   %;;; 
 ,%,.      `;;;,;;;,    .,%%%%%%%%%'%; ;;;;;,;;  %;;; 
;,`%%%%%%%%%%`;;,;;'%%%%%%%%%%%%%'%%'  `;;;;;,;, %;;; 
;;;,`%%%%%%%%%%%,; ..`%%%%%%%%;'%%%'    `;;;;,;; %%;; 
 `;;;;;,`%%%%%,;;/, .. `""""""'',%%%%%      `;;;;;; %%;;, 
    `;;;;;;;,;;/////,.    ,;%%%%%%%        `;;;;,`%%;; 
           ;;;/%%%%,%///;;;';%%%%%%,          `;;;%%;;, 
          ;;;/%%%,%%%%%/;;;';;'%%%%%,             `%%;; 
         .;;/%%,%%%%%//;;'  ;;;'%%%%%,             %%;;, 
         ;;//%,%%%%//;;;'   `;;;;'%%%%             `%;;; 
         ;;//%,%//;;;;'      `;;;;'%%%              %;;;, 
         `;;//,/;;;'          `;;;'%%'              `%;;; 
           `;;;;'               `;'%'                `;;;; 
                                  '      .,,,.        `;;;; 
                                      ,;;;;;;;;;;,     `;;;; 
                                     ;;;'    ;;;,;;,    `;;;; 
                                     ;;;      ;;;;,;;.   `;;;; 
                                      `;;      ;;;;;,;;   ;;;; 
                                        `'      `;;;;,;;  ;;;; 
                                                   `;;,;, ;;;; 
                                                      ;;, ;;;; 
                                                        ';;;;; 
                                                         ;;;;; 
",
                Choices = new List<Choice>(), // lista bedzie pusta
                SceneColor = ConsoleColor.Green
            };

            // tworzenie scen
            Scene scene1 = new Scene
            {
                Description = "Jesteś archeologiem i właśnie odkryłeś tajemniczy czarny kamień z nieznanych znaków.\nKamień ten może prowadzić do wielkiego skarbu lub przeklętej katastrofy.",
                AsciiArt = @"
                                                 ##                                                 
                                  ##+            ##            ##+                                  
                                    ##-                      +##                                    
                         ###-         ########################         +##.                         
                             ###   ###   ##      ##      ##   ###   ###                             
                                -##.   -#-       ##       ##.     ..                                
                               ##     ##.        ##        -#+     ###                              
                           ###       ##          ##          ##      .###                           
                         ##-        ##           ##           ##        +##                         
                        ##############+++++++++++####+  +####+##+++++++++###                        
                          ##         ##          ##          ##         ##                          
                           .##        #+         ##         ##        ##                            
                             ##+      .#-        ##        +#       ###                             
                               ##.     -#.       ##       +#      .##                               
                                 ##     -#       ##      .#.     ##                                 
                                  -#+    +#      ##     .#-    ##-                                  
                                     #+   ##     ##    .#+   ###                                    
                                      #    ##    ##    ##  .##                                      
                                        ##  ##   ##   ##  ##                                        
                                         -## ##  ##  ## ##-                                         
                                           ##+## ## ##+##                                           
                                             ##########                                             
                                                -##+                                               
",
                Choices = new List<Choice>(),
            };

            Scene scene2 = new Scene
            {
                Description = "Znaki na kamieniu zaczynają świecić i ukazują Ci drogę do ukrytego pomieszczenia w jaskini.\nW środku jest ołtarz z miejscem na kamień.",
                AsciiArt = @"


                                                                        
                                 <^\()/^>               <^\()/^>
                                  \/  \/                 \/  \/
                                   /__\      .  '  .      /__\ 
                                    /\    .     |     .    /\            
                   <^\()/^>       !_\/       '  |  '       \/_!       <^\()/^>
                    \/  \/     !_/I_||  .  '   \'/   '  .  ||_I\_!     \/  \/
                     /__\     /I_/| ||      -== + ==-      || |\_I\     /__\
                     /_ \   !//|  | ||  '  .   /.\   .  '  || |  |\\!   /_ \
                    (-   ) /I/ |  | ||       .  |  .       || |  | \I\ (=   )
                     \__/!//|  |  | ||    '     |     '    || |  |  |\\!\__/
                     /  \I/ |  |  | ||       '  .  '    *  || |  |  | \I/  \
                    {_ __}  |  |  | ||                     || |  |  |  {____}
                 _!__|= ||  |  |  | ||   *      +          || |  |  |  ||  |__!_
                 _I__|  ||__|__|__|_||          A          ||_|__|__|__||- |__I_
                 -|--|- ||--|--|--|-||       __/_\__  *    ||-|--|--|--||= |--|-
                  |  |  ||  |  |  | ||      /\-'o'-/\      || |  |  |  ||  |  |
                  |  |= ||  |  |  | ||     _||:<_>:||_     || |  |  |  ||= |  |
                  |  |- ||  |  |  | || *  /\_/=====\_/\  * || |  |  |  ||= |  |
                  |  |- ||  |  |  | ||  __|:_:_[I]_:_:|__  || |  |  |  ||- |  | 
                 _|__|  ||__|__|__|_||:::::::::::::::::::::||_|__|__|__||  |__|_
                 -|--|= ||--|--|--|-||:::::::::::::::::::::||-|--|--|--||- |--|-
                  |- ||  |  |  | ||:::::::::::::::::::::|| |  |  |  ||= |  |--|- 
                ~~~~~~~~~^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^~~~~~~~~~

",          
                Choices = new List<Choice>()
            };

            Scene scene3 = new Scene
            {
                Description = "Po wyjściu z jaskini spotykasz tajemniczą postać w kapturze,\nktóra proponuje Ci wielką sumę pieniędzy za kamień.",
                AsciiArt = @"
                                     *********
                                   *************
                                  *****     *****
                                 ***           ***
                                ***             ***
                                **    0     0    **
                                **               **                  ____
                                ***             ***             //////////
                                ****           ****        ///////////////  
                                *****         *****    ///////////////////
                                ******       ******/////////         |  |
                              *********     ****//////               |  |
                           *************   **/////*****              |  |
                          *************** **///***********          *|  |*
                         ************************************    ****| <=>*
                        *********************************************|<===>* 
                        *********************************************| <==>*
                        ***************************** ***************| <=>*
                        ******************************* *************|  |*
                        ********************************** **********|  |*  
                        *********************************** *********|  |
        ",
                Choices = new List<Choice>()
            };

            Scene scene4 = new Scene
            {
                Description = "Po włożeniu kamienia ołtarz zaczyna się obracać, ukazując tajemne przejście.",
                AsciiArt = @"
                                                 {} {}
                                         !  !  ! II II !  !  !
                                      !  I__I__I_II II_I__I__I  !
                                      I_/|__|__|_|| ||_|__|__|\_I
                                   ! /|_/|  |  | || || |  |  |\_|\ !       
                       .--.        I//|  |  |  | || || |  |  |  |\\I        .--.
                      /-   \    ! /|/ |  |  |  | || || |  |  |  | \|\ !    /=   \
                      \=__ /    I//|  |  |  |  | || || |  |  |  |  |\\I    \-__ /
                       }  {  ! /|/ |  |  |  |  | || || |  |  |  |  | \|\ !  }  {
                      {____} I//|  |  |  |  |  | || || |  |  |  |  |  |\\I {____}
                _!__!__|= |=/|/ |  |  |  |  |  | || || |  |  |  |  |  | \|\=|  |__!__!_
                _I__I__|  ||/|__|__|__|__|__|__|_|| ||_|__|__|__|__|__|__|\||- |__I__I_
                -|--|--|- ||-|--|--|--|--|--|--|-|| ||-|--|--|--|--|--|--|-||= |--|--|-
                 |  |  |  || |  |  |  |  |  |  | || || |  |  |  |  |  |  | ||  |  |  |
                 |  |  |= || |  |  |  |  |  |  | || || |  |  |  |  |  |  | ||= |  |  |
                 |  |  |- || |  |  |  |  |  |  | || || |  |  |  |  |  |  | ||= |  |  |
                 |  |  |- || |  |  |  |  |  |  | || || |  |  |  |  |  |  | ||- |  |  | 
                _|__|__|  ||_|__|__|__|__|__|__|_|| ||_|__|__|__|__|__|__|_||  |__|__|_
                -|--|--|= ||-|--|--|--|--|--|--|-|| ||-|--|--|--|--|--|--|-||- |--|--|-
                -|--|--|| |  |  |  |  |  |  | || || |  |  |  |  |  |  | ||= |  |  | 
                ~~~~~~~~~~~^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^~~~~~~~~~~~
",
                Choices = new List<Choice>()
            };

            Scene scene5 = new Scene
            {
                Description = "Decydujesz się zbadanie kamienia w swoim laboratorium.\nPo dokładnych badaniach możesz coś odkryć.",
                AsciiArt= @"

                __]_____]____]_____]______]_______]_____]______]______]______]___]
                             _                       _______  |||""||;;|.||##||=|||
                  _                           _     |   *   | |||-|| =|-||==||+|||
                  ____________       _              |       | |||_||__|_||__||_|||
                |`.   --__     `.        _______    |       | ||================||
                |  `._____________`.  .'|.-----.|   _ ======| ||| | -|&|^^|!!|-|||
                |   | .-----------.| |  ||     ||  (o))   _ | ||| |**|=|+-|##|=|||
                |   | |  .-------.|| |  ||     ||  /||   / \`._|  .-.|_|__|__|_|||
                |   | |  |       |||_`..|'_____'| //||___\_/.'\| (( ))==========||
                |   | |`.|  ==== ||| | `---------(o)||         \  /-'-=|+|.-|-'|||
                |`. | |`.|_______|||/|______________||__.--._ (o)/|=|;:|-|&&|&&|||
                |  `|_|===========||_|                 (____)-.'(o)_|__|_|__|__|||
                |   | |  .-------.||                           `._\=============||
                |   | |  |       |||                             `.     |       ||
                |   | |`.|  ==== |||`._____________________________`.  o|o      ||
                |`. | |`.|_______||| |._.----------------.__.-------.|__|_______||
                |  `|_|===========|| || '----------------'  | .---. ||  __
                |   | |  .-------.|| ||               |     |_______||.'\.'.
                |   | |  |       ||| || ______________|     | .---. ||'.__.'
                |   | |`.|  ==== ||| ||                `.   |_______|||  _ |
                 `. | |`.|_______||| ||                  `. | .---. |||_  ||
                   `|_|===========||`||                    `|_______|||____|
                                       `.                    `.
                                         `.____________________`.
",
                Choices = new List<Choice>()
            };

            // tworzymy wybory i dodajemy je do listy wyborow w konkretnej scenie
            scene1.Choices.Add(new Choice { Description = "Przyjrzeć się kamieniowi", NextScene = scene2 });
            scene1.Choices.Add(new Choice { Description = "Opuścić jaskinię", NextScene = scene3 });

            scene2.Choices.Add(new Choice { Description = "Włożyć kamień na ołtarz", NextScene = scene4 });
            scene2.Choices.Add(new Choice { Description = "Zabrać kamień", NextScene = scene5 });

            scene3.Choices.Add(new Choice { Description = "Sprzedać kamień", NextScene = endingA }); // prowadzi do zakonczenia A
            scene3.Choices.Add(new Choice { Description = "Kontynuować badanie", NextScene = scene5 });

            scene4.Choices.Add(new Choice { Description = "Wejść w przejście", NextScene = endingA }); // prowadzi do zakonczenia A
            scene4.Choices.Add(new Choice { Description = "Wrócić z kamieniem", NextScene = scene5 });

            scene5.Choices.Add(new Choice { Description = "Wykorzystać technologię", NextScene = endingB }); // prowadzi do zakonczenia B
            scene5.Choices.Add(new Choice { Description = "Ukryć kamień", NextScene = endingA }); // prowadzi do zakonczenia A
            return scene1; // inicjalizujemy pierwsza scene
        }
    }
}
