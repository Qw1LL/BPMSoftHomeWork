namespace BPMSoft.Configuration
{
	using System.Collections.Generic;
	using BPMSoft.Core;

	public class WorkspaceFeatures : ICompatibilityFeatures
	{
		private static readonly IList<string> _features = new List<string> {
			//"OneCoolFeature",
			//"Second New Feature",
			//"AnotherCoolFeature",
			//"Not-Very-CoolFeature",
			//"CompletelyBadFeature",
			//"New Feature",
		};

		public IList<string> GetFeatures() {
			return _features;
		}

	}
}
