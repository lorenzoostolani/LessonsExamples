using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.Cell.Domain
{
    public class BackupCell: Cell
    {
        private int oldVal;

        public BackupCell(int v): base(v)
        {
            oldVal = v;
        }

        public BackupCell() : base() 
        { 
            oldVal = 0;
        }

        public override void setVal(int v)
        {
            oldVal = getVal();
            base.setVal(v);
        }
        public override void clear()
        {
            oldVal = getVal();
            base.clear();
        }
        public void restore() 
        { 
            int tmp = getVal();
            base.setVal(oldVal);
            oldVal = tmp;
        }


    }
}