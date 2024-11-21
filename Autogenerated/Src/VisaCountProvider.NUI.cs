namespace BPMSoft.Configuration {
	using BPMSoft.Core.DB;
	using System.Collections.Generic;
	using BPMSoft.Core;
	using System;

	#region Class: VisaCountProvider
	
	public class VisaCountProvider: INotificationProvider
	{
		
		#region Fields: Private
		
		private Dictionary<string, object> parameters;
		private UserConnection _userConnection;
		
		#endregion
		
		#region Constructors: Public
		
		public VisaCountProvider(Dictionary<string, object> parameters) {
			this.SetParameters(parameters);
		}
		
		#endregion
		
		#region Methods: Public
		
		public int GetCount() {
			Guid sysAdminUnitId = (Guid)this.parameters["sysAdminUnitId"];
			var countSelect = new Select(_userConnection).Column(Func.Count("VwVisa", "Id")).Distinct()
				.From("VwVisa")
				.Where("VisaOwnerId").IsEqual(Column.Parameter(sysAdminUnitId))
				.And("IsCanceled").IsEqual(Column.Parameter(false))
				.And("StatusId").In(
					new Select(_userConnection).Column("Id").From("VisaStatus")
						.Where("IsFinal").IsEqual(Column.Parameter(false))
				) as Select;
			int result = countSelect.ExecuteScalar<int>();
			return result;
		}
		
		public string GetRemindings() {
			return string.Empty;
		}
		
		public Select GetEntitiesSelect() {
			return null;
		}
		
		public void SetParameters(Dictionary<string, object> parameters) {
			this.parameters = parameters;
			_userConnection = (UserConnection)parameters["userConnection"];
		}
		
		#endregion
	}
	
	#endregion
}
