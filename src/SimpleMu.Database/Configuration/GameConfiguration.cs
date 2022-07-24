using SimpleMu.Database.Configuration.Items;
using SimpleMu.Database.Entities;

namespace SimpleMu.Database.Configuration;

/// <summary>
///     Defines the game configuration.
///     A game configuration contains the whole configuration of a game, directly or indirectly.
/// </summary>
public class GameConfiguration
{
    /// <summary>
    ///     Gets or sets the maximum reachable level.
    /// </summary>
    public short MaximumLevel { get; set; }

    /// <summary>
    ///     Gets or sets the maximum reachable master level.
    /// </summary>
    public short MaximumMasterLevel { get; set; }

    /// <summary>
    ///     Gets or sets the experience rate of the game.
    /// </summary>
    public float ExperienceRate { get; set; }

    /// <summary>
    ///     Gets or sets the minimum monster level which are required to be killed
    ///     in order to gain master experience for master character classes.
    /// </summary>
    public byte MinimumMonsterLevelForMasterExperience { get; set; }

    /// <summary>
    ///     Gets or sets the information range. This defines how far players can see other game objects.
    /// </summary>
    public byte InfoRange { get; set; }

    /// <summary>
    ///     Gets or sets a value indicating whether area skills hit players.
    /// </summary>
    /// <remarks>
    ///     Usually false, during castle siege this might be true.
    /// </remarks>
    public bool AreaSkillHitsPlayer { get; set; }

    /// <summary>
    ///     Gets or sets the maximum inventory money value.
    /// </summary>
    public int MaximumInventoryMoney { get; set; }

    /// <summary>
    ///     Gets or sets the maximum vault money value.
    /// </summary>
    public int MaximumVaultMoney { get; set; }

    /// <summary>
    ///     Gets or sets the experience table. Index is the player level, value the needed experience to reach that level.
    /// </summary>
    public long[]? ExperienceTable { get; set; }

    /// <summary>
    ///     Gets or sets the master experience table. Index is the player level, value the needed experience to reach that
    ///     level.
    /// </summary>
    public long[]? MasterExperienceTable { get; set; }

    /// <summary>
    ///     Gets or sets the interval for attribute recoveries. See also
    ///     MUnique.OpenMU.GameLogic.Attributes.Stats.Regeneration.
    /// </summary>
    public int RecoveryInterval { get; set; }

    /// <summary>
    ///     Gets or sets the maximum numbers of letters a player can have in his inbox.
    /// </summary>
    public int MaximumLetters { get; set; }

    /// <summary>
    ///     Gets or sets the price of sending a letter.
    /// </summary>
    public int LetterSendPrice { get; set; }

    /// <summary>
    ///     Gets or sets the maximum number of characters per account.
    /// </summary>
    public byte MaximumCharactersPerAccount { get; set; }

    /// <summary>
    ///     Gets or sets the character name regex.
    /// </summary>
    /// <remarks>
    ///     "^[a-zA-Z0-9]{3,10}$";.
    /// </remarks>
    public string? CharacterNameRegex { get; set; }

    /// <summary>
    ///     Gets or sets the maximum length of the password.
    /// </summary>
    public int MaximumPasswordLength { get; set; }

    /// <summary>
    ///     Gets or sets the maximum size of parties.
    /// </summary>
    public byte MaximumPartySize { get; set; }

    /// <summary>
    ///     Gets or sets a value indicating whether if a monster should drop or adds money to the character directly.
    /// </summary>
    public bool ShouldDropMoney { get; set; }

    /// <summary>
    ///     Gets or sets the accumulated damage which needs to be done to decrease <see cref="Item.Durability" /> of a
    ///     defending item by 1.
    /// </summary>
    public double DamagePerOneItemDurability { get; set; }

    /// <summary>
    ///     Gets or sets the accumulated damage which needs to be done to decrease <see cref="Item.Durability" /> of a pet item
    ///     by 1.
    /// </summary>
    public double DamagePerOnePetDurability { get; set; }

    /// <summary>
    ///     Gets or sets the number of hits which needs to be done to decrease the <see cref="Item.Durability" /> of an
    ///     offensive item by 1.
    /// </summary>
    public double HitsPerOneItemDurability { get; set; }

    /// <summary>
    ///     Gets or sets the possible jewel mixes.
    /// </summary>

    public virtual ICollection<JewelMix> JewelMixes { get; protected set; } = null!;

    /// <summary>
    ///     Gets or sets the warp list.
    /// </summary>

    public virtual ICollection<WarpInfo> WarpList { get; protected set; } = null!;

    /// <summary>
    ///     Gets or sets the drop item groups which can be assigned to maps and characters.
    /// </summary>

    public virtual ICollection<DropItemGroup> DropItemGroups { get; protected set; } = null!;

    /// <summary>
    ///     Gets or sets the skills of this game configuration.
    /// </summary>

    public virtual ICollection<Skill> Skills { get; protected set; } = null!;

    /// <summary>
    ///     Gets or sets the character classes.
    /// </summary>

    public virtual ICollection<CharacterClass> CharacterClasses { get; protected set; } = null!;

    /// <summary>
    ///     Gets or sets the item definitions.
    /// </summary>

    public virtual ICollection<ItemDefinition> Items { get; protected set; } = null!;

    /// <summary>
    ///     Gets or sets the item slot types.
    /// </summary>

    public virtual ICollection<ItemSlotType> ItemSlotTypes { get; protected set; } = null!;

    /// <summary>
    ///     Gets or sets the item option definitions.
    /// </summary>

    public virtual ICollection<ItemOptionDefinition> ItemOptions { get; protected set; } = null!;

    /// <summary>
    ///     Gets or sets the item option types.
    /// </summary>

    public virtual ICollection<ItemOptionType> ItemOptionTypes { get; protected set; } = null!;

    /// <summary>
    ///     Gets or sets the item set groups.
    /// </summary>

    public virtual ICollection<ItemSetGroup> ItemSetGroups { get; protected set; } = null!;

    /// <summary>
    ///     Gets or sets the item option combination bonuses.
    /// </summary>

    public virtual ICollection<ItemOptionCombinationBonus> ItemOptionCombinationBonuses { get; protected set; } = null!;

    /// <summary>
    ///     Gets or sets the map definitions.
    /// </summary>

    public virtual ICollection<GameMapDefinition> Maps { get; protected set; } = null!;

    /// <summary>
    ///     Gets or sets the monster definitions.
    /// </summary>

    public virtual ICollection<MonsterDefinition> Monsters { get; protected set; } = null!;

    /// <summary>
    ///     Gets or sets the magic effects.
    /// </summary>

    public virtual ICollection<MagicEffectDefinition> MagicEffects { get; protected set; } = null!;

    /// <summary>
    ///     Gets or sets the master skill roots.
    /// </summary>

    public virtual ICollection<MasterSkillRoot> MasterSkillRoots { get; protected set; } = null!;

    /// <summary>
    ///     Gets or sets the event definitions.
    /// </summary>

    public virtual ICollection<MiniGameDefinition> MiniGameDefinitions { get; protected set; } = null!;
}