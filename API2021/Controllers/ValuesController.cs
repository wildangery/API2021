using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace API2021.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        
        [HttpGet]
        public string Get()
        {
            DataSet ds = Wilayah.GetWilayah();
            string Json = JsonConvert.SerializeObject(ds, Formatting.Indented);

            return Json;
        }

        [HttpGet]
        public string GetRack()
        {
            string query = "SELECT b.tanggal, w.id_ruangan, b.id_rak, w.nama_ruangan, b.nama_rak, b.qr_rak FROM as_rak b join as_ruangan w on b.id_ruangan=w.id_ruangan ";
            DataSet ds = Settings.LoadDataSet(query);
            string json = JsonConvert.SerializeObject(ds, Formatting.Indented);

            return json;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public string PostTest([FromBody] string value)
        {
            try
            {
                Ruangan oWilayah = JsonConvert.DeserializeObject<Ruangan>(value);

                string insertdata = $"INSERT INTO as_wilayah (nama_wilayah, tanggal) values ('{oWilayah.nama_wilayah}','{oWilayah.tanggal}');";
                string a = Settings.ExsecuteSql(insertdata);
                return a;
                //return value;
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
 
        }

        [HttpPost]
        public string UpdateTest([FromBody] string value)
        {
            try
            {
                Wilayah uWilayah = JsonConvert.DeserializeObject<Wilayah>(value);

                string updatedata = $"Update as_wilayah SET nama_wilayah='{uWilayah.nama_wilayah}' where id_wilayah='{uWilayah.id_wilayah}'";
                string a = Settings.ExsecuteSql(updatedata);
                return a;
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
        }

        [HttpPost]
        public string DeleteTest([FromBody] string value)
        {
            try
            {
                Wilayah dWilayah = JsonConvert.DeserializeObject<Wilayah>(value);

                string deletedata = $"Delete as_wilayah where id_wilayah='{dWilayah.id_wilayah}'";
                string a = Settings.ExsecuteSql(deletedata);
                return a;
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
