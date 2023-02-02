using SocialBrothersBackEndCase.Models;


namespace SocialBrothersBackEndCase.Repositories
{
    public class InMemAddressesRepository : ItemsRepository
    {
        public static readonly string[] streets = new[]
    {
        "Clearance Row", "Oval Way", "Princess Boulevard", "Brown Boulevard", "Park Avenue", "Crescent Avenue", "Parkview Avenue", "Sunshine Avenue", "Oceanview Street", "Willow Boulevard"
    };
        public static readonly string[] houseNumbers = new[]
    {
        "32", "24", "2", "6", "72", "102", "50", "100", "80", "96"
    };
        public static readonly string[] zipCodes = new[]
    {
        "6257", "25746er", "5428bf", "27857eq", "55654bf", "2542", "5427be", "24587", "25472re", "25752"
    };
        public static readonly string[] cities = new[]
    {
        "Leeuwarden", "Amsterdam", "Utrecht", "Groningen", "Rotterdam", "Lelystad"
    };
        private readonly List<DataList> items = new()
        {
            new DataList
            {
                Id = Guid.NewGuid(), 
                street =streets[Random.Shared.Next(streets.Length)],
                house_number = houseNumbers[Random.Shared.Next(houseNumbers.Length)],
                zip_code = zipCodes[Random.Shared.Next(zipCodes.Length)],
                city = cities[Random.Shared.Next(cities.Length)],
                country = "The Netherlands"
             }
         };

        public IEnumerable<DataList> GetDataLists()
        { 
            return items; 
        }
        public void GetDataList(DataList item)
        {
            var index = items.FindIndex(existingItem => existingItem.Id == item.Id);
            items[index] = item;
        }
    

        public void createItem(DataList item)
        {
            items.Add(item);
        }

        public void UpdateItem(DataList item)
        {
                 var index = items.FindIndex(existingItem => existingItem.Id == item.Id);
                items[index] = item;
        }

        public void DeleteItem(Guid id)
        {
            var index = items.FindIndex(existingItem => existingItem.Id == id);
            items.RemoveAt(index);
        }
    }
    
 }

