﻿namespace GamersParadise.Models
{
    public class MainCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<SubCategory> SubCategories { get; set; }
    }
}
