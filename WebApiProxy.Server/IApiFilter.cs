using System.Web.Http.Description;

namespace WebApiProxy.Server
{
    public interface IApiFilter
    {
        /// <summary>
        /// 返回true则过滤掉当前<param name="description">ApiDescription</param>
        /// </summary>
        /// <param name="description"></param>
        /// <returns></returns>
        bool Filter(ApiDescription description);
    }
}