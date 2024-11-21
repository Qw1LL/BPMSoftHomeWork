namespace BPMSoft.Configuration
{
	using EntitySynchronization;
	using System.Collections.Generic;
	using BPMSoft.Core;
	using BPMSoft.Core.Entities;

	#region Class: AccountAddressSynchronizer

	/// <summary>
	/// Provides methods for synchronizing account address with account.
	/// </summary>
	public class AccountAddressSynchronizer : BaseAddressSynchronizer
	{
		#region Construcors: Public

		public AccountAddressSynchronizer(UserConnection userConnection, Entity addressEntity) :
			base(userConnection, addressEntity, "Account") {
		}

		#endregion

		#region Methods: Protected

		protected override ICollection<SynchronizationColumnMapping> GetSynchronizationColumnMappings() {
			SynchronizationColumnComparator stringEqualComparator = EqualComparatorProvider.GetStringEqualComparator();
			var baseColumnMappings = base.GetSynchronizationColumnMappings();
			baseColumnMappings.Add(new SynchronizationColumnMapping {
				SourceColumnName = "GPSN",
				DestinationColumnName = "GPSN",
				Comparator = stringEqualComparator
			});
			baseColumnMappings.Add(new SynchronizationColumnMapping {
				SourceColumnName = "GPSE",
				DestinationColumnName = "GPSE",
				Comparator = stringEqualComparator
			});
			return baseColumnMappings;
		}

		#endregion
	}

	#endregion
}
