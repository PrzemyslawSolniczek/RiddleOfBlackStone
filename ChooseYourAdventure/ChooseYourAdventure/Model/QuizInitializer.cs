using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChooseYourAdventure.Model
{
    public class QuizInitializer
    {
        public static Question InitializeQuiz() 
        {
            Question question1 = new Question
            {
                Description = "Co jest potrzebne, aby zrealizować wzorzec Unikat (Singleton)?",
                Answers = new List<Answer>()
            };
            question1.Answers.Add(new Answer {Description = "publiczny konstruktor i publiczna statyczna metoda dostępowa", correctAnswer = false});
            question1.Answers.Add(new Answer { Description = "publiczny konstruktor i prywatna statyczna metoda dostępowa", correctAnswer = false });
            question1.Answers.Add(new Answer { Description = "prywatny konstruktor i publiczna statyczna metoda dostępowa", correctAnswer = true });
            question1.Answers.Add(new Answer { Description = "prywatny konstruktor i prywatna statyczna metoda dostępowa", correctAnswer = false });
            return question1;
        }
        
    }
}
