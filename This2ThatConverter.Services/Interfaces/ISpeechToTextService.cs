
using System.Threading.Tasks;

namespace This2ThatConverter.Services.Interfaces
{
    public interface ISpeechToTextService
    {
        Task<string> ToggleListeningAsync();
    }
}
