namespace BPMSoft.Core.Process
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Attributes;
	using BPMSoft.Core.Configuration;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Factories;
	using BPMSoft.Core.Process;
	using BPMSoft.Core.Process.Configuration;
	using BPMSoft.Web.Common;
	using BPMSoft.Web.Common.ServiceRouting;
	using Newtonsoft.Json;
	using Newtonsoft.Json.Linq;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Drawing;
	using System.Globalization;
	using System.IO;
	using System.Linq;
	using System.Text;

	#region Class: GetCustomerSspServiceListMethodsWrapper

	/// <exclude/>
	public class GetCustomerSspServiceListMethodsWrapper : ProcessModel
	{

		public GetCustomerSspServiceListMethodsWrapper(Process process)
			: base(process) {
			AddScriptTaskMethod("ScriptTaskExecute", ScriptTaskExecute);
		}

		#region Methods: Private

		private bool ScriptTaskExecute(ProcessExecutingContext context) {
			string webAppPath = AppDomain.CurrentDomain.BaseDirectory;
			string sspServicesDir = Path.Combine(webAppPath, "SspServices");
			string file = Path.Combine(sspServicesDir, "CustomerSspServiceList.txt");
			
			var userConnection = Get<UserConnection>("UserConnection");
			BPMSoft.Core.Configuration.SysWorkspace workspace = userConnection.Workspace;
			if (!workspace.IsWorkspaceAssemblyInitialized) {
				return true;
			}
			
			var collector = ClassFactory.Get<IWorkspaceAssemblyCollector>();
			var assemblies = collector.GetAssemblies(workspace, RefAssemblyMarker.ServiceRoutes);
			var loader = ClassFactory.Get<IAssemblyTypeLoader>();
			var types = loader.GetTypes(assemblies);
			var parser = new CustomServicesParser(types.ToList());
			var serviceNames = new HashSet<string>(parser.Services.Keys.Union(parser.WebServices.Keys));
			var repo = ClassFactory.Get<IServiceConfigRepository>();
			var customerServiceNames = serviceNames
				.Where(name => !repo.ContainsService(name, includeRestricted: true))
				.ToList();
			
			if (!customerServiceNames.Any()) {
				return true;
			}
			
			string header = $"# List of services appended on {DateTime.Now}";
			File.AppendAllLines(file, customerServiceNames.OrderBy(n => n).Prepend(header));
			return true;
		}

		#endregion

	}

	#endregion

}

