using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    public class Box : IComparable<Box>
    {
        private int x;
        private int y;
        private int z;
        private int weight;
        private Guid id;
        private DateTime productionDate;
        private DateTime validUntil;
        private const int expirationDate = 100;

        public Box(int x, int y, int z, DateTime date, bool isProductionDate, int weight)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            if (isProductionDate)
            {
                this.productionDate = date.Date;
                validUntil = date.AddDays(expirationDate).Date;
            }
            else
            {
                validUntil = date;
                productionDate = date.AddDays(-expirationDate).Date;
            }
            this.weight = weight;
            id = Guid.NewGuid();
        }

        public int CompareTo(Box other)
        {
            return getVolume().CompareTo(other.getVolume());
        }

        public int getX() { return x; }
        public int getY() { return y; }
        public int getZ() { return z; }

        public DateTime getValidUntil()
        {
            return validUntil;
        }

        public int getVolume()
        {
            return x * y * z;
        }

        public Guid getId() { return id; }

        public int getWeight() { return weight; }

        public DateTime getProductionDate() { return productionDate; }

        public void print()
        {
            Console.WriteLine("Box id: " + id + "\nx: " + x + ", y: " + y + ", z: " + z+ "\nweight: " + weight);
        }

    }
}
