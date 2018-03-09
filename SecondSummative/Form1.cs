///Astoria Buzek
///Pet Shop
///March 2018

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.Media;

namespace SecondSummative
{
    public partial class background : Form
    {
        //Variable Declaration

        double subtotal;
        double tax;
        double total;
        double tendered;
        double change;
        double collarAmount;
        double treatAmount;
        double toyAmount;
        const double TAX_PERCENT = 0.13;
        const double COLLAR_COST = 6.5;
        const double TREAT_COST = 4.75;
        const double TOY_COST = 1.5;
        double collarTotal;
        double treatTotal;
        double toyTotal;

        SoundPlayer player = new SoundPlayer(Properties.Resources.CatMeow);

     


        public background()
        {
            InitializeComponent();

        }

        private void receiptButton_Click(object sender, EventArgs e)
        {
            //Play Noise
            SoundPlayer player = new SoundPlayer(Properties.Resources.Printer);
            player.Play();

            //Receipt Visability
            coverLabel.Visible = false;

            //Enter Drawing Tools
            Graphics g = receiptbackgroundLabel.CreateGraphics();
            Font drawFont = new Font("Lucidia Console", 8, FontStyle.Regular);
            SolidBrush drawBrush = new SolidBrush(Color.Black);

            Refresh();

            //print reciept
            g.DrawString("Astoria's Pet Shop", drawFont, drawBrush, 105, 1);
            g.DrawString("Order Number 2733", drawFont, drawBrush, 1, 25);
            g.DrawString("March 1st, 2018", drawFont, drawBrush, 1, 45);

            g.DrawString("Collars", drawFont, drawBrush, 1, 80);
            g.DrawString(collarInput.Text, drawFont, drawBrush, 150, 80);
            g.DrawString("x", drawFont, drawBrush, 215, 80);
            g.DrawString(COLLAR_COST.ToString("C"), drawFont, drawBrush, 235, 80);
            g.DrawString("=", drawFont, drawBrush, 300, 80);
            g.DrawString(collarTotal.ToString("C"), drawFont, drawBrush, 320, 80);

            g.DrawString("Treats", drawFont, drawBrush, 1, 120);
            g.DrawString(treatsInput.Text, drawFont, drawBrush, 150, 120);
            g.DrawString("x", drawFont, drawBrush, 215, 120);
            g.DrawString(TREAT_COST.ToString("C"), drawFont, drawBrush, 235, 120);
            g.DrawString("=", drawFont, drawBrush, 300, 120);
            g.DrawString(treatTotal.ToString("C"), drawFont, drawBrush, 320, 120);

            g.DrawString("Toys", drawFont, drawBrush, 1, 160);
            g.DrawString(toysInput.Text, drawFont, drawBrush, 150, 160);
            g.DrawString("x", drawFont, drawBrush, 215, 160);
            g.DrawString(TOY_COST.ToString("C"), drawFont, drawBrush, 235, 160);
            g.DrawString("=", drawFont, drawBrush, 300, 160);
            g.DrawString(toyTotal.ToString("C"), drawFont, drawBrush, 320, 160);

            g.DrawString("Subtotal", drawFont, drawBrush, 1, 220);
            g.DrawString(subtotal.ToString("C"), drawFont, drawBrush, 320, 220);

            g.DrawString("Tax", drawFont, drawBrush, 1, 260);
            g.DrawString(tax.ToString("C"), drawFont, drawBrush, 320, 260);

            g.DrawString("Total", drawFont, drawBrush, 1, 300);
            g.DrawString(total.ToString("C"), drawFont, drawBrush, 320, 300);

            g.DrawString("Tendered", drawFont, drawBrush, 1, 360);
            g.DrawString(tendered.ToString("C"), drawFont, drawBrush, 320, 360);

            g.DrawString("Change", drawFont, drawBrush, 1, 400);
            g.DrawString(change.ToString("C"), drawFont, drawBrush, 320, 400);

            g.DrawString("Have a nice day!", drawFont, drawBrush, 105, 470);
            g.DrawString("Telephone (123) 456-7890", drawFont, drawBrush, 70, 500);


        }


        private void itemsButton_Click(object sender, EventArgs e)
        {
            try
            {
                //Play Noise
                player.Play();

                //Variable Assignment

                collarAmount = Convert.ToInt16(collarInput.Text);
                treatAmount = Convert.ToInt16(treatsInput.Text);
                toyAmount = Convert.ToInt16(toysInput.Text);

                subtotal = collarAmount * COLLAR_COST + treatAmount * TREAT_COST + toyAmount * TOY_COST;
                tax = subtotal * TAX_PERCENT;
                total = subtotal + tax;
                collarTotal = collarAmount * COLLAR_COST;
                treatTotal = treatAmount * TREAT_COST;
                toyTotal = toyAmount * TOY_COST;

                stLabel.Text = subtotal.ToString("C");
                txLabel.Text = tax.ToString("C");
                ttlabel.Text = total.ToString("C");
            }

            catch

            {
                //Mistake
                warningLabel.Text = "Inputs Must be Numeric!!";
            }


            

        }

        private void changeButton_Click(object sender, EventArgs e)
        {
            try
            {
                //Play Noise
                player.Play();

                //Tendered and Change 
                tendered = Convert.ToDouble(tenderedInput.Text);
                change = tendered - total;
                chLabel.Text = change.ToString("C");
            }
            catch
            {
                //Mistake
                warningLabel.Text = "Inputs Must be Numeric!!";
            }
        }

        private void neworderButton_Click(object sender, EventArgs e)
        {
            //Play Noise
            player.Play();

            //Clear Screen
            collarInput.Clear();
            treatsInput.Clear();
            toysInput.Clear();
            tenderedInput.Clear();

            stLabel.Text = "";
            txLabel.Text = "";
            ttlabel.Text = "";
            chLabel.Text = "";

            subtotal = 0;
            tax = 0;
            total = 0;
            tendered = 0;
            change = 0;
            collarAmount = 0;
            treatAmount = 0;
            toyAmount = 0;
            collarTotal = 0;
            treatTotal = 0;
            toyTotal = 0;

            coverLabel.Visible = true;

        }
    }
}
