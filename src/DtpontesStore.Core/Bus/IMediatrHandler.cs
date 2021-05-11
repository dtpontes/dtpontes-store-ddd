using DtpontesStore.Core.Messages;
using System.Threading.Tasks;

namespace DtpontesStore.Core.Bus
{
    public interface IMediatrHandler
    {
        Task PublicarEvento<T>(T evento) where T : Event;
    }


}
