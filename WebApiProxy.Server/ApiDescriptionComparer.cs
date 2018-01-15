using System.Collections.Generic;
using System.Web.Http.Description;

namespace WebApiProxy.Server
{
    public class ApiDescriptionComparer : IEqualityComparer<ApiDescription>
    {
        public bool Equals(ApiDescription x, ApiDescription y)
        {
            return x?.ActionDescriptor.ActionName == y?.ActionDescriptor.ActionName;
        }

        public int GetHashCode(ApiDescription obj)
        {
            return obj.ActionDescriptor.ActionName.GetHashCode();
        }
    }
}