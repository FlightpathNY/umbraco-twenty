namespace UmbracoTwenty.Models
{
    public class MenuItemViewModel
    {
        public MenuItemViewModel()
        {
            Link = new Link();
        }
        public string Type { get; set; }
        public string Text { get; set; }
        public Link Link { get; set; }
    }

    public class Link
    {
        public string Name { get; set; }
        public string Url { get; set; }
    }
}