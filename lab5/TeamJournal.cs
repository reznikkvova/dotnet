using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    public class TeamJournal
    {
        private List<TeamJournalEntry> _teamJournalEvents;

        public void ResearchTeamAdded(object sender, TeamListHandlerEventArgs args)
        {
            if (_teamJournalEvents == null)
            {
                _teamJournalEvents = new List<TeamJournalEntry>();
            }

            _teamJournalEvents.Add(new TeamJournalEntry(args.NameCollection, args.TypeChanges, args.Position));
        }

        public void ResearchTeamInserted(object sender, TeamListHandlerEventArgs args)
        {
            if (_teamJournalEvents == null)
            {
                _teamJournalEvents = new List<TeamJournalEntry>();
            }

            _teamJournalEvents.Add(new TeamJournalEntry(args.NameCollection, args.TypeChanges, args.Position));
        }

        public override string ToString()
        {
            StringBuilder res = new StringBuilder();
            if (_teamJournalEvents != null)
            {
                foreach (TeamJournalEntry teamJournalEntry in _teamJournalEvents)
                {
                    res.Append($"{teamJournalEntry}\n");
                }

                return $"Info about all changes:\n{res}";
            }

            else
            {
                return "List is empty";
            }
        }
    }
}
