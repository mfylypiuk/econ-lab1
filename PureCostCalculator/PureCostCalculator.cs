using IOData;
using System;

namespace PureCostCalculator
{
    public class PureCostCalculator
    {
        private SalaryData salaryData;
        private EquipmentData equipmentData;

        public PureCostCalculator(SalaryData salaryData, EquipmentData equipmentData)
        {
            this.salaryData = salaryData;
            this.equipmentData = equipmentData;
        }

        public PureCostData Calculate()
        {
            double esp = ((salaryData.BasicContractorSalary + salaryData.AdditionalSalary) * 34.7) / 100.0;
            double Cii = salaryData.BasicContractorSalary + salaryData.AdditionalSalary + esp + equipmentData.TotalPcMaintenanceAndOperationCosts;

            PureCostData result = new PureCostData();
            result.SoftwareProductCost = Cii;

            return result;
        }
    }
}
