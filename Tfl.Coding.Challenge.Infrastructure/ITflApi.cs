using System.Threading;
using System.Threading.Tasks;

namespace Tfl.Coding.Challenge.Infrastructure
{
    public interface ITflApi
    {
        Task<RoadStatusModel> Status(string id, CancellationToken token = default);
    }
}
