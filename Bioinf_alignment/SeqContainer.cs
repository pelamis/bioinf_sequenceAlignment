using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bioinf_alignment
{
    [Flags]
    enum Directions: byte {
        NONE=0,
        TOP=1,
        DIAG=2,
        LEFT=4
    }

    //interface Container<T>
    //{
    //    T next();
    //    T retrieveElem(int row, int col);
    //    T retrieveCurrentIncident(Directions pos);
    //    T getCurrent();
    //}

    //interface Iterator
    //{
    //    bool isEnd();
    //    AlignmentField getCurrent();
    //    AlignmentField getIncident(Directions pos);
    //    //Iterator next();
    //}

    class AlignmentField
    {
        public int Score;
        public char Seq1char, Seq2char;
        public Directions Pathes;

        public AlignmentField()
        {
            Score = 0;
            Seq1char = (char)0;
            Seq2char = (char)0;
            Pathes = Directions.NONE;
        }
        public AlignmentField(char ch1, char ch2)
        {
            Score = 0;
            Seq1char = ch1;
            Seq2char = ch2;
            Pathes = Directions.NONE;
        }

        public AlignmentField(int score, char ch1, char ch2, Directions pathes)
        {
            Score = score;
            Seq1char = ch1;
            Seq2char = ch2;
            Pathes = pathes;
        }
    }

    class Container
    {
        private AlignmentField [,] Matrix;
        public readonly int Cols, Rows;

        public Container(String s1, String s2)
        {
            String modS1 = (char)0x0 + s1;
            String modS2 = (char)0x0 + s2;
            Cols = modS2.Length;
            Rows = modS1.Length;
            Matrix=new AlignmentField[Rows,Cols];
            for (int i = 0; i < Rows; i++)
                for (int j = 0; j < Cols; j++)
                  Matrix[i, j] = new AlignmentField(modS1[i], modS2[j]);               
        }

        public AlignmentField retrieveElem(int row, int col)
        {
            return ((row >= 0) && (row < Rows) && (col >= 0) && (col < Cols)) ? Matrix[row, col] : null;
        }

        public SerialIterator createSerialIterator()
        {
            return new SerialIterator(this);
        }

        public BacktracingIterator createBacktracingIterator()
        {
            return new BacktracingIterator(Rows - 1, Cols - 1, this);
        }

    }

    class SerialIterator
    {
        public Container Data;
        public int CurRow, CurCol;

        public SerialIterator(Container data)
        {
            this.Data = data;
            this.CurCol = this.CurRow = 0;
        }

        private SerialIterator(Container data, int row, int col)
        {
            this.Data = data;
            this.CurCol = col;
            this.CurRow = row;
        }

        public bool isEnd()
        {
            return (CurCol < Data.Cols && CurRow < Data.Rows) ? false : true;
        }

        public AlignmentField getCurrent()
        {
            return Data.retrieveElem(CurRow, CurCol);
        }

        public AlignmentField getIncident(Directions pos) 
        {
            switch (pos) {
                case Directions.LEFT: return Data.retrieveElem(CurRow, CurCol - 1);
                case Directions.TOP: return Data.retrieveElem(CurRow - 1, CurCol);
                case Directions.DIAG: return Data.retrieveElem(CurRow - 1, CurCol - 1);
            }
            return null;
        }

        public SerialIterator next()
        {
            int col = CurCol, row = CurRow;
            if (isEnd()) return this;
            if (CurCol + 1 < Data.Cols) col++;
            else
            {
                row++;
                col = 0;
            }
            return new SerialIterator(Data, row, col);
        }
    }

    class BacktracingIterator
    {
        public Container Data;
        public int CurRow, CurCol;
        public Directions pathTaken;

        public BacktracingIterator(int startcol, int startrow, Container data)
        {
            Data = data;
            pathTaken = Directions.NONE;
            CurCol = startcol;
            CurRow = startrow;
        }

        private BacktracingIterator(Container data, int row, int col, Directions newPath)
        {
            this.Data = data;
            this.CurCol = col;
            this.CurRow = row;
            this.pathTaken = newPath;
        }

        public Directions choosePath(AlignmentField cell)
        {
            if ((cell.Pathes & Directions.DIAG) != 0) return Directions.DIAG;
            if ((cell.Pathes & Directions.TOP) != 0) return Directions.TOP;
            if ((cell.Pathes & Directions.LEFT) != 0) return Directions.LEFT;
            return Directions.NONE;
        }

        public AlignmentField getCurrent()
        {
            return Data.retrieveElem(CurRow, CurCol);
        }

        public Boolean isEnd()
        {
            return (pathTaken == Directions.NONE);
        }

        public BacktracingIterator next()
        {
            int row = CurRow, col = CurCol;
            Directions newPath = Directions.NONE;
            switch (pathTaken)
            {
                case Directions.NONE: return this;
                case Directions.DIAG: { row--; col--; break;}
                case Directions.LEFT: { col--; break; }
                case Directions.TOP: { row--; break; }
            }
            newPath = choosePath(Data.retrieveElem(CurRow, CurCol));
            return new BacktracingIterator(Data, row, col, newPath);
        }
    }
}
