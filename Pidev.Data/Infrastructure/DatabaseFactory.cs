using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pidev.Data;

namespace TestEF.Data
{
    public class DataBaseFactory: Disposable, IDataBaseFactory
    {
       PidevContext ctxt;

        public PidevContext Ctxt
        {
            get
            {
                return ctxt;
            }
        }

        public DataBaseFactory()
        {
            ctxt = new PidevContext();
        }

        public override void DisposeCore()
        {
            if (ctxt != null)
                ctxt.Dispose();
        }
    }
}
