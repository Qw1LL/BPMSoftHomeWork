namespace BPMSoft.Configuration
{
	using System;
	using System.Text;
	using System.Collections.Generic;
	using System.Data;
	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Factories;
	using BPMSoft.Nui;
	using BPMSoft.Core.DB;

	public class SectionHelper: ISectionHelper {

		#region Methods: Public

		public string GetConfigurationScript(UserConnection userConnection) {
			var helper = ClassFactory.Get<ConfigurationSectionHelper>();
			return helper.GetConfigurationScript(userConnection);
		}

		public string GetClientUnitSchemaDescriptors(UserConnection userConnection) {
			var helper = ClassFactory.Get<ConfigurationSectionHelper>();
			return helper.GetClientUnitSchemaDescriptors(userConnection);
		}

		#endregion

	}
}

