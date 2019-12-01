using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pidev.Data;

namespace TestEF.Data
{
    public interface IDataBaseFactory:IDisposable
    {
        PidevContext Ctxt { get; }
    }
}
