using IOData;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComplexityAndDevelopmentTimeCalculator
{
    class ComplexityCalculator
    {
        private string typeOfTask;
        private string softwareNoveltyLevel;
        private double softwareComplexityLevel;
        private string programmingLanguageLevel;

        private double q; // коефіцієнт, який враховує умовне число команд в залежності від типу задачі, яку вирішує програмний продукт
        private double C; // коефіцієнт, який враховує новизну та складність програми, на перетині показників складності та новизни

        public ComplexityCalculator(string typeOfTask, string softwareNoveltyLevel, double softwareComplexityLevel, string programmingLanguageLevel)
        {
            this.typeOfTask = typeOfTask;
            this.softwareNoveltyLevel = softwareNoveltyLevel;
            this.softwareComplexityLevel = softwareComplexityLevel;
            this.programmingLanguageLevel = programmingLanguageLevel;
        }

        private void DoPreliminaryActions()
        {
            // q
            switch (typeOfTask)
            {
                case "ПЗ ведення БД і лінійних файлів":
                    {
                        q = 1000.0;
                        break;
                    }
                default:
                    {
                        throw new Exception("Unknown data");
                    }
            }

            // C
            if (programmingLanguageLevel == "високий" && softwareComplexityLevel == 3 && softwareNoveltyLevel == "В")
            {
                C = 1.0;
            }
            // ... other ...
            else
            {
                throw new Exception("Unknown data");
            }
        }

        public ComplexityData Calculate()
        {
            DoPreliminaryActions();

            // умовна кількість команд в програмі 
            double Q = q * C;
            // число тисяч команд програмного коду
            double Noae = Q / 1000.0;
            // трудомісткість розробки програмного продукту 
            double t = 3.6 * Math.Pow(Noae, 1.2);

            ComplexityData result = new ComplexityData();
            result.SourceCodeCommandsCount = Q;
            result.LaborIntensive = t;
            result.Productivity = Q / t;

            return result;
        }
    }
}
