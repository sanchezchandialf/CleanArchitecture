using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA_ApplicationLayer
{
    public interface Imapper<TDTO,TOutput>
    {
        public TOutput ToEntity(TDTO dto);

    }
}
