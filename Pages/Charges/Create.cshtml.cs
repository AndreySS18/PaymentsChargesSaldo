using System.Globalization;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace PaymentsCharges.Pages.Charges
{
    public class AddModel : PageModel
    {
        public Months Charge = new Months();
        public string errorMessage = "";
        public string successMessage = "";
        DataContextDapper _dapper;
        public AddModel(IConfiguration config)
        {
            _dapper = new DataContextDapper(config);
        }
        public void OnGet()
        {
        }
        public void OnPost() 
        {
            Charge.ApartmentNumber = Request.Form["Number"];
            Charge.January = Request.Form["January"];
            Charge.February = Request.Form["February"];
            Charge.March = Request.Form["March"];
            Charge.April = Request.Form["April"];
            Charge.May = Request.Form["May"];
            Charge.June = Request.Form["June"];
            Charge.July = Request.Form["July"];
            Charge.August = Request.Form["August"];
            Charge.September = Request.Form["September"];
            Charge.October = Request.Form["October"];
            Charge.November = Request.Form["November"];
            Charge.December = Request.Form["December"];

            string sql = @"INSERT INTO ourhome.charges (
      ApartmentNumber,
      January,
      February,
      March,
      April,
      May,
      June,
      July,
      August,
      September,
      October,
      November,
      December
      ) VALUES (" +
        Charge.ApartmentNumber + "," +
        Charge.January + "," +
        Charge.February + "," +
        Charge.March + "," +
        Charge.April + "," +
        Charge.May + "," +
        Charge.June + "," +
        Charge.July + "," +
        Charge.August + "," +
        Charge.September + "," +
        Charge.October + "," +
        Charge.November + "," +
        Charge.December
      + ");";

            if (Charge.ApartmentNumber.Length == 0 || Charge.January.Length == 0 || Charge.February.Length == 0 ||
                Charge.March.Length == 0 || Charge.April.Length == 0 || Charge.May.Length == 0 ||
                Charge.June.Length == 0 || Charge.July.Length == 0 || Charge.August.Length == 0 ||
                Charge.October.Length == 0 || Charge.November.Length == 0 || Charge.September.Length == 0 ||
                Charge.December.Length == 0)
            {
                errorMessage = "All the fields should be not empty";
                return;
            }

            try
            {
                _dapper.ExecuteSql(sql);
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return;
            }

            Charge.ApartmentNumber = "";  Charge.January = ""; Charge.February = "";
            Charge.March = ""; Charge.April = ""; Charge.May = "";
            Charge.June = ""; Charge.July = ""; Charge.August = "";
            Charge.October = ""; Charge.November = ""; Charge.September = "";
            Charge.December = "";
            successMessage = "New Charge Added Correctly";

            Response.Redirect("/HomePage");
        }
    }
}
