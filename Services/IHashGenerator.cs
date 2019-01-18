namespace ginx.me.Services
{
    public interface IHashGenerator
    {
        UniqueIdWithSalt GetNext();
    }
}