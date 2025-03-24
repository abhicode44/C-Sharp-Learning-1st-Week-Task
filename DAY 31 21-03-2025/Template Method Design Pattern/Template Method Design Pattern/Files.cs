using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template_Method_Design_Pattern
{
    internal abstract  class Files
    {
        public void Save()
        {
            Open();
            Write();
            Close();
        }

        protected abstract void Open();
        protected abstract void Write();
        protected abstract void Close();

    }
}
