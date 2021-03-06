using System.Text;

namespace SimpleMu.Database.Configuration;

/// <summary>
///     Defines a reward of a <see cref="MiniGameDefinition" />.
/// </summary>
public class MiniGameReward
{
    /// <summary>
    ///     Gets or sets the rank to which this reward is applicable.
    ///     It's applicable, when more than one player can complete the mini game and
    ///     you'd want to give different awards for a differently ranked players.
    /// </summary>
    public int? Rank { get; set; }

    /// <summary>
    ///     Gets or sets the reward type.
    /// </summary>
    public MiniGameRewardType RewardType { get; set; }

    /// <summary>
    ///     Gets or sets the amount of the rewards.
    ///     In case of <see cref="MiniGameRewardType.Money" /> it's the amount of money.
    ///     In case of <see cref="MiniGameRewardType.Experience" /> it's the amount of experience.
    ///     In case of <see cref="MiniGameRewardType.Item" /> it's the amount of <see cref="ItemReward" />.
    /// </summary>
    public int RewardAmount { get; set; }

    /// <summary>
    ///     Gets or sets the <see cref="DropItemGroup" /> of this reward, if <see cref="RewardType" /> is
    ///     <see cref="MiniGameRewardType.Item" />.
    /// </summary>
    public virtual DropItemGroup? ItemReward { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        var result = new StringBuilder();
        if (Rank.HasValue)
        {
            result.Append("Rank ").Append(Rank.Value).Append(": ");
        }

        result.Append(RewardType.ToString()).Append(" ").Append(RewardAmount);

        if (ItemReward != null)
        {
            result.Append(" ").Append(ItemReward.Description);
        }

        return result.ToString();
    }
}