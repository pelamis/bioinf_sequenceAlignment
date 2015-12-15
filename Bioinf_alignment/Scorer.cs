using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bioinf_alignment
{
    //interface Scorer
    //{
    //    Tuple<int, Directions> calcScoreAndPaths(SerialIterator cells, Boolean isGapFirstOpening);
    //}

    class BasicScorer
    {
        public int match, mismatch, gapfirst, gapcont;

        public BasicScorer(int vmatch, int vmismatch, int vgapf, int vgapc)
        {
            match = vmatch;
            mismatch = vmismatch;
            gapfirst = vgapf;
            gapcont = vgapc;
        }
        private int matchingCase(char ch1, char ch2, int cellScore)
        {
            return cellScore + ((ch1 == ch2) ? match : mismatch);
        }

        private int penaltyCase(bool isGapOpening, int cellScore)
        {
            return cellScore + ((isGapOpening) ? gapfirst : gapcont);
        }
      
        public Tuple<int,Directions> calcScoreAndPaths(SerialIterator cells, Boolean isGapOpening)
        {

            AlignmentField matching = cells.getIncident(Directions.DIAG),
                            topgap = cells.getIncident(Directions.TOP),
                            leftgap = cells.getIncident(Directions.LEFT);
            Dictionary<Directions,int> possibleScores = new Dictionary<Directions,int>();
            int gapPenalty, charsCompareResult, score=0;
            Directions paths = Directions.NONE;
             //DIAG,TOP,LEFT
            AlignmentField[] incidCells = new AlignmentField[3] {   cells.getIncident(Directions.DIAG),
                                                                    cells.getIncident(Directions.TOP),
                                                                    cells.getIncident(Directions.LEFT) };
  
            charsCompareResult = matchChars(cells.getCurrent().Seq1char, cells.getCurrent().Seq2char);
            gapPenalty = (isGapOpening) ? gapfirst : gapcont;

            Func<int,int>[] cellScorers = new Func<int, int>[3] { s => s + charsCompareResult, s => s + gapPenalty, s => s + gapPenalty};
            
            for (int i = 0; i < 3; i++)
            {
                if (incidCells[i] != null)
                    if (incidCells[i])
            }

            #region CrappyCode
            if (matching != null)
                possibleScores[Directions.DIAG] = matching.Score + charsCompareResult;

            if (leftgap != null)
                possibleScores[Directions.LEFT] = leftgap.Score + gapPenalty;

            if (topgap != null)
                possibleScores[Directions.TOP] = topgap.Score + gapPenalty;
            

            if (possibleScores.Count > 0)
            {
                score = cells.getCurrent().Score = possibleScores.Values.Max();
                foreach (KeyValuePair<Directions, int> entry in possibleScores)
                    if (entry.Value == score) paths |= entry.Key;
            }
            #endregion

            return new Tuple<int, Directions>(score, paths);
        }
    }

    //class SimilarityMatrixScorer : Scorer
    //{

    //}

}
