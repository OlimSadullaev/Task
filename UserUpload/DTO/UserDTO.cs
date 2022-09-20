using CsvHelper.Configuration.Attributes;

namespace UserUpload.DTO
{
    public class UserDTO
    {
        [Name("PersonName")]
        public string PersonName { get; set; }

        [Name("Age")]
        public int Age { get; set; }

        [Name("Pet 1")]
        public string Pet_1 { get; set; }

        [Name("Pet 1 Type")]
        public string Pet_1_Type { get; set; }

        [Name("Pet 2")]
        public string Pet_2 { get; set; }

        [Name("Pet 2 Type")]
        public string Pet_2_Type { get; set; }

        [Name("Pet 3")]
        public string Pet_3 { get; set; }

        [Name("Pet 3 Type")]
        public string Pet_3_Type { get; set; }
    }
}
