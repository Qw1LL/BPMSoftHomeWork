namespace BPMSoft.Configuration
{

	using System;

	#region Class: MatchesFound

	[Serializable]
	public class MatchesFound
	{

		#region Properties: Public

		public Guid Id{
			get;
			set;
		}

		public DateTime CreatedOn{
			get;
			set;
		}

		public Guid CreatedById{
			get;
			set;
		}

		public string CreatedByName{
			get;
			set;
		}

		public DateTime ModifiedOn{
			get;
			set;
		}

		public Guid ModifiedById{
			get;
			set;
		}

		public string ModifiedByName{
			get;
			set;
		}

		public int ProcessListeners{
			get;
			set;
		}
		
		public string SocialAccount{
			get;
			set;
		}

		public Guid SocialMediaId{
			get;
			set;
		}

		public string SocialMediaName{
			get;
			set;
		}

		public bool SetForContact{
			get;
			set;
		}

		public string PublicProfileUrl{
			get;
			set;
		}

		public string SocialId{
			get;
			set;
		}

		#endregion

	}

	#endregion

}

