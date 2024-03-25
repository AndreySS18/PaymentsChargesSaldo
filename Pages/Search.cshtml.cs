using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace PaymentsCharges.Pages
{
    public class SearchModel : PageModel
    {
        DataContextDapper _dapper;
        public Months chargesList = new Months();
        public Months paymentsList = new Months();

        public int sumCharges;
        public int sumPayments;

        public int dolg;
        string _errorMessage = "";

        public string ErrorMessage { get => _errorMessage; set => _errorMessage = value; }
        public SearchModel(IConfiguration config)
        {
            _dapper = new DataContextDapper(config);
        }

        public void OnGet() { }

        public void OnPost(int? Apartment)
        {
            System.Console.WriteLine(Apartment);
            string sql = $"select * from charges WHERE ApartmentNumber = {Apartment};";

            if (_dapper.LoadDataSingle<Months>(sql) == null)
            {
                ErrorMessage = "No Data!";
                return;
            }

             string sql2 = $"select * from payments WHERE ApartmentNumber = {Apartment};";

            if (_dapper.LoadDataSingle<Months>(sql2) == null)
            {
                ErrorMessage = "No Data!";
                return;
            }

            chargesList = _dapper.LoadDataSingle<Months>(sql);
            paymentsList = _dapper.LoadDataSingle<Months>(sql2);

            sql = @"select 
      ApartmentNumber+
      January+
      February+
      March+
      April+
      May+
      June+
      July+
      August+
      September+
      October+
      November+
      December
      from charges WHERE ApartmentNumber = " + Apartment + ";";

            sumCharges = _dapper.LoadDataSingle<int>(sql);

            sql = @"select 
      ApartmentNumber+
      January+
      February+
      March+
      April+
      May+
      June+
      July+
      August+
      September+
      October+
      November+
      December
      from payments WHERE ApartmentNumber = '" + Apartment + "';";

            sumPayments = _dapper.LoadDataSingle<int>(sql);

            dolg = sumCharges - sumPayments;
        }
    }
}
