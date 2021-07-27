using EllipticCurve.Utils;
using NHibernate.Mapping.ByCode;
using System;
using System.Collections;
using System.Collections.Generic;
using String = System.String;

namespace Homework3
{
    public class DriverExam
    {
        private static String[] CORRECT_ANSWERS = { "B", "D", "A", "A", "C", "A", "B", "A", "C", "D", "B", "C", "D", "A", "D", "C", "B", "D", "A" };
        private static int EXPEXTED_TOTAL = CORRECT_ANSWERS.Length;
        private static int PASSING_MARK = 15;

        private int correct;
        private int incorrect;
        private Boolean passed;
        private int[] missed;

        public DriverExam (String[] answers)
        {
            if (answers == null || answers.Length != EXPEXTED_TOTAL)
            {
                throw new Exception("Wrong answers specified. ");
            }
            int correctCount = 0;
            List<Integer> missedCounters = new ArrayList<>();
            for (int i = 0; i < EXPEXTED_TOTAL; i++)
            {
                if (answers[i] == null || answers[i].isEmpty())
                {
                    missedCounters.Add(Integer.valueOf(i));
                }
                if (answers[i].Equals(CORRECT_ANSWERS[i]))
                {
                    correctCount++;
                }
            }
            correct = correctCount;
            missed = new int[missedCounters.size()];
            int i = 0;
            for (Integer value : missedCounters)
            {
                missed[i++] = value.intValue();
            }
            incorrect = EXPEXTED_TOTAL - correctCount - missed.Length;
            passed = correctCount > PASSING_MARK;
        }

        public Boolean Passed()
        {
            return correct >= 15;
        }

        public int totalCorrect()
        {
            return correct;
        }

        public int totalIncorrect()
        {
            return incorrect;
        }

        public int[] questionsMissed()
        {
            return missed;
        }
    }


    public class DriverTestExam
    {

        public static void Main(string[] args)
        {
            Console.WriteLine("   Driver's License Exam \n");

            Console.WriteLine(" 20 Questions Multiple Choice  ");
            Console.WriteLine("    Mark  A,  B,  C, or  D     ");


            String[] answers = new String[20];
            String answer;

            for (int i = 0; i < 20; i++)
            {
                do
                {
                    Console.Write((i + 1) + ": ");
                    answer = Console.ReadLine();
                } while (!isValidAnswer(answer));

                answers[i] = answer;
            }

            DriverExam exam = new DriverExam(answers);

            Console.WriteLine("   Results   ");

            Console.WriteLine("Total Correct Answers:  " + exam.totalCorrect());

            Console.WriteLine("Total Incorrect Answers:  " + exam.totalIncorrect());

            String passed = exam.Passed() ? "YES" : "NO";

            Console.WriteLine("Passed:  " + passed);

            if (exam.totalIncorrect() > 0)
            {
                Console.Write("The number of incorrect answers are:  ");

                int missedIndex;

                for (int i = 0; i < exam.totalIncorrect(); i++)
                {
                    missedIndex = exam.questionsMissed()[i] + 1;
                    Console.Write(" " + missedIndex);
                }
            }
        }

        private static bool isValidAnswer(string answer)
        {
            return "A".Equals(answer) || "B".Equals(answer) || "C".Equals(answer) || "D".Equals(answer);
        }
    }
}
