using CryptoPerformers.Data;
using CryptoPerformers.Services;
using CryptoPerformers.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]

namespace CryptoPerformers
{
    public class App : Application
    {
        private static CryptoDatabase database;
        private static AppSettingsService appSettingsService;
        private static CryptoDataService cryptoDataService;

        public App()
        {
            appSettingsService = new AppSettingsService();
            cryptoDataService = new CryptoDataService();
            cryptoDataService.ApiUrl = appSettingsService.ApiUrl;

            Resources = new ResourceDictionary();
            Resources.Add("primaryGray", Color.LightSlateGray);

            var nav = new NavigationPage(new CryptoPage());
            nav.BarBackgroundColor = (Color) Current.Resources["primaryGray"];
            nav.BarTextColor = Color.White;

            MainPage = nav;
        }

        public static CryptoDatabase Database
        {
            get
            {
                if (database == null)
                    database = new CryptoDatabase(DependencyService.Get<IFileHelper>()
                        .GetLocalFilePath("CryptoDataSQLite.db3"));
                return database;
            }
        }

        //public int ResumeAtTodoId { get; set; }

        protected override void OnStart()
        {
            //Debug.WriteLine("OnStart");

            //if (appSettingsService.IsFirstStart)
            //{
            UpdateDataBase();

            //    appSettingsService.IsFirstStart = false;
            //}

            //// always re-set when the app starts
            //// users expect this (usually)
            ////			Properties ["ResumeAtTodoId"] = "";
            //if (Properties.ContainsKey("ResumeAtTodoId"))
            //{
            //	var rati = Properties["ResumeAtTodoId"].ToString();
            //	Debug.WriteLine("   rati=" + rati);
            //	if (!String.IsNullOrEmpty(rati))
            //	{
            //		Debug.WriteLine("   rati=" + rati);
            //		ResumeAtTodoId = int.Parse(rati);

            //		if (ResumeAtTodoId >= 0)
            //		{
            //			var todoPage = new TodoItemPage();
            //			todoPage.BindingContext = await Database.GetItemAsync(ResumeAtTodoId);
            //			await MainPage.Navigation.PushAsync(todoPage, false); // no animation
            //		}
            //	}
            //}
        }

        public static void UpdateDataBase()
        {
            var cryptoList = cryptoDataService.GetCryptoData();
            foreach (var crypto in cryptoList) Database.SaveItemAsync(crypto);
        }

        protected override void OnSleep()
        {
            //Debug.WriteLine("OnSleep saving ResumeAtTodoId = " + ResumeAtTodoId);
            //// the app should keep updating this value, to
            //// keep the "state" in case of a sleep/resume
            //Properties["ResumeAtTodoId"] = ResumeAtTodoId;
        }

        protected override void OnResume()
        {
            //Debug.WriteLine("OnResume");
            //if (Properties.ContainsKey("ResumeAtTodoId"))
            //{
            //	var rati = Properties["ResumeAtTodoId"].ToString();
            //	Debug.WriteLine("   rati=" + rati);
            //	if (!String.IsNullOrEmpty(rati))
            //	{
            //		Debug.WriteLine("   rati=" + rati);
            //		ResumeAtTodoId = int.Parse(rati);

            //		if (ResumeAtTodoId >= 0)
            //		{
            //			var todoPage = new TodoItemPage();
            //			todoPage.BindingContext = await Database.GetItemAsync(ResumeAtTodoId);
            //			await MainPage.Navigation.PushAsync(todoPage, false); // no animation
            //		}
            //	}
            //}
        }
    }
}