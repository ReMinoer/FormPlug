namespace FormPlug.SocketAttributes
{
    public class NumericSocketAttribute : SocketAttribute
    {
        public double Minimum { get; set; }
        public double Maximum { get; set; }
        public double Increment { get; set; }
        public int Decimals { get; set; }

        public NumericSocketAttribute()
        {
            Minimum = 0;
            Maximum = 10;
            Increment = 1;
            Decimals = 0;
        }
    }
}