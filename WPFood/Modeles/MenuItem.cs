using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace WPFood.Modeles
{
    public class MenuItem
    {
        public int Id { get; set; }
        public Item Item { get; set; }
        public Menu Menu { get; set; }

        public MenuItem(Item _item,Menu _menu)
        {
            Item = _item;
            Menu = _menu;
        }
        public MenuItem()
        {

        }

        public MenuItem(string item, Menu leMenu)
        {
            Item = new Item(item);
            Menu = leMenu;
        }

    }
}
