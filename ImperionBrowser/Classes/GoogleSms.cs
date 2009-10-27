using System;
using System.Collections.Generic;
using System.Text;
using Google.GData.Calendar;
using System.Windows.Forms;
using Google.GData.Extensions;
using Google.GData.Client;
using System.Net;

namespace ImperionBrowser
{
    public class GoogleSms
    {
        private string mUserName;
        private string mUserPassword;

        public GoogleSms(string iUserName, string iPassword)
        {
            mUserName = iUserName;
            mUserPassword = iPassword;
        }

        private CalendarFeed RetrievingOwnGoogleCalendars()
        {
            // Create a CalenderService and authenticate
            CalendarService myService = new CalendarService("ImperionBrowser"); //exampleCo-exampleApp-1
            myService.setUserCredentials(mUserName , mUserPassword);

            CalendarQuery query = new CalendarQuery();
            query.Uri = new Uri("http://www.google.com/calendar/feeds/default/owncalendars/full");
            CalendarFeed resultFeed = myService.Query(query);
            return resultFeed; 
        }

        public void AddCalendarsToComboBox(ComboBox iDestinationCombobox)
        {
            try
            {
                iDestinationCombobox.Items.Clear();
                CalendarFeed cal_Feed = RetrievingOwnGoogleCalendars();
                foreach (CalendarEntry centry in cal_Feed.Entries)
                {
                    iDestinationCombobox.Items.Add(centry);
                }

                iDestinationCombobox.DisplayMember = "Title";
                iDestinationCombobox.ValueMember = "Title";
                
                if (iDestinationCombobox.Items.Count > 0)
                {
                    iDestinationCombobox.SelectedIndex = 0;
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message.ToString());
            }
        }

        public bool SendSms(string iPostUrl, string iText, string iLocation)
        {
            EventEntry entry = new EventEntry();
            try
            {
                // Set the title and content of the entry.
                entry.Title.Text = iText;
                entry.Content.Content = "Sadly the content will not be sended by sms";
                
                // Set a location for the event.
                Where eventLocation = new Where();
                eventLocation.ValueString = iLocation;
                entry.Locations.Add(eventLocation);
                DateTime dtstartdatetime = DateTime.Now.AddMinutes(2);
                DateTime dtenddatetime = DateTime.Now.AddMinutes(5);

                When eventTime = new When(dtstartdatetime, dtenddatetime);
                entry.Times.Add(eventTime);
                
                CalendarService service = new CalendarService("ImperionGoogle");
                service.setUserCredentials(mUserName, mUserPassword);

                Uri postUri = new Uri(iPostUrl);
                
                GDataGAuthRequestFactory requestFactory = (GDataGAuthRequestFactory)service.RequestFactory;

                #region not used yet / proxy
                /*IWebProxy iProxy = WebRequest.GetSystemWebProxy();
                WebProxy myProxy = new WebProxy();
                // potentially, setup credentials on the proxy here
                myProxy.Credentials = CredentialCache.DefaultCredentials;
                myProxy.UseDefaultCredentials = false;
                if (ProxyAddress.Text.Trim() != "" && ProxyPort.Text.Trim() != "")
                {
                    myProxy.Address = new Uri("http://" + ProxyAddress.Text.Trim() + ":" + ProxyPort.Text.Trim());
                }*/
                #endregion

                requestFactory.CreateRequest(GDataRequestType.Insert, postUri);//  = myProxy;

                //add sms notification
                Reminder r = new Reminder();
                r.Method = Reminder.ReminderMethod.sms;
                r.Minutes = 1;
                entry.Reminders.Add(r);

                // Send the request and receive the response:
                AtomEntry insertedEntry = service.Insert(postUri, entry);
                
                return true;
            }
            catch(Exception e)
            {
                MessageBox.Show(e.ToString());
                return false;
            }
            
        }

        public static string buildCalendarUri(CalendarEntry iTargetCalendar)
        {
            string url = "http://www.google.com/calendar/feeds/";
            url += iTargetCalendar.SelfUri.ToString().Substring(iTargetCalendar.SelfUri.ToString().LastIndexOf('/') + 1);
            url += "/private/full";

            return url;
        }
    }

}
