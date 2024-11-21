namespace BPMSoft.Configuration
{
	using BPMSoft.Core;
	using BPMSoft.Common;
	using BPMSoft.Core.DB;
	using BPMSoft.Web.Common;
	using BPMSoft.Core.Factories;
	using BPMSoft.Web.Http.Abstractions;

	#region Class: PortalAppEventListener

	public class PortalAppEventListener: IAppEventListener
	{
		#region Methods: Public

		public void OnAppStart(AppEventContext context) {
			ClassFactory.Bind<ISectionStructureBuilder, PortalSectionStructureBuilder>(UserType.SSP.ToString());
			ClassFactory.Bind<ISectionStructureBuilder, GeneralSectionStructureBuilder>(UserType.General.ToString());
		}

		public void OnAppEnd(AppEventContext context) {
		}

		public void OnSessionStart(AppEventContext context) {
		}

		public void OnSessionEnd(AppEventContext context) {
		}

		#endregion
	}

	#endregion

	#region Class: PortalSectionStructureBuilder

	public class PortalSectionStructureBuilder: ISectionStructureBuilder
	{
		#region Methods: Public

		public void ApplyCustomConditions(string schemaName, Select select) {
			(select as Select).Join(JoinType.Inner, "SysModuleEntityInPortal")
				.On("SysModuleEntityInPortal", "SysModuleEntityId").IsEqual(schemaName, "SysModuleEntityId");
		}

		#endregion
	}

	#endregion

	#region Class: GeneralSectionStructureBuilder

	public class GeneralSectionStructureBuilder: ISectionStructureBuilder
	{
		#region Properties: Private
		
		private UserConnection UserConnection {
			get {
				 return (UserConnection)HttpContext.Current.Session["UserConnection"];
			}
		}
		
		#endregion
		
		#region Methods: Public

		public void ApplyCustomConditions(string schemaName, Select select) {
			var sysModuleEntityInPortalSelect = new Select(UserConnection)
					.Column("SysModuleEntityId")
				.From("SysModuleEntityInPortal") as Select;
			select.AddCondition(schemaName, "SysModuleEntityId", LogicalOperation.And).Not().In(sysModuleEntityInPortalSelect);
		}

		#endregion
	}

	#endregion

}
