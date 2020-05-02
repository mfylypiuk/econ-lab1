using IOData;
using System;

namespace SalaryCalculator
{
    public class SalaryCalculator
    {
        private DevelopmentTimeData developmentTimeData;
        private double tariffCoefficient;
        private double averageWorkingHours;
        private double averagePremiumPercentage;
        private double additionalWagePercentage;

        public SalaryCalculator(DevelopmentTimeData developmentTimeData, double tariffCoefficient, double averageWorkingHours, double averagePremiumPercentage, double additionalWagePercentage)
        {
            this.tariffCoefficient = tariffCoefficient;
            this.averageWorkingHours = averageWorkingHours;
            this.averagePremiumPercentage = averagePremiumPercentage;
            this.developmentTimeData = developmentTimeData;
            this.additionalWagePercentage = additionalWagePercentage;
        }

        private void DoPreliminaryActions()
        {

        }

        public SalaryData Calculate()
        {
            // посадовий оклад (ставка) працівника 1-го розряду (1600 грн.)
            double C = 1600.0;
            // тарифний коефіцієнт
            double Eo = tariffCoefficient;
            // загальний час на створення програмного продукту (год.)
            double Ocaa = developmentTimeData.TimeToCreateSoftwareProduct;
            // число робочих днів на місяць (дні)
            double Xd = 22.0;
            // тривалість робочого дня в годинах (год.)
            double Oda = averageWorkingHours;
            // відсоток премії (%)
            double I = averagePremiumPercentage;
            // основна заробітна платня
            double CIaee_ini = (C * Eo * Ocaa) / (Xd * Oda) * (1 + (I / 100.0));

            // відсоток додаткової заробітної платні (%)
            double A = additionalWagePercentage;
            // додаткова заробітна платня
            double CIaee_aia = CIaee_ini * (A / 100.0);

            // загальна заробітна платня
            double Ccaa = CIaee_ini + CIaee_aia;

            // розрахунок нарахувань на заробітну плату (єдиного соціального внеску)
            double Aana = (Ccaa * 34.7) / 100.0;

            SalaryData result = new SalaryData();
            result.AdditionalSalary = CIaee_aia;
            result.BasicContractorSalary = CIaee_ini;

            return result;
        }
    }
}
