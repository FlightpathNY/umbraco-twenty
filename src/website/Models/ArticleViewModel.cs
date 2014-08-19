using System.Web;
using Zone.UmbracoMapper;

namespace UmbracoTwenty.Models
{
    public class ArticleViewModel : BaseViewModel
    {
        [PropertyMapping(SourceProperty = "Title")]
        public string Title { get; set; }

        [PropertyMapping(SourceProperty = "Subtitle")]
        public string Subtitle { get; set; }

        [PropertyMapping(SourceProperty = "FeaturedImage")]
        public string FeaturedImage { get; set; }

        [PropertyMapping(SourceProperty = "Header")]
        public string Header { get; set; }

        [PropertyMapping(SourceProperty = "Body")]
        public string Body { get; set; }

    }
}