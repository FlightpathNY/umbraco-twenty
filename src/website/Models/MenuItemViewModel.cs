namespace UmbracoTwenty.Models
{
    public class MenuItemViewModel
    {
        public MenuItemViewModel()
        {
            Link = new MenuLink();
        }
        public string Type { get; set; }
        public string Text { get; set; }
        public MenuLink Link { get; set; }
    }

    public class MenuLink
    {
        public string Name { get; set; }

        public string Url { get; set; }
    }
}