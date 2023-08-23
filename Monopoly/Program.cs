using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    class Program
    {
        static void Main(string[] args)
        {
            int maxPallet = 5;
            int maxBoxInPallet = 7;
            Generator gen = new Generator(maxPallet, maxBoxInPallet);
            List<Pallet> pallets = gen.generatePallets();
            gen.fillPallets(pallets);
            //Сгруппировать все паллеты по сроку годности, отсортировать по возрастанию срока годности, в каждой группе отсортировать паллеты по весу.
            var groupByDateUntilValid = from pallet in pallets
                                        group pallet by pallet.getValidUntil() into newGroup
                                        orderby newGroup.Key
                                        select newGroup;
            var listWithOrder = groupByDateUntilValid.ToList();
            foreach (var group in listWithOrder)
            {
                group.ToList().Sort();
            }

            //3 паллеты, которые содержат коробки с наибольшим сроком годности, отсортированные по возрастанию объема.
            int showInConsole = 3;
            var listWithReverseOrder = new List<IGrouping<DateTime, Pallet>>(listWithOrder);
            listWithReverseOrder.Reverse();
            foreach(var group in listWithReverseOrder)
            {
                foreach(var p in group)
                {
                    p.sort();
                    p.print();
                    showInConsole--;
                    if(showInConsole == 0)
                    {
                        break;
                    }
                }
                if (showInConsole == 0)
                {
                    break;
                }
            }
            Console.ReadLine();
        }
    }
}
