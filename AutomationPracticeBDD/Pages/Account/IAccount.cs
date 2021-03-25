
namespace AutomationPracticeBDD.Pages.Account
{
    public interface IAccount
    {
        void Login(string userName, string password);
        bool VerifyHomePage();

        void DeepLinkToAccountInfo();
        void UpdateAccountInfo(string firstName, string password);
        void SaveAccountInfo();
        void VerifyAccountInfo(string firstName);

    }
}
