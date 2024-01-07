namespace parliament_app.Data;

public class Parliamentarian
{
    public readonly int Id;
    public string MadeVote;
    private bool _isVotingActive;
    private bool _alreadyVoted;
    private Parliament _parliament;

    public Parliamentarian(int id, Parliament parliament)
    {
        Id = id;
        MadeVote = "VOTE";
        _isVotingActive = false;
        _alreadyVoted = false;
        _parliament = parliament;
        _parliament.CollectingVotes += VotingIsActive;
        _parliament.StopCollectingVotes += VotingIsClosed;
    }

    public void Vote()
    {
        if (!_isVotingActive || _alreadyVoted) return;
        
        _alreadyVoted = true;
        if (new Random().Next() % 2 == 0)
        {
            MadeVote = "YES";
            _parliament.VoteFor();
        }
        else
        {
            MadeVote = "NO";
            _parliament.VoteAgainst();
        }
    }

    private void VotingIsActive(object? o, EventArgs e)
    {
        _isVotingActive = true;
    }

    private void VotingIsClosed(object? o, EventArgs e)
    {
        _alreadyVoted = false;
        _isVotingActive = false;
    }
}