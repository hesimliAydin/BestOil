namespace BestOil
{
    public partial class Form1 : Form
    {
        public double CafeTotal { get; set; }
        public Form1()
        {
            InitializeComponent();

            CafeTotal = Convert.ToDouble(cafeTotalTxtB.Text);

            oilPriceTxtB.TextChanged += OilPriceTxtB_TextChanged;
            oilLitrTxtB.TextChanged += OilLitrTxtB_TextChanged;

            comboBox1.SelectedIndexChanged += OilLitrTxtB_TextChanged;
        }

        private void OilLitrTxtB_TextChanged(object? sender, EventArgs e)
        {
            try
            {
            oilTotalPriceTxtB.Text=(Convert.ToDouble(currentPriceTxtb.Text)*Convert.ToDouble(oilLitrTxtB.Text)).ToString();

            oilPriceTxtB.Text = oilTotalPriceTxtB.Text;
            }
            catch { }
        }

        private void OilPriceTxtB_TextChanged(object? sender, EventArgs e)
        {
            try
            {

            oilTotalPriceTxtB.Text = oilPriceTxtB.Text;

            oilLitrTxtB.Text= (Convert.ToDouble(oilPriceTxtB.Text)/ Convert.ToDouble(currentPriceTxtb.Text)).ToString();
            }
            catch { }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var oil = comboBox1.SelectedItem as Fuel;
            currentPriceTxtb.Text = oil.Price.ToString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            List<Fuel> FuelType = new List<Fuel>()
            {
                new("AI-92",1),
                new("AI-95",2),
                new("AI-98",2.3),
                new("Diesel",0.8),
                new("LPG",0.65),
                new("CNG",0.45)
            };
            comboBox1.DisplayMember = nameof(Fuel.Name);
            comboBox1.Items.AddRange(FuelType.ToArray());
            comboBox1.SelectedIndex = 0;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            oilPriceTxtB.Enabled = true;
            oilLitrTxtB.Enabled = false;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            oilPriceTxtB.Enabled=false;
            oilLitrTxtB.Enabled=true;
        }

        private void hotCountTextB_TextChanged(object sender, EventArgs e)
        {
            double total = 0;
            try
            {
                 total = Convert.ToDouble(hotPriceTxtB.Text) * Convert.ToDouble(hotCountTextB.Text);
            }
            catch { }
                if (hotCountTextB.Text.Trim() == String.Empty)
                {
                    total = 0;
                }
                CafeTotal = total;
                cafeTotalTxtB.Text = CafeTotal.ToString();

             
            
        }

        private void hotCheckB_CheckedChanged(object sender, EventArgs e)
        {
            hotCountTextB.Enabled = !hotCountTextB.Enabled;
        }

        private void gamCountTextB_TextChanged(object sender, EventArgs e)
        {
            double total = 0;
            try
            {
                 total = Convert.ToDouble(GamPriceTxtB.Text) * Convert.ToDouble(gamCountTextB.Text);
            }
            catch 
            {

                
            }
                if (gamCountTextB.Text.Trim() == String.Empty)
                {
                    total = 0;
                }
                CafeTotal += total;
                cafeTotalTxtB.Text = CafeTotal.ToString();
            
            
        }

        private void gamCheckB_CheckedChanged(object sender, EventArgs e)
        {
            gamCountTextB.Enabled = !gamCountTextB.Enabled;
        }

        private void kartofCountTextB_TextChanged(object sender, EventArgs e)
        {
            try
            {
                var total = Convert.ToDouble(KartofPrizeTxtB) * Convert.ToDouble(KartofPrizeTxtB.Text);
                if (kartofCountTextB.Text.Trim()==String.Empty)
                {
                    cafeTotalTxtB.Text = String.Empty;
                }
                else
                cafeTotalTxtB.Text = total.ToString();
            }
            catch { }
            
        }

        private void kartofCheckB_CheckedChanged(object sender, EventArgs e)
        {
            kartofCountTextB.Enabled = !kartofCountTextB.Enabled;
        }

        private void ColaCountTextB_TextChanged(object sender, EventArgs e)
        {
            try
            {
                var total = Convert.ToDouble(ColaPrizeTxtB) * Convert.ToDouble(ColaPrizeTxtB.Text);
                if (ColaCountTextB.Text.Trim()==String.Empty)
                {
                    cafeTotalTxtB.Text = String.Empty;
                }
                else
                cafeTotalTxtB.Text = total.ToString();
            }
            catch { }
        }

        private void colaCheckB_CheckedChanged(object sender, EventArgs e)
        {
            colaCheckB.Enabled = !colaCheckB.Enabled;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var total=Convert.ToDouble(oilTotalPriceTxtB.Text)+Convert.ToDouble(cafeTotalTxtB.Text);
            paymentGroupB.Text = total.ToString();
        }
        
    }
}