using System;

namespace CharacterAnimation.Core
{
    public static class program
    {
        [STAThread]
        static void Main() 
        { 
            using var game = new CharacterAnimation.Core.Game1();
            game.Run();
        }
    }
}
