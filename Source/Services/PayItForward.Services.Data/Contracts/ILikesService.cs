namespace PayItForward.Services.Data.Contracts
{
    public interface ILikesService
    {
        bool AddLike(int storyId, string userId);
    }
}
