using System;
using System.Net;
using System.Configuration; 
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Tooling.Connector;

class Program
{
    static void Main(string[] args)
    {
        try
        {
         
            string url = ConfigurationManager.AppSettings["url"];
            string appid = ConfigurationManager.AppSettings["appid"];
            string secret = ConfigurationManager.AppSettings["secret"];
    
            var conn = new CrmServiceClient($@"AuthType=ClientSecret;url={url};ClientId={appid};ClientSecret={secret}");

            if (conn.IsReady)
            {
                Entity contact = new Entity("contact");
                contact.Attributes["firstname"] = "Danilo";
                contact.Attributes["lastname"] = "Capuano";
                conn.Create(contact);
            }

        }
        catch (Exception e)
        {

        }
    }
}

