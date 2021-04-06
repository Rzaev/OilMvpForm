using OilMvpForm.Data;
using OilMvpForm.Models;
using OilMvpForm.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OilMvpForm.Presenters
{
    public class MainPresenter
    {
        private readonly PetrolContext _db;

        private IMainView _view;

        public MainPresenter(IMainView view)
        {
            _view = view;
            _view.AddButtonClicked += ViewAddButtonClick;
            _view.LoadButtonClicked += ViewLoadButtonClick;

            _db = new PetrolContext();

        }

        private void ViewAddButtonClick(object sender,EventArgs e)
        {
            Petrol petrol = new Petrol()
            { 
              Benzin=_view.BenzinText,
              Price=_view.PriceText,
              Choice=_view.ChoiceText,
              Total=_view.TotalText
            };


            //Petrols yaratdigimiz DbSetdir
            _db.Petrols.Add(petrol);
            _db.SaveChanges();
        }

        private void ViewLoadButtonClick(object sender,EventArgs e)
        {
            var list = _db.Petrols.ToList();

            //Get-ini yazmadigimiz List-dir
            _view.Petrols = list;
        }

    }
}
