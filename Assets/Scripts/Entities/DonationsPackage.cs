using System.Collections.Generic;

namespace Assets.Scripts.Entities
{
    //yes I know it would be great to have something like being sure the sum of percentages add up to 100, but THAT would be too much
    public class DonationsPackage
    {
        public readonly int Id;
        public string PackageName;
        public List<(string, float)> CausePercentages;

        public DonationsPackage(int id, string packageName, List<(string, float)> causePercentages)
        {
            Id = id;
            PackageName = packageName;
            CausePercentages = causePercentages;
        }
    }
}
