﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class CoronaController : ApiController
    {
        // GET: api/Corona
        public List<Datum> Get()
        {
            CoronaOperations coop = new CoronaOperations();
            return coop.GetTheRecords("SELECT * FROM theStats");
        }

        // GET: api/Corona
        public List<Datum> Get(string country)
        {
            CoronaOperations coop = new CoronaOperations();
            return coop.GetTheRecords(string.Format("SELECT * FROM theStats WHERE countrycode = '{0}'", country));
        }

        // GET: api/Corona/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Corona
        public HttpResponseMessage Post(Datum newDatum)
        {
            string query = "INSERT INTO theStats (countrycode, date, cases, deaths, recovered)";
            query += " VALUES ('{0}', '{1}', '{2}', '{3}', '{4}')";
            CoronaOperations coop = new CoronaOperations();
            if (coop.PutTheRecord(string.Format(query, newDatum.countrycode, newDatum.date, newDatum.cases, newDatum.deaths, newDatum.recovered))){
                return new HttpResponseMessage(HttpStatusCode.Created);
            } else
            return new HttpResponseMessage(HttpStatusCode.Conflict);
        }

        // PUT: api/Corona/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Corona/5
        public void Delete(int id)
        {
        }
    }
}
