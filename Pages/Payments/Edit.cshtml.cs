using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace PaymentsCharges.Pages.Payments
{
    public class EditModel : PageModel
    {
        DataContextDapper dapper;
        public string errorMessage = "";
        public string successMessage = "";
        public Months Payment = new Months();
        public EditModel(IConfiguration config)
        {
            dapper = new DataContextDapper(config);
        }
        public void OnGet()
        {
            string? apartment = Request.Query["apartment1"];

            string sql = $"Select * from payments WHERE ApartmentNumber = {apartment};";

            try
            {
                Payment = dapper.LoadDataSingle<Months>(sql);
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return;
            }
        }

        public void OnPost()
        {
            string? apartment = Request.Query["apartment1"];

            Payment.ApartmentNumber = apartment;
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

            if (Payment.ApartmentNumber.Length == 0 || Payment.January.Length == 0 || Payment.February.Length == 0 ||
                Payment.March.Length == 0 || Payment.April.Length == 0 || Payment.May.Length == 0 ||
                Payment.June.Length == 0 || Payment.July.Length == 0 || Payment.August.Length == 0 ||
                Payment.October.Length == 0 || Payment.November.Length == 0 || Payment.September.Length == 0 ||
                Payment.December.Length == 0)
            {
                errorMessage = "All the fields should be not empty";
                return;
            }

            string sql = @"UPDATE ourhome.payments SET" +
      " January = " + Payment.January +
      ", February = " + Payment.February +
      ", March = " + Payment.March +
      ", April = " + Payment.April +
      ", May = " + Payment.May +
      ", June = " + Payment.June +
      ", July = " + Payment.July +
      ", August = " + Payment.August +
      ", September = " + Payment.September +
      ", October = " + Payment.October +
      ", November = " + Payment.November +
      ", December = " + Payment.December
      + " WHERE (ApartmentNumber = " + Payment.ApartmentNumber + ");";

            try
            {
                dapper.ExecuteSql(sql);
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return;
            }

            successMessage = "Успешно изменено!";

            Response.Redirect("/HomePage");
        }
    }
}
