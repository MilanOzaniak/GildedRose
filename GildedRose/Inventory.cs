using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security.Cryptography;

namespace GildedRose
{
    class Inventory
    {
        private readonly IEnumerable<Item> items;

        public Inventory(IEnumerable<Item> items)
        {
            this.items = items;
        }

        /// <summary>
        /// Items:
        /// "+5 Dexterity Vest"
        /// "Aged Brie"
        /// "Elixir of the Mongoose"
        /// "Sulfuras, Hand of Ragnaros"
        /// "Backstage passes to a TAFKAL80ETC concert"
        /// "Conjured Mana Cake"
        /// </summary>
        public void UpdateQuality()
        {
            foreach (var itm in items)
            {
                int a = 1;
                if (itm.SellIn <= 0)
                {
                    a = 2;
                }

                if (itm.Name == "Sulfuras, Hand of Ragnaros")
                {
                    continue;
                }

                else if (itm.Name == "Aged Brie")
                {
                    itm.Quality += a;
                }


                else if (itm.Name == "Backstage passes to a TAFKAL80ETC concert")
                {
                    if (itm.SellIn <= 0)
                    {
                        itm.Quality = 0;
                    }

                    else if (itm.SellIn > 10)
                    {
                        itm.Quality += a;
                    }

                    else if (itm.SellIn <= 5)
                    {
                        itm.Quality += a * 3;
                    }

                    else if (itm.SellIn <= 10)
                    {
                        itm.Quality += a * 2;
                    }

                }

                else if (itm.Name == "Conjured Mana Cake")
                {
                    itm.Quality -= a * 2;
                }

                else if (itm.Name == "+5 Dexterity Vest" || itm.Name == "Elixir of the Mongoose")
                {
                    itm.Quality -= a;
                }



                itm.SellIn -= 1;


                if (itm.Quality > 50)
                {
                    itm.Quality = 50;
                }

                if (itm.Quality < 0)
                {
                    itm.Quality = 0;
                }



            }
        }
    }
}
