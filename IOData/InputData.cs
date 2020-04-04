using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace IOData
{
    public class InputData
    {
        public int TaskDescriptionPrepareTime { get; set; }
        public string TypeOfTask { get; set; }
        public string SoftwareNoveltyLevel { get; set; }
        public int SoftwareComplexityLevel { get; set; }
        public string ProgrammingLanguageLevel { get; set; }
        public double ProgrammerExperience { get; set; }
        public int DocumentationTime { get; set; }
        public double TariffCoefficient { get; set; }
        public string ProjectDevelopmentMonth { get; set; }
        public double AverageWorkingHours { get; set; }
        public int AveragePremiumPercentage { get; set; }
        public int AdditionalWagePercentage { get; set; }
        public double KilowattCost { get; set; }
        public double PcTotalPower { get; set; }
        public double LightingTotalPower { get; set; }
        public int EngineerFirstCategoryMonthlySalary { get; set; }
        public int SystemProgrammerMonthlySalary { get; set; }
        public int OperatorMonthlySalary { get; set; }
        public int EngineerServiceRate { get; set; }
        public int SystemProgrammerServiceRate { get; set; }
        public int OperatorServiceRate { get; set; }
        public double EngineerTariffCoefficient { get; set; }
        public double SystemProgrammerTariffCoefficient { get; set; }
        public double OperatorTariffCoefficient { get; set; }
        public int PcComplexCarryingAmount { get; set; }
        public int TermOfPcUse { get; set; }

        public Dictionary<string, string> ToViewableDictionary()
        {
            Dictionary<string, string> result = new Dictionary<string, string>()
            {
                { "Час підготовки опису завдання, год.", TaskDescriptionPrepareTime.ToString() },
                { "Тип задачі", TypeOfTask },
                { "Рівень новизни ПП", SoftwareNoveltyLevel },
                { "Рівень складності ПП", SoftwareComplexityLevel.ToString() },
                { "Рівень мови програмування", ProgrammingLanguageLevel },
                { "Стаж програміста, років", ProgrammerExperience.ToString() },
                { "Час на оформлення документації, год.", DocumentationTime.ToString() },
                { "Тарифний коефіцієнт", TariffCoefficient.ToString() },
                { "Місяць початку розробки проекту", ProjectDevelopmentMonth },
                { "Середня тривалість робочого дня, год.", AverageWorkingHours.ToString() },
                { "Середній відсоток премії, %", AveragePremiumPercentage.ToString() },
                { "Відсоток додаткової заробітної праці, %", AdditionalWagePercentage.ToString() },
                { "Вартість одного кВт, грн.", KilowattCost.ToString() },
                { "Сумарна потужність ПЕОМ, кВт/год.", PcTotalPower.ToString() },
                { "Сумарна потужність, яка йде на освітлення, кВт/год.", LightingTotalPower.ToString() },
                { "Щомісячна зарплатня інженера 1-го розряду, грн.", EngineerFirstCategoryMonthlySalary.ToString() },
                { "Щомісячна зарплатня системного програміста, грн.", SystemProgrammerMonthlySalary.ToString() },
                { "Щомісячна зарплатня оператора, грн.", OperatorMonthlySalary.ToString() },
                { "Норма обслуговування (інженер)", EngineerServiceRate.ToString() },
                { "Норма обслуговування (системний програміст)", SystemProgrammerServiceRate.ToString() },
                { "Норма обслуговування (оператор)", OperatorServiceRate.ToString() },
                { "Тарифний коефіцієнт (інженер)", EngineerTariffCoefficient.ToString() },
                { "Тарифний коефіцієнт (системний програміст)", SystemProgrammerTariffCoefficient.ToString() },
                { "Тарифний коефіцієнт (оператор)", OperatorTariffCoefficient.ToString() },
                { "Балансова вартість комплексу ПЕОМ, грн.", PcComplexCarryingAmount.ToString() },
                { "Термін використання ПЕОМ, роки", TermOfPcUse.ToString() }
            };
            
            return result;
        }
    }
}
