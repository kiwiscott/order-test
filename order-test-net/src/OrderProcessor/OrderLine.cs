namespace OrderProcessor
{
    public struct OrderLine
    {
        public decimal Price { get; internal set; }
        public string Code { get; internal set; }
        public int LineNo { get; internal set; }
        public string Category { get; internal set; }
        public int Quantity { get; internal set; }
    }
}

