using IOData;
using System;

namespace ComplexityAndDevelopmentTimeCalculator
{
    public class CommonCalculator
    {
        private string typeOfTask;
        private string softwareNoveltyLevel;
        private int softwareComplexityLevel;
        private string programmingLanguageLevel;
        private int taskDescriptionPrepareTime;
        private double programmerExperience;
        private int documentationTime;

        public ComplexityData ComplexityData { get; set; }
        public DevelopmentTimeData DevelopmentTimeData { get; set; }

        public CommonCalculator(string typeOfTask, string softwareNoveltyLevel, int softwareComplexityLevel, string programmingLanguageLevel,
            int taskDescriptionPrepareTime, double programmerExperience, int documentationTime)
        {
            this.typeOfTask = typeOfTask;
            this.softwareNoveltyLevel = softwareNoveltyLevel;
            this.softwareComplexityLevel = softwareComplexityLevel;
            this.programmingLanguageLevel = programmingLanguageLevel;
            this.taskDescriptionPrepareTime = taskDescriptionPrepareTime;
            this.programmerExperience = programmerExperience;
            this.documentationTime = documentationTime;
        }

        public void Calculate()
        {
            ComplexityCalculator complexityCalculator = new ComplexityCalculator(typeOfTask, softwareNoveltyLevel, softwareComplexityLevel, programmingLanguageLevel);
            ComplexityData = complexityCalculator.Calculate();
            DevelopmentTimeCalculator developmentTimeCalculator = new DevelopmentTimeCalculator(ComplexityData, taskDescriptionPrepareTime, programmerExperience, documentationTime);
            DevelopmentTimeData = developmentTimeCalculator.Calculate();
        }
    }
}
