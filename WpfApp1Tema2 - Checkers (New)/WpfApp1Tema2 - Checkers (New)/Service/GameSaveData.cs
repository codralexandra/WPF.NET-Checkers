using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1Tema2___Checkers__New_.Models;

namespace WpfApp1Tema2___Checkers__New_.Service
{
    [Serializable]
    public class GameSaveData
    {
        public string CurrentPlayer { get; set; }
        public int RedPieces { get; set; }
        public int BlackPieces { get; set; }
        public bool IsPreviousPositionSet { get; set; }
        public int PreviousPositionRow { get; set; }
        public int PreviousPositionColumn { get; set; }
        public bool MultipleJump { get; set; }
        public ObservableCollection<ObservableCollection<Cell>> Board { get; set; }
    }
}
