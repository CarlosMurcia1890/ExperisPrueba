using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using ExperisPrueba.Models;
using System.IO;

namespace ExperisPrueba.Utilidades
{
    public class ServicioDatos
    {
       public List<DatosJson> ObtenerDatosCandidatos()
        {
            
            string url = ConfigurationManager.AppSettings.Get("InfoJson");
            List<DatosJson> candidatos;
            //Address address;
            //Company company;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

            using(HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                if (response.StatusCode != HttpStatusCode.OK)
                    throw new Exception(string.Format("Server Error (HTTP {0}: {1}).", response.StatusCode, response.StatusDescription));

                using (Stream stream = response.GetResponseStream())
                using (StreamReader reader = new StreamReader(stream))
                {
                    var json = reader.ReadToEnd();
                    candidatos = JsonConvert.DeserializeObject<List<DatosJson>>(json);
                }
            }

            return candidatos;
        }        
    }
}