using MPersist.Core.Message.Response;

namespace MPersist.Core.Interfaces
{
    public interface IDataRequestor
    {
        void ResponseRecieved(AbstractResponse response);
    }
}
