using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    public class Pallet : IComparable<Pallet>
    {
        private List<Box> boxes;
        private int x;
        private int y;
        private int z;
        private DateTime validUntil;
        private const int weight = 30;
        private Guid id;

        public Pallet(List<Box> b, int x, int y, int z)
        {
            this.boxes = new List<Box>();
            this.x = x;
            this.y = y;
            this.z = z;
            addBox(b);
            this.id = Guid.NewGuid();
            this.validUntil = countDateTime();
        }

        public Pallet(int x, int y, int z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.id = Guid.NewGuid();
            this.boxes = new List<Box>();
            validUntil = DateTime.MaxValue;
        }

        private DateTime countDateTime()
        {
            DateTime min = DateTime.MaxValue;
            foreach (Box cur in boxes)
            {
                if( cur.getValidUntil() < min)
                {
                    min = cur.getValidUntil();
                }
            }
            return min;
        }

        public DateTime getValidUntil()
        {
            return validUntil;
        }

        public int getVolume()
        {
            int volume = x * y * z;
            foreach(Box box in boxes)
            {
                volume += box.getVolume();
            }
            return volume;
        }

        public int getWeight()
        {
            int w = 0;
            foreach(Box box in boxes)
            {
                w += box.getWeight();
            }
            return w + weight;
        }

        public int CompareTo(Pallet p)
        {
            return getWeight().CompareTo(p.getWeight());
        }

        private bool checkBox( Box box)
        {
            return box.getX() <= x && box.getZ() <= z;
        }

        private bool checkBox(List<Box> b)
        {
            foreach(Box box in b)
            {
                if(!checkBox(box))
                    return false;
            }
            return true;
        }
        public bool addBox(Box b)
        {
            if (checkBox(b))
            {
                boxes.Add(b);
                if(b.getValidUntil() < validUntil)
                {
                    validUntil = b.getValidUntil();
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool addBox(List<Box> b)
        {
            if (checkBox(b))
            {
                this.boxes.AddRange(b);
                validUntil = countDateTime();
                return true;
            }
            return false;
        }

        public void sort()
        {
            boxes.Sort();
        }
        public void print()
        {
            Console.WriteLine("==============Pallet============\n" + "Pallet id: " + id +
                "\nValid until " + validUntil.ToShortDateString() +
                $"\nSize x: {x}, y: {y}, z: {z}" + $"\nTotal weight: {getWeight()}");
            foreach(Box box in boxes)
            {
                box.print();
            }
        }

    }
}
