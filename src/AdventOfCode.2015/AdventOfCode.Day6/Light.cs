namespace AdventOfCode.Day6
{
    public class Light
    {
        public int X { get; set; }
        public int Y { get; set; }
        public bool On { get; set; }
        public int Brightness { get; set; }

        public Light(int x, int y)
        {
            X = x;
            Y = y;
            Brightness = 0;
        }
    }
}
