using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace EQW {
    class GameProcess {
        Process game;
        public void LaunchGame() {
            game = new Process();
            game.StartInfo.FileName = "D:\\EQ\\Live\\EverQuest\\LaunchPad.exe";
            game.Start();
        }
    }
}
