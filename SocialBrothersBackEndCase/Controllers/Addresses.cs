using Microsoft.AspNetCore.Mvc;
using SocialBrothersBackEndCase.Models;
using System.Data;
using SocialBrothersBackEndCase.Repositories;
using SocialBrothersBackEndCase.Dtos;
using Newtonsoft.Json.Linq;

namespace SocialBrothersBackEndCase.Controllers
{

    /// <summary>
    /// PART 1 & 2 
    /// </summary>

    [ApiController]
    [Route("DataList")]
    public class Addresses : ControllerBase
    {
        //Gets addresses  
        [HttpGet("{SearchByCity}" + "   By Ascending Order")]
        public ActionResult <IEnumerable<DataList>> GetAddresses(string SearchByCity)
        {
            using (var db = new Context())
            {
                var random = InMemAddressesRepository.houseNumbers[Random.Shared.Next(InMemAddressesRepository.houseNumbers.Length)].ToString();

                var existingItem = db.List.Where(u => u.city == SearchByCity).FirstOrDefault();

                //var existingItem = db.List.OrderByDescending(u => u.city == SearchByCity);

                //var existingItem = db.List.OrderBy(e => e.city).ThenBy(e => e.city).ThenByDescending(e => e.city).FirstOrDefault();

                if(InMemAddressesRepository.cities.Contains(SearchByCity))
                {
                    return Enumerable.Range(1, 5).Select(index => new DataList
                    {
                        Id = Guid.Parse(existingItem.id),
                        house_number = existingItem.house_number,
                        street = existingItem.street,
                        zip_code = existingItem.zip_code,
                        city = existingItem.city,
                        country = "The Netherlands",
                        
                    })
           .ToArray();

                }
                else
                {
                    return NotFound();
                }
            }
        }

        //Gets one address row from the database
        [HttpGet("{id}" + "   Get one address row from the database")]

        public ActionResult<DataList> GetData(Guid id)
        {
            using (var db = new Context())
            {
                var item = db.List.Where(u => u.id == id.ToString()).FirstOrDefault();
                
                if (item is null)
                {
                    return NotFound();
                }
            }
            return CreatedAtAction(nameof(GetData), id);
        }

        //Adds random values to the database and saves
        [HttpPost]
        [Route("InsertIntoDatabase" + "   Add new addresses row and fill with records")]
        public List<InsertIntoDatabase> AddToDatabase()
        {

            var items = new List<InsertIntoDatabase>();
            
            using (var db = new Context())
            {

                db.Add(new InsertIntoDatabase
                {
                
                    id = Guid.NewGuid().ToString(),
                    street = InMemAddressesRepository.streets[Random.Shared.Next(InMemAddressesRepository.streets.Length)],
                    house_number = InMemAddressesRepository.houseNumbers[Random.Shared.Next(InMemAddressesRepository.houseNumbers.Length)],
                    zip_code = InMemAddressesRepository.zipCodes[Random.Shared.Next(InMemAddressesRepository.zipCodes.Length)],
                    city = InMemAddressesRepository.cities[Random.Shared.Next(InMemAddressesRepository.cities.Length)],
                    country = "The Netherlands"

                });

                try
                {
                    db.SaveChanges();
                }
                
                catch (Exception ex)
                {
                    Exception newEx = new Exception("Method failed.");
                    throw newEx;
                }
                
                return items;
              
            }
        }
        
        //PUT /DataList/{id}
        [HttpPut("{id}" + "   Update choosen guid id record")]
        public ActionResult UpdateItem(Guid id, UpdateItemDto itemDto)
        {
            using (var db = new Context())
            
            {
            
                var existingItem = db.List.Where(u => u.id == id.ToString()).FirstOrDefault();

                if (existingItem is null)
                {
                    return NotFound();
                }
                
                db.Add(new InsertIntoDatabase
                {
                
                    id = existingItem.id.ToString() + "----Updated----" + DateTime.Now.ToString(),
                    street = existingItem.street,
                    house_number = existingItem.house_number,
                    zip_code = existingItem.zip_code,
                    city = existingItem.city,
                    country = existingItem.country

                });
                
                db.SaveChanges();
                
                if (existingItem.country != null)
                {
                    db.Remove(existingItem);
                    db.SaveChanges();
                }
                
                else
                {
                    return NotFound();
                }
                
                return CreatedAtAction(nameof(UpdateItem), id);
            }
        }

        //DELETE/DataList/{id}
        [HttpDelete("{id}" + "   Delete entire database row record")]
        public ActionResult DeleteItem(Guid id)
        {
            using (var db = new Context())
            {
                var existingItem = db.List.Where(u => u.id == id.ToString()).FirstOrDefault();

                if (existingItem is null)
                {
                    return NotFound();
                }
                
                if (existingItem.country != null)
                {
                    db.Remove(existingItem);
                    db.SaveChanges();
                }
                
                else
                {
                    return NotFound();
                }
                
                return CreatedAtAction(nameof(DeleteItem), id);
            }
        }

        /// <summary>
        /// PART 3 distance between two addresses
        /// </summary>
        /// 
        [HttpGet(" distance in km")]

        public int getDistance(string originAddress, string destinationAddress)
        {
            System.Threading.Thread.Sleep(1000);
            int distance = 0;

            // google maps api key
            string key = " ";

            string url = "https://maps.googleapis.com/maps/api/directions/json?origin=" + originAddress + "&destination=" + destinationAddress + "&key=" + key;
            url = url.Replace(" ", "+");
            string content = fileGetContents(url);
            JObject o = JObject.Parse(content);
            
            try
            {
                distance = (int)o.SelectToken("routes[0].legs[0].distance.value");
                return distance;
            }
            catch
            {
                return distance;
            }
        }

        protected string fileGetContents(string fileName)
        {
            string sContents = string.Empty;
            string me = string.Empty;
            try
            {
                if (fileName.ToLower().IndexOf("https:") > -1)
                {
                    System.Net.WebClient wc = new System.Net.WebClient();
                    byte[] response = wc.DownloadData(fileName);
                    sContents = System.Text.Encoding.ASCII.GetString(response);
                }
                else
                {
                    System.IO.StreamReader sr = new System.IO.StreamReader(fileName);
                    sContents = sr.ReadToEnd();
                    sr.Close();
                }
            }
            catch { sContents = "unable to connect to server "; }
            return sContents;
        }



    }
}
