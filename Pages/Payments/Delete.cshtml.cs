using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace PaymentsCharges.Pages.Payments
{
    public class DeleteModel : PageModel
    {
        DataContextDapper dapper;

        public DeleteModel(IConfiguration config)
        {
            dapper = new DataContextDapper(config);
        }
        public void OnGet()
        {
            string apartment = Request.Query["apartment1"];

            string sql = $"DELETE FROM payments WHERE ApartmentNumber = {apartment};";
            Console.WriteLine(sql);

            if (!dapper.ExecuteSql(sql))
            {
                throw new Exception("Not deleted!");
            }

            Response.Redirect("/HomePage");
        }
    }
}
