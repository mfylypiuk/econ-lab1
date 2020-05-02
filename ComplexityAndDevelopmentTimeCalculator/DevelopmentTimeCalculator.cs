using IOData;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComplexityAndDevelopmentTimeCalculator
{
    public class DevelopmentTimeCalculator
    {
        private ComplexityData complexityData;
        private double taskDescriptionPrepareTime;
        private double programmerExperience;
        private double documentationTime;
        private double K;

        public DevelopmentTimeCalculator(ComplexityData complexityData, double taskDescriptionPrepareTime, double programmerExperience, double documentationTime)
        {
            this.complexityData = complexityData;
            this.taskDescriptionPrepareTime = taskDescriptionPrepareTime;
            this.programmerExperience = programmerExperience;
            this.documentationTime = documentationTime;
        }

        private void DoPreliminaryActions()
        {
            if (programmerExperience >= 5 && programmerExperience < 10)
            {
                K = 1.25;
            }
            // ... other ...
            else
            {
                throw new Exception("Unknown data");
            }
        }

        public DevelopmentTimeData Calculate()
        {
            DoPreliminaryActions();

            // загальна тривалість розробки ПП 
            double O = 2.5 * Math.Pow(complexityData.LaborIntensive, 0.32);
            // середня кількість виконавців
            double PLaee = complexityData.LaborIntensive / O;
            // продуктивність праці
            double Id = Math.Abs((1000 * complexityData.SourceCodeCommandsCount) / complexityData.LaborIntensive);

            // коефіцієнт урахування змін завдання
            double B = 1.45;
            // час на опис завдання 
            double To = (complexityData.SourceCodeCommandsCount * B) / (50.0 * K);
            // час на розробку алгоритму та блок-схеми 
            double Ta = complexityData.SourceCodeCommandsCount / (50.0 * K);
            // час написання програми мовою програмування 
            double Th = (complexityData.SourceCodeCommandsCount * 1.5) / (50.0 * K);
            // час налагодження та тестування програми 
            double Tht = (complexityData.SourceCodeCommandsCount * 4.2) / (50.0 * K);

            // Час, необхідний для виконання кожного етапу створення ПП
            double T = taskDescriptionPrepareTime + To + Ta + Th + Tht + documentationTime;

            DevelopmentTimeData result = new DevelopmentTimeData();
            result.SpecialistsCount = PLaee;
            result.TimeToCreateSoftwareProduct = T;

            return result;
        }
    }
}
