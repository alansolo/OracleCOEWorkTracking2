using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OracleCOEWorkTracking.Controllers.Helpers
{
    public class Mappers<T, VM>
    {
        public static VM MapToViewModel(T t)
        {
            return AutoMapper.Mapper.Map<T, VM>(t);
        }

        public static T MapToEntity(VM vm)
        {
            return AutoMapper.Mapper.Map<VM, T>(vm);
        }
    }
}
