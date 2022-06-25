using Project_Mehovoi_Eskiz.Core;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MyType = Project_Mehovoi_Eskiz.Core.Type;


namespace Project_Mehovoi_Eskiz
{
    /// <summary>
    /// Логика взаимодействия для GoodViewWindow.xaml
    /// </summary>
    public partial class GoodViewWindow : Window
    {
        DataBaseContext context = new DataBaseContext();
        SessionClass session = null;
        int Prod_Id;
        public GoodViewWindow()
        {
            InitializeComponent();
        }

        private void DownloadContent()
        {
            int num;
            //MessageBox.Show(Prod_Id.ToString());
            Cat_product cartProd = context.Cat_product.SqlQuery($"SELECT * FROM Cat_product WHERE Prod_ID={Prod_Id}").ToList()[0];
            Product prod = context.Products.SqlQuery($"SELECT * FROM Product WHERE Prod_ID={Prod_Id}").ToList()[0];
            Catalog catalog = context.Catalogs.SqlQuery($"SELECT * FROM Catalog WHERE Prod_ID={Prod_Id}").ToList()[0];
            ProdName.Text = cartProd.Prod_NAME;
            System.Drawing.Image image = null;
            BitmapImage bitmap = new BitmapImage();
            using (MemoryStream ms = new MemoryStream(catalog.PhotoHash))
            {
                image = System.Drawing.Image.FromStream(ms);
                // Save to the stream
                //image.Save(ms, ImageFormat.Jpeg);

                // Rewind the stream
                ms.Seek(0, SeekOrigin.Begin);

                // Tell the WPF BitmapImage to use this stream
                bitmap.BeginInit();
                bitmap.StreamSource = ms;
                bitmap.CacheOption = BitmapCacheOption.OnLoad;
                bitmap.EndInit();
            }

            
            //GoodImage.Source = new ImageSource(new Uri("C:\\Users\\qweaper\\Source\\Repos\\Mehovoi_Eskiz\\Project_Mehovoi_Eskiz\\Images\\PlaceHolder.png"), UriKind.Absolute);
            GoodImage.Source = bitmap;
            DescText.Text = cartProd.Prod_Description;
            ProdPrice.Text = prod.Price.ToString();
            ProdType.Text = ((MyType)context.Types.SqlQuery($"SELECT * FROM Type WHERE Type_Id={prod.Type_Id}").ToList()[0]).Type_Name;
            num = cartProd.Prod_left;
            if (num > 0) { NumIsAvailable.Text = num.ToString(); }
            else { NumIsAvailable.Text = "Out of stock"; }
        }
        public GoodViewWindow(string Prod_Id)
        {
            InitializeComponent();
            this.Prod_Id = int.Parse(Prod_Id);
            DownloadContent();
            
        }
        public GoodViewWindow(string Prod_Id, SessionClass sessionExample)
        {
            InitializeComponent();
            this.Prod_Id = int.Parse(Prod_Id);
            DownloadContent();
            this.session = sessionExample;
        }

        private void BuyButton_Click(object sender, RoutedEventArgs e)
        {
            Cart_pos cartPos = new Cart_pos()
            {
                quantity = int.Parse(NumIsAvailable.Text),
                UID = session.UserId,
                Prod_ID = this.Prod_Id
            };
            if (cartPos.quantity <= int.Parse(NumOfGoods.Text))
            {
                Product prod = context.Products.SqlQuery($"SELECT * FROM Product WHERE Prod_ID={Prod_Id}").ToList()[0];
                Cart cart = null;
                cart = context.Carts.SqlQuery($"SELECT * FROM Cart WHERE User_ID={session.UserId}").ToList()[0];
                if (cart != null)
                {
                    cart.Total_Price += cartPos.quantity * prod.Price;
                    cart.num_of_positions += int.Parse(NumOfGoods.Text);
                    MessageBox.Show("not null");
                    context.SaveChanges();
                }
                else
                {
                    cart = new Cart()
                    {
                        User_ID = session.UserId,
                        Total_Price = cartPos.quantity * prod.Price,
                        num_of_positions = int.Parse(NumOfGoods.Text)
                    };
                    context.Carts.Add(cart);
                    MessageBox.Show("null");
                    context.SaveChanges();
                }
            }
            else if (int.Parse(NumOfGoods.Text) == 0)
            {
                MessageBox.Show("You rty to order a zero num of product.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                MessageBox.Show("Wrong num of product you try to order.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }
    }
}
