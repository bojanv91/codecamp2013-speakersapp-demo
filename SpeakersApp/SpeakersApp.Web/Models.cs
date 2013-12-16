using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpeakersApp.Web
{
    public class speaker
    {
        public speaker()
        {

        }
        public speaker(string firstname, string lastname, string session, string image)
        {
            this.firstname = firstname;
            this.lastname = lastname;
            this.image = image;
            this.session = session;
        }

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string id { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string image { get; set; }
        public string session { get; set; }
    }
}

