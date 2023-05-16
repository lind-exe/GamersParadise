

namespace GamersParadise.DAL
{
    public static class AdminManager
    {
        private static Uri _baseAdress = new Uri("https://localhost:44342/");

        public static List<SubCategory> SubCategories { get; set; }

        public static SubCategory SubCategory { get; set; }

        // GET (READ ALL)
        public static async Task<List<SubCategory>> GetAllSubCategories()
        {
                SubCategories ??= new List<SubCategory>();
            

            using (var client = new HttpClient())
            {
                client.BaseAddress = _baseAdress;
                HttpResponseMessage response = await client.GetAsync("api/SubCategories");

                if (response.IsSuccessStatusCode)
                {
                    string responseString = await response.Content.ReadAsStringAsync();
                    SubCategories = JsonSerializer.Deserialize<List<SubCategory>>(responseString);
                }

            }
            return SubCategories;
        }

        // GET ID (READ 1)

        public static async Task<SubCategory> GetOneSubCategory(int id)
        {
            SubCategory ??= new SubCategory();

            using (var client = new HttpClient())
            {
                client.BaseAddress = _baseAdress;
                HttpResponseMessage response = await client.GetAsync("api/SubCategories/" + id);

                if (response.IsSuccessStatusCode)
                {
                    string responseString = await response.Content.ReadAsStringAsync();
                    SubCategory = JsonSerializer.Deserialize<SubCategory>(responseString);
                }

            }
            return SubCategory;
        }

        public static async Task SaveSubCategory(SubCategory existingSubCategory)
        {
            var saveSubCategory = (await GetAllSubCategories()).Where(p => p.Id == existingSubCategory.Id).FirstOrDefault();

            if (saveSubCategory != null) // PUT (UPDATE)
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = _baseAdress;
                    var json = JsonSerializer.Serialize(existingSubCategory);
                    StringContent httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
                    HttpResponseMessage response = await client.PutAsync("api/SubCategories/" + saveSubCategory.Id, httpContent);
                }
            }
            else // POST (CREATE)
            {
                SubCategories ??= await GetAllSubCategories();

                using (var client = new HttpClient())
                {
                    client.BaseAddress = _baseAdress;
                    var json = JsonSerializer.Serialize(existingSubCategory);
                    StringContent httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
                    HttpResponseMessage response = await client.PostAsync("api/SubCategories/", httpContent);
                }
            }
        }
    }
}
