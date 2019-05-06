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
         
            string username = ConfigurationManager.AppSettings["username"];
            string password = ConfigurationManager.AppSettings["password"];
            string crmurl = ConfigurationManager.AppSettings["crmurl"];

            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            CrmServiceClient conn = new CrmServiceClient("authtype=Office365;Url=" + crmurl + "; Username=" + username + "; Password=" + password);
            IOrganizationService service = conn.OrganizationServiceProxy;

            Entity contact = new Entity("contact");
            contact["fullname"] = "Danilo Capuano";
            contact["firstname"] = "Danilo";
            contact["lastname"] = "Capuano";

            service.Create(contact);

        }
        catch (Exception e)
        {

        }
    }
}

