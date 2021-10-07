using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;

namespace API_Tests_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            PeopleResponseModel model = SendRequest();
            PeopleResponseModel expModel = CreateExpectedModel();
            Console.WriteLine(CompareModels(expModel, model));
            Console.Read();
        }

        private static bool CompareModels(PeopleResponseModel expModel, PeopleResponseModel model)
        {
            bool expectedPropertiesExist = true;
            bool actualPropertiesExist = true;
            bool propertiesFormatEquils = true;
            foreach (var prop in expModel.GetType().GetProperties())
            {
                if (model.GetType().GetProperty(prop.Name) == null)
                {
                    actualPropertiesExist = false;
                    Console.WriteLine($"Property {prop.Name} doesn't exist in actual model");
                    break;
                }
                if (model.GetType().GetProperty(prop.Name).PropertyType != prop.PropertyType) 
                {
                    propertiesFormatEquils = false;
                    Console.WriteLine($"Expected Property type is {prop.PropertyType}, but was - {model.GetType().GetProperty(prop.Name).PropertyType}");
                }
            }
            foreach (var prop in model.GetType().GetProperties())
            {
                if (expModel.GetType().GetProperty(prop.Name) == null)
                {
                    expectedPropertiesExist = false;
                    Console.WriteLine($"Property {prop.Name} doesn't exist in expected model");
                }
            }

            return expectedPropertiesExist && actualPropertiesExist && propertiesFormatEquils;
        }

        private static PeopleResponseModel CreateExpectedModel()
        {
            PeopleResponseModel model = new PeopleResponseModel()
            {
                Name = "Luke Skywalker",
                Height = "172",
                Mass = "77",
                HairColor = "blond",
                SkinColor = "fair",
                EyeColor = "blue",
                BirthYear = "19BBY",
                Gender = "male",
                Homeworld = "https://swapi.dev/api/planets/1/",
                Films = new System.Collections.Generic.List<string>()
                {
                    "https://swapi.dev/api/films/1/",
                    "https://swapi.dev/api/films/2/",
                    "https://swapi.dev/api/films/3/",
                    "https://swapi.dev/api/films/6/"
                },
                Species = new List<object>(),
                Vehicles = new List<string>(),
                Starships = new List<string>(),
                Created = DateTime.Parse("2014-12-09T13:50:51.644000Z"),
                Edited = DateTime.Parse("2014-12-20T21:17:56.891000Z"),
                Url = "https://swapi.dev/api/people/1/"
            };
            return model;
        }

        private static PeopleResponseModel SendRequest()
        {
            bool success = true;
            Uri uri = new Uri("https://swapi.dev/api/people/1");
            RestClient client = new RestClient(uri);
            RestRequest request = new RestRequest(Method.GET);
            request.AddHeader("content-type", "application/json");
            var response = client.Execute(request);
            PeopleResponseModel respModel = new PeopleResponseModel();
            try
            {
                respModel = JsonConvert.DeserializeObject<PeopleResponseModel>(response.Content);
            }
            catch (Exception) { success = false; }
            return respModel;
        }

        private static IRestResponse SendRequestUniversal(string uri, Method method, Dictionary<string, string> headers = null, object parameters = null)
        {
            RestClient client = new RestClient(uri);
            RestRequest request = new RestRequest(method);
            headers = headers == null ? new Dictionary<string, string> { { "content-type", "application/json" } } : headers;
            if (!headers.ContainsKey("content-type")) headers.Add("content-type", "application/json");
           
            foreach (var header in headers)
                request.AddHeader(header.Key, header.Value);

            //Add parameters to body.
            if (headers.ContainsValue("application/json") && request.Method != Method.GET)
            {
                request.RequestFormat = DataFormat.Json;
                request.AddJsonBody(parameters);
            }
            /* TO DO - For POST methods */

            var response = client.Execute(request);
            return response;
        }
    }
}
