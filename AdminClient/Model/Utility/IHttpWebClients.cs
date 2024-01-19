using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminClient.Model.Utility
{
    public interface IHttpWebClients
    {
        string PostRequest(string URI, string parameterValues, bool isAnonymous = false);
    }
}
