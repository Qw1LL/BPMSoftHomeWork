namespace BPMSoft.Configuration.CampaignService
{
	using global::Common.Logging;
	using System;
	using System.Collections.Generic;
	using System.Linq;

	#region Class: CampaignUtilities

	public static class CampaignUtilities
	{

		#region Fields: Private

		private static readonly ILog _log = LogManager.GetLogger("CampaignService");

		#endregion

		#region Properties: Public

		/// <summary>
		/// ###### ### ########## # CampaignService.
		/// </summary>
		public static ILog Log {
			get {
				return _log;
			}
		}

		/// <summary>
		/// Splits <paramref name="number"/> into groups using <paramref name="groupSizes"/>.
		/// </summary>
		/// <param name="number">Positive integer number.</param>
		/// <param name="groupSizes">Each group should be positive integer number.</param>
		/// <returns>Array of groups corresponding to <paramref name="groupSizes"/>.</returns>
		/// <example>
		/// SplitNumberByGroups(10, new int[] { 60, 40 }) => [6,4]
		/// SplitNumberByGroups(1000, new int[] { 34, 33, 33 }) => [340,330,330]
		/// You can use an array of zeros to split number into equal groups:
		/// SplitNumberByGroups(1000, new int[] { 0, 0, 0 }) => [334,333,333]
		/// </example>
		public static int[] SplitNumberByGroups(int number, params int[] groupSizes) {
			if (number < 0 || groupSizes.Length == 0) {
				return new int[] { };
			}
			if (number == 0) {
				return Enumerable.Repeat(0, groupSizes.Length).ToArray();
			}
			if (groupSizes.Sum() == 0) {
				var quotient = number / groupSizes.Length;
				var remainder = number % groupSizes.Length;
				var resultArray = Enumerable.Repeat(quotient, groupSizes.Length).ToArray();
				for (int i = 0; i < remainder; i++) {
					resultArray[i]++;
				}
				return resultArray;
			}
			if (groupSizes.Length == 1) {
				return new[] { number };
			}
			Array.Sort(groupSizes);
			var commonGroup = groupSizes.First();
			var commonPart = number * commonGroup / groupSizes.Sum();
			var restCount = number - commonPart * groupSizes.Length;
			var result = Enumerable.Repeat(commonPart, groupSizes.Length).ToArray();
			if (commonPart == 0) {
				var nonEmptyValuesCount = Math.Min(restCount, groupSizes.Length);
				result = Enumerable.Repeat(1, nonEmptyValuesCount).ToArray();
				restCount -= groupSizes.Length;
			}
			var restPercentages = groupSizes.SkipWhile(x => x == commonGroup).Select(x => x - commonGroup).ToArray();
			if (!restPercentages.Any()) {
				restPercentages = restPercentages.Append(0).ToArray();
			}
			var parts = SplitNumberByGroups(restCount, restPercentages);
			for (int i = parts.Count() - 1; i >= 0; i--) {
				result[i] += parts[i];
			}
			result = result.Concat(Enumerable.Repeat(0, groupSizes.Length - result.Length)).ToArray();
			return result;
		}

		#endregion

	}

	#endregion

	#region Class: ObjectsDistributor

	/// <summary>
	/// Contains extension methods for objects distribution.
	/// </summary>
	public static class ObjectsDistributorExtensions
	{
		/// <summary>
		/// Distributes array of unique identifiers by groups corresponding to the relative size of each group.
		/// </summary>
		/// <param name="objects">Source array of objects to distribute.</param>
		/// <param name="groups">Groups with identifiers and size of group in percents.</param>
		/// <returns>Dictionary of distributed objects by groups.</returns>
		public static Dictionary<Guid, Guid[]> DistributeByGroups(this Guid[] objects, Dictionary<Guid, int> groups) {
			var orderedGroups = groups.OrderBy(x => new Random().Next()).OrderBy(x => x.Value).ToArray();
			var distribution = CampaignUtilities.SplitNumberByGroups(objects.Length, groups.Values.ToArray());
			Array.Sort(distribution);
			var result = new Dictionary<Guid, Guid[]>();
			var processedObjectsCount = 0;
			for (int i = 0; i < distribution.Length; i++) {
				var groupSize = distribution[i];
				var group = orderedGroups.Skip(i).Take(1).First();
				var objectsBatch = objects.Skip(processedObjectsCount).Take(groupSize);
				result.Add(group.Key, objectsBatch.ToArray());
				processedObjectsCount += objectsBatch.Count();
			}
			return result;
		}
	}

	#endregion

}
