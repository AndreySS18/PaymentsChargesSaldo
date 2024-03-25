using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace PaymentsCharges.Pages
{
    public class HomePageModel : PageModel
    {
        DataContextDapper _dapper;
        public HomePageModel(IConfiguration config)
        {
            _dapper = new DataContextDapper(config);
        }
        public IEnumerable<Months> chargesList;
        public IEnumerable<Months> PaymentsList;
        public void OnGet()
        {
            try
            {
                string sql = @"select * from charges";
                chargesList = _dapper.LoadData<Months>(sql);
                sql = @"select * from payments";
                PaymentsList = _dapper.LoadData<Months>(sql);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.ToString);
            }
        }
    }
}
