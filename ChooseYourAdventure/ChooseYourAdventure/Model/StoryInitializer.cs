using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChooseYourAdventure.Model
{
    internal class StoryInitializer
    {
        public static Scene InitializeStory()
        {
            // tworzenie zakonczen
            Scene endingA = new Scene
            {
                Description = "Zakończenie A: Okazuje się, że kamień był przeklęty. Przez Twoje decyzje świat pogrąża się w chaosie...",
                Choices = new List<Choice>(), // lista bedzie pusta
                SceneColor = ConsoleColor.Red
            };

            Scene endingB = new Scene
            {
                Description = "Zakończenie B: Dzięki Twoim badaniom i decyzjom, starożytna technologia przywraca równowagę...",
                Choices = new List<Choice>(), // lista bedzie pusta
                SceneColor = ConsoleColor.Green
            };

            // tworzenie scen
            Scene scene1 = new Scene
            {
                Description = "Jesteś archeologiem i właśnie odkryłeś tajemniczy czarny kamień...",
                Choices = new List<Choice>()
            };

            Scene scene2 = new Scene
            {
                Description = "Znaki na kamieniu zaczynają świecić...",
                Choices = new List<Choice>()
            };

            Scene scene3 = new Scene
            {
                Description = "Po wyjściu z jaskini spotykasz tajemniczą postać...",
                Choices = new List<Choice>()
            };

            Scene scene4 = new Scene
            {
                Description = "Po włożeniu kamienia ołtarz zaczyna się obracać...",
                Choices = new List<Choice>()
            };

            Scene scene5 = new Scene
            {
                Description = "Decydujesz się zbadanie kamienia w swoim laboratorium...",
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
