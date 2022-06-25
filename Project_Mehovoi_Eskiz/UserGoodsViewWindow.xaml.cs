using Project_Mehovoi_Eskiz.Core;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
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

namespace Project_Mehovoi_Eskiz
{
    /// <summary>
    /// Логика взаимодействия для UserGoodsViewWindow.xaml
    /// </summary>
    public partial class UserGoodsViewWindow : Window
    {
        private DataBaseContext context = new DataBaseContext();
        private SessionClass session = new SessionClass();

        public UserGoodsViewWindow()
        {
            InitializeComponent();
        }

        private void ShowDataInListBox()
        {
            var data = context.Cat_product.ToList();
            GoodsList.ItemsSource = data;
            Console.WriteLine(data.ToString());
        }

        private void PriceTextBox_Initialized(object sender, EventArgs e)
        {
            var PriceTextBlock = (TextBlock)sender;
            var good = PriceTextBlock.DataContext as Cat_product; 
            var price = context.Products.SqlQuery($"SELECT * FROM Product WHERE Prod_ID={good.Prod_ID}").ToArray();
            PriceTextBlock.Text = price[0].Price.ToString();
        }

        private void PhotoIm_Initialized(object sender, EventArgs e)
        {
            var PhotoIm = (Image)sender;
            var good = PhotoIm.DataContext as Cat_product;
            var image = context.Catalogs.SqlQuery($"SELECT * FROM Catalog WHERE Prod_ID={good.Prod_ID}").ToArray();
            /*PhotoIm.Source = new BitmapImage(new Uri(image[0].PhotoHyperlink.ToString(), UriKind.Relative));*/
            PhotoIm.Source = new BitmapImage(new Uri(".\\Images\\PlaceHolder.jpeg", UriKind.Relative));


        } 

        private void ArticulTextBlock_Initialized(object sender, EventArgs e)
        {
            var Articul = (TextBlock)sender;
            var good = Articul.DataContext as Cat_product;
            Articul.Text = good.Prod_Articul.ToString();
        }

        private void ProdNameTextBlock_Initialized(object sender, EventArgs e)
        {
            var ProdName = (TextBlock)sender;
            var good = ProdName.DataContext as Cat_product;
            ProdName.Text = good.Prod_NAME.ToString();
        }

       
        private void Prod_ID_Initialized(object sender, EventArgs e)
        {
            var Prod_IDTb = (TextBox)sender;
            var good = Prod_IDTb.DataContext as Cat_product;
            Prod_IDTb.Text = good.Prod_ID.ToString();
        }
        private void BuyButton_Initialized(object sender, EventArgs e)
        {
            Button buyBtn = (Button)sender;
            var good = buyBtn.DataContext as Cat_product;
            StackPanel panel = new StackPanel();
            TextBlock Id = new TextBlock() {Text=good.Prod_ID.ToString(), Visibility = Visibility.Hidden, Name="ProdId"};
            TextBlock text = new TextBlock() { Text="Подробнее" };
            panel.Children.Add(Id);
            panel.Children.Add(text);
            buyBtn.Content = panel;
        }


        private void OnSelectionChanged(Object sender, SelectionChangedEventArgs args)
        {
            var tc = sender as TabControl; //The sender is a type of TabControl...

            if (tc != null)
            {
                TabItem item = tc.SelectedItem as TabItem;
                if (item.Name == "Catalog")
                {
                    ShowDataInListBox();
                
                }
                else if (item.Name == "AccountInfo")
                {
                    ShowAccountInfo();
                }
                else if (item.Name == "Cart") 
                {
                
                }
            }
        }

        private void ShowAccountInfo()
        {
            var users = (from polzovatels in context.Polzovatels.ToList()
                         where polzovatels.User_ID == session.UserId
                         select polzovatels).ToList();
            Polzovatel user = users[0];
            GreetingText.Text = String.Format("Hello, {0} {1}!", user.UName.ToString(), user.USurname);

            List<Order> userOrders = (from orders in context.Orders.ToList()
                                     where orders.User_ID == session.UserId
                                     select orders).ToList();
            OrderPosition.ItemsSource = userOrders;
        }

        private void Catalog_Initialized(object sender, EventArgs e)
        {
            ShowDataInListBox();
        }

        private void BuyButton_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            StackPanel panel = btn.Content as StackPanel;
            TextBlock id = null;
            foreach (var item in panel.Children)
            {
                if (((TextBlock)item).Name == "ProdId") 
                {
                    id = (TextBlock)item;
                }
            } 
            GoodViewWindow window = new GoodViewWindow(id.Text, session);
            window.Owner = this;
            window.Show();
        }

        private void OrderNumTBlck_Initialized(object sender, EventArgs e)
        {
            var OrderNumTb = (TextBlock)sender;
            var order = OrderNumTb.DataContext as Order;
            OrderNumTb.Text = order.Order_Number.ToString();
        }

        private void NumOfPosTBlck_Initialized(object sender, EventArgs e)
        {
            var NumOfPosTb = (TextBlock)sender;
            var num = NumOfPosTb.DataContext as Order;
            NumOfPosTb.Text = num.num_of_positions.ToString();
        }

        private void TotalPriceTBlck_Initialized(object sender, EventArgs e)
        {
            var TotalPriceTb = (TextBlock)sender;
            var total = TotalPriceTb.DataContext as Order;
            TotalPriceTb.Text = total.Total_Price.ToString();
        }

        private void OrderDateTBlck_Initialized(object sender, EventArgs e)
        {
            var OrderDateTb = (TextBlock)sender;
            var orderDate = OrderDateTb.DataContext as Order;
            OrderDateTb.Text = orderDate.Order_date.ToString();
        }

        private void StatusTBlck_Initialized(object sender, EventArgs e)
        {
            var StatusTb = (TextBlock)sender;
            var status = context.Order_Status.SqlQuery($"SELECT * FROM Order_status WHERE Status_id={(StatusTb.DataContext as Order).Status_id}").ToList();
            StatusTb.Text = status[0].Status_Type.ToString();
        }

       
    }
}
