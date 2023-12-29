using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Messages
{
    public class BusinessMessages
    {
        public static string CategoryLimit = "Kategori sayısı max 10 olabilir.";

        public static string? CategoryProductLimit = "Bir Kategoride Max ürün 20 olmalı.";
        public static string MaxCustomerTenPerCity = "Max Customer number is 10 per city, it can't be exceeded";
        public static string ContactNameCantRepeat = "Contact name can't be same";
    }
}
