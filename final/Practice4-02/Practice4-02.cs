using System;
using System.Collections.Generic;




class Program
{

    static void Main(string[] args)
    {

        Address firstAdress = new Address("Home Street", "Centerville", "Utah", "United States", Address.Country.USA);
        Customer firstCustomer = new Customer("Will", firstAdress);

        Address secondAdress = new Address("Kuma Street", "Tokyo", "Tokyo Prefecture", "Japan", Address.Country.OTHER);
        Customer secondCustomer = new Customer("Hana", secondAdress);
        
        
        CustomerOrder orderOne = new CustomerOrder(firstCustomer);
        CustomerOrder orderTwo = new CustomerOrder(secondCustomer);

        Product pokemonS = new Product("Pokemon Scarlet", 1, 60.0f, 1);
        Product pokemonV = new Product("Pokemon Violet", 2, 60.0f, 1);
        Product chicken = new Product("8 Pack Fried Chicken", 3, 8.79f, 1);

        // customer 1
        orderOne.AddToProductList(pokemonS);
        orderOne.AddToProductList(chicken);

        orderOne.GetShippingLabel();
        Console.WriteLine("");
        Console.WriteLine("Packing Label:");
        orderOne.GetPackingLabel();
        Console.WriteLine("");
        orderOne.GetTotal();

        Console.WriteLine("");

        // customer 2
        orderTwo.AddToProductList(pokemonV);
        orderTwo.AddToProductList(chicken);
        orderTwo.AddToProductList(chicken);

        orderTwo.GetShippingLabel();
        Console.WriteLine("");
        Console.WriteLine("Packing Label:");
        orderTwo.GetPackingLabel();
        Console.WriteLine("");
        orderTwo.GetTotal();

    }


}


class CustomerOrder
{

    private Customer customer;
    private List<Product> productList = new List<Product>();
    
    private float total = 0f;

    public CustomerOrder(Customer newCustomer)
    {
        customer = newCustomer;
    }

    public void AddToProductList(Product newProduct)
    {
        productList.Add(newProduct);
    }

    // Shipping Label
    public void GetShippingLabel()
    {
        Console.WriteLine("Customer Name: " + customer.GetName());
        Console.WriteLine("Customer Address: " + customer.GetAdress());
    }

    // get packing label
    public void GetPackingLabel()
    {
        foreach (Product product in productList)
        {
            Console.WriteLine(product.GetProductID() + " - " + product.GetProductName() + " X " + product.GetProductQuantity());
        }
    }

    public void GetTotal()
    {
        int shipping = 0;
        float currentPrice = 0f;
        if(customer.CheckIfUSA() == Address.Country.USA) {shipping = 5;} else {shipping = 35;}

        foreach (Product product in productList)
        {
            currentPrice = currentPrice + product.GetProductPrice();
        }

        total = currentPrice + shipping;

        Console.WriteLine("The Total for this order is: " + total);
        
    }

}


class Customer
{
    private string name = "";
    private Address customerAdress;

    public Customer (string newName, Address newAdress)
    {
        name = newName;
        customerAdress = newAdress;
    }

    public string GetName()
    {
        return name;
    }
    
    
    public string GetAdress()
    {
        return customerAdress.GetFullAdress();
    }

    public Address.Country CheckIfUSA()
    {
        return customerAdress.GetCountry();
    }
}

class Address
{
    private string street = "";
    private string city = "";
    private string state = "";
    private string countryName = "";
    private Country country = Country.USA;

    public enum Country
    {
        USA,
        OTHER
    }

    public Address(string streetName, string cityName, string stateName, string newCountryName, Country currentCountry)
    {
        street = streetName;
        city = cityName;
        state = stateName;
        countryName = newCountryName;
        country = currentCountry;
    }   

    public string GetStreetName()
    {
        return street;
    }
    public string GetCityName()
    {
        return city;
    }
    public string GetStateName()
    {
        return state;
    }
    public string GetCountryName()
    {
        return countryName;
    }
    public Country GetCountry()
    {
        return country;
    }

    public string GetFullAdress()
    {
        return GetStreetName() + ", " + GetCityName() + ", " + GetStateName() + ", " + GetCountryName();
    }

}

class Product
{
    private string name;
    private int productID;
    private float price;
    private int quantity;

    public Product(string productName, int newProductId, float productPrice, int productQuantity)
    {
        name = productName;
        productID = newProductId;
        quantity = productQuantity;
        price = productPrice;
    }

    public string GetProductName()
    {
        return name;
    }
    public int GetProductID()
    {
        return productID;
    }
    public float GetProductPrice()
    {
        return price * quantity;
    }
    public int GetProductQuantity()
    {   
        return quantity;
    }

}