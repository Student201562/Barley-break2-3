using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barley_break
{
    class ClassGameThird : ClassGameSecond
    {
        public readonly List<int[]> saveValueGameField;
        public int[] help;
        public ClassGameThird(params int[] valueForPlay)
        {
            if (IsExsistGameField(valueForPlay))
            {
                int temp = 0;

                this.gameField = new int[(int)Math.Sqrt(valueForPlay.Length), (int)Math.Sqrt(valueForPlay.Length)];
                for (int i = 0; i < gameField.GetLength(0); i++)
                {
                    for (int j = 0; j < gameField.GetLength(1); j++)
                    {
                        gameField[i, j] = valueForPlay[temp];
                        temp++;
                    }
                }
                saveValueGameField = new List<int[]>();
                help = new int[4];
                GenerationNumbersOnField();
            }
            else
            {
                throw new Exception();
            }

        }
        public override bool Shift(int mValue)
        {
            int[] massiveZero = GetLocation(0);
            int[] massiveMoveValue = GetLocation(mValue);


            if (base.Shift(mValue))
            {
                saveValueGameField.Add(massiveZero);
                saveValueGameField.Add(massiveMoveValue);

                help = new[] { massiveZero[0], massiveZero[1], massiveMoveValue[0], massiveMoveValue[1] };
                //saveValueGameField.Add(massiveMoveValue[0]);
                //saveValueGameField.Add(massiveMoveValue[1]);
                return true;
            }
            return false;
        }

        public int[] returnHelp()
        {
            return help;
        }
    }
}
