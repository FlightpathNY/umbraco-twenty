using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbraco.Core;
using Umbraco.Core.Persistence;
using Umbraco.Core.Persistence.DatabaseAnnotations;

namespace UmbracoTwenty.Persistence
{
    public class ContactForm
    {
        private readonly UmbracoDatabase _database;

        public ContactForm()
        {
            _database = ApplicationContext.Current.DatabaseContext.Database;
            if (!_database.TableExist("ContactForm"))
            {
                _database.CreateTable<ContactFormPoco>();
            }
        }

        public void Save(UmbracoTwenty.Models.ContactFormModel model)
        {
            ContactFormPoco poco = new ContactFormPoco();
            poco.Name = model.Name;
            poco.Email = model.Email;
            poco.Subject = model.Subject;
            poco.Message = model.Message;
            poco.Date = DateTime.Now;
            _database.Insert(poco);
        }
    }

    [TableName("ContactForm")]
    [PrimaryKey("Id")]
    [ExplicitColumns]
    public class ContactFormPoco
    {
        [Column("Id")]
        [PrimaryKeyColumn(Name = "PK_Id")]
        public int Id { get; set; }

        [Column("Date")]
        public DateTime Date { get; set; }

        [Column("Name")]
        [NullSetting(NullSetting = NullSettings.Null)]
        [SpecialDbType(SpecialDbTypes.NTEXT)]
        public string Name { get; set; }

        [Column("Email")]
        [NullSetting(NullSetting = NullSettings.Null)]
        [SpecialDbType(SpecialDbTypes.NTEXT)]
        public string Email { get; set; }

        [Column("Subject")]
        [NullSetting(NullSetting = NullSettings.Null)]
        [SpecialDbType(SpecialDbTypes.NTEXT)]
        public string Subject { get; set; }

        [Column("Message")]
        [NullSetting(NullSetting = NullSettings.Null)]
        [SpecialDbType(SpecialDbTypes.NTEXT)]
        public string Message { get; set; }
    }
}