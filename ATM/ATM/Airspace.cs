namespace ATM
{
    public class Airspace
    {
        private int x, y, z;

        public Airspace(int x_ = 80000, int y_ = 80000, int z_ = 20000)
        {
            x = x_;
            y = y_;
            z = z_;
        }

        public int X { get => x; set => x = value; }
        public int Y { get => y; set => y = value; }
        public int Z { get => z; set => z = value; }
    }
}