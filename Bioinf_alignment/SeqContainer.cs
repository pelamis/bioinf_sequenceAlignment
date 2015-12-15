using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//В ячейках таблицы лежат структуры <вес <edges>>

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
                {   
                    //Console.WriteLine(s1[i - 1] + "\t" + s2[j - 1] + "\n");
                    Matrix[i, j] = new AlignmentField(modS1[i], modS2[j]); 
                    //Matrix[i, j].Seq1char = modS1[i];
                    //Matrix[i, j].Seq2char = modS2[j];
                }
        }

        public AlignmentField retrieveElem(int row, int col)
        {
            return ((row >= 0) && (row < Rows) && (col >= 0) && (col < Cols)) ? Matrix[row, col] : null;
        }

        public SerialIterator createSerialIterator()
        {
            return new SerialIterator(this);
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

        private SerialIterator(SerialIterator copying)
        {
            this.Data = copying.Data;
            this.CurCol = copying.CurCol;
            this.CurRow = copying.CurRow;
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
            if (CurCol + 1 < Data.Cols) CurCol++;
            else
            {
                CurRow++;
                CurCol = 0;
            }
            return (isEnd()) ? null : new SerialIterator(this);
        }

    }
}
