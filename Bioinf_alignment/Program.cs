using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bioinf_alignment
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            string butt = "GATTACA";
            string head = "ATGCGAT";
            Container teh = new Container(head,butt);
            BasicScorer drama = new BasicScorer(1, -1, -1, -1);
            NeedlemanWunchAligner zomg = new NeedlemanWunchAligner(teh, drama);

            zomg.run();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
