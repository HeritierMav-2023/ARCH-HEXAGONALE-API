using SGE.HexagonalArchiPattern.Core;
using SGE.HexagonalArchiPattern.Core.Ports.Driven;


namespace SGE.HexagonalArchiPattern.Messaging.Publishers
{
    public class MessagePublisher : IMessagePublisher
    {
        public Task PublishMessageAsync(Message message)
        {
            return Task.CompletedTask;
        }
    }
}
