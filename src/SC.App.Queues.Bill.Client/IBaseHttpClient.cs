namespace SC.App.Queues.Bill.Client
{
    public interface IBaseHttpClient
    {
        void SetAuthorization(string authorization);

        void SetAcceptLanguage(string acceptLanguage);
    }
}