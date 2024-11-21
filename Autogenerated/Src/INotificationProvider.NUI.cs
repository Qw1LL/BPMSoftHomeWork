namespace BPMSoft.Configuration {
	using BPMSoft.Core.DB;
	using System.Collections.Generic;

	#region Interface: INotificationProvider

	public interface INotificationProvider {

		#region Methods: Public

		int GetCount();
		Select GetEntitiesSelect();
		void SetParameters(Dictionary<string, object> parameters);

		#endregion

	}

	#endregion

}
