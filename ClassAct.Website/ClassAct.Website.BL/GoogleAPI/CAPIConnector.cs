using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ClassAct.Website.BL.GoogleAPI
{
    public class CAPIConnector
    {

        private string ApiKey
        {
            get
            {
                return "AIzaSyDEgHJIB8tTRxLPp26IMEMXXM6ra4Cv1Uk"; //ConfigurationManager.AppSettings["GooglePlaceAPIKey"]; //
            }
        }

        private string TextSearchBaseURL
        {
            get
            {
                return "https://maps.googleapis.com/maps/api/place/textsearch/json?query={0}&radius=0&type=restaurant&key={1}";
            }
        }

        private string PlaceDetailBaseURL
        {
            get
            {
                return "https://maps.googleapis.com/maps/api/place/details/json?placeid={0}&key={1}";
            }
        }

        private string PlacePhotoBaseURL
        {
            get
            {
                return "https://maps.googleapis.com/maps/api/place/photo?maxwidth={0}&photoreference={1}&key={2}";
            }
        }

        public string GetPlaceId(string query)
        {
            try
            {
                // Construct the url
                string url = TextSearchBaseURL.Replace("{0}", query);
                url = url.Replace("{1}", ApiKey);

                // Get the data
                var json = new WebClient().DownloadString(url);
                CGooglePlace GooglePlace = JsonConvert.DeserializeObject<CGooglePlace>(json);

                if (GooglePlace.Results.Count == 0)//GooglePlace.Status == "ZERO_RESULTS")
                {
                    if(GooglePlace.Status == "OVER_QUERY_LIMIT")
                    {
                        return "APIError";
                    }
                    else
                    {
                        return "empty";
                    }
                }
                else
                {
                    return GooglePlace.Results[0].Place_id;                 
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public string GetPhotoReference(string placeid)
        {
            try
            {
                // Construct the url
                string url = PlaceDetailBaseURL.Replace("{0}", placeid);
                url = url.Replace("{1}", ApiKey);

                // Get the data
                var json = new WebClient().DownloadString(url);
                CGooglePlaceDetail GooglePlaceDetail = JsonConvert.DeserializeObject<CGooglePlaceDetail>(json);

                if (GooglePlaceDetail.result.photos != null)
                {
                    return GooglePlaceDetail.result.photos[0].photo_reference;
                }
                else
                {
                    if (GooglePlaceDetail.status == "OVER_QUERY_LIMIT")
                    {
                        return "APIError";
                    }
                    else
                    {
                        return "empty";
                    }    
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// Returns an image as a Base64 string
        /// </summary>
        /// <param name="photoreference"></param>
        /// <param name="maxwidth"></param>
        /// <returns></returns>
        public string GetPhoto(string photoreference, int maxwidth)
        {
            string url = PlacePhotoBaseURL.Replace("{0}", maxwidth.ToString());
            url = url.Replace("{1}", photoreference);
            url = url.Replace("{2}", ApiKey);

            byte[] img = new System.Net.WebClient().DownloadData(url);

            return Convert.ToBase64String(img, 0, img.Length);
        }

        #region Get Location based on Users IP Address
        /*THis doesn't work.  
        public string getCity()
        {

            IP2Location.IPResult location = new IP2Location.IPResult();
            string city = location.City;
            return city;
        }*/
#endregion
    }
}
