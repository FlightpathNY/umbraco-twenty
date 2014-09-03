using System.Web;
using System.Collections.Generic;
using Zone.UmbracoMapper;

namespace UmbracoTwenty.Models
{
    public class ArticleViewModel : BaseViewModel
    {
        public ArticleViewModel()
        {
            //FeaturedImage = new Zone.UmbracoMapper.MediaFile();
            ArticleCallouts = new List<CalloutViewModel>();
        }

        [PropertyMapping(SourceProperty = "Title")]
        public string Title { get; set; }

        [PropertyMapping(SourceProperty = "Subtitle")]
        public string Subtitle { get; set; }

        //[PropertyMapping(SourceProperty = "FeaturedImage")]
        public Zone.UmbracoMapper.MediaFile FeaturedImage { get; set; }

        [PropertyMapping(SourceProperty = "Header")]
        public string Header { get; set; }

        [PropertyMapping(SourceProperty = "Body")]
        public string Body { get; set; }

        public IList<CalloutViewModel> ArticleCallouts { get; set; }
    }
}