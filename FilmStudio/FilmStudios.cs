using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//
using System;
using System.Collections.Generic;

// Define the Business Object "Product" with two public properties
//    of simple datatypes.
//

//namespace FilmStudio
//{

public class MyItem
{
    private string myDescription;
    private int myQuantity;

    public MyItem(string description, int quantity)
    {
        myDescription = description;
        myQuantity = quantity;
    }

    public string Description
    {
        get
        {
            return myDescription;
        }
    }

    public int Quantity
    {
        get
        {
            return myQuantity;
        }
    }
}

// Define Business Object "Merchant" that provides a 
//    GetProducts method that returns a collection of 
//    Product objects.

public class BookedItems
{
    private List<MyItem> m_items;

    public BookedItems()
    {
        m_items = new List<MyItem>();
        m_items.Add(new MyItem("Pen", 25));
        m_items.Add(new MyItem("Pencil", 30));
        m_items.Add(new MyItem("Notebook", 15));
    }

    public List<MyItem> GetItems()
    {
        return m_items;
    }
}

//}
