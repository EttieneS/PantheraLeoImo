using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Calendar.v3;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System.IO;
using System.Threading;
using Google.Apis.Calendar.v3.Data;

namespace LionDevAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class CalenderController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public void CreateEvent()
        {
            string clientSecretJson = "C:\\Programs\\LionDevAPI\\apikey.json"; //add your json path here
            string userName = "vryheidgg@gmail.com";//"547548302236-b5h8qc1uu5526o9560uan2crfe1o8107.apps.googleusercontent.com"; // add your google account here
            string[] scopes = new string[1] { "https://www.googleapis.com/auth/calendar"}; // replace n with the number of scopes you need and write them one by one
            CalendarService service = GetCalendarService(clientSecretJson, userName, scopes);

            Event newEvent = new Event()
            {
                Summary = "event title",
                Description = "Test Event",
                Start = new EventDateTime()
                {
                    DateTime = DateTime.Parse("2022-02-28T09:00:00-07:00"),
                    TimeZone = "Africa/Johannesburg",
                },
                End = new EventDateTime()
                {
                    DateTime = DateTime.Parse("2022-02-28T09:00:00-08:00"),
                    TimeZone = "Africa/Johannesburg",
                },
            }; //// more options here https://developers.google.com/calendar/api/v3/reference/events/insert#.net

            String calendarId = "primary"; // choose a calendar in your google account - you might have multiple calendars
            EventsResource.InsertRequest request = service.Events.Insert(newEvent, calendarId);
            Event createdEvent = request.Execute();
        }

        public static CalendarService GetCalendarService(string clientSecretJson, string userName, string[] scopes)
        {
            try
            {
                if (string.IsNullOrEmpty(userName))
                    throw new ArgumentNullException("userName");
                if (string.IsNullOrEmpty(clientSecretJson))
                    throw new ArgumentNullException("clientSecretJson");
                if (!System.IO.File.Exists(clientSecretJson))
                    throw new Exception("clientSecretJson file does not exist.");

                var cred = GetUserCredential(clientSecretJson, userName, scopes);
                return GetService(cred);
            }
            catch (Exception ex)
            {
                throw new Exception("Get Calendar service failed.", ex);
            }
        }

        private static UserCredential GetUserCredential(string clientSecretJson, string userName, string[] scopes)
        {
            try
            {
                if (string.IsNullOrEmpty(userName))
                    throw new ArgumentNullException("userName");
                if (string.IsNullOrEmpty(clientSecretJson))
                    throw new ArgumentNullException("clientSecretJson");
                if (System.IO.File.Exists(clientSecretJson))
                    // These are the scopes of permissions you need. It is best to request only what you need and not all of them               
                    using (var stream = new FileStream(clientSecretJson, FileMode.Open, FileAccess.Read))
                    {
                        string credPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
                        credPath = Path.Combine(credPath, ".credentials/", System.Reflection.Assembly.GetExecutingAssembly().GetName().Name);

                        // Requesting Authentication or loading previously stored authentication for userName
                        var credential = GoogleWebAuthorizationBroker.AuthorizeAsync(GoogleClientSecrets.Load(stream).Secrets,
                                                                                 scopes,
                                                                                 userName,
                                                                                 CancellationToken.None,
                                                                                 new FileDataStore(credPath, true)).Result;

                        credential.GetAccessTokenForRequestAsync();
                        return credential;
                    }
                throw new Exception("clientSecretJson file does not exist.");
            }
            catch (Exception ex)
            {
                throw new Exception("Get user credentials failed.", ex);
            }
        }

        private static CalendarService GetService(UserCredential credential)
        {
            try
            {
                if (credential == null)
                    throw new ArgumentNullException("credential");

                // Create Calendar API service.
                return new CalendarService(new BaseClientService.Initializer()
                {
                    HttpClientInitializer = credential,
                    ApplicationName = "Calendar Oauth2 Authentication Sample"
                });
            }
            catch (Exception ex)
            {
                throw new Exception("Get Calendar service failed.", ex);
            }
        }
    }
}