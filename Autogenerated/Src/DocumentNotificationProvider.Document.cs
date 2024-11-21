namespace BPMSoft.Configuration {
	using BPMSoft.Core.DB;
	using System.Collections.Generic;
	using BPMSoft.Core;
	using System;

	#region Class: DocumentNotificationProvider
	
	public class DocumentNotificationProvider: INotificationProvider 
	{
		#region Fields: Private
		
		private Dictionary<string, object> parameters;
		private UserConnection _userConnection;
		
		#endregion
		
		#region Constructors: Public
		
		public DocumentNotificationProvider(Dictionary<string, object> parameters) {
			this.SetParameters(parameters);
		}
		
		#endregion
		
		#region Methods: Public
		
		public int GetCount() {
			Guid sysAdminUnitId = (Guid)this.parameters["sysAdminUnitId"];
			DateTime date = (DateTime)this.parameters["dueDate"];
			var countSelect = new Select(_userConnection).Column(Func.Count("Reminding", "Id")).Distinct()
				.From("Reminding")
				.LeftOuterJoin("SysAdminUnit").On("Reminding", "ContactId").IsEqual("SysAdminUnit", "ContactId")
				.InnerJoin("Document").On("Reminding", "SubjectId").IsEqual("Document", "Id")
				.Where("RemindTime").IsLessOrEqual(Column.Parameter(date.ToUniversalTime()))
				.And("IsRead").IsEqual(Column.Parameter(false))
				.And("SysAdminUnit","Id").IsEqual(Column.Parameter(sysAdminUnitId)) as Select;
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
