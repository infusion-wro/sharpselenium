using System;
using Selenium.PageObject.Element;

namespace Selenium.PageObject.Impl.Results.Element
{
    class ResultRow : IPlaceholdersProvider
    {
        private readonly string date;
        private readonly string tournament;
        private readonly string match;

        private ResultRow(Builder builder)
        {
            this.date = builder.Date;
            this.tournament = builder.Tournament;
            this.match = builder.Match;
        }

        public class Builder
        {
            private string date;
            private string tournament;
            private string match;

            public Builder withDate(string date)
            {
                this.date = date;
                return this;
            }

            public string Date
            {
                get { return date; }
            }

            public Builder withTournament(string tournament)
            {
                this.tournament = tournament;
                return this;
            }

            public string Tournament
            {
                get { return tournament; }
            }

            public Builder withMatch(string match)
            {
                this.match = match;
                return this;
            }

            public string Match
            {
                get { return match; }
            }

            public ResultRow create()
            {
                return new ResultRow(this);
            }

        }

        public string[] Placeholders
        {
            get
            {
                string[] placeholders = new string[3];
                placeholders[0] = date;
                placeholders[1] = tournament;
                placeholders[2] = match;
                return placeholders;
            }
        }
    }
}
