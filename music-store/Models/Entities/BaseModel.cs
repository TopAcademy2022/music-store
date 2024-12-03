using Microsoft.Extensions.Logging;

namespace music_store.Models.Entities
{
    public class BaseModel
    {
        protected readonly ILogger _logger;

        public BaseModel(ILogger logger)
        {
            _logger = logger;
        }
    }
}
