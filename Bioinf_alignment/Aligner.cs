using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 //Scorer имеет ссылку на объект контейнера!
namespace Bioinf_alignment
{
    class NeedlemanWunchAligner
    {
        public Container Data;
        public BasicScorer ScoringSystem;


        public NeedlemanWunchAligner(Container data, BasicScorer scorer)
        {
            Data = data;
            ScoringSystem = scorer;
        }

        public void fillTable() {
            SerialIterator cf;
            AlignmentField curCell;
            Tuple<int, Directions> scoreAndPath;
            #region INIT

            bool isPossibleGapOpening = true;

            #endregion

            #region fillScoresAndPaths
            
            for (cf=Data.createSerialIterator(); !cf.isEnd(); cf = cf.next()) {
                //Получение скора и "стрелок" для ячейки
                scoreAndPath = ScoringSystem.calcScoreAndPaths(cf,isPossibleGapOpening);
                //Исправить этот кусок кода! Гэпы разных типов не должны смешиваться в один!
                if (((scoreAndPath.Item2 & Directions.DIAG) != 0) || (cf.CurCol == 0)) isPossibleGapOpening = true;
                else isPossibleGapOpening = false;
                curCell = cf.getCurrent();
                curCell.Score = scoreAndPath.Item1;
                curCell.Pathes = scoreAndPath.Item2;
            }

            #endregion
        }

        public Tuple<List<Char>, List<Char>> buildPathAndAlignment()
        {
            List<Char> leftStrAligned = new List<char>();
            List<Char> upperStrAligned = new List<char>();
            BacktracingIterator cf;
            for (cf = Data.createBacktracingIterator(); !cf.isEnd(); cf = cf.next())
            {
                switch (cf.pathTaken)
                {
                    case Directions.DIAG: {
                        leftStrAligned.Add(cf.getCurrent().leftSeqChar);
                        upperStrAligned.Add(cf.getCurrent().upSeqChar);
                        break;
                    }
                    case Directions.LEFT:
                    {
                        leftStrAligned.Add('-');
                        upperStrAligned.Add(cf.getCurrent().upSeqChar);
                        break;
                    }
                    case Directions.TOP:
                    {
                        leftStrAligned.Add(cf.getCurrent().leftSeqChar);
                        upperStrAligned.Add('-');
                        break;
                    }
                }
            }
            leftStrAligned.Reverse();
            upperStrAligned.Reverse();

            return new Tuple<List<Char>, List<Char>>(upperStrAligned, leftStrAligned);

        }


        public Tuple<String, String> run()
        {
            Tuple<List<Char>, List<Char>> aligned;
            String s1="", s2="";
            fillTable();
            aligned = buildPathAndAlignment();
            List<Char> strup = aligned.Item1,
                strleft = aligned.Item2;
            foreach (Char ch in aligned.Item1) s1 += ch;  
            foreach (Char ch in aligned.Item2) s2 += ch;
            return new Tuple<string, string>(s1, s2);
        }
    }
}
