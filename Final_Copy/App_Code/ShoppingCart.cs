using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Soap;
using System.Linq;

/// <summary>
/// Shopping cart contains fields, getters/setters, and methods for handling item lists,
/// pricing information, and adding/deleting items.
/// </summary>

[Serializable()]
public class ShoppingCart
{
    #region private fields
    private List<Item> basket;
    private double subTotal;
    private double tax;
    private double total;
    private double itemTotal;
    #endregion

    #region Getters/Setters
    public double SubTotal
    {
        get { return subTotal; }
        set { subTotal = value; }
    }

    public double Tax
    {
        get { return tax; }
        set { tax = value; }
    }

    public double Total
    {
        get { return total; }
        set { total = value; }
    }

    public List<Item> Basket
    {
        get { return this.basket; }
        set { this.basket = value; }
    }
    #endregion

    #region Constructor(s)
    public ShoppingCart()
    {
        this.basket = new List<Item>();
        this.subTotal = 0.0;
        this.tax = 0.0;
        this.total = 0.0;
    }
    #endregion

    #region setTotal() 
    public void setTotal()
    {
        double temp = 0.0;
        try
        {
            List<Item> tempList = this.basket;
            if (!(tempList.Count() == 0) || (!tempList.Any() == false))
            {
                foreach (Item n in tempList)
                {
                    temp += n.IPrice * n.IQuant;
                    n.IItemTotal = n.IPrice * n.IQuant;
                }
                this.subTotal = temp;
                this.tax = (this.subTotal * 0.06);
                this.total = (this.tax + this.subTotal);  
            }
            else
            {
                SubTotal = 0.00;
                Tax = 0.00;
                total = 0.00;
            }
        }
        catch (Exception)
        { 
            // Fail Silently
        }
    }
    #endregion

    #region addItem()
    public void addItem(Item p)
    {
        try
        {
            List<Item> tempList = this.basket;
            int tempInt = 0;
            foreach (Item n in tempList)
            {
                if (n.IID == p.IID)
                {
                    n.IQuant += p.IQuant;
                    ++tempInt;
                }
            }
            if ((tempInt == 0) || (p == null))
            {
                this.basket.Add(p);
            }
            setTotal();
        }
        catch (ArgumentNullException)
        {
            // Fail Silently
        }
    }
    #endregion

    #region removeItem()
    //Determines if removing item will make basket empty.
    //If so- new Item list is instanced and assigned to handle any null reference exceptions
    public void removeItem(int id)
    {
        try
        {
            if (this.basket.Count() == 1)
            {
                this.basket = new List<Item>();
                this.subTotal = 0.0;
                this.tax = 0.0;
                this.total = 0.0;
            }
            else
            {
                var index = this.basket.FindIndex(n => n.IID == id);
                this.basket.RemoveAt(index);
                setTotal();
            }
        }
        catch (Exception)
        {
            // Fail Silently
        }           
    }
    #endregion
}