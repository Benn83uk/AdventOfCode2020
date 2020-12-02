namespace AdventOfCode2020.App
{
    public class CharacterPositionPolicyFactory : IPasswordPolicyFactory
    {
        public IPasswordPolicy CreateFromString(string policy)
        {
            var splitBySpace = policy.Split(' ');
            var positionsStr = splitBySpace[0];
            var character = splitBySpace[1][0];
            var positionsSplitByDash = positionsStr.Split("-");
            var positions = new int[2];
            positions[0] = int.Parse(positionsSplitByDash[0]);
            positions[1] = int.Parse(positionsSplitByDash[1]);
            return new CharacterPositionPolicy(character, positions);
        }
    }
}