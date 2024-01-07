namespace parliament_app.Data;

public class Parliament
{
    public readonly List<Parliamentarian> Parliamentarians;
    public int CurrVotesFor;
    public int CurrVotesAgainst;
    public event EventHandler CollectingVotes = null!;
    public event EventHandler StopCollectingVotes = null!;

    public Parliament(int numberOfParliamentarians)
    {
        Parliamentarians = new List<Parliamentarian>();
        for (var i = 0; i < numberOfParliamentarians; i++)
            Parliamentarians.Add(new Parliamentarian(i, this));

        CurrVotesFor = 0;
        CurrVotesAgainst = 0;
    }

    public void VoteFor()
    {
        CurrVotesFor++;
    }

    public void VoteAgainst()
    {
        CurrVotesAgainst++;
    }

    public void StartVoting()
    {
        CollectingVotes?.Invoke(this, EventArgs.Empty);
    }

    public void StopVoting()
    {
        StopCollectingVotes?.Invoke(this, EventArgs.Empty);
    }
}