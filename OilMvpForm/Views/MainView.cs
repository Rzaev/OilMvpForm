using OilMvpForm.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OilMvpForm.Views
{
    public partial class MainView : Form,IMainView
    {
        public MainView()
        {
            InitializeComponent();
        }

        public EventHandler<EventArgs> AddButtonClicked { get; set; }
        public EventHandler<EventArgs> LoadButtonClicked { get; set ; }
        public string BenzinText { get => PetrolList.SelectedItem.ToString(); set => PetrolList.Text = value; }
        public List<Petrol> Petrols { set
            {
                listBox1.DataSource = null;
                listBox1.DataSource = value;
            }
        }
        public double PriceText { get => SetPrice(); set => SetPrice(); }
        public double ChoiceText { get => RadioSelected(); set => RadioSelected(); }
        public double TotalText { get => SetTotal(); set => SetTotal(); }
 

        private double RadioSelected()
        {
            if (LitrRadio.Checked)
                return Double.Parse(LitrChoiceTxt.Text);
            else
                return Double.Parse(MoneyChoiceTxt.Text);

        }
        
        private double SetPrice()
        {
            if (PetrolList.Text == "A-95")
            {
                PriceTxt.Text = "1.50";
                return Double.Parse(PriceTxt.Text);
            }
            else if (PetrolList.Text == "A-92")
            {
                PriceTxt.Text = "1.25";
                return Double.Parse(PriceTxt.Text);
            }
            else
            {
                PriceTxt.Text = "0.80";
               return Double.Parse(PriceTxt.Text);
            }
        }


        private double SetTotal()
        {
            if (LitrChoiceTxt.Enabled == true)
            {
                double price = Double.Parse(PriceTxt.Text);
                double litr = Double.Parse(LitrChoiceTxt.Text);
                //PetrolMoneyLbl.Text = (price * litr).ToString();
                return price * litr;
            }
            else
            {
                //double price = Double.Parse(PriceTxt.Text);
                //int money = int.Parse(MoneyChoiceTxt.Text);
                //PetrolMoneyLbl.Text = (money / price).ToString();


                //PetrolMoneyLbl.Text = MoneyChoiceTxt.Text;

                return Double.Parse(MoneyChoiceTxt.Text);
            }
        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            AddButtonClicked.Invoke(sender, e);
        }

        private void LoadBtn_Click(object sender, EventArgs e)
        {
            LoadButtonClicked.Invoke(sender, e);
        }

        private void MainView_Load(object sender, EventArgs e)
        {
            LitrChoiceTxt.Enabled = false;
            MoneyChoiceTxt.Enabled = false;
            AddBtn.Enabled = false;
            CalculatePetrol.Enabled = false;
            LitrRadio.Enabled = false;
            MoneyRadio.Enabled = false;
        }

        private void PetrolList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (PetrolList.Text == "A-95")
            {
                PriceTxt.Text = "1.50";
                Double.Parse(PriceTxt.Text);
            }
            else if (PetrolList.Text == "A-92")
            {
                PriceTxt.Text = "1.25";
                Double.Parse(PriceTxt.Text);
            }
            else
            {
                PriceTxt.Text = "0.80";
                Double.Parse(PriceTxt.Text);
            }

            LitrRadio.Enabled = true;
            MoneyRadio.Enabled = true;
        }

        private void LitrRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (LitrRadio.Checked)
            {
                MoneyChoiceTxt.Clear();
                LitrChoiceTxt.Enabled = true;
            }
            else
                LitrChoiceTxt.Enabled = false;
        }

        private void MoneyRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (MoneyRadio.Checked)
            {
                LitrChoiceTxt.Clear();
                MoneyChoiceTxt.Enabled = true;
            }
            else
                MoneyChoiceTxt.Enabled = false;
        }

        private void LitrChoiceTxt_TextChanged(object sender, EventArgs e)
        {
            if (LitrChoiceTxt.Text != string.Empty)
            {
                CalculatePetrol.Enabled = true;
                AddBtn.Enabled = true;
            }
            else
            {
                CalculatePetrol.Enabled = false;
                AddBtn.Enabled = false;
            }
        }

        private void MoneyChoiceTxt_TextChanged(object sender, EventArgs e)
        {
            if (MoneyChoiceTxt.Text != string.Empty)
            {
                CalculatePetrol.Enabled = true;
                AddBtn.Enabled = true;
            }
            else
            {
                CalculatePetrol.Enabled = false;
                AddBtn.Enabled = false;
            }
        }

        private void CalculatePetrol_Click(object sender, EventArgs e)
        {
            if (LitrChoiceTxt.Enabled == true)
            {
                double price = Double.Parse(PriceTxt.Text);
                int litr = int.Parse(LitrChoiceTxt.Text);
                PetrolMoneyLbl.Text = (price * litr).ToString();
            }
            else
            {
                //double price = Double.Parse(PriceTxt.Text);
                //int money = int.Parse(MoneyChoiceTxt.Text);
                //PetrolMoneyLbl.Text = (money / price).ToString();
                PetrolMoneyLbl.Text = MoneyChoiceTxt.Text;
            }
        }

       
    }
}
