using Project_Mehovoi_Eskiz.Core;
using System;
using System.Collections.Generic;
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
using MyType = Project_Mehovoi_Eskiz.Core.Type;

namespace Project_Mehovoi_Eskiz
{
    /// <summary>
    /// Логика взаимодействия для DBWorkingWindow.xaml
    /// </summary>
    public partial class DBWorkingWindow : Window
    {
        private DataBaseContext context = new DataBaseContext();
        bool deletFlag = false;
        public DBWorkingWindow()
        {
            InitializeComponent();
        }
        private void ReadDataFromTableByORM(string TableName)
        {
            using (DataBaseContext context = new DataBaseContext())
            {
                if (TableName == "Cart")
                {
                    DBDataGrid.ItemsSource = context.Carts.ToList();
                }
                else if (TableName == "accessiries")
                {
                    DBDataGrid.ItemsSource = context.accessories.ToList();
                }
                else if (TableName == "Cat_product")
                {
                    DBDataGrid.ItemsSource = context.Cat_product.ToList();
                }
                else if (TableName == "Catalogs")
                {
                    DBDataGrid.ItemsSource = context.Catalogs.ToList();
                }
                else if (TableName == "Customs")
                {
                    DBDataGrid.ItemsSource = context.Customs.ToList();
                }
                else if (TableName == "Default_Size")
                {
                    DBDataGrid.ItemsSource = context.Default_Size.ToList();
                }
                else if (TableName == "furriery_n_fabrics")
                {
                    DBDataGrid.ItemsSource = context.furriery_n_fabrics.ToList();
                }
                else if (TableName == "Materials")
                {
                    DBDataGrid.ItemsSource = context.Materials.ToList();
                }
                else if (TableName == "Messages")
                {
                    DBDataGrid.ItemsSource = context.Messages.ToList();
                }
                else if (TableName == "Order_Position")
                {
                    DBDataGrid.ItemsSource = context.Order_Position.ToList();
                }
                else if (TableName == "Order_Status")
                {
                    DBDataGrid.ItemsSource = context.Order_Status.ToList();
                }
                else if (TableName == "Orders")
                {
                    DBDataGrid.ItemsSource = context.Orders.ToList();

                }
                else if (TableName == "Polzovatel")
                {
                    DBDataGrid.ItemsSource = context.Polzovatels.ToList();
                }
                else if (TableName == "Products")
                {
                    DBDataGrid.ItemsSource = context.Products.ToList();
                }
                else if (TableName == "Types")
                {
                    DBDataGrid.ItemsSource = context.Types.ToList();
                }
                else if (TableName == "Cart_pos")
                {
                    DBDataGrid.ItemsSource = context.Cart_pos.ToList();
                }
                else if (TableName == "Payed_Orders")
                {
                    DBDataGrid.ItemsSource = context.Payed_Orders.ToList();
                }

            }
        }

        private void FilterDataBySQL(string SqlExpression) 
        {
            using (DataBaseContext context = new DataBaseContext())
            {
                string TableName = TablesList.SelectedItem.ToString();
                if (TableName == "Cart")
                {
                    DBDataGrid.ItemsSource = context.Carts.SqlQuery(SqlExpression).ToList();
                }
                else if (TableName == "accessiries")
                {
                    DBDataGrid.ItemsSource = context.accessories.SqlQuery(SqlExpression).ToList();
                }
                else if (TableName == "Cat_product")
                {
                    DBDataGrid.ItemsSource = context.Cat_product.SqlQuery(SqlExpression).ToList();
                }
                else if (TableName == "Catalogs")
                {
                    DBDataGrid.ItemsSource = context.Catalogs.SqlQuery(SqlExpression).ToList();
                }
                else if (TableName == "Customs")
                {
                    DBDataGrid.ItemsSource = context.Customs.SqlQuery(SqlExpression).ToList();
                }
                else if (TableName == "Default_Size")
                {
                    DBDataGrid.ItemsSource = context.Default_Size.SqlQuery(SqlExpression).ToList();
                }
                else if (TableName == "furriery_n_fabrics")
                {
                    DBDataGrid.ItemsSource = context.furriery_n_fabrics.SqlQuery(SqlExpression).ToList();
                }
                else if (TableName == "Materials")
                {
                    DBDataGrid.ItemsSource = context.Materials.SqlQuery(SqlExpression).ToList();
                }
                else if (TableName == "Messages")
                {
                    DBDataGrid.ItemsSource = context.Messages.SqlQuery(SqlExpression).ToList();
                }
                else if (TableName == "Order_Position")
                {
                    DBDataGrid.ItemsSource = context.Order_Position.SqlQuery(SqlExpression).ToList();
                }
                else if (TableName == "Order_Status")
                {
                    DBDataGrid.ItemsSource = context.Order_Status.SqlQuery(SqlExpression).ToList();
                }
                else if (TableName == "Orders")
                {
                    DBDataGrid.ItemsSource = context.Orders.SqlQuery(SqlExpression).ToList();

                }
                else if (TableName == "Polzovatel")
                {
                    DBDataGrid.ItemsSource = context.Polzovatels.SqlQuery(SqlExpression).ToList();
                }
                else if (TableName == "Products")
                {
                    DBDataGrid.ItemsSource = context.Products.SqlQuery(SqlExpression).ToList();
                }
                else if (TableName == "Types")
                {
                    DBDataGrid.ItemsSource = context.Types.SqlQuery(SqlExpression).ToList();
                }
                else if (TableName == "Cart_pos")
                {
                    DBDataGrid.ItemsSource = context.Cart_pos.SqlQuery(SqlExpression).ToList();
                }
                else if (TableName == "Payed_Orders")
                {
                    DBDataGrid.ItemsSource = context.Payed_Orders.SqlQuery(SqlExpression).ToList();
                }
            }
        }

        private void TablesList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TextBlock textblock = (TextBlock)TablesList.SelectedItem;

            ReadDataFromTableByORM(textblock.Text);
        }

     
        private void UpdateBtn_Click(object sender, RoutedEventArgs e) 
        {
            TextBlock textblock = (TextBlock)TablesList.SelectedItem;
            if (textblock != null)
            {
                ReadDataFromTableByORM(textblock.Text);
            }
        }
        private void SavingBtn_Click(object sender, RoutedEventArgs e)
        {
            List<TextBox> textBoxes = new List<TextBox>();
            ListBox listBox = (ListBox)InsertGroup.Content;
            List<string> paramsList = new List<string>();

            for (int i = 0; i < listBox.Items.Count; i++)
            {
                textBoxes.Add((TextBox)listBox.Items[i]);
            }
            TextBlock TableTextBlock = TablesList.SelectedItem as TextBlock;
            if (TableTextBlock == null)
            {
                MessageBox.Show("You don't select any table.");
                return;
            }
            string TableName = TableTextBlock.Text;
            foreach (TextBox item in textBoxes)
            {
                paramsList.Add(item.Text);
            }

            if (CRadioBtn.IsChecked == true)
            {
                if (TableName == "Cart")
                {
                    Cart newEntityObject = new Cart()
                    {
                        /*UID = int.Parse(paramsList[0]),*/
                        Total_Price = double.Parse(paramsList[1]),
                        num_of_positions = int.Parse(paramsList[2]),
                        User_ID = int.Parse(paramsList[3])
                    };
                    context.Carts.Add(newEntityObject);
                }
                else if (TableName == "accessiries")
                {
                    accessory newEntityObject = new accessory()
                    {
                        cost_per_pc = int.Parse(paramsList[0]),
                        pieces = int.Parse(paramsList[1]),
                        Mat_ID = int.Parse(paramsList[2])
                    };
                    context.accessories.Add(newEntityObject);

                }
                else if (TableName == "Cat_product")
                {
                    Cat_product newEntityObject = new Cat_product()
                    {
                        Prod_NAME = paramsList[0],
                        Prod_Description = paramsList[1],
                        Prod_ID = int.Parse(paramsList[2]),
                        Prod_Articul = paramsList[3],
                    };
                    context.Cat_product.Add(newEntityObject);

                }
                else if (TableName == "Catalogs")
                {
                    Catalog newEntityObject = new Catalog()
                    {
                        /*Prod_Articul = paramsList[0],*/
                        Prod_Name = paramsList[1],
                        PhotoHyperlink = paramsList[2]
                    };
                    context.Catalogs.Add(newEntityObject);
                }
                else if (TableName == "Customs")
                {
                    Custom newEntityObject = new Custom()
                    {
                        Breast = int.Parse(paramsList[0]),
                        Waste = int.Parse(paramsList[1]),
                        Back_width = int.Parse(paramsList[2]),
                        Hips = int.Parse(paramsList[3]),
                        shelf_height = int.Parse(paramsList[4]),
                        arm_length = int.Parse(paramsList[5]),
                        Chest_height = int.Parse(paramsList[6]),
                        shelf_width = int.Parse(paramsList[7]),
                        sleeve_length = int.Parse(paramsList[8]),
                        product_length = int.Parse(paramsList[9]),
                        Prod_ID = int.Parse(paramsList[10])
                    };
                    context.Customs.Add(newEntityObject);
                }

                else if (TableName == "Default_Size")
                {
                    Default_Size newEntityObject = new Default_Size()
                    {
                        /*RU_size = int.Parse(paramsList[0]),
                        Waste_size = int.Parse(paramsList[1]),
                        Hips_size = int.Parse(paramsList[2]),
                        Breast_size = int.Parse(paramsList[3]),
                        Prod_ID = int.Parse(paramsList[4])*/
                    };
                    context.Default_Size.Add(newEntityObject);
                }
                else if (TableName == "furriery_n_fabrics")
                {
                    furriery_n_fabrics newEntityObject = new furriery_n_fabrics()
                    {
                        cost_per_meter_2 = int.Parse(paramsList[0]),
                        Meters_2 = int.Parse(paramsList[1]),
                        Mat_ID = int.Parse(paramsList[2])
                    };
                    context.furriery_n_fabrics.Add(newEntityObject);
                }
                else if (TableName == "Materials")
                {
                    Material newEntityObject = new Material()
                    {
                        Mat_Name = paramsList[0],
                        Mat_Type = paramsList[1],
                        Mat_ID = int.Parse(paramsList[2])
                    };
                    context.Materials.Add(newEntityObject);
                }
                else if (TableName == "Messages")
                {
                    Message newEntityObject = new Message()
                    {
                        AdminName = paramsList[0],
                        MsgDateTime = DateTime.Parse(paramsList[1]),
                        MsgText = paramsList[2],
                        User_ID = int.Parse(paramsList[3])
                    };
                    context.Messages.Add(newEntityObject);
                }
                else if (TableName == "Order_Position")
                {
                    Order_Position newEntityObject = new Order_Position()
                    {
                        quantity = int.Parse(paramsList[0]),
                        Order_Number = int.Parse(paramsList[1]),
                        Prod_ID = int.Parse(paramsList[2])
                    };
                    context.Order_Position.Add(newEntityObject);
                }
                else if (TableName == "Order_Status")
                {
                    Order_Status newEntityObject = new Order_Status()
                    {
                        Status_id = int.Parse(paramsList[0]),
                        Status_Type = paramsList[1]
                    };
                    context.Order_Status.Add(newEntityObject);
                }
                else if (TableName == "Orders")
                {
                    Order newEntityObject = new Order()
                    {
                        Order_Number = int.Parse(paramsList[0]),
                        num_of_positions = int.Parse(paramsList[1]),
                        Total_Price = int.Parse(paramsList[2]),
                        Order_date = DateTime.Parse(paramsList[3]),
                        User_ID = int.Parse(paramsList[4]),
                        Status_id = int.Parse(paramsList[5])
                    };
                    context.Orders.Add(newEntityObject);
                }
                else if (TableName == "Polzovatel")
                {
                    Polzovatel newEntityObject = new Polzovatel()
                    {
                        User_ID = int.Parse(paramsList[0]),
                        UName = paramsList[1],
                        ContactNumber = paramsList[2],
                        Password = paramsList[3],
                        EMail = paramsList[4],
                        isAdmin = paramsList[5],
                        USurname = paramsList[6]
                    };
                    context.Polzovatels.Add(newEntityObject);
                }
                else if (TableName == "Products")
                {
                    Product newEntityObject = new Product()
                    {
                        Price = int.Parse(paramsList[0]),
                        Is_custom = paramsList[1],
                        Prod_ID = int.Parse(paramsList[2]),
                        Type_Id = int.Parse(paramsList[3])
                    };
                    context.Products.Add(newEntityObject);
                }
                else if (TableName == "Types")
                {
                    MyType newEntityObject = new MyType()
                    {
                        Type_Id = int.Parse(paramsList[0]),
                        Type_Name = paramsList[1]
                    };
                    context.Types.Add(newEntityObject);
                }
                else if (TableName == "Cart_pos")
                {
                    Cart_pos newEntityObject = new Cart_pos()
                    {
                        quantity = int.Parse(paramsList[0]),
                        UID = int.Parse(paramsList[1]),
                        Prod_ID = int.Parse(paramsList[2])
                    };
                    context.Cart_pos.Add(newEntityObject);
                }
                else if (TableName == "Payed_Orders")
                {
                    Payed_Orders newEntityObject = new Payed_Orders()
                    {
                        Payment_date = DateTime.Parse(paramsList[0]),
                        Payment_sum = int.Parse(paramsList[1]),
                        Order_Number = int.Parse(paramsList[2])
                    };
                    context.Payed_Orders.Add(newEntityObject);
                }
            }
            else if (URadioBtn.IsChecked == true)
            {
                if (TableName == "Polzovatel")
                {
                    int ID = int.Parse(paramsList[0]);
                    List<Polzovatel> EntityObject = context.Polzovatels.ToList();
                    Polzovatel newEntityObject = EntityObject.Find(user => user.User_ID == ID);
                    //context.Polzovatels.Remove(newEntityObject);
                    newEntityObject.User_ID = int.Parse(paramsList[0]);
                    newEntityObject.UName = paramsList[1];
                    newEntityObject.ContactNumber = paramsList[2];
                    newEntityObject.Password = paramsList[3];
                    newEntityObject.EMail = paramsList[4];
                    newEntityObject.isAdmin = paramsList[5];
                    newEntityObject.USurname = paramsList[6];
                }
            }


            try
            {
                context.SaveChanges();
                MessageBox.Show("Data saved successfully");
            }
            catch (Exception error)
            {
                MessageBox.Show("Error! Something went wrong...\n" + error.ToString());
            }
            TextBlock textblock = (TextBlock)TablesList.SelectedItem;
            if (textblock != null)
            {
                ReadDataFromTableByORM(textblock.Text);
            }
        }
        private void textBox_Load(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            //textBox.Text = "help message";//подсказка
        }

        private void textBox_Enter(object sender, EventArgs e)//происходит когда элемент стает активным
        {
            TextBox box = (TextBox)sender;
            box.Text = null;
            box.Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 0));
        }

        private void CreateInsertFields()
        {
            try
            {
                var HeaderTexts = DBDataGrid.Columns.Select(row => row.Header.ToString()).ToList();
                ListBox list = (ListBox)InsertGroup.Content;

                foreach (string item in HeaderTexts)
                {
                    TextBox box = new TextBox() { Text = item, Width = list.ActualWidth * 0.95, Foreground = new SolidColorBrush(Color.FromRgb(150, 150, 150)) };
                    box.PreviewMouseLeftButtonDown += textBox_Enter;
                    list.Items.Add(box);
                }
            }

            catch (Exception error)
            {
                MessageBox.Show(error.ToString());
            }
        }
        private void RRadioBtn_Checked(object sender, RoutedEventArgs e)
        {
            SavingBtn.IsEnabled = false;
            DeleteBtn.IsEnabled = false;
            TablesList.IsEnabled = true;
        }
        private void RRadioBtn_Unchecked(object sender, RoutedEventArgs e)
        {
            SavingBtn.IsEnabled = true;
            DeleteBtn.IsEnabled = false;
        }
        private void CRadioBtn_Checked(object sender, RoutedEventArgs e)
        {
            TablesList.IsEnabled = true;
            InsertGroup.IsEnabled = true;
            SavingBtn.IsEnabled = true;
            DeleteBtn.IsEnabled = false;
            CreateInsertFields();
        }
        private void CRadioBtn_Unchecked(object sender, RoutedEventArgs e)
        {
            InsertGroup.IsEnabled = false;
            DeleteBtn.IsEnabled = false;
            ListBox list = (ListBox)InsertGroup.Content;
            list.Items.Clear();
        }
        private void URadioBtn_Checked(object sender, RoutedEventArgs e)
        {
            TablesList.IsEnabled = true;
            InsertGroup.IsEnabled = true;
            SavingBtn.IsEnabled = true;
            DeleteBtn.IsEnabled = false;
        }
        private void URadioBtn_Unchecked(object sender, RoutedEventArgs e)
        {
            InsertGroup.IsEnabled = true;
            DeleteBtn.IsEnabled = false;
            ListBox list = (ListBox)InsertGroup.Content;
            list.Items.Clear();
        }
        private void DRadioBtn_Checked(object sender, RoutedEventArgs e)
        {
            TablesList.IsEnabled = true;
            InsertGroup.IsEnabled = true;
            DeleteBtn.IsEnabled = true;
            SavingBtn.IsEnabled = false;
        }
        private void DBDataGrid_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            /*Polzovatel user = (Polzovatel)DBDataGrid.SelectedItem;
            MessageBox.Show(user.Password);*/
            if (CRadioBtn.IsChecked == false && RRadioBtn.IsChecked == false && !deletFlag)
            {
                int length = DBDataGrid.Columns.Select(row => row.Header.ToString()).ToList().Count;
                ListBox list = (ListBox)InsertGroup.Content;
                list.Items.Clear();
                for (int i = 0; i < length; i++)
                {
                    object cell = DBDataGrid.SelectedItem;
                    TextBlock item = (DBDataGrid.SelectedCells[i].Column.GetCellContent(cell) as TextBlock);
                    if (item != null)
                    {
                        TextBox box = new TextBox() { Text = item.Text, Width = list.ActualWidth * 0.95 };
                        box.PreviewMouseLeftButtonDown += textBox_Enter;
                        list.Items.Add(box);
                    }
                }
            }
            deletFlag = false;
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            List<TextBox> textBoxes = new List<TextBox>();
            ListBox listBox = (ListBox)InsertGroup.Content;
            List<string> paramsList = new List<string>();

            for (int i = 0; i < listBox.Items.Count; i++)
            {
                textBoxes.Add((TextBox)listBox.Items[i]);
            }
            TextBlock TableTextBlock = TablesList.SelectedItem as TextBlock;
            if (TableTextBlock == null)
            {
                MessageBox.Show("You don't select any table.");
                return;
            }
            string TableName = TableTextBlock.Text;
            foreach (TextBox item in textBoxes)
            {
                paramsList.Add(item.Text);
            }
            MessageBoxResult messageBoxResult = MessageBox.Show("Are you sure?", "Delete Confirmation", MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)
            {

                int ID = int.Parse(paramsList[0]);
                List<Polzovatel> EntityObject = context.Polzovatels.ToList();
                Polzovatel newEntityObject = EntityObject.Find(user => user.User_ID == ID);
                context.Polzovatels.Remove(newEntityObject);
                context.SaveChanges();
                deletFlag = true;
            }
            TextBlock textblock = (TextBlock)TablesList.SelectedItem;
            if (textblock != null)
            {
                ReadDataFromTableByORM(textblock.Text);
            }

        }

    }
}
/*
if (TableName == "Cart")
{
    Cart newEntityObject = new Cart()
    {
        UID = int.Parse(paramsList[0]),
        Total_Price = double.Parse(paramsList[1]),
        num_of_positions = int.Parse(paramsList[2]),
        User_ID = int.Parse(paramsList[3])
    };
    context.Carts.Add(newEntityObject);
}
else if (TableName == "accessiries")
{
    accessory newEntityObject = new accessory()
    {
        cost_per_pc = int.Parse(paramsList[0]),
        pieces = int.Parse(paramsList[1]),
        Mat_ID = int.Parse(paramsList[2])
    };
    context.accessories.Add(newEntityObject);

}
else if (TableName == "Cat_product")
{
    Cat_product newEntityObject = new Cat_product()
    {
        Prod_NAME = paramsList[0],
        Prod_Description = paramsList[1],
        Prod_ID = int.Parse(paramsList[2]),
        Prod_Articul = paramsList[3],
    };
    context.Cat_product.Add(newEntityObject);

}
else if (TableName == "Catalogs")
{
    Catalog newEntityObject = new Catalog()
    {
        Prod_Articul = paramsList[0],
        Prod_Name = paramsList[1],
        PhotoHyperlink = paramsList[2]
    };
    context.Catalogs.Add(newEntityObject);
}
else if (TableName == "Customs")
{
    Custom newEntityObject = new Custom()
    {
        Breast = int.Parse(paramsList[0]),
        Waste = int.Parse(paramsList[1]),
        Back_width = int.Parse(paramsList[2]),
        Hips = int.Parse(paramsList[3]),
        shelf_height = int.Parse(paramsList[4]),
        arm_length = int.Parse(paramsList[5]),
        Chest_height = int.Parse(paramsList[6]),
        shelf_width = int.Parse(paramsList[7]),
        sleeve_length = int.Parse(paramsList[8]),
        product_length = int.Parse(paramsList[9]),
        Prod_ID = int.Parse(paramsList[10])
    };
    context.Customs.Add(newEntityObject);
}

else if (TableName == "Default_Size")
{
    Default_Size newEntityObject = new Default_Size()
    {
        RU_size = int.Parse(paramsList[0]),
        Waste_size = int.Parse(paramsList[1]),
        Hips_size = int.Parse(paramsList[2]),
        Breast_size = int.Parse(paramsList[3]),
        Prod_ID = int.Parse(paramsList[4])
    };
    context.Default_Size.Add(newEntityObject);
}
else if (TableName == "furriery_n_fabrics")
{
    furriery_n_fabrics newEntityObject = new furriery_n_fabrics()
    {
        cost_per_meter_2 = int.Parse(paramsList[0]),
        Meters_2 = int.Parse(paramsList[1]),
        Mat_ID = int.Parse(paramsList[2])
    };
    context.furriery_n_fabrics.Add(newEntityObject);
}
else if (TableName == "Materials")
{
    Material newEntityObject = new Material()
    {
        Mat_Name = paramsList[0],
        Mat_Type = paramsList[1],
        Mat_ID = int.Parse(paramsList[2])
    };
    context.Materials.Add(newEntityObject);
}
else if (TableName == "Messages")
{
    Message newEntityObject = new Message()
    {
        AdminName = paramsList[0],
        MsgDateTime = DateTime.Parse(paramsList[1]),
        MsgText = paramsList[2],
        User_ID = int.Parse(paramsList[3])
    };
    context.Messages.Add(newEntityObject);
}
else if (TableName == "Order_Position")
{
    Order_Position newEntityObject = new Order_Position()
    {
        quantity = int.Parse(paramsList[0]),
        Order_Number = int.Parse(paramsList[1]),
        Prod_ID = int.Parse(paramsList[2])
    };
    context.Order_Position.Add(newEntityObject);
}
else if (TableName == "Order_Status")
{
    Order_Status newEntityObject = new Order_Status()
    {
        Status_id = int.Parse(paramsList[0]),
        Status_Type = paramsList[1]
    };
    context.Order_Status.Add(newEntityObject);
}
else if (TableName == "Orders")
{
    Order newEntityObject = new Order()
    {
        Order_Number = int.Parse(paramsList[0]),
        num_of_positions = int.Parse(paramsList[1]),
        Total_Price = int.Parse(paramsList[2]),
        Order_date = DateTime.Parse(paramsList[3]),
        User_ID = int.Parse(paramsList[4]),
        Status_id = int.Parse(paramsList[5])
    };
    context.Orders.Add(newEntityObject);
}
else if (TableName == "Polzovatel")
{
    Polzovatel newEntityObject = new Polzovatel()
    {
        User_ID = int.Parse(paramsList[0]),
        UName = paramsList[1],
        ContactNumber = paramsList[2],
        Password = paramsList[3],
        EMail = paramsList[4],
        isAdmin = paramsList[5],
        USurname = paramsList[6]
    };
    context.Polzovatels.Add(newEntityObject);
}
else if (TableName == "Products")
{
    Product newEntityObject = new Product()
    {
        Price = int.Parse(paramsList[0]),
        Is_custom = paramsList[1],
        Prod_ID = int.Parse(paramsList[2]),
        Type_Id = int.Parse(paramsList[3])
    };
    context.Products.Add(newEntityObject);
}
else if (TableName == "Types")
{
    MyType newEntityObject = new MyType()
    {
        Type_Id = int.Parse(paramsList[0]),
        Type_Name = paramsList[1]
    };
    context.Types.Add(newEntityObject);
}
else if (TableName == "Cart_pos")
{
    Cart_pos newEntityObject = new Cart_pos()
    {
        quantity = int.Parse(paramsList[0]),
        UID = int.Parse(paramsList[1]),
        Prod_ID = int.Parse(paramsList[2])
    };
    context.Cart_pos.Add(newEntityObject);
}
else if (TableName == "Payed_Orders")
{
    Payed_Orders newEntityObject = new Payed_Orders()
    {
        Payment_date = DateTime.Parse(paramsList[0]),
        Payment_sum = int.Parse(paramsList[1]),
        Order_Number = int.Parse(paramsList[2])
    };
    context.Payed_Orders.Add(newEntityObject);
}
*/