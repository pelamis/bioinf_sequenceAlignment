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
        private int matchChars(char ch1, char ch2)
        {
            return (ch1 == ch2) ? match : mismatch;
        }
      
        public Tuple<int,Directions> calcScoreAndPaths(SerialIterator cells, Boolean isGapOpening)
        {

            AlignmentField matching = cells.getIncident(Directions.DIAG),
                            topgap = cells.getIncident(Directions.TOP),
                            leftgap = cells.getIncident(Directions.LEFT);
            Dictionary<Directions,int> possibleScores = new Dictionary<Directions,int>();
            int gapPenalty, charsCompareResult, score=0;
            Directions paths = Directions.NONE;

            charsCompareResult = matchChars(cells.getCurrent().Seq1char, cells.getCurrent().Seq2char);
            gapPenalty = (isGapOpening) ? gapfirst : gapcont;

            #region CrappyCode
            if (matching != null)
                possibleScores[Directions.DIAG] = matching.Score + charsCompareResult;

            if (leftgap != null)
                possibleScores[Directions.LEFT] = leftgap.Score + gapPenalty;

            if (topgap != null)
                possibleScores[Directions.TOP] = topgap.Score + gapPenalty;
            #endregion

            if (possibleScores.Count > 0)
            {
                score = cells.getCurrent().Score = possibleScores.Values.Max();
                foreach (KeyValuePair<Directions, int> entry in possibleScores)
                    if (entry.Value == score) paths |= entry.Key;
            }

            return new Tuple<int, Directions>(score, paths);
        }
    }

    //class SimilarityMatrixScorer : Scorer
    //{

    //}

}
