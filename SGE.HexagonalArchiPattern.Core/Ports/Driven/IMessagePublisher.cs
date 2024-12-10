
namespace SGE.HexagonalArchiPattern.Core.Ports.Driven
{
    public interface IMessagePublisher
    {
        Task PublishMessageAsync(Message message);
    }
}
