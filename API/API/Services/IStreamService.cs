using API.Models;

namespace API.Services
{
    public interface IStreamService
    {
        List<Streams> Get();
        Streams Create(Streams stream);
    }
}
