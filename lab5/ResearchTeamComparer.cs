using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    public class ResearchTeamComparer : IComparer<ResearchTeam>
    {
        public int Compare(ResearchTeam a, ResearchTeam b)
        {
            if (a.Papers == null && a.Papers == null)
            {
                return 0;
            }
            else
            {
                return a.Papers.Count.CompareTo(b.Papers.Count);
            }
        }
    }
}
