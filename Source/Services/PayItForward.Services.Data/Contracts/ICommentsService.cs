namespace PayItForward.Services.Data.Contracts
{
    public interface ICommentsService
    {
        int Add(string userId, int storyId, string comment);
    }
}
