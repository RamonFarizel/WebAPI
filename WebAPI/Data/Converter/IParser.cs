using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Data.Converter
{
    //O - Origem
    //D - Destino
    public interface IParser<O,D>
    {
        D Parse(O origem);
        IList<D> ParseList(IList<O> Origin);
    }
}
