using IOData;
using System;

namespace FinishedSoftwareProductCostCalculator
{
    public class FinishedSoftwareProductCostCalculator
    {
        private PureCostData pureCostData;

        public FinishedSoftwareProductCostCalculator(PureCostData pureCostData)
        {
            this.pureCostData = pureCostData;
        }

        public FinishedSoftwareProductCostData Calculate()
        {
            double O = pureCostData.SoftwareProductCost * (1.0 + (40.0 / 100.0));

            FinishedSoftwareProductCostData result = new FinishedSoftwareProductCostData();
            result.FinishedSoftwareProductCost = O;

            return result;
        }
    }
}
