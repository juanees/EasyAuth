using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyAuth.Interfaces
{
    public interface IUserSerializationStrategy
    {
        public string Serialize(IUser user);
    }
}
