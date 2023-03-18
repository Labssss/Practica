using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StationeryApp.Entities
{
    public partial class Product
    {
        // DiscountText - текст для отображения информации о скидке на товаре
        public string DiscountText
        {
            get
            {
                if (ProductDiscountAmount == 0 || ProductDiscountAmount == null)
                    return "";
                else
                    return $"* скидка {ProductDiscountAmount}%";
            }
        }
        // DiscountColor - цвет для отображения информации о скидке на товаре
        public string DiscountColor
        {
            get
            {
                if (ProductDiscountAmount >= 5)
                    return "#7fff00"; // если скидка больше или равна 5%, вернуть зеленый цвет
                else
                    return "White"; // иначе вернуть белый цвет
            }
        }

        // DiscountPrice - цена товара со скидкой
        public string DiscountPrice
        {
            get
            {
                if (ProductDiscountAmount == 0 || ProductDiscountAmount == null)
                    return $"{ProductCost:C2}"; // если скидки нет, то вернуть стандартную цену товара
                else
                    return $"Цена со скидкой: {(decimal)((100 - (ProductDiscountAmount)) / 100.0 * (double)ProductCost):C2}"; // иначе вернуть цену со скидкой
            }
        }

        // DiscountPriceNumber - цена товара со скидкой в виде числа с плавающей точкой
        public double DiscountPriceNumber
        {
            get
            {
                if (ProductDiscountAmount == 0 || ProductDiscountAmount == null)
                    return (double)ProductCost; // если скидки нет, то вернуть стандартную цену товара в виде числа с плавающей точкой
                else
                    return (double)((100 - (ProductDiscountAmount)) / 100.0 * (double)ProductCost); // иначе вернуть цену со скидкой в виде числа с плавающей точкой
            }
        }

        // Strike - указывает, нужно ли выводить стандартную цену товара со скидкой в зачеркнутом виде
        public string Strike
        {
            get
            {
                if (ProductDiscountAmount == 0 || ProductDiscountAmount == null)
                    return "False"; // если скидки нет, то вернуть False
                else
                    return "StrikeThrough"; // иначе вернуть StrikeThrough для отображения зачеркнутой стандартной цены товара со скидкой
            }
        }

        // FullPrice - полная стоимость товара без учета скидок
        public string FullPrice
        {
            get
            {
                return $"{ProductCost:C2}"; // вернуть стандартную цену товара
            }
        }
    }
}
