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
      
        public Tuple<int,Directions> calcScoreAndPaths(SerialIterator cells, Boolean isGapOpening)
        {
            AlignmentField[] incidCells = new AlignmentField[3] {   cells.getIncident(Directions.DIAG),
                                                                    cells.getIncident(Directions.TOP),
                                                                    cells.getIncident(Directions.LEFT) };
            Dictionary<Directions,int> possibleScores = new Dictionary<Directions,int>();           
            int gapPenalty = (isGapOpening) ? gapfirst : gapcont,
                charsCompareResult = (cells.getCurrent().leftSeqChar == cells.getCurrent().upSeqChar) ? match : mismatch, 
                score = 0;         
            Directions paths = Directions.NONE;          
            Directions[] cellOrder = new Directions[3] {Directions.DIAG, Directions.TOP, Directions.LEFT};
            Func<int,int>[] cellScorers = new Func<int, int>[3] { s => s + charsCompareResult, s => s + gapPenalty, s => s + gapPenalty};
            
            for (int i = 0; i < 3; i++)
                if (incidCells[i] != null) possibleScores[cellOrder[i]] = cellScorers[i](incidCells[i].Score);
     
            #region CrappyCode        
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
