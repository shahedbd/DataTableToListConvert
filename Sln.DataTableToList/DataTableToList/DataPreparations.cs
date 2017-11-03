using System.Data;

namespace DataTableToList
{
    public static class DataPreparations
    {
        public static DataTable GetDataTableData()
        {
            DataTable dt = new DataTable("PersonalInfo");
            dt.Columns.Add("PersonalInfoID", typeof(long));
            dt.Columns.Add("FirstName", typeof(string));
            dt.Columns.Add("LastName", typeof(string));
            dt.Columns.Add("DateOfBirth", typeof(string));

            dt.Columns.Add("City", typeof(string));
            dt.Columns.Add("Country", typeof(string));
            dt.Columns.Add("MobileNo", typeof(string));
            dt.Columns.Add("NID", typeof(string));

            dt.Columns.Add("Email", typeof(string));
            dt.Columns.Add("Status", typeof(int));


            dt.Rows.Add(1, "Rahim", "Hossain", "12-12-1987", "Dhaka", "Bangladesh", "132465798", "7896395820741963", "e1@gmail.com", 1);
            dt.Rows.Add(2, "Hasan", "Hossain", "12-12-1987", "London", "UK", "132465798", "7896395820741963", "e2@gmail.com", 1);
            dt.Rows.Add(3, "Karim", "Hossain", "12-12-1987", "Washington", "USA", "132465798", "7896395820741963", "e3@gmail.com", 1);
            dt.Rows.Add(4, "Mehedi", "Hossain", "12-12-1987", "Dhaka", "Bangladesh", "132465798", "7896395820741963", "e4@gmail.com", 1);
            dt.Rows.Add(5, "Manik", "Hossain", "12-12-1987", "Dhaka", "Bangladesh", "132465798", "7896395820741963", "e5@gmail.com", 1);


            return dt;
        }


    }
}
