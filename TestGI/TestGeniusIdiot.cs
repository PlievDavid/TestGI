using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestGI
{
    class TestGeniusIdiot
    {
        Random rnd = new Random();
        List<Question> listQuestion = new List<Question> { };
        int indexQuestion = -1;
        int countRightAnswer = 0;
        string[] diagnose = { "идиот", "кретин", "дурак", "норма", "талант", "гений" };
        int[] orderQuestions = { 2, 3, 1, 0, 4 };
        void LoadStandart()
        {
            listQuestion.Add(new Question("2 + 2 * 2", 6));
            listQuestion.Add(new Question("Бревно нужно разделить на 10 частей, сколько нужно распилов", 9));
            listQuestion.Add(new Question("На 2 руках 10 пальцев. Сколько пальцев на 5 руках", 25));
            listQuestion.Add(new Question("Укол делают каждые пол часа. Сколько минут нужно на 3 укола", 60));
            listQuestion.Add(new Question("5 свечей горело, 3 погасло. Сколько осталось?", 3));
        }
        void LoadFromFile()
        {
            listQuestion.Clear();
            StreamReader sr = new StreamReader("data/questionsdata.txt");
            while (!sr.EndOfStream)
            {
                string[] line = sr.ReadLine().Split('|');
                Question question = new Question(line[0], Convert.ToInt32(line[1].ToString()));
                listQuestion.Add(question);
            }
        }
        public TestGeniusIdiot(bool fromFile = true)
        {
            if (fromFile)
                LoadFromFile();
            else
                LoadStandart();
            orderQuestions = shuffle();
        }
        public string NextQuestion()
        {
            if (indexQuestion < listQuestion.Count - 1)
            {
                indexQuestion++;
                return listQuestion[orderQuestions[indexQuestion]].ToString();
            }
            else
            {
                return listQuestion[orderQuestions[listQuestion.Count-1]].ToString();
            }
        }
        public int NumberQuestion()
        {
            return indexQuestion + 1;
        }
        public bool EndOfTest()
        {
            return indexQuestion == listQuestion.Count-1;
        }
        public void CheckAnswer(int userAnswer)
        {
            if (listQuestion[orderQuestions[indexQuestion]].CheckAnswer(userAnswer))
            {
                countRightAnswer++;
            }
        }
        public string Diagnose()
        {
            if (countRightAnswer == listQuestion.Count)
            {
                return diagnose[diagnose.Length - 1];
            }
            else if (countRightAnswer == 0)
                return diagnose[0];
            return diagnose[(diagnose.Length-1) * countRightAnswer / listQuestion.Count()];
        }

        int[] shuffle()
        {
            int n = listQuestion.Count;
            int[] temp = new int[n];
            for (int i = 0; i < temp.Length; i++)
            {
                temp[i] = i;
            }
            for (int i = 0; i < 10; i++)
            {
                int ind1 = rnd.Next(0, n);
                int ind2 = rnd.Next(0, n);
                int t = temp[ind1];
                temp[ind1] = temp[ind2];
                temp[ind2] = t;
            }
            return temp;
        }
    }
}
