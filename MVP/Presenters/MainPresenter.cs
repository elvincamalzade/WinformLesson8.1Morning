using MVP.Data;
using MVP.Models;
using MVP.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVP.Presenters
{
    public class MainPresenter
    {
        private readonly CarContext _db;
        private IMainView _view;

        public MainPresenter(IMainView view)
        {
            _view = view;
            _view.AddButtonClicked += ViewAddButtonClicked;
            _view.LoadButtonClicked += ViewLoadButtonClicked;

            _db = new CarContext();
        }

        private void ViewLoadButtonClicked(object sender,EventArgs e)
        {
            var list = _db.Cars.ToList();

            _view.Cars = list;
            
        }

        private void ViewAddButtonClicked(object sender,EventArgs e)
        {
            Car car = new Car
            {
                Model=_view.ModelText,
                Vendor=_view.VendorText,
                Year=int.Parse(_view.YearText),
                Color=_view.ColorText,
                Transmission=_view.TransmissionText
            };
            _db.Cars.Add(car);
            _db.SaveChanges();

        }
    }
}
