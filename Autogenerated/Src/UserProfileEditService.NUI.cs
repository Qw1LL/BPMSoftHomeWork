namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using System.ServiceModel;
	using System.ServiceModel.Activation;
	using System.ServiceModel.Web;
	using System.Runtime.Serialization;
	using BPMSoft.Common;
	using BPMSoft.Common.Json;
	using BPMSoft.Core;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.Entities;
	using BPMSoft.Web.Common;
	using BPMSoft.Web.Common.ServiceRouting;
	
	#region Class: UserProfileEditService

	[ServiceContract]
	[DefaultServiceRoute]
	[SspServiceRoute]
	[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
	public class UserProfileEditService : BaseService
	{

		#region Fields: Private
		
		/// <summary>
		/// ####### ########## ####### ##### ####### "VwSysAdminUnit".
		/// #### - ### ######## ####### #######, ######## - ### ######## #######.
		/// </summary>
		private UpdateUserProfileDto _newUserValues;
		
		#endregion

		#region Methods: Private

		private void SaveUser() {
			object primaryColumnValue = UserConnection.CurrentUser.Id;
			EntitySchema entitySchema = UserConnection.EntitySchemaManager.GetInstanceByName("VwSysAdminUnit");
			Entity entity = entitySchema.CreateEntity(UserConnection);
			entity.UseAdminRights = false;
			entity.FetchFromDB(primaryColumnValue);
			if(!string.IsNullOrEmpty(_newUserValues.Name)) {
				entity.SetColumnValue("Name", _newUserValues.Name);
			}
			if (_newUserValues.SysCulture != null) {
				entity.SetColumnValue("SysCultureId", _newUserValues.SysCulture);
			}
			if (_newUserValues.TimeZone != null) {
				entity.SetColumnValue("TimeZoneId", (_newUserValues.TimeZone.Equals(Guid.Empty)) ? null : _newUserValues.TimeZone);
			}
			if (_newUserValues.DateTimeFormat != null) {
				entity.SetColumnValue("DateTimeFormatId", (_newUserValues.DateTimeFormat.Equals(Guid.Empty)) ? null : _newUserValues.DateTimeFormat);
			}
			entity.Save(false);
		}
		
		#endregion

		#region Methods: Public
		
		/// <summary>
		/// ######### ######### # ####### SysAdminUnit ####### #############.
		/// </summary>
		/// <param name="updateUser">############### ###### ########## ####### ##### "VwSysAdminUnit".</param>
		/// <returns>##### ##########, #### ### #### ##########, ##### ###### ######.</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public string UpdateUserProfile(UpdateUserProfileDto updateUser) {
			string errorMessage = string.Empty;
			try {
				_newUserValues = updateUser ?? throw new ArgumentNullException("updateUser");
				SaveUser();
			} catch (Exception e) {
				errorMessage = e.Message;
			}
			return errorMessage;
		}
		
		#endregion
	}

	#endregion

	#region Class: UpdateUserProfileDto
	[DataContract]
	public class UpdateUserProfileDto {
		[DataMember(Name = "Name", IsRequired=false)]
		public string Name { get; set; }=string.Empty;
		[DataMember(Name = "SysCulture", IsRequired=false)]
		public Guid? SysCulture { get; set; }
		[DataMember(Name = "DateTimeFormat", IsRequired=false)]
		public Guid? DateTimeFormat { get; set; }
		[DataMember(Name = "TimeZone", IsRequired=false)]
		public Guid? TimeZone { get; set; }
	}
	#endregion
}
