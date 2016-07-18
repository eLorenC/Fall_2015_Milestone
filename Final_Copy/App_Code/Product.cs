using System.Linq;
using System.Data;
using System.Data.Linq;
using System.Configuration;
using System.Data.Linq.Mapping;

/// <summary>
/// Summary description for Product
/// </summary>
/// 

#region WLW DataContext Class
// WLW class extends DataContext
public class WLW : DataContext
{
    private Table<Product> products;
    
    // Defines DataContext for product table using the ConfigurationManager Connection String -> Connects
    // to local db instance. May use .mdf
    public WLW(): base(ConfigurationManager.ConnectionStrings["WeLoveWhiskey"].ConnectionString) { }
}
#endregion

#region Product Entity
/// <summary>
/// Product class designated as Entity class that is associated with a database table instance.
/// Linq.Mapping classes used to generate an object model of data.
/// This class is only to be used for the storing of database table field information &&
/// Querying using the IQueryable(T) Interface methods.
/// 
/// Note: table and column attributes preface the declaration.
/// <summary>
[Table(Name = "Product")] //Linq Mapping
public class Product : WLW
{
    private int _ProductID;

    [Column(IsPrimaryKey = true, Storage = "_ProductID")]
    public int ProductID
    {
        get { return _ProductID; }
        set { _ProductID = value; }
    }

    private string _productName;

    [Column(Storage = "_productName")]
    public string productName
    {
        get { return _productName; }
        set { _productName = value; }
    }

    private string _productDesc;

    [Column(Storage = "_productDesc")]
    public string productDesc
    {
        get { return _productDesc; }
        set { _productDesc = value; }
    }

    private string _pType;

    [Column(Storage = "_pType")]
    public string pType
    {
        get { return _pType; }
        set { _pType = value; }
    }

    private string _size;

    [Column(Storage = "_size")]
    public string size
    {
        get { return _size; }
        set { _size = value; }
    }

    private double _price;

    [Column(Storage = "_price")]
    public double price
    {
        get { return _price; }
        set { _price = value; }
    }
}
#endregion

/// <summary>
/// Item class for instanciating versions of the products stored in Product Class Table.
/// </summary>
public class Item
{
    #region Private Fields
    private string iName;
    private string iType;
    private string iSize;
    private string iDesc;
    private double iPrice;
    private double iItemTotal;
    private int iQuant;
    private int iID;
    #endregion

    #region Getters/Setters
    public string IName
    {
        get
        {
            return iName;
        }

        set
        {
            iName = value;
        }
    }

    public string IType
    {
        get
        {
            return iType;
        }

        set
        {
            iType = value;
        }
    }

    public string ISize
    {
        get
        {
            return iSize;
        }

        set
        {
            iSize = value;
        }
    }

    public double IPrice
    {
        get
        {
            return iPrice;
        }

        set
        {
            iPrice = value;
        }
    }

    public int IQuant
    {
        get
        {
            return iQuant;
        }

        set
        {
            iQuant = value;
        }
    }

    public int IID
    {
        get
        {
            return iID;
        }

        set
        {
            iID = value;
        }
    }

    public string IDesc
    {
        get
        {
            return iDesc;
        }

        set
        {
            iDesc = value;
        }
    }

    public double IItemTotal
    {
        get
        {
            return iItemTotal;
        }

        set
        {
            iItemTotal = value;
        }
    }
    #endregion

    #region Item Constructors
    //=========================================================================================================
    //=========================================================================================================
    // Default Item Constructor
    public Item() { }

    //=========================================================================================================
    //=========================================================================================================
    // Overloaded Constructor (all properties)
    public Item(string name, string desc, string type, string size, double price, int quant, int id)
    {
        this.iName = name;
        this.iDesc = desc;
        this.iType = type;
        this.iSize = size;
        this.iPrice = price;
        this.iQuant = quant;
        this.iID = id;
        this.iItemTotal = iQuant * iPrice;
    }

    //=========================================================================================================
    //=========================================================================================================
    // Overloaded Constructor -> Creates and populates table instance of Product with 
    // DB information matching the parameters.
    public Item(int pId, int qty)
    {
        WLW tempDB = new WLW();
        Table<Product> pt = tempDB.GetTable<Product>();
        IQueryable<Product> prod =
                    from p in pt
                    where p.ProductID == pId
                    select p;
        this.iID = pId;
        this.iName = prod.FirstOrDefault().productName;
        this.iDesc = prod.FirstOrDefault().productDesc;
        this.iType = prod.FirstOrDefault().pType;
        this.iSize = prod.FirstOrDefault().size;
        this.iPrice = prod.FirstOrDefault().price;
        this.iQuant = qty;
        this.iItemTotal = qty * iPrice;
    }
    #endregion
}
