using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

public class Olympics : IOlympics
{
    Dictionary<int, Competition> competitions;
    Dictionary<int, Competitor> competitors;

    public Olympics()
    {
        competitions = new Dictionary<int, Competition>();
        competitors = new Dictionary<int, Competitor>();
    }

    public void AddCompetition(int id, string name, int score)
    {
        //Competition competition;

        if (competitions.ContainsKey(id))
        {
            throw new ArgumentException();
        }

        var competition = new Competition(name, id, score);

        //try
        //{
        //    competition = new Competition(name, id, score);
        //}
        //catch (Exception)
        //{
        //    throw new ArgumentException();
        //}

        competitions[id] = competition;
    }

    public void AddCompetitor(int id, string name)
    {
        //Competitor competitor;

        if (competitors.ContainsKey(id))
        {
            throw new ArgumentException();
        }

        var competitor = new Competitor(id, name);

        //try
        //{
        //    competitor = new Competitor(id, name);
        //}
        //catch (Exception)
        //{
        //    throw new ArgumentException();
        //}

        competitors[id] = competitor;
    }

    public void Compete(int competitorId, int competitionId)
    {
        Competitor competitor;
        Competition competition;

        //if (!competitors.ContainsKey(competitorId) || !competitions.ContainsKey(competitionId))
        //{
        //    throw new ArgumentException();
        //}

        try
        {
            competitor = competitors[competitorId];
            competition = competitions[competitionId];

            competition.Competitors.Add(competitor);
            competitor.TotalScore += competition.Score;
        }
        catch (Exception)
        {
            throw new ArgumentException();
        }

        //competitor = competitors[competitorId];
        //competition = competitions[competitionId];

        competition.Competitors.Add(competitor);
    }

    public int CompetitionsCount()
    {
        return competitions.Count;
    }

    public int CompetitorsCount()
    {
        return competitors.Count;
    }

    public bool Contains(int competitionId, Competitor comp)
    {
        Competition competition = null;

        //if (!competitions.ContainsKey(competitionId))
        //{
        //    throw new ArgumentException();
        //}

        try
        {
            competition = competitions[competitionId];
        }
        catch (Exception)
        {
            throw new ArgumentException();
        }
        //competition = competitions[competitionId];

        return !competition.Competitors.Contains(comp);
    }

    public void Disqualify(int competitionId, int competitorId)
    {
        Competitor competitor;
        Competition competition;

        try
        {
            competitor = competitors[competitorId];
            competition = competitions[competitionId];

            competition.Competitors.Remove(competitor);
            competitor.TotalScore -= competition.Score;
        }
        catch (Exception)
        {
            throw new ArgumentException();
        }
    }

    public IEnumerable<Competitor> FindCompetitorsInRange(long min, long max)
    {
        return competitors
            .Where(c => c.Value.TotalScore > min && c.Value.TotalScore <= max)
            .Select(c => c.Value)
            .OrderBy(c => c.Id);
    }

    public IEnumerable<Competitor> GetByName(string name)
    {
        var competitorsWithName = competitors
            .Where(c => c.Value.Name == name)
            .Select(c => c.Value)
            .OrderBy(c => c.Id);

        if (competitorsWithName.Count() == 0)
        {
            throw new ArgumentException();
        }

        return competitorsWithName;
    }

    public Competition GetCompetition(int id)
    {
        Competition competition;

        try
        {
            competition = competitions[id];
        }
        catch (Exception)
        {
            throw new ArgumentException();
        }

        return competition;
    }

    public IEnumerable<Competitor> SearchWithNameLength(int min, int max)
    {
        var competitorsWithName = competitors
            .Where(c => c.Value.Name.Length >= min && c.Value.Name.Length <= max)
            .Select(c => c.Value)
            .OrderBy(c => c.Id);

        return competitorsWithName;
    }
}