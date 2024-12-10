using SGE.HexagonalArchiPattern.Core.Enums;


namespace SGE.HexagonalArchiPattern.Core.Ports.Driving
{
    public interface IWritingService
    {
        Task ChangeArticleStatusAsync(Guid articleId, WritingStatus writingStatus);

        Task StartWritingAsync(Guid authorId, Guid articleId);
    }
}
