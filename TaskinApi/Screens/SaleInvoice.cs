using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TaskinApi.DAL;

namespace TaskinApi.Screens
{
    public partial class SaleInvoice : Form
    {
        public SaleInvoice()
        {
            InitializeComponent();
        }
        private PictureBox Pic;
        private Label price = new Label();

        private Label description = new Label();
        
        private void SaleInvoice_Load(object sender, EventArgs e)
        {
            Getcategory();
        }

        private async void Getcategory()
        {
            var res = await Helper.GetAll();
            var result = JsonConvert.DeserializeObject<List<Touches>>(res);
            foreach (var item in result)
            {
                Pic = new PictureBox();
                Pic.Width = 124;
                Pic.Height = 90;
                Pic.BackColor = Color.WhiteSmoke;
                Pic.BackgroundImageLayout = ImageLayout.Stretch;
                Pic.BorderStyle = BorderStyle.FixedSingle;

                description = new Label();
                description.Text = item.description;
                description.BackColor = Color.FromArgb(150, 0, 0, 0);
                description.ForeColor = Color.WhiteSmoke;
                description.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

                description.TextAlign = ContentAlignment.MiddleCenter;
                description.Dock = DockStyle.Top;
                Pic.Tag = item.Id;



                MemoryStream ms = new MemoryStream(item.pic);
                Bitmap bitmap = new Bitmap(ms);
                Pic.BackgroundImage = bitmap;
                Pic.Controls.Add(price);
                Pic.Controls.Add(description);
                flowLayoutPanel1.Controls.Add(Pic);
                Pic.Click += new EventHandler(OnClick2);
               

                async void OnClick2(object? sender, EventArgs e)
                {
                    lblcategory.Text = item.description;
                    var res1 = await Helper.GetbyId(item.ListTypeId);
                    //int id = Convert.ToInt32(item.ListTypeId.ToString());
                    var result1 = JsonConvert.DeserializeObject<List<Products>>(res1);
                    flowLayoutPanel2.Controls.Clear();
                    flowLayoutPanel2.SuspendLayout();
                    foreach (var item in result1)
                    {
                        
                        Pic = new PictureBox();
                        Pic.Width = 124;
                        Pic.Height = 140;
                        Pic.BackColor = Color.WhiteSmoke;
                        Pic.BackgroundImageLayout = ImageLayout.Stretch;
                        Pic.BorderStyle = BorderStyle.FixedSingle;

                        description = new Label();
                        description.Text = item.PName;
                        description.BackColor = Color.FromArgb(150, 0, 0, 0);
                        description.ForeColor = Color.WhiteSmoke;
                        description.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

                        description.TextAlign = ContentAlignment.MiddleCenter;
                        description.Dock = DockStyle.Bottom;
                        Pic.Tag = item.ProductId;



                        MemoryStream ms = new MemoryStream(item.Picture);
                        Bitmap bitmap = new Bitmap(ms);
                        Pic.BackgroundImage = bitmap;
                        Pic.Controls.Add(price);
                        Pic.Controls.Add(description);
                        flowLayoutPanel2.Controls.Add(Pic);
                        
                        

                    }
                    flowLayoutPanel2.ResumeLayout();

                }
            }
        }

       

        private void btnscrollright_Click(object sender, EventArgs e)
        {
            flowLayoutPanel1.AutoScrollPosition = new Point(flowLayoutPanel1.HorizontalScroll.Value + flowLayoutPanel1.HorizontalScroll.SmallChange * 120, 0);
        }

        private void btnscrollleft_Click(object sender, EventArgs e)
        {
            flowLayoutPanel1.AutoScrollPosition = new Point(flowLayoutPanel1.HorizontalScroll.Value - flowLayoutPanel1.HorizontalScroll.SmallChange * 120, 0);
        }
    }
}
