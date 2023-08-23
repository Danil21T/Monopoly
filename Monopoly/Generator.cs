using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    public class Generator
    {
        private int amountPallet;
        private int amountBoxesInPalletMax;
        private int amountBoxesInPalletMin = 0;
        private int maxSizePallet = 50;
        private int maxSizeBox = 55;
        private int maxWeightBox = 50;
        private int minWeightBox = 0;
        private int dateSpread = 50;
        public Generator(int amountPallet, int amountBoxesInPallet) { 
            this.amountPallet = amountPallet;
            this.amountBoxesInPalletMax = amountBoxesInPallet;
        }

        public List<Pallet> generatePallets()
        {
            List<Pallet> pallets = new List<Pallet>();
            Random rand = new Random();
            for(int i = 0; i < amountPallet; i++)
            {
                pallets.Add(new Pallet(rand.Next(maxSizePallet), rand.Next(maxSizePallet), rand.Next(maxSizePallet)));
            }
            return pallets;
        }

        public Box generateBox()
        {
            Random rand = new Random();
            DateTime date = DateTime.Now.AddDays(rand.Next(-dateSpread, dateSpread));
            return new Box(rand.Next(maxSizeBox), rand.Next(maxSizeBox), rand.Next(maxSizeBox), date, true, rand.Next(minWeightBox, maxWeightBox));
        }

        public void fillPallets(List<Pallet> pallets)
        {
            Random random = new Random();
            foreach(Pallet pallet in pallets)
            {
                int amountOfBox;
                do{ amountOfBox = random.Next(amountBoxesInPalletMin, amountBoxesInPalletMax + 1); }
                while (amountOfBox == 0);
                for(int  j = 0; j < amountOfBox; j++)
                {
                    if (!pallet.addBox(generateBox()))
                    {
                        j--;
                    }
                }
            }
        }
    }
}
