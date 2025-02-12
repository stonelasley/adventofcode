namespace Aoc2023.Day07;

public class Day07 : IDay
{
    public string SolveOne(IInputProvider inputProvider)
    {
        string[] input = inputProvider.Read();
        List<Hand> hands = input.Select(x => new Hand(x)).ToList();
        hands.Sort();
        int total = 0;
        for (int i = 0; i < hands.Count(); i++)
        {
            total += hands[i].Bid * (i + 1);
        }

        return total.ToString();
    }

    
    public string SolveTwo(IInputProvider inputProvider)
    {

        string[] input = inputProvider.Read();
        return "unsolved";
    }
}

public class Card
{
    public char Symbol { get; }
    public int Score { get; }
    
    public Card(char card)
    {
        Symbol = card;
        switch (card)
        {
            case 'T':
                Score = 10;
                break;
            case 'J':
                Score = 11;
                break;
            case 'Q':
                Score = 12;
                break;
            case 'K':
                Score = 13;
                break;
            case 'A':
                Score = 14;
                break;
            default:
                Score = int.Parse(card.ToString());
                break;
        }
        
    }
}
public class Hand : IComparable<Hand>
{
    public List<Card> Cards { get; }
    public int Bid { get; private set; }
    public HandResult Result { get; }
    
    public Hand(string input)
    {
        string[] handInfo = input.Split(' ', StringSplitOptions.TrimEntries);
        Bid = int.Parse(handInfo[1]);
        Cards = handInfo[0].ToCharArray().Select(x => new Card(x)).ToList();
        Result = CategorizeHand(Cards);
    }

    private static HandResult CategorizeHand(IReadOnlyCollection<Card> cards)
    {
        Dictionary<char, int> matches = new();
        List<Card> sortedCards = cards.OrderBy(x => x.Score).ToList();

        for (int i = 0; i < sortedCards.Count - 1; i++)
        {
            Card currentCard = sortedCards[i];
            bool matchesNext = currentCard.Score == sortedCards[i + 1].Score;
            if(matchesNext) {
                if (!matches.TryAdd(currentCard.Symbol, 2))
                {
                    matches[currentCard.Symbol]++;
                }
            }
        }

        if (matches.Keys.Count > 1)
        {
            int matchCount = matches.Values.Max();
            // full house
            if(matchCount == 3)
            {
                var scoredCardSymbol = matches.First(x => x.Value == 3).Key;
                Card card = sortedCards.First(x => x.Symbol == scoredCardSymbol);
                return new HandResult(HandType.FullHouse, card.Score);
            }
            // 2 pair
            if(matchCount == 2)
            {
                var pairCards = matches.Keys.Select(x => new Card(x)).Max(x => x.Score);
                return new HandResult(HandType.TwoPair, pairCards);
            }
        }
        else if (matches.Keys.Count == 1)
        {
            int matchCount = matches.Values.Max();
            // 5 of a kind
            if (matchCount == 5)
            {
                return new HandResult(HandType.FiveOfAKind, sortedCards.Max(x => x.Score));
            }
            // 4 of a kind
            if (matchCount == 4)
            {
                var scoredCardSymbol = matches.First(x => x.Value == 4).Key;
                Card card = sortedCards.First(x => x.Symbol == scoredCardSymbol);
                return new HandResult(HandType.FourOfAKind, card.Score);
            }
            // 3 of a kind
            if (matchCount == 3)
            {
                var scoredCardSymbol = matches.First(x => x.Value == 3).Key;
                Card card = sortedCards.First(x => x.Symbol == scoredCardSymbol);
                return new HandResult(HandType.ThreeOfAKind, card.Score);
            }
            // 1 pair
            if (matchCount == 2)
            {
                var scoredCardSymbol = matches.First(x => x.Value == 2).Key;
                Card card = sortedCards.First(x => x.Symbol == scoredCardSymbol);
                return new HandResult(HandType.OnePair, card.Score);
            }
        }
        // high card
        return new HandResult(HandType.HighCard, sortedCards.Max(x => x.Score));
    }
    public int CompareTo(Hand? other)
    {
        if (other == null)
        {
            return 1;
        }
        if (Result.HandType != other.Result.HandType)
        {
            return Result.HandType - other.Result.HandType;
        }

        for (int i = 0; i < Cards.Count; i++)
        {
            Card otherCard = other.Cards[i];
            Card card = Cards[i];
            if (card.Score != otherCard.Score)
            {
                return card.Score - otherCard.Score;
            }
        }

        return 0;
    }
}

public enum HandType
{
    HighCard,
    OnePair,
    TwoPair,
    ThreeOfAKind,
    FullHouse,
    FourOfAKind,
    FiveOfAKind
}

public record HandResult(HandType HandType, int Score)
{
    public int Rank = ((int)HandType + 1) * Score;
}