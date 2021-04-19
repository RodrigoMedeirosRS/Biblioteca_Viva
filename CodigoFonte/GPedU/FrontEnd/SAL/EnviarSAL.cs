using Godot;
using System;
using System.IO;
using System.Net;
using System.Text;
using System.Collections.Generic;
using DTO;
using DewCore.RestClient;
using DewCore;


namespace SAL
{
    public static class EnviarSAL
    {
        public static String Post(string url, Dictionary<string, string> values)
        {
            try
            {
                RESTRequest request = new RESTRequest(url);
                request.SetMethod(Method.POST);
                //request.AddContent("email",myMail);
                //request.AddMultipartFormData("password",myPass);
                RESTClient client = new RESTClient();
                var result = client.PerformRequest(request);
                return result.Result.ToString();
            }
            catch(Exception ex)
            {
                GD.Print(ex.Message);
                return ex.Message;
            }
            
        }
    }
}