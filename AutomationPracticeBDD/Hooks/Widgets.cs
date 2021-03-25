using System;
using AutomationPracticeBDD.Common.Constants;
using AutomationPracticeBDD.Pages.Account;
using AutomationPracticeBDD.Pages.PlaceOrder;
using AutomationPracticeBDD.Settings.Models;
using BoDi;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;

namespace AutomationPracticeBDD.Hooks
{
    [Binding]
    internal class Widgets
    {
        private readonly IObjectContainer _objectContainer;

        public Widgets(IObjectContainer objectContainer) => _objectContainer = objectContainer;

        [BeforeScenario(Order = (int)HookRunOrder.SpecFlowHooks)]
        public void BeforeScenario()
        {
            if (ClientTestConfiguration.TestConfiguration.Platform.Equals("Desktop",
                StringComparison.InvariantCultureIgnoreCase))
                LoadDesktopBindings();
            else
                LoadMobileBindings();
    
        }

        private void LoadMobileBindings()
        {
            _objectContainer.RegisterInstanceAs(GetPlatformWidget<PlaceOrderMobile, IPlaceOrder>());
            _objectContainer.RegisterInstanceAs(GetPlatformWidget<AccountMobile, IAccount>());
        }

        private void LoadDesktopBindings()
        {
            _objectContainer.RegisterInstanceAs(GetPlatformWidget<PlaceOrderDesktop, IPlaceOrder>());
            _objectContainer.RegisterInstanceAs(GetPlatformWidget<AccountDesktop, IAccount>());
        }

        private TU GetPlatformWidget<T, TU>() where T : TU =>
            (TU) Activator.CreateInstance(typeof(T), _objectContainer.Resolve<ChromeDriver>());
    }
}