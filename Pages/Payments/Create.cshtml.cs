using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace PaymentsCharges.Pages.Payments
{
    public class CreateModel : PageModel
    {
        public Months Payment = new Months();
        public string errorMessage = "";
        public string successMessage = "";
        DataContextDapper _dapper;
        public CreateModel(IConfiguration config)
        {
            _dapper = new DataContextDapper(config);
        }
        public void OnGet()
        {
        }
        public void OnPost()
        {
            Payment.ApartmentNumber = Request.Form["Number"];
            Payment.January = Request.Form["January"];
            Payment.February = Request.Form["February"];
            Payment.March = Request.Form["March"];
            Payment.April = Request.Form["April"];
            Payment.May = Request.Form["May"];
            Payment.June = Request.Form["June"];
            Payment.July = Request.Form["July"];
            Payment.August = Request.Form["August"];
            Payment.September = Request.Form["September"];
            Payment.October = Request.Form["October"];
            Payment.November = Request.Form["November"];
            Payment.December = Request.Form["December"];

            string sql = @"INSERT INTO ourhome.payments (
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
        Payment.ApartmentNumber + "," +
        Payment.January + "," +
        Payment.February + "," +
        Payment.March + "," +
        Payment.April + "," +
        Payment.May + "," +
        Payment.June + "," +
        Payment.July + "," +
        Payment.August + "," +
        Payment.September + "," +
        Payment.October + "," +
        Payment.November + "," +
        Payment.December
      + ");";

            if (Payment.ApartmentNumber.Length == 0 || Payment.January.Length == 0 || Payment.February.Length == 0 ||
                Payment.March.Length == 0 || Payment.April.Length == 0 || Payment.May.Length == 0 ||
                Payment.June.Length == 0 || Payment.July.Length == 0 || Payment.August.Length == 0 ||
                Payment.October.Length == 0 || Payment.November.Length == 0 || Payment.September.Length == 0 ||
                Payment.December.Length == 0)
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

            Payment.ApartmentNumber = ""; Payment.January = ""; Payment.February = "";
            Payment.March = ""; Payment.April = ""; Payment.May = "";
            Payment.June = ""; Payment.July = ""; Payment.August = "";
            Payment.October = ""; Payment.November = ""; Payment.September = "";
            Payment.December = "";
            successMessage = "New Payment Added Correctly";

            Response.Redirect("/HomePage");
        }
    }
}
