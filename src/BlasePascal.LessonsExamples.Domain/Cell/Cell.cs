namespace BlaisePascal.Cell.Domain
{
    public class Cell
    {
        private int val;

        public Cell(int v)
        {
            val = v;
        }

        public Cell() : this(0) { }

        public int getVal() { return val; } 
        public virtual void setVal(int v) { val = v; }
        public virtual void clear () { val = 0; }

    }
}
