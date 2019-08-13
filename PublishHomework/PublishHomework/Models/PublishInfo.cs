using System.Collections.Generic;

namespace PublishHomework.Models
{
    public class PublishInfo
    {
        public string ServerAddress { get; set; }
        public Category Categ { get; set; } = new Category();
        public IList<string> Pictures { get; } = new List<string>();
    }
}