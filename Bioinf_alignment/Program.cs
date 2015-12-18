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
            string left = "HEAGAWGHEE";
            string up = "PAWHEAE";
            Container teh = new Container(left,up);
            BasicScorer drama = new BasicScorer(1, -1, -1, -1);
            NeedlemanWunchAligner zomg = new NeedlemanWunchAligner(teh, drama);
            Tuple<String, String> res;
            res = zomg.run();
            System.Console.WriteLine(res.Item1);
            System.Console.WriteLine(res.Item2);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
