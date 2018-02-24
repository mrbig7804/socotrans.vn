using System;
using System.Data;
using System.Configuration;
using System.Web;


/// <summary>
/// Summary description for MyCart
/// </summary>
public class MyCart:DataTable
{
	public MyCart()
	{
        this.Columns.Add("ProductID", typeof(string));
        this.Columns.Add("Title", typeof(string));
        this.Columns.Add("Quantity", typeof(int));
        this.Columns.Add("UnitPrice", typeof(double));
        this.Columns.Add("SmallPictureUrl", typeof(string));
       
        this.PrimaryKey = new DataColumn[] { this.Columns["ProductID"] };
      
	}

    private double shipping;

    public double _shipping
    {
        get { return shipping; }
        set { shipping = value; }
    }
    public void AddProductToCart(string id, string name, int addquantity, double price, string image) {
        DataRow drCart = this.NewRow();
        //if the product already exists in your cart
        if (TestCart(id))
        {
            for (int i = 0; i < this.Rows.Count; i++)
            {
                if (id.CompareTo(this.Rows[i]["ProductID"].ToString()) == 0)
                    this.Rows[i]["Quantity"] = int.Parse(this.Rows[i]["Quantity"].ToString()) + addquantity;
            }
        }
        //if the product is not yet in your cart
        else {
            drCart["ProductID"] = id;
            drCart["Title"] = name;
            drCart["Quantity"] = addquantity;
            drCart["UnitPrice"] = price;
            drCart["SmallPictureUrl"] = image;
            
            this.Rows.Add(drCart);
        }
    }

    //Test product has been existed in your cart
    public bool TestCart(string id){
        bool test = false;
        if (this.Rows.Count > 0) {
            for (int i = 0; i < this.Rows.Count;i++ )    
            {
                if (id.CompareTo(this.Rows[i]["ProductID"].ToString())==0)
                    test = true;
            }
        }
        return test;
    }
    //Total Cost before shipping
    public double CostBeforeShipping() {
        double cost = 0;
        for (int i = 0; i < this.Rows.Count; i++) {
            cost += Convert.ToDouble(this.Rows[i]["Quantity"].ToString()) * Convert.ToDouble(this.Rows[i]["Price"].ToString());
        }
        return cost;
    }
    //Total Cost after shipping
    public double CostAfterShipping(double ship)
    {
        double cost = CostBeforeShipping() +ship;
        return cost;
    }
    //Total quantity
    public int TotalQuantity()
    {
        int q = 0;
        for (int i = 0; i < this.Rows.Count; i++)
        {
            q += Convert.ToInt32(this.Rows[i]["Quantity"].ToString());
        }
        return q;
    }
   
    //Update Quantity
    public void UpdateQuantity(string id, int quantity) {
        try
        {
            for (int i = 0; i < this.Rows.Count; i++)
            {
                if (id.CompareTo(this.Rows[i]["ProductID"].ToString()) == 0)
                    this.Rows[i]["Quantity"] = quantity;
            }
        }
        catch(Exception ex) { 
        
        }
    }
    //Delete product from your cart
    public void DeleteProduct(string id) {
        try
        {
            DataRow drCart = this.Rows.Find(id);
            this.Rows.Remove(drCart);
        }
        catch (Exception ex) { 
        
        }
    }
    //show all your cart
    public DataTable Show() {
        return this;
    }
    //count product
     public int getNumberCart(){
        int i=0;
         return (i + this.Rows.Count);
     
    }
}
