namespace BPMSoft.Configuration.EntitySynchronization
{

	#region Interface: IEqualComparatorProvider

	public interface IEqualComparatorProvider
	{

		SynchronizationColumnComparator GetStringEqualComparator();

		SynchronizationColumnComparator GetDateEqualComparator();

	}

	#endregion

}

