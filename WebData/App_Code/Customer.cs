using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for Customer
/// </summary>
public class Customer
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Mobile { get; set; }
    public string Street { get; set; }
    public string Distreet { get; set; }
    public string City { get; set; }
	public Customer()
	{
     
	}
    public Customer(string name,string email,string phone, string mobile, string street,string distreet,string city)
    {
        this.Name = name;
        this.Email = email;
        this.Phone = phone;
        this.Mobile = mobile;
        this.Street = street;
        this.Distreet = distreet;
        this.City = city;
    }

    public void AddCustomer(string name, string email, string phone, string mobile, string street, string distreet, string city)
    {
        this.Name = name;
        this.Email = email;
        this.Phone = phone;
        this.Mobile = mobile;
        this.Street = street;
        this.Distreet = distreet;
        this.City = city;
    }
}