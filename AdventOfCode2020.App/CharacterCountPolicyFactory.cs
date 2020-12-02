namespace AdventOfCode2020.App
{
    public class CharacterCountPolicyFactory : IPasswordPolicyFactory
    {
        public IPasswordPolicy CreateFromString(string policy)
        {
            var splitBySpace = policy.Split(' ');
            var range = splitBySpace[0];
            var character = splitBySpace[1][0];
            var rangeSplitByDash = range.Split("-");
            var minAppearances = int.Parse(rangeSplitByDash[0]); 
            var maxAppearances = int.Parse(rangeSplitByDash[1]);
            return new CharacterCountPolicy(character, minAppearances, maxAppearances);
        }
    }
}