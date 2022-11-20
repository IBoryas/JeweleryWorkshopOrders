using JewelryWorkshopOrders.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelryWorkshopOrders.Dal.Seed
{
    public class MaterialSeed
    {
        public static async Task Seed(JewelryWorkshopOrdersDbContext context)
        {
            if (!context.MaterialTypes.Any())
            {
                var gold = new MaterialType()
                {
                    Material = "Gold"
                };

                var silver = new MaterialType()
                {
                    Material = "Silver"
                };

                context.MaterialTypes.AddRange(gold, silver);

                var gold958 = new Material()
                {
                    MaterialType = gold,
                    Content = 958
                };

                var gold750 = new Material()
                {
                    MaterialType = gold,
                    Content = 750
                };

                var gold585 = new Material()
                {
                    MaterialType = gold,
                    Content = 585
                };

                var silver875 = new Material()
                {
                    MaterialType = silver,
                    Content = 875
                };

                var silver925 = new Material()
                {
                    MaterialType = silver,
                    Content = 925
                };

                context.Materials.AddRange(gold958, gold585, gold750, silver875, silver925);

                await context.SaveChangesAsync();
            }
        }
    }
}
