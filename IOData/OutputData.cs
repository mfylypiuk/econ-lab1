using System;
using System.Collections.Generic;
using System.Text;

namespace IOData
{
    public class OutputData
    {
        public ComplexityData ComplexityData { get; set; }
        public DevelopmentTimeData DevelopmentTimeData { get; set; }
        public SalaryData SalaryData { get; set; }
        public EquipmentData EquipmentData { get; set; }
        public PureCostData PureCostData { get; set; }
        public FinishedSoftwareProductCostData FinishedSoftwareProductCostData { get; set; }

        public Dictionary<string, string> ToViewableDictionary()
        {
            Dictionary<string, string> result = new Dictionary<string, string>()
            {
                { "Кількість команд вихідного коду (команд)", ComplexityData.SourceCodeCommandsCount.ToString() },
                { "Трудомісткість, (люд.-міс.)", ComplexityData.LaborIntensive.ToString() },
                { "Продуктивність (вих.ком./люд.-міс.)", ComplexityData.Productivity.ToString() },
                { "Кількість виконавців (люд.)", DevelopmentTimeData.SpecialistsCount.ToString() },
                { "Час, потрібний на створення програмного продукту (міс.)", DevelopmentTimeData.TimeToCreateSoftwareProduct.ToString() },
                { "Основна заробітна платні виконавця (грн.)", SalaryData.BasicContractorSalary.ToString() },
                { "Додаткова заробітна платня (грн.)", SalaryData.AdditionalSalary.ToString() },
                { "Загальні витрати на утримання і експлуатацію ПЕОМ при виконанні проекту (грн.)", EquipmentData.TotalPcMaintenanceAndOperationCosts.ToString() },
                { "Собівартість програмного продукту (грн.)", PureCostData.SoftwareProductCost.ToString() },
                { "Вартість готового програмного продукту (грн.)", FinishedSoftwareProductCostData.FinishedSoftwareProductCost.ToString() }
            };

            return result;
        }
    }
}
