namespace UmbracoTwenty.Models
{
    public class CalloutViewModel
    {
        public CalloutViewModel()
        {
            Image = new Zone.UmbracoMapper.MediaFile();
            Link = new Link();
        }
        public Zone.UmbracoMapper.MediaFile Image { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public string LinkText { get; set; }
        public Link Link { get; set; }
    }
}