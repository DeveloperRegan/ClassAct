using ClassAct.Website.BL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClassAct.DatabaseAdder
{
    public partial class RandomlyRateResturants : Form
    {
        CPersonList oPersonList;

        public RandomlyRateResturants()
        {
            InitializeComponent();
        }

        private void RandomlyRateResturants_Load(object sender, EventArgs e)
        {
            oPersonList = new CPersonList();
            oPersonList.Load();

            cboPerson.DataSource = oPersonList;
            cboPerson.DisplayMember = "UserName";
            cboPerson.ValueMember = "PersonID";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int.TryParse(txtResturantCount.Text, out int count);
            Random Rand = new Random();
            CResturantList oREstuantList = new CResturantList();
            oREstuantList.Load();
            CResturant oResturant = new CResturant();
           int max = oREstuantList.Count - 1;
            Guid.TryParse(cboPerson.SelectedValue.ToString(), out Guid ID);

            for(int i =0; i< count; i++)
            {
                int nextIndex = Rand.Next(0, max);
                oResturant = oREstuantList[nextIndex];
                
                if(i%2==0)
                {
                    oResturant.DislikeResturant(ID);
                    listBox1.Items.Add(oResturant.ResturantName + "Was Liked");
                }
                else if(i%3==0)
                {
                    oResturant.DislikeResturant(ID);
                    listBox1.Items.Add(oResturant.ResturantName + "Was Disliked");
                }

                
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
              
                CPerson oPerson = new CPerson();
                MessageBox.Show("Created a person");
                Guid.TryParse(cboPerson.SelectedValue.ToString(), out Guid ID);
                MessageBox.Show("Guid Magic");
                oPerson.PersonID = ID;
                MessageBox.Show("Next Steam");
                CRecommendation oReccomendation = new CRecommendation(oPerson);
                MessageBox.Show("Normalized Data");
                oReccomendation.AddRecommendationsToDatabase(oPerson);

                listBox1.Items.Clear();

                oReccomendation.LoadAllRecommendations(oPerson);
                foreach (var x in oReccomendation.Recommendations)
                {
                    listBox1.Items.Add(x.ResturantName + "Was reccommended");
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
           
        }
    }
}
