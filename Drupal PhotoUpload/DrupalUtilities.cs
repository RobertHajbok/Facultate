using System;
using System.Collections.Specialized;
using System.Globalization;
using System.IO;
using System.Net;
using System.Xml;

namespace Drupal_PhotoUpload
{
    public class DrupalUtilities
    {
        #region Drupal Data Members
        // The event delegate
        public delegate void FireDrupalEventHandler(object sender, DrupalEventArgs fe);

        // The event
        public event FireDrupalEventHandler NewDrupalViewData;

        private readonly string _dServerUrl = "";
        private readonly string _dServiceName = "";
        private readonly string _dUserName = "";
        private readonly string _dUserPw = "";
        private bool _loggedIn;
        private string _loggedInUserId = "-1";

        public const string MethodUserLogout = "/user/logout";
        public const string MethodUserLogin = "/user/login";
        public const string MethodFileCreate = "/file";
        public const string MethodNodeRetrieve = "/node/";
        public const string MethodNodeCreate = "/node";
        public const string MethodViewRetrieve = "/views/";
        #endregion

        #region HTTP Request Data Members
        private readonly CookieContainer _drupalCookies;
        #endregion

        public DrupalUtilities(string serverUrl, string serviceName, string drupalUserName, string drupalUserPw)
        {
            _dServerUrl = serverUrl;
            _dServiceName = serviceName;
            _dUserName = drupalUserName;
            _dUserPw = drupalUserPw;

            // Initialize a new cookie container for use with any requests
            _drupalCookies = new CookieContainer();
        }

        public void Login()
        {
            var thisHttpRequest = (HttpWebRequest)WebRequest.Create(_dServerUrl + _dServiceName + MethodUserLogin);
            thisHttpRequest.CookieContainer = _drupalCookies;
            thisHttpRequest.Method = "POST";

            // Add Post parameters manually
            var boundary = "---------------------------" + DateTime.Now.Ticks.ToString("x");
            var boundarybytes = System.Text.Encoding.ASCII.GetBytes("\r\n--" + boundary + "\r\n");
            const string formdataTemplate = "Content-Disposition: form-data; name=\"{0}\"\r\n\r\n{1}";
            thisHttpRequest.KeepAlive = true;

            // Add/Edit Headers
            thisHttpRequest.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";
            thisHttpRequest.ContentType = "multipart/form-data; boundary=" + boundary;

            var nvc = new NameValueCollection {{"username", _dUserName}, {"password", _dUserPw}};
            var rs = thisHttpRequest.GetRequestStream();

            foreach (string key in nvc.Keys)
            {
                rs.Write(boundarybytes, 0, boundarybytes.Length);
                var formitem = string.Format(formdataTemplate, key, nvc[key]);
                var formitembytes = System.Text.Encoding.UTF8.GetBytes(formitem);
                rs.Write(formitembytes, 0, formitembytes.Length);
            }
            rs.Write(boundarybytes, 0, boundarybytes.Length);

            var trailer = System.Text.Encoding.ASCII.GetBytes("\r\n--" + boundary + "--\r\n");
            rs.Write(trailer, 0, trailer.Length);
            rs.Close();

            // Send to the consolodated response handler
            ParseHttpResponse(ref thisHttpRequest, MethodUserLogin);
        }

        /// <summary>
        /// Call to logout if any session is currently active.
        /// </summary>
        public void Logout()
        {
            if (!_loggedIn) return;
            var thisHttpRequest = (HttpWebRequest)WebRequest.Create(_dServerUrl + _dServiceName + MethodUserLogout);
            thisHttpRequest.CookieContainer = _drupalCookies;
            thisHttpRequest.Method = "POST";

            // Add/Edit Headers
            thisHttpRequest.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";
            thisHttpRequest.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";

            // Send to the consolodated response handler
            ParseHttpResponse(ref thisHttpRequest, MethodUserLogout);
        }

        /// <summary>
        /// Attempts to retrieve a node with the specified id
        /// returns in xml format
        /// </summary>
        /// <param name="nodeId"></param>
        public void GetNode(int nodeId)
        {
            var thisHttpRequest = (HttpWebRequest)WebRequest.Create(_dServerUrl + _dServiceName + MethodNodeRetrieve + nodeId);
            thisHttpRequest.CookieContainer = _drupalCookies;
            thisHttpRequest.Method = "GET";

            // Add/Edit headers - This leaves user agent blank
            thisHttpRequest.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";
            thisHttpRequest.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";

            // Send to the consolodated response handler
            ParseHttpResponse(ref thisHttpRequest, MethodNodeRetrieve);

        }

        /// <summary>
        /// We we need to first create a new file inside of drupal. To do this with the REST server we base 64 encode 
        /// a bytearray of an already encoded media file. So if its an image, the bytearray should already be 
        /// jpeg/png encoded. If its a video the bytearray should already be encoded in the desired format.
        /// </summary>
        public void SubmitFileB64(ref byte[] fileContentNoB64, string fileNameOnServerWExtension, string validMimeType)
        {
            if (!_loggedIn) return;
            var thisHttpRequest = (HttpWebRequest)WebRequest.Create(_dServerUrl + _dServiceName + MethodFileCreate);
            thisHttpRequest.CookieContainer = _drupalCookies;
            thisHttpRequest.Method = "POST";

            // Add Post parameters manually
            var boundary = "---------------------------" + DateTime.Now.Ticks.ToString("x");
            var boundarybytes = System.Text.Encoding.ASCII.GetBytes("\r\n--" + boundary + "\r\n");
            const string formdataTemplate = "Content-Disposition: form-data; name=\"{0}\"\r\n\r\n{1}";
            thisHttpRequest.KeepAlive = true;

            // Add/Edit Headers
            //--> Worked in Java thisHttpRequest.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";
            thisHttpRequest.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";
            thisHttpRequest.ContentType = "multipart/form-data; boundary=" + boundary;

            // Base64 Encode the data
            string base64String;
            try
            {
                base64String = Convert.ToBase64String(fileContentNoB64, 0, fileContentNoB64.Length);
            }
            catch (ArgumentNullException)
            {
                System.Diagnostics.Debug.WriteLine("Error encoding file to b64");
                return;
            }

            if (base64String == "") return;
            var nvc = new NameValueCollection
            {
                {"filename", fileNameOnServerWExtension},
                {"filesize", fileContentNoB64.Length.ToString(CultureInfo.InvariantCulture)},
                {"uid", "1"},
                {"file", base64String}
            };

            var rs = thisHttpRequest.GetRequestStream();

            foreach (string key in nvc.Keys)
            {
                rs.Write(boundarybytes, 0, boundarybytes.Length);
                var formitem = string.Format(formdataTemplate, key, nvc[key]);
                var formitembytes = System.Text.Encoding.UTF8.GetBytes(formitem);
                rs.Write(formitembytes, 0, formitembytes.Length);
            }
            rs.Write(boundarybytes, 0, boundarybytes.Length);

            var trailer = System.Text.Encoding.ASCII.GetBytes("\r\n--" + boundary + "--\r\n");
            rs.Write(trailer, 0, trailer.Length);
            rs.Close();

            // Send to the consolodated response handler
            ParseHttpResponse(ref thisHttpRequest, MethodFileCreate);
        }

        /// <summary>
        /// Consolidates parsing the response for all of these http requests
        /// using a reference to the originals.
        /// </summary>
        /// <param name="theRequestRef"></param>
        /// <param name="responseType">_responseType is the type of request that was made so we know how to parse the results if sucessful</param>
        private void ParseHttpResponse(ref HttpWebRequest theRequestRef, string responseType)
        {
            WebResponse wresp = null;
            try
            {
                wresp = theRequestRef.GetResponse();
                var stream2 = wresp.GetResponseStream();
                var reader2 = new StreamReader(stream2);
                var xmlResponse = reader2.ReadToEnd();

                switch (responseType)
                {
                    case MethodUserLogout:
                        System.Diagnostics.Debug.WriteLine(string.Format("Logout complete, server response is: {0}", xmlResponse));
                        _loggedIn = false;
                        break;
                    case MethodUserLogin:
                        System.Diagnostics.Debug.WriteLine(string.Format("Login sucessful, server response is: {0}", xmlResponse));
                        _loggedIn = true;
                        break;
                    case MethodFileCreate:
                        System.Diagnostics.Debug.WriteLine(string.Format("File created, server response is: {0}", xmlResponse));
                        break;
                    case MethodNodeCreate:
                        System.Diagnostics.Debug.WriteLine(string.Format("Node created, server response is: {0}", xmlResponse));
                        break;
                    case MethodNodeRetrieve:
                        System.Diagnostics.Debug.WriteLine(string.Format("Node retrieved, server response is: {0}", xmlResponse));
                        break;
                    case MethodViewRetrieve:
                        System.Diagnostics.Debug.WriteLine(string.Format("View retrieved, server response is: {0}", xmlResponse));
                        break;
                }

                // Send the response off for xml parsing
                ParseDrupalXmlResponse(xmlResponse, responseType);
            }
            catch (WebException ex)
            {
                using (var response = ex.Response)
                {
                    var httpResponse = (HttpWebResponse)response;

                    switch (responseType)
                    {
                        case MethodUserLogout:
                            System.Diagnostics.Debug.WriteLine("Error logging out Status: {0} Description: {1}", httpResponse.StatusCode, httpResponse.StatusDescription);
                            break;
                        case MethodUserLogin:
                            System.Diagnostics.Debug.WriteLine("Error logging inn Status: {0} Description: {1}", httpResponse.StatusCode, httpResponse.StatusDescription);
                            break;
                        case MethodFileCreate:
                            System.Diagnostics.Debug.WriteLine("Error creating file Status: {0} Description: {1}", httpResponse.StatusCode, httpResponse.StatusDescription);
                            break;
                        case MethodNodeCreate:
                            System.Diagnostics.Debug.WriteLine("Error creating node Status: {0} Description: {1}", httpResponse.StatusCode, httpResponse.StatusDescription);
                            break;
                        case MethodNodeRetrieve:
                            System.Diagnostics.Debug.WriteLine("Error recieving node: {0} Description: {1}", httpResponse.StatusCode, httpResponse.StatusDescription);
                            break;
                        case MethodViewRetrieve:
                            System.Diagnostics.Debug.WriteLine("Error getting view: {0} Description: {1}", httpResponse.StatusCode, httpResponse.StatusDescription);
                            break;
                    }

                    using (var data = response.GetResponseStream())
                    {
                        var text = new StreamReader(data).ReadToEnd();
                        System.Diagnostics.Debug.WriteLine(text);
                        if (data != null) 
                            data.Close();
                    }
                    httpResponse.Close();
                }

                if (wresp != null)
                {
                    wresp.Close();
                }
            }
            finally
            {
                theRequestRef = null;
            }
        }

        private void ParseDrupalXmlResponse(string response, string responseType)
        {
            if (response == "") return;
            // Create an XmlReader
            using (var reader = XmlReader.Create(new StringReader(response)))
            {
                try
                {
                    switch (responseType)
                    {
                        case MethodUserLogout:
                            reader.ReadToFollowing("result");
                            var tempLogoutValue = reader.ReadElementContentAsString();
                            System.Diagnostics.Debug.WriteLine("Logout xml parse result: " + tempLogoutValue);
                            if (tempLogoutValue == "1")
                            {
                                _loggedInUserId = "-1";
                            }

                            // DISPATCH
                            var logoutEventData = new DrupalEventArgs(MethodUserLogout, response);
                            NewDrupalViewData(this, logoutEventData);
                            break;
                        case MethodUserLogin:
                            reader.ReadToFollowing("uid");
                            _loggedInUserId = reader.ReadElementContentAsString();
                            System.Diagnostics.Debug.WriteLine("Login xml parse userID: " + _loggedInUserId);
                            // DISPATCH
                            var loginEventData = new DrupalEventArgs(MethodUserLogin, response);
                            NewDrupalViewData(this, loginEventData);
                            break;
                        case MethodFileCreate:
                            reader.ReadToFollowing("fid");
                            reader.ReadElementContentAsString();
                            // ReadToFollowing auto hops to the next element
                            if (reader.Name != "uri")
                            {
                                reader.ReadToFollowing("uri");
                            }
                            reader.ReadElementContentAsString();
                            var fileEventData = new DrupalEventArgs(MethodFileCreate, response);
                            NewDrupalViewData(this, fileEventData);
                            break;
                        case MethodNodeCreate:
                            reader.ReadToFollowing("nid");
                            reader.ReadElementContentAsString();
                            // ReadToFollowing auto hops to the next element
                            if (reader.Name != "uri")
                            {
                                reader.ReadToFollowing("uri");
                            }
                            reader.ReadElementContentAsString();
                            break;
                        case MethodNodeRetrieve:
                            // Data here will be really unique to the content type of the node may want to consider
                            // passing this off to a specific class.

                            // DISPATCH
                            var thisEventData = new DrupalEventArgs(MethodNodeRetrieve, response);
                            NewDrupalViewData(this, thisEventData);

                            break;
                        case MethodViewRetrieve:
                            // Data here will be really unique to the content types contained in the view may want to consider
                            // passing this off to a specific class.

                            // DISPATCH
                            var nextEventData = new DrupalEventArgs(MethodViewRetrieve, response);
                            NewDrupalViewData(this, nextEventData);

                            break;
                    }
                }
                catch (XmlException e)
                {
                    System.Diagnostics.Debug.WriteLine("Exception parsing drupal result xml: {0}", e.ToString());
                }
            }
        }
    }
}
