using System.Collections.Generic;

namespace CSharp8.Features
{
    public class NullableReferenceTypes
    {
        public enum QuestionType
        {
            YesNo,
            Number,
            Text
        }

        public class SurveyQuestion
        {
            public SurveyQuestion(QuestionType typeOfQuestion, string questionText)
            {
                QuestionText = questionText;
                TypeOfQuestion = typeOfQuestion;
            }

            public string QuestionText { get; }
            public QuestionType TypeOfQuestion { get; }
            
        }
        
        public class SurveyRun
        {
            private List<SurveyQuestion> surveyQuestions = new List<SurveyQuestion>();
            private List<string?>? surveyAnswers = null;

            public void AddQuestion(QuestionType type, string question) =>
                AddQuestion(new SurveyQuestion(type, question));
            public void AddQuestion(SurveyQuestion surveyQuestion) => surveyQuestions.Add(surveyQuestion);
            public void AddAnswer(string? answer)
            {
                if (surveyAnswers == null)
                {
                    surveyAnswers = new List<string?>();
                }
                surveyAnswers.Add(answer);
            }
        }

        static void Program()
        {
            var surveyRun = new SurveyRun();
            surveyRun.AddQuestion(QuestionType.YesNo, "Has your code ever thrown a NullReferenceException?");
            surveyRun.AddQuestion(new SurveyQuestion(QuestionType.Number, "How many times (to the nearest 100) has that happened?"));
            surveyRun.AddQuestion(QuestionType.Text, "What is your favorite color?");
            
            //Warning - Cannot covert null literal to non-nullable reference type
            //surveyRun.AddQuestion(QuestionType.Text, null);
            //surveyRun.AddQuestion(QuestionType.Text, default);
            
            surveyRun.AddAnswer("Orange");
            surveyRun.AddAnswer(null);
        }
    }
}