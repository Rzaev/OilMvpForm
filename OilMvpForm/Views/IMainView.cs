using OilMvpForm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OilMvpForm.Views
{
    public interface IMainView
    {
        EventHandler<EventArgs> AddButtonClicked { get; set; }
        EventHandler<EventArgs> LoadButtonClicked { get; set; }



        string BenzinText { get; set; }
        List<Petrol> Petrols {set; }
        double PriceText { get; set; }
        double ChoiceText { get; set; }
        double TotalText { get; set; }
    }
}
