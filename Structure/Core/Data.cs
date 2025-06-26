using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterAnimation.Core
{
    public static class Data
    {
        public static int ScreenW { get; set; } = 1800; //30 tile remeber to double the tile Width size from 50 to 100
        public static int ScreenH { get; set; } = 1200; //20 tile remeber to double the tile Height size from 50 to 100
        public static bool Exit { get; set; } = false;

        public enum Scenes { Menu, Game, Settings}
        public static Scenes CurrentState { get; set; } = Scenes.Menu;
    }
}
