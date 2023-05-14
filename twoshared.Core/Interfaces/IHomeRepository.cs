using twoshared.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace twoshared.Core.Interfaces
{
    public interface IHomeRepository
    {
        List<Products> Get_Products();
        string Insert_Shopping_Item_Post(int idProduct, int idCustomer);
        List<ItemsCart> Get_Products_Customer(int idCustomer);
        string Shopping_Item_Delete(int id);
        string Shopping_Item_tag_insert(int id, string name);
        List<Tags> Get_Tags_Item(int item);
        string Shopping_Item_tag_delete(int id);
    }
}
