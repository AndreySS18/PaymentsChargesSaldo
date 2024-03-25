using Microsoft.AspNetCore.Mvc.RazorPages;



namespace PaymentsCharges.Pages.Charges
{
    public class EditModel : PageModel
    {
        DataContextDapper dapper;
        public string errorMessage = "";
        public string successMessage = "";
        public Months Charge = new Months();
        public EditModel(IConfiguration config)
        {
            dapper = new DataContextDapper(config);
        }
        public void OnGet()
        {
            string? apartment = Request.Query["apartment"];

            string sql = $"Select * from charges WHERE ApartmentNumber = {apartment};";

            try
            {
                Charge = dapper.LoadDataSingle<Months>(sql);
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return;
            }
        }

        public void OnPost() 
        {
            string? apartment = Request.Query["apartment"];

            Charge.ApartmentNumber = apartment;
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

            if (Charge.ApartmentNumber.Length == 0 || Charge.January.Length == 0 || Charge.February.Length == 0 ||
                Charge.March.Length == 0 || Charge.April.Length == 0 || Charge.May.Length == 0 ||
                Charge.June.Length == 0 || Charge.July.Length == 0 || Charge.August.Length == 0 ||
                Charge.October.Length == 0 || Charge.November.Length == 0 || Charge.September.Length == 0 ||
                Charge.December.Length == 0)
            {
                errorMessage = "All the fields should be not empty";
                return;
            }

            string sql = @"UPDATE ourhome.charges SET" + 
      " January = " + Charge.January +
      ", February = " + Charge.February +
      ", March = " + Charge.March +
      ", April = " + Charge.April +
      ", May = " + Charge.May +
      ", June = " + Charge.June +
      ", July = " + Charge.July +
      ", August = " + Charge.August +
      ", September = " + Charge.September +
      ", October = " + Charge.October +
      ", November = " + Charge.November +
      ", December = " + Charge.December
      + " WHERE (ApartmentNumber = " + Charge.ApartmentNumber + ");";

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
