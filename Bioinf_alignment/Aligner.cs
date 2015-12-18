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
            Directions gapType = Directions.NONE;
            bool isPossibleGapOpening = true;

            #region fillScoresAndPaths
            
            for (cf=Data.createSerialIterator(); !cf.isEnd(); cf = cf.next()) {
                //Получение скора и "стрелок" для ячейки
                scoreAndPath = ScoringSystem.calcScoreAndPaths(cf,isPossibleGapOpening);

                #region BUGSPOSSIBLE
                //Считаем, что новый гэп открывается в трёх случаях:
                //1. В ячейке есть стрелка, соответсвующая сравнению (match/mismatch)
                //2. Начали обрабатывать следующую строку матрицы
                //3. Меняется тип гэпа (верхний/левый)
                if (((scoreAndPath.Item2 & Directions.DIAG) != 0) || (cf.CurCol == 0) || (scoreAndPath.Item2 != gapType))
                {
                    isPossibleGapOpening = true;
                    if ((scoreAndPath.Item2 & Directions.DIAG) != 0) gapType = Directions.NONE;
                    if (cf.CurCol == 0) gapType = Directions.TOP;
                    if (scoreAndPath.Item2 != gapType) gapType = scoreAndPath.Item2;
                }
                else isPossibleGapOpening = false;
                #endregion

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
            foreach (Char ch in aligned.Item1) s1 += ch;  
            foreach (Char ch in aligned.Item2) s2 += ch;
            return new Tuple<string, string>(s1, s2);
        }
    }

    //class SmithWatermanAligner
    //{
    //    public Container Data;
    //    public BasicScorer ScoringSystem;

    //    public SmithWatermanAligner(Container data, BasicScorer scorer)
    //}
}
