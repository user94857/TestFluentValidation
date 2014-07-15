using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Helpers;
using System.Web.Script.Serialization;
using FVTest.FluentValidation;
using FVTest.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ConsoleClientTest
{
    class Program
    {
        static void Main(string[] args)
        {
            RunAsync().Wait();
        }

        static async Task RunAsync()
        {
            using (var client = new HttpClient())
            {
                //YOU MAY HAVE TO CHANGE THE PORT NUMBER TO GET THIS CLIENT TO WORK
                client.BaseAddress = new Uri("http://localhost:59995/");

                var _MyObject = new MyObject { Name = "Test1" };
                var _SubObject = new SubObject { Name = "Test" };
                var _EmptyNameSubObject = new SubObject { Name = "" };
                _MyObject.SubObjects = new List<SubObject> { _SubObject, _EmptyNameSubObject };

                try
                {
                    string sData = JsonConvert.SerializeObject(_MyObject);
                    Console.WriteLine();
                    Console.WriteLine("The Json We Are Sending To The Server:");
                    Console.WriteLine(sData);
                    /* 
                     * {
                           "MyObject_ID":null,
                           "MyObject_Name":"Test1",
                           "MyObject_Sub_Objects":[
                              {
                                 "SubObject_ID":null,
                                 "SubObject_Name":"Test"
                              },
                              {
                                 "SubObject_ID":null,
                                 "SubObject_Name":""
                              }
                           ]
                     *  }
                     */
                    
                    HttpResponseMessage response = await client.PostAsJsonAsync("api/myobject", _MyObject);
                    var returnData = await response.Content.ReadAsStringAsync();
                   
                    Console.WriteLine();
                    Console.WriteLine("The Json We Are Getting Back From The Server:");
                    var jsonResult = JsonConvert.DeserializeObject<Dictionary<string, dynamic>>(returnData);

                    foreach (KeyValuePair<string, dynamic> kvp in jsonResult)
                    {
                        Console.WriteLine("{0} = {1}", kvp.Key, kvp.Value);
                    }
                    Console.WriteLine();                    
                    /* {
                          "Message":"The request is invalid.",
                          "ModelState":{
                             "_MyObject.SubObjects[1].SubObject_Name":[
                                "'Sub Object_ Name' should not be empty."
                             ]
                          }
                       }
                    */
                    Console.WriteLine("Should Return    _MyObject.testing123[1].SubObject_Name");
                    Console.WriteLine("NOT              _MyObject.SubObjects[1].SubObject_Name");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                Console.ReadLine();
            }
        }
    }
}
