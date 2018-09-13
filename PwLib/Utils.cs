using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PwLib
{
    public class Utils
    {
        public static Dictionary<String, String> SERVERS = new Dictionary<String, String>()
        {
            { "", "drakon" },
            { "Дракон", "drakon" },
            { "Орион", "orion" },
            { "Электра", "electra" },
            { "Мира", "mira" },
            { "Гелиос", "gelios" },
            { "Атлас", "atlas" },
            { "Кассиопея", "kassiopeya" },
            { "Лисичка", "lisichka" },
            { "Гидра", "gidra" },
            { "Цербер", "cerberus" }
        };

        public static void Delay(int msec) { Thread.Sleep(msec); }

        public static void RandomDelay(int from = 500, int to = 1000)
        {
            Delay(new Random().Next(from, to));
        }
    }
}
