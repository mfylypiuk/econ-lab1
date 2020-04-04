using System;
using System.Collections.Generic;
using System.Text;

namespace IOData
{
    public class OutputData
    {
        public ComplexityData ComplexityData { get; set; }
        public DevelopmentTimeData DevelopmentTimeData { get; set; }
        public int BasicContractorSalary { get; set; }
        public int AdditionalSalary { get; set; }
        public int TotalPcMaintenanceAndOperationCosts { get; set; }
        public int SoftwareProductCost { get; set; }
        public int FinishedSoftwareProductCost { get; set; }

        public Dictionary<string, string> ToViewableDictionary()
        {
            Dictionary<string, string> result = new Dictionary<string, string>()
            {
                { "Кількість команд вихідного коду (команд)", ComplexityData.SourceCodeCommandsCount.ToString() },
                { "Трудомісткість, (люд.-міс.)", ComplexityData.LaborIntensive.ToString() },
                { "Продуктивність (вих.ком./люд.-міс.)", ComplexityData.Productivity.ToString() },
                { "Кількість виконавців (люд.)", DevelopmentTimeData.SpecialistsCount.ToString() },
                { "Час, потрібний на створення програмного продукту (міс.)", DevelopmentTimeData.TimeToCreateSoftwareProduct.ToString() },
                { "Основна заробітна платні виконавця (грн.)", BasicContractorSalary.ToString() },
                { "Додаткова заробітна платня (грн.)", AdditionalSalary.ToString() },
                { "Загальні витрати на утримання і експлуатацію ПЕОМ при виконанні проекту (грн.)", TotalPcMaintenanceAndOperationCosts.ToString() },
                { "Собівартість програмного продукту (грн.)", SoftwareProductCost.ToString() },
                { "Вартість готового програмного продукту (грн.)", FinishedSoftwareProductCost.ToString() }
            };

            return result;
        }
    }
}
