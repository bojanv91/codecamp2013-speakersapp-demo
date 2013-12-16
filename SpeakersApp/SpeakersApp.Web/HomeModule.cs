using MongoDB.Driver;
using MongoDB.Driver.Linq;
using Nancy;
using Nancy.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpeakersApp.Web
{
    public class HomeModule : NancyModule
    {
        public HomeModule()
        {
            string conn = "mongodb://localhost/?safe=true";
            MongoServer server = MongoServer.Create(conn);
            MongoDatabase db = server.GetDatabase("speakersdb");
            MongoCollection speakersCollection 
                = db.GetCollection<speaker>("speakers");

            Get["/api"] = p =>
            {
                return "Hello CodeCampers!";
            };

            Get["/api/speakers"] = p =>
            {
                IList<speaker> speakers = speakersCollection.AsQueryable<speaker>().ToList();
                return speakers;
            };

            Post["/api/speakers/"] = p =>
            {
                speaker speaker = this.Bind<speaker>();
                speakersCollection.Insert<speaker>(speaker);
                return speaker;
            };
        }

    }

}


