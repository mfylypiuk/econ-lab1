using IOData;
using System;

namespace EquipmentCalculator
{
    public class EquipmentCalculator
    {
        private DevelopmentTimeData developmentTimeData;
        private double averageWorkingHours;
        private double kilowattCost;
        private double pcTotalPower;
        private double lightingTotalPower;
        private double pcComplexCarryingAmount;
        private double termOfPcUse;
        private double engineerFirstCategoryMonthlySalary;
        private double tariffCoefficient;
        private double averagePremiumPercentage;
        private double engineerServiceRate;

        public EquipmentCalculator(DevelopmentTimeData developmentTimeData, double averageWorkingHours, double kilowattCost, double pcTotalPower, 
            double lightingTotalPower, double pcComplexCarryingAmount, double termOfPcUse,
            double engineerFirstCategoryMonthlySalary, double tariffCoefficient, 
            double averagePremiumPercentage, double engineerServiceRate)
        {
            this.averageWorkingHours = averageWorkingHours;
            this.kilowattCost = kilowattCost;
            this.pcTotalPower = pcTotalPower;
            this.lightingTotalPower = lightingTotalPower;
            this.pcComplexCarryingAmount = pcComplexCarryingAmount;
            this.termOfPcUse = termOfPcUse;
            this.engineerFirstCategoryMonthlySalary = engineerFirstCategoryMonthlySalary;
            this.tariffCoefficient = tariffCoefficient;
            this.averagePremiumPercentage = averagePremiumPercentage;
            this.engineerServiceRate = engineerServiceRate;
            this.developmentTimeData = developmentTimeData;
        }

        public EquipmentData Calculate()
        {
            double averageWorkingDaysPerYear = 250.0;
            // коефіцієнт, що позначає ремонт і профілактику обладнання
            double Edia = 0.9;
            // тривалість роботи за комп’ютером в рік (год.)
            double Odia = averageWorkingDaysPerYear * averageWorkingHours * Edia;
            // витрати на освітлення приміщення
            double Aie = Odia * kilowattCost * pcTotalPower;
            // витрати електроенергії на роботу ЕОМ
            double Aina = Odia * kilowattCost * lightingTotalPower;
            // витрати на електроенергію
            double Aai = Aie + Aina;
            // витрати на витратні матеріали 
            double Ai = pcComplexCarryingAmount * 0.02;
            // витрати на профілактику 
            double Aidio = pcComplexCarryingAmount * 0.03;
            // амортизаційні відрахування 
            double A = pcComplexCarryingAmount / termOfPcUse;
            // посадовий оклад (ставка) працівника 1-го розряду 
            double C = engineerFirstCategoryMonthlySalary;
            // тарифний коефіцієнт
            double Eo = tariffCoefficient;
            // відсоток премії
            double I = averagePremiumPercentage;
            // кількість комп’ютерів, які обслуговуються одним робітником
            double Iiane = engineerServiceRate;
            //
            double CIiane_ini = (C * Eo / engineerServiceRate) * (1.0 + (I / 100.0));
            //
            double CIiane_aia = CIiane_ini * (A / 100.0);
            //
            double Aiane_ana = ((CIiane_ini + CIiane_aia) * 34.7) / 100.0;

            // сумарні річні витрати
            double Anoi = Aai + Ai + Aidio + A + CIiane_ini + CIiane_aia + Aiane_ana;
            // собівартість 1-єї машино-години роботи ПЕОМ
            double Ci_aia = Anoi / Odia;

            double Ocaa = developmentTimeData.TimeToCreateSoftwareProduct;
            double Aii = Ci_aia * Ocaa;

            EquipmentData result = new EquipmentData();
            result.TotalPcMaintenanceAndOperationCosts = Aii;

            return result;
        }

        // собівартість 1-єї машино-години роботи ПЕОМ
    }
}
