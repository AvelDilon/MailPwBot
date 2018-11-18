using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PwLib
{
    public class PwClass
    {
        public int id = 0;
        public String name;

        public static Dictionary<int, String> CLASS_LIST = new Dictionary<int, String>() {
            { 0, "Воин" },
            { 1, "Маг" },
            { 2, "Шаман" },
            { 3, "Друид" },
            { 4, "Оборотень" },
            { 5, "Убийца" },
            { 6, "Лучник" },
            { 7, "Жрец" },
            { 8, "Страж" },
            { 9, "Мистик" },
            { 10, "Призрак" },
            { 11, "Жнец" }
        };

        public PwClass(int id)
        {
            this.id = id;
            name = CLASS_LIST[id];
        }
    }
}
