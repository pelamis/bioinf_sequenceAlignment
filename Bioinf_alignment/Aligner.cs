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
                //Calculating score and getting path for current cell
                scoreAndPath = ScoringSystem.calcScoreAndPaths(cf,isPossibleGapOpening);
                //If there is a "match" path giving a highscore, supposing the previous gap closed and setting the flag in state "suppose new gap opening" 
                if ((scoreAndPath.Item2 & Directions.DIAG) != 0) isPossibleGapOpening = true;
                else isPossibleGapOpening = false;
                curCell = cf.getCurrent();
                curCell.Score = scoreAndPath.Item1;
                curCell.Pathes = scoreAndPath.Item2;
            }

            #endregion
        }

        public void buildPath()
        {

        }

        public void buildAlgnment()
        {

        }

        public void run()
        {
            fillTable();
        }
    }
}
