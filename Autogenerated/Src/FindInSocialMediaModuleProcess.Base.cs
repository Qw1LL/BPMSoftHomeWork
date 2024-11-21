namespace BPMSoft.Core.Process
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Process;
	using BPMSoft.Core.Process.Configuration;
	using BPMSoft.Core.Store;
	using BPMSoft.Social;
	using Newtonsoft.Json;
	using Newtonsoft.Json.Linq;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Drawing;
	using System.Globalization;
	using System.Text;

	#region Class: FindInSocialMediaModuleProcessSchema

	/// <exclude/>
	public class FindInSocialMediaModuleProcessSchema : BPMSoft.Core.Process.ProcessSchema
	{

		#region Constructors: Public

		public FindInSocialMediaModuleProcessSchema(ProcessSchemaManager processSchemaManager)
			: base(processSchemaManager) {
		}

		public FindInSocialMediaModuleProcessSchema(FindInSocialMediaModuleProcessSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			Name = "FindInSocialMediaModuleProcess";
			UId = new Guid("d389027a-6008-40cd-b17b-623d1d1344c1");
			CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			CreatedInSchemaUId = Guid.Empty;
			CreatedInVersion = @"0.0.0.0";
			CultureName = @"en-US";
			EntitySchemaUId = Guid.Empty;
			IsCreatedInSvg = true;
			IsLogging = false;
			MaxLoopCount = 101;
			ModifiedInSchemaUId = Guid.Empty;
			ParametersEditPageSchemaUId = Guid.Empty;
			ParentSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d");
			SequenceFlowStrokeDefColor = Color.FromArgb(-4473925);
			SerializeToDB = false;
			SerializeToMemory = true;
			TaskFillDefColor = Color.FromArgb(-1);
			UsageType = ProcessSchemaUsageType.Advanced;
			ZipMethodsBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 };
			ZipCompiledMethodsBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,165,146,81,107,194,48,16,199,159,13,244,59,100,62,181,32,253,2,101,15,107,183,74,97,14,81,183,151,177,135,152,94,53,152,94,198,245,162,136,248,221,87,173,99,234,131,48,188,135,144,220,229,126,255,228,159,4,226,219,207,173,209,114,109,136,189,178,50,29,143,166,174,226,56,115,88,153,133,39,197,198,225,97,197,74,179,28,2,159,166,97,36,119,129,232,173,21,73,221,101,166,122,9,181,146,143,242,189,1,106,119,33,232,99,239,11,178,225,109,87,29,41,84,11,160,184,229,20,216,176,66,13,233,246,77,213,16,246,79,220,126,148,136,51,104,139,187,192,199,25,129,98,232,152,225,165,82,36,85,115,251,252,137,152,59,103,101,5,172,151,19,104,188,61,227,199,249,33,155,147,171,159,211,240,82,115,76,166,86,180,205,156,245,53,14,228,83,171,182,134,25,1,12,201,148,153,39,2,228,137,219,20,229,64,34,108,62,191,228,78,200,219,113,117,167,35,184,137,115,131,101,122,146,249,80,214,67,231,204,97,236,71,3,209,235,226,191,237,179,141,97,6,42,202,59,24,175,6,87,80,22,120,23,36,87,26,90,255,87,29,228,218,146,125,251,240,166,146,225,195,217,235,68,71,35,255,190,2,122,107,19,177,23,4,236,9,127,11,73,32,246,129,8,196,15,132,77,137,169,204,2,0,0 };
			RealUId = new Guid("d389027a-6008-40cd-b17b-623d1d1344c1");
			Version = 0;
			PackageUId = new Guid("5be3998b-c5c3-42bb-a01c-2e4149059a97");
			UseSystemSecurityContext = false;
		}

		protected virtual ProcessSchemaParameter CreatePageInstanceIdParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("5395b142-e19d-4404-9832-d0dd0018dc8a"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("d389027a-6008-40cd-b17b-623d1d1344c1"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("d389027a-6008-40cd-b17b-623d1d1344c1"),
				Name = @"PageInstanceId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Text"),
			};
		}

		protected virtual ProcessSchemaParameter CreateActiveTreeGridCurrentRowIdParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("b16d44d3-07fb-4a3f-9150-1d70ebfcc516"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("d389027a-6008-40cd-b17b-623d1d1344c1"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("d389027a-6008-40cd-b17b-623d1d1344c1"),
				Name = @"ActiveTreeGridCurrentRowId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Guid"),
			};
		}

		protected virtual ProcessSchemaParameter CreateSocialUsersKeyParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("cec9d094-514a-47ec-943c-abcaee182be1"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("d389027a-6008-40cd-b17b-623d1d1344c1"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("d389027a-6008-40cd-b17b-623d1d1344c1"),
				Name = @"SocialUsersKey",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Text"),
			};
		}

		protected virtual ProcessSchemaParameter CreateSocialNetworksParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("856f4570-e2c1-421a-8b36-1ca4fdc9ffca"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("d389027a-6008-40cd-b17b-623d1d1344c1"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("d389027a-6008-40cd-b17b-623d1d1344c1"),
				Name = @"SocialNetworks",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Text"),
			};
		}

		protected virtual ProcessSchemaParameter CreateSearchCriteriaParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("24e84ec1-16cf-46da-8db6-13db647a3fd2"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("d389027a-6008-40cd-b17b-623d1d1344c1"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("d389027a-6008-40cd-b17b-623d1d1344c1"),
				Name = @"SearchCriteria",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Text"),
			};
		}

		protected virtual ProcessSchemaParameter CreateMatchesFoundPageUIdParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("fa5b71ac-faa8-480c-863b-78eedcb9e206"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("d389027a-6008-40cd-b17b-623d1d1344c1"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("d389027a-6008-40cd-b17b-623d1d1344c1"),
				Name = @"MatchesFoundPageUId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Guid"),
			};
		}

		protected virtual ProcessSchemaParameter CreateHeightParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("d9c957b1-ccc6-4858-98d6-88e8e3300945"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("d389027a-6008-40cd-b17b-623d1d1344c1"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("d389027a-6008-40cd-b17b-623d1d1344c1"),
				Name = @"Height",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Integer"),
				SourceValue = new ProcessSchemaParameterValue() {
					Source = ProcessSchemaParameterValueSource.Script,
					Value = @"350",
					MetaPath = null,
					ModifiedInSchemaUId = new Guid("d389027a-6008-40cd-b17b-623d1d1344c1"),
				},
			};
		}

		protected virtual ProcessSchemaParameter CreateWidthParameter() {
			return new ProcessSchemaParameter(this) {
			UId = new Guid("353019c4-47a0-4f83-b00f-3c00a7c5e9be"),
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("d389027a-6008-40cd-b17b-623d1d1344c1"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("d389027a-6008-40cd-b17b-623d1d1344c1"),
				Name = @"Width",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Integer"),
				SourceValue = new ProcessSchemaParameterValue() {
					Source = ProcessSchemaParameterValueSource.Script,
					Value = @"550",
					MetaPath = null,
					ModifiedInSchemaUId = new Guid("d389027a-6008-40cd-b17b-623d1d1344c1"),
				},
			};
		}

		protected override void InitializeParameters() {
			base.InitializeParameters();
			Parameters.Add(CreatePageInstanceIdParameter());
			Parameters.Add(CreateActiveTreeGridCurrentRowIdParameter());
			Parameters.Add(CreateSocialUsersKeyParameter());
			Parameters.Add(CreateSocialNetworksParameter());
			Parameters.Add(CreateSearchCriteriaParameter());
			Parameters.Add(CreateMatchesFoundPageUIdParameter());
			Parameters.Add(CreateHeightParameter());
			Parameters.Add(CreateWidthParameter());
		}

		protected virtual void InitializeOpenMatchFoundWindowUserTaskParameters(IParametrizedProcessSchemaElement parametrizedElement) {
			var pageUIdParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("e2e21ba3-bb6d-4e10-bce5-4bf650d7b7ba"),
				ContainerUId = new Guid("e1632db6-b725-48a3-8c30-3e992b0923af"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b7042ef4-f468-443e-b3ea-39ebbda1c828"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b7042ef4-f468-443e-b3ea-39ebbda1c828"),
				Name = @"PageUId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Guid")
			};
			pageUIdParameter.SourceValue = new ProcessSchemaParameterValue(pageUIdParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(pageUIdParameter);
			var pageUrlParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("e594e5b0-c983-486b-9113-8c72c303d9e0"),
				ContainerUId = new Guid("e1632db6-b725-48a3-8c30-3e992b0923af"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b7042ef4-f468-443e-b3ea-39ebbda1c828"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b7042ef4-f468-443e-b3ea-39ebbda1c828"),
				Name = @"PageUrl",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Text")
			};
			pageUrlParameter.SourceValue = new ProcessSchemaParameterValue(pageUrlParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(pageUrlParameter);
			var openerInstanceIdParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("7452b4c9-d854-4ac1-9357-9fef2d645f5b"),
				ContainerUId = new Guid("e1632db6-b725-48a3-8c30-3e992b0923af"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b7042ef4-f468-443e-b3ea-39ebbda1c828"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b7042ef4-f468-443e-b3ea-39ebbda1c828"),
				Name = @"OpenerInstanceId",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Text")
			};
			openerInstanceIdParameter.SourceValue = new ProcessSchemaParameterValue(openerInstanceIdParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(openerInstanceIdParameter);
			var closeOpenerOnLoadParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("c02dadae-f305-4ee0-b2a3-d048ef78be5b"),
				ContainerUId = new Guid("e1632db6-b725-48a3-8c30-3e992b0923af"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b7042ef4-f468-443e-b3ea-39ebbda1c828"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b7042ef4-f468-443e-b3ea-39ebbda1c828"),
				Name = @"CloseOpenerOnLoad",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Boolean")
			};
			closeOpenerOnLoadParameter.SourceValue = new ProcessSchemaParameterValue(closeOpenerOnLoadParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(closeOpenerOnLoadParameter);
			var pageParametersParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("54158a13-96c0-4e28-bfee-17cd7c98e909"),
				ContainerUId = new Guid("e1632db6-b725-48a3-8c30-3e992b0923af"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b7042ef4-f468-443e-b3ea-39ebbda1c828"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b7042ef4-f468-443e-b3ea-39ebbda1c828"),
				Name = @"PageParameters",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Object")
			};
			pageParametersParameter.SourceValue = new ProcessSchemaParameterValue(pageParametersParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(pageParametersParameter);
			var widthParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("9862e552-2baf-420c-84aa-51b1c5b87a08"),
				ContainerUId = new Guid("e1632db6-b725-48a3-8c30-3e992b0923af"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b7042ef4-f468-443e-b3ea-39ebbda1c828"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b7042ef4-f468-443e-b3ea-39ebbda1c828"),
				Name = @"Width",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Integer")
			};
			widthParameter.SourceValue = new ProcessSchemaParameterValue(widthParameter) {
				Source = ProcessSchemaParameterValueSource.Script,
				Value = @"[#[IsOwnerSchema:false].[IsSchema:false].[Parameter:{353019c4-47a0-4f83-b00f-3c00a7c5e9be}]#]",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("d389027a-6008-40cd-b17b-623d1d1344c1")
			};
			parametrizedElement.Parameters.Add(widthParameter);
			var closeMessageParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("4f217434-6d17-4938-b1bf-a28f71b418b5"),
				ContainerUId = new Guid("e1632db6-b725-48a3-8c30-3e992b0923af"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b7042ef4-f468-443e-b3ea-39ebbda1c828"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b7042ef4-f468-443e-b3ea-39ebbda1c828"),
				Name = @"CloseMessage",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Text")
			};
			closeMessageParameter.SourceValue = new ProcessSchemaParameterValue(closeMessageParameter) {
				Source = ProcessSchemaParameterValueSource.ConstValue,
				Value = @"MatchFoundWindowClosed",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("d389027a-6008-40cd-b17b-623d1d1344c1")
			};
			parametrizedElement.Parameters.Add(closeMessageParameter);
			var heightParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("f7c8b17a-e5aa-40eb-845f-3655c06d1dc1"),
				ContainerUId = new Guid("e1632db6-b725-48a3-8c30-3e992b0923af"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b7042ef4-f468-443e-b3ea-39ebbda1c828"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b7042ef4-f468-443e-b3ea-39ebbda1c828"),
				Name = @"Height",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Integer")
			};
			heightParameter.SourceValue = new ProcessSchemaParameterValue(heightParameter) {
				Source = ProcessSchemaParameterValueSource.Script,
				Value = @"[#[IsOwnerSchema:false].[IsSchema:false].[Parameter:{d9c957b1-ccc6-4858-98d6-88e8e3300945}]#]",
				MetaPath = null,
				ModifiedInSchemaUId = new Guid("d389027a-6008-40cd-b17b-623d1d1344c1")
			};
			parametrizedElement.Parameters.Add(heightParameter);
			var centeredParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("22fbda9a-a82c-4aeb-a709-630d00e56f66"),
				ContainerUId = new Guid("e1632db6-b725-48a3-8c30-3e992b0923af"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b7042ef4-f468-443e-b3ea-39ebbda1c828"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b7042ef4-f468-443e-b3ea-39ebbda1c828"),
				Name = @"Centered",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Object")
			};
			centeredParameter.SourceValue = new ProcessSchemaParameterValue(centeredParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(centeredParameter);
			var useOpenerRegisterScriptParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("4a197821-213b-4f40-95f9-76b973066fe0"),
				ContainerUId = new Guid("e1632db6-b725-48a3-8c30-3e992b0923af"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b7042ef4-f468-443e-b3ea-39ebbda1c828"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b7042ef4-f468-443e-b3ea-39ebbda1c828"),
				Name = @"UseOpenerRegisterScript",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Boolean")
			};
			useOpenerRegisterScriptParameter.SourceValue = new ProcessSchemaParameterValue(useOpenerRegisterScriptParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(useOpenerRegisterScriptParameter);
			var useCurrentActivePageParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("7b935efe-de49-4f8b-9fc5-6a0df3434963"),
				ContainerUId = new Guid("e1632db6-b725-48a3-8c30-3e992b0923af"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b7042ef4-f468-443e-b3ea-39ebbda1c828"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b7042ef4-f468-443e-b3ea-39ebbda1c828"),
				Name = @"UseCurrentActivePage",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Boolean")
			};
			useCurrentActivePageParameter.SourceValue = new ProcessSchemaParameterValue(useCurrentActivePageParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(useCurrentActivePageParameter);
			var ignoreProfileParameter = new ProcessSchemaParameter(this) {
				UId = new Guid("55f3d967-cdbc-4274-a41b-a3b1936260fa"),
				ContainerUId = new Guid("e1632db6-b725-48a3-8c30-3e992b0923af"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = Guid.Empty,
				CreatedInSchemaUId = new Guid("b7042ef4-f468-443e-b3ea-39ebbda1c828"),
				Direction = ProcessSchemaParameterDirection.Variable,
				IsCopyValue = false,
				IsLazy = false,
				IsPerformer = false,
				IsRequired = false,
				IsResult = false,
				IsValueSerializable = true,
				ModifiedInSchemaUId = new Guid("b7042ef4-f468-443e-b3ea-39ebbda1c828"),
				Name = @"IgnoreProfile",
				SourceParameterUId = Guid.Empty,
				Tag = @"",
				UseBackgroundMode = false,
				DataValueType = DataValueTypeManager.GetInstanceByName("Boolean")
			};
			ignoreProfileParameter.SourceValue = new ProcessSchemaParameterValue(ignoreProfileParameter) {
				Source = ProcessSchemaParameterValueSource.None,
				Value = null,
				MetaPath = null,
				ModifiedInSchemaUId = Guid.Empty
			};
			parametrizedElement.Parameters.Add(ignoreProfileParameter);
		}

		protected override void InitializeBaseElements() {
			base.InitializeBaseElements();
			ProcessSchemaLaneSet schemaLaneSet31 = CreateLaneSet31LaneSet();
			LaneSets.Add(schemaLaneSet31);
			ProcessSchemaLane schemaLane94 = CreateLane94Lane();
			schemaLaneSet31.Lanes.Add(schemaLane94);
			ProcessSchemaEventSubProcess eventsubprocess1 = CreateEventSubProcess1EventSubProcess();
			FlowElements.Add(eventsubprocess1);
			ProcessSchemaStartEvent start1 = CreateStart1StartEvent();
			FlowElements.Add(start1);
			ProcessSchemaScriptTask prepareopenmatchfoundwindowscripttask = CreatePrepareOpenMatchFoundWindowScriptTaskScriptTask();
			FlowElements.Add(prepareopenmatchfoundwindowscripttask);
			ProcessSchemaUserTask openmatchfoundwindowusertask = CreateOpenMatchFoundWindowUserTaskUserTask();
			FlowElements.Add(openmatchfoundwindowusertask);
			ProcessSchemaStartMessageEvent matchfoundwindowclosedmessage = CreateMatchFoundWindowClosedMessageStartMessageEvent();
			eventsubprocess1.FlowElements.Add(matchfoundwindowclosedmessage);
			ProcessSchemaScriptTask setsocialuserscripttask = CreateSetSocialUserScriptTaskScriptTask();
			eventsubprocess1.FlowElements.Add(setsocialuserscripttask);
			FlowElements.Add(CreateSequenceFlow329SequenceFlow());
			FlowElements.Add(CreateSequenceFlow1SequenceFlow());
			FlowElements.Add(CreateSequenceFlow2SequenceFlow());
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow329SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow329",
				UId = new Guid("18e153ad-338d-47ee-9a38-8f0643fcabfb"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("d389027a-6008-40cd-b17b-623d1d1344c1"),
				CurveCenterPosition = new Point(458, 352),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("d389027a-6008-40cd-b17b-623d1d1344c1"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("b4f8958c-2ef7-4cbd-9859-beabc5f460b9"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("e1632db6-b725-48a3-8c30-3e992b0923af"),
				TargetSequenceFlowPointLocalPosition = new Point(0, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow1SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow1",
				UId = new Guid("2c881e09-aade-4636-a438-52845d440ee3"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("d389027a-6008-40cd-b17b-623d1d1344c1"),
				CurveCenterPosition = new Point(181, 196),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("d389027a-6008-40cd-b17b-623d1d1344c1"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("74c6050a-d695-4efc-aa2f-1f3106bfaa82"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("b4f8958c-2ef7-4cbd-9859-beabc5f460b9"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaSequenceFlow CreateSequenceFlow2SequenceFlow() {
			ProcessSchemaSequenceFlow schemaFlow = new ProcessSchemaSequenceFlow(this, ProcessSchemaEditSequenceFlowType.Sequence) {
				Name = "SequenceFlow2",
				UId = new Guid("482ac04a-5f7d-4f0e-85f2-3f6e8262a1dd"),
				ContainerItemIndex = 0,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("d389027a-6008-40cd-b17b-623d1d1344c1"),
				CurveCenterPosition = new Point(220, 349),
				DragGroupName = @"SequenceFlow",
				FlowType = ProcessSchemaEditSequenceFlowType.Sequence,
				ManagerItemUId = new Guid("0d8351f6-c2f4-4737-bdd9-6fbfe0837fec"),
				ModifiedInSchemaUId = new Guid("d389027a-6008-40cd-b17b-623d1d1344c1"),
				SequenceFlowEndPointPosition = new Point(0, 0),
				SequenceFlowStartPointPosition = new Point(0, 0),
				Size = new Size(0, 0),
				SourceRefUId = new Guid("90430d45-296a-4ef2-b727-db8ba2de0d37"),
				SourceSequenceFlowPointLocalPosition = new Point(0, 0),
				StrokeColor = Color.FromArgb(-7105128),
				TargetRefUId = new Guid("85d15b6f-b750-4a1e-8403-d7b4d9aa285b"),
				TargetSequenceFlowPointLocalPosition = new Point(-1, 0),
				UseBackgroundMode = false,
				VisualType = ProcessSchemaSequenceFlowVisualType.AutoPolyline
			};
			return schemaFlow;
		}

		protected virtual ProcessSchemaLaneSet CreateLaneSet31LaneSet() {
			ProcessSchemaLaneSet schemaLaneSet31 = new ProcessSchemaLaneSet(this) {
				UId = new Guid("05e99a05-3dd4-4940-b564-1e6281152e95"),
				ContainerItemIndex = 1,
				ContainerUId = Guid.Empty,
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("d389027a-6008-40cd-b17b-623d1d1344c1"),
				Direction = ProcessSchemaPoolDirectionType.Vertical,
				DragGroupName = @"LaneSet",
				ManagerItemUId = new Guid("11a47caf-a0d5-41fa-a274-a0b11f77447a"),
				ModifiedInSchemaUId = new Guid("d389027a-6008-40cd-b17b-623d1d1344c1"),
				Name = @"LaneSet31",
				Position = new Point(5, 5),
				Size = new Size(0, 0),
				UseBackgroundMode = false
			};
			return schemaLaneSet31;
		}

		protected virtual ProcessSchemaLane CreateLane94Lane() {
			ProcessSchemaLane schemaLane94 = new ProcessSchemaLane(this) {
				UId = new Guid("17373d58-8938-4877-beee-b6dd74a95f65"),
				ContainerItemIndex = 1,
				ContainerUId = new Guid("05e99a05-3dd4-4940-b564-1e6281152e95"),
				CreatedInOwnerSchemaUId = Guid.Empty,
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("d389027a-6008-40cd-b17b-623d1d1344c1"),
				DragGroupName = @"Lane",
				ManagerItemUId = new Guid("abcd74b9-5912-414b-82ac-f1aa4dcd554e"),
				ModifiedInSchemaUId = new Guid("d389027a-6008-40cd-b17b-623d1d1344c1"),
				Name = @"Lane94",
				Position = new Point(29, 0),
				Size = new Size(0, 0),
				UseBackgroundMode = false
			};
			return schemaLane94;
		}

		protected virtual ProcessSchemaStartEvent CreateStart1StartEvent() {
			ProcessSchemaStartEvent schemaStartEvent = new ProcessSchemaStartEvent(this) {
				UId = new Guid("74c6050a-d695-4efc-aa2f-1f3106bfaa82"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("17373d58-8938-4877-beee-b6dd74a95f65"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("d389027a-6008-40cd-b17b-623d1d1344c1"),
				DragGroupName = @"Event",
				EntitySchemaUId = Guid.Empty,
				IsInterrupting = false,
				IsLogging = true,
				ManagerItemUId = new Guid("53818048-7868-48f6-ada0-0ebaa65af628"),
				ModifiedInSchemaUId = new Guid("d389027a-6008-40cd-b17b-623d1d1344c1"),
				Name = @"Start1",
				Position = new Point(49, 39),
				SerializeToDB = false,
				Size = new Size(27, 27),
				UseBackgroundMode = false
			};
			
			return schemaStartEvent;
		}

		protected virtual ProcessSchemaScriptTask CreatePrepareOpenMatchFoundWindowScriptTaskScriptTask() {
			ProcessSchemaScriptTask ScriptTask = new ProcessSchemaScriptTask(this) {
				UId = new Guid("b4f8958c-2ef7-4cbd-9859-beabc5f460b9"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("17373d58-8938-4877-beee-b6dd74a95f65"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("d389027a-6008-40cd-b17b-623d1d1344c1"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				ImageList = null,
				ImageName = null,
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("0e490dda-e140-4441-b600-6f5c64d024df"),
				ModifiedInSchemaUId = new Guid("d389027a-6008-40cd-b17b-623d1d1344c1"),
				Name = @"PrepareOpenMatchFoundWindowScriptTask",
				Position = new Point(160, 25),
				SerializeToDB = false,
				Size = new Size(69, 55),
				UseBackgroundMode = false,
				UseFlowEngineScriptVersion = false,
				ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,133,146,111,79,194,48,16,198,95,187,79,209,244,21,139,176,240,199,9,6,53,33,40,134,40,72,2,196,215,71,123,64,51,104,73,219,177,16,227,119,183,219,208,129,153,225,213,118,119,207,239,185,107,175,98,73,42,35,176,108,141,102,160,98,201,39,176,194,249,144,7,67,243,188,221,217,67,197,247,201,167,119,85,162,32,15,68,98,66,94,98,193,43,180,209,172,215,23,172,25,214,96,113,219,174,221,132,172,83,187,91,46,160,214,108,215,91,192,58,97,189,21,54,168,223,245,190,188,61,104,194,148,180,192,172,115,120,65,219,207,131,138,171,166,181,29,104,216,162,69,109,142,13,158,4,179,66,73,208,135,123,99,181,144,171,42,201,191,143,41,50,85,76,192,102,110,156,254,21,15,14,161,166,200,80,114,157,205,23,140,49,201,230,244,131,153,154,102,112,202,22,173,130,30,119,135,56,241,162,85,114,238,92,38,71,208,108,221,215,194,165,4,56,226,120,172,96,236,100,255,218,143,209,38,74,71,78,78,123,155,13,45,209,205,18,97,93,52,228,39,150,191,185,18,253,0,24,46,148,138,206,128,34,89,66,188,9,25,33,31,202,51,162,72,58,226,125,135,50,219,121,182,241,15,33,185,74,210,171,152,129,137,130,226,1,148,60,139,238,101,118,114,186,226,98,182,11,100,90,116,55,32,141,5,201,48,107,255,19,92,110,235,126,250,177,214,40,109,207,189,166,189,27,97,133,206,192,234,24,47,144,253,141,50,56,66,99,114,130,254,21,102,117,78,187,158,70,27,107,153,91,126,3,245,183,166,38,85,3,0,0 }
			};
			
			return ScriptTask;
		}

		protected virtual ProcessSchemaUserTask CreateOpenMatchFoundWindowUserTaskUserTask() {
			ProcessSchemaUserTask schemaTask = new ProcessSchemaUserTask(this) {
				UId = new Guid("e1632db6-b725-48a3-8c30-3e992b0923af"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("17373d58-8938-4877-beee-b6dd74a95f65"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("d389027a-6008-40cd-b17b-623d1d1344c1"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("1418e61a-82c3-403e-8221-01088f52c125"),
				ModifiedInSchemaUId = new Guid("d389027a-6008-40cd-b17b-623d1d1344c1"),
				Name = @"OpenMatchFoundWindowUserTask",
				Position = new Point(291, 25),
				SchemaUId = new Guid("b7042ef4-f468-443e-b3ea-39ebbda1c828"),
				SerializeToDB = false,
				Size = new Size(69, 55),
				UseBackgroundMode = false,
			ZipAfterActivitySaveScript = new byte[] { 31,139,8,0,0,0,0,0,0,10,3,0,0,0,0,0,0,0,0,0 }
			};
			InitializeOpenMatchFoundWindowUserTaskParameters(schemaTask);
			return schemaTask;
		}

		protected virtual ProcessSchemaEventSubProcess CreateEventSubProcess1EventSubProcess() {
			ProcessSchemaEventSubProcess schemaEventSubProcess1 = new ProcessSchemaEventSubProcess(this) {
				UId = new Guid("6efae6cc-9cc3-4eb3-9ab6-a849f8b0980a"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("17373d58-8938-4877-beee-b6dd74a95f65"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("d389027a-6008-40cd-b17b-623d1d1344c1"),
				DragGroupName = @"EventSubProcess",
				EntitySchemaUId = Guid.Empty,
				IsExpanded = true,
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("0824af03-1340-47a3-8787-ef542f566992"),
				ModifiedInSchemaUId = new Guid("d389027a-6008-40cd-b17b-623d1d1344c1"),
				Name = @"EventSubProcess1",
				Position = new Point(49, 126),
				SchemaUId = Guid.Empty,
				SerializeToDB = false,
				Size = new Size(294, 154),
				TriggeredByEvent = true,
				UseBackgroundMode = false,
				UseLastSchemaVersion = false
			};
			
			return schemaEventSubProcess1;
		}

		protected virtual ProcessSchemaStartMessageEvent CreateMatchFoundWindowClosedMessageStartMessageEvent() {
			ProcessSchemaStartMessageEvent schemaStartMessageEvent = new ProcessSchemaStartMessageEvent(this) {
				UId = new Guid("90430d45-296a-4ef2-b727-db8ba2de0d37"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("6efae6cc-9cc3-4eb3-9ab6-a849f8b0980a"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("d389027a-6008-40cd-b17b-623d1d1344c1"),
				DragGroupName = @"Event",
				EntitySchemaUId = Guid.Empty,
				ImageList = null,
				ImageName = null,
				IsInterrupting = false,
				IsLogging = true,
				ManagerItemUId = new Guid("02340c80-8e75-4f7a-917b-04125bc07192"),
				Message = @"MatchFoundWindowClosed",
				ModifiedInSchemaUId = new Guid("d389027a-6008-40cd-b17b-623d1d1344c1"),
				Name = @"MatchFoundWindowClosedMessage",
				Position = new Point(35, 56),
				SerializeToDB = false,
				Size = new Size(27, 27),
				UseBackgroundMode = false
			};
			
			return schemaStartMessageEvent;
		}

		protected virtual ProcessSchemaScriptTask CreateSetSocialUserScriptTaskScriptTask() {
			ProcessSchemaScriptTask ScriptTask = new ProcessSchemaScriptTask(this) {
				UId = new Guid("85d15b6f-b750-4a1e-8403-d7b4d9aa285b"),
				ContainerItemIndex = 0,
				ContainerUId = new Guid("6efae6cc-9cc3-4eb3-9ab6-a849f8b0980a"),
				CreatedInOwnerSchemaUId = new Guid("bb4d6607-026b-4b27-b640-8f5c77c1e89d"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("d389027a-6008-40cd-b17b-623d1d1344c1"),
				DragGroupName = @"Task",
				EntitySchemaUId = Guid.Empty,
				FillColor = Color.FromArgb(-1),
				ImageList = null,
				ImageName = null,
				IsForCompensation = false,
				IsLogging = true,
				ManagerItemUId = new Guid("0e490dda-e140-4441-b600-6f5c64d024df"),
				ModifiedInSchemaUId = new Guid("d389027a-6008-40cd-b17b-623d1d1344c1"),
				Name = @"SetSocialUserScriptTask",
				Position = new Point(182, 42),
				SerializeToDB = false,
				Size = new Size(69, 55),
				UseBackgroundMode = false,
				UseFlowEngineScriptVersion = false,
				ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,157,147,81,79,194,48,20,133,159,33,225,63,52,60,117,145,244,15,32,38,50,192,44,42,49,12,125,49,62,148,237,14,26,182,214,220,221,110,33,198,255,110,187,73,128,68,141,240,218,158,115,190,211,220,219,74,34,43,161,44,149,209,19,73,146,141,216,115,9,24,26,173,33,33,119,40,226,195,229,176,215,85,25,63,82,191,198,38,81,50,247,142,242,30,118,111,108,52,98,218,230,121,240,209,235,118,16,200,162,102,153,204,75,112,206,207,94,183,114,172,196,104,146,9,57,142,134,154,141,159,30,99,147,145,112,188,76,173,45,202,6,25,182,26,126,218,36,104,240,140,127,39,136,25,80,178,153,161,41,38,99,126,235,20,21,44,17,224,14,85,26,90,68,208,180,48,117,148,6,1,243,101,60,218,250,154,14,204,163,169,182,5,160,92,229,112,29,181,79,152,3,213,6,183,158,120,19,252,241,66,215,161,179,47,16,3,133,38,183,133,126,145,185,5,222,95,214,138,8,176,63,96,37,161,210,107,49,45,222,105,23,252,195,18,165,231,152,102,50,129,149,49,219,75,60,231,145,30,148,222,66,26,233,75,60,63,147,50,131,32,147,13,227,251,129,48,165,219,193,180,115,250,45,214,75,196,201,168,196,210,196,77,58,15,6,77,130,152,203,2,26,200,69,33,236,138,245,155,206,141,202,45,142,79,114,75,123,8,147,21,112,127,234,14,143,54,68,44,160,48,238,230,116,81,188,238,251,3,16,90,24,126,1,225,136,126,60,103,3,0,0 }
			};
			
			return ScriptTask;
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		protected override void InitializeUsings() {
			Usings.Add(new SchemaUsing() {
				UId = new Guid("8c7ea91a-2e8f-4052-a58a-93461fb4d6ec"),
				Name = "BPMSoft.Social",
				Alias = "",
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			});
			Usings.Add(new SchemaUsing() {
				UId = new Guid("7df23a63-f721-4310-b255-a7cb6cc4e6d6"),
				Name = "BPMSoft.Core.Store",
				Alias = "",
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			});
		}

		#endregion

		#region Methods: Public

		public override Process CreateProcess(UserConnection userConnection) {
			return new FindInSocialMediaModuleProcess(userConnection);
		}

		public override object Clone() {
			return new FindInSocialMediaModuleProcessSchema(this);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("d389027a-6008-40cd-b17b-623d1d1344c1"));
		}

		#endregion

	}

	#endregion

	#region Class: FindInSocialMediaModuleProcess

	/// <exclude/>
	public class FindInSocialMediaModuleProcess : BPMSoft.Core.Process.Process
	{

		#region Class: ProcessLane94

		/// <exclude/>
		public class ProcessLane94 : ProcessLane
		{

			public ProcessLane94(UserConnection userConnection, FindInSocialMediaModuleProcess process)
				: base(userConnection) {
				Owner = process;
				IsUsedParentUserContexts = false;
			}

		}

		#endregion

		#region Class: OpenMatchFoundWindowUserTaskFlowElement

		/// <exclude/>
		public class OpenMatchFoundWindowUserTaskFlowElement : OpenPageUserTask
		{

			#region Constructors: Public

			public OpenMatchFoundWindowUserTaskFlowElement(UserConnection userConnection, FindInSocialMediaModuleProcess process)
				: base(userConnection) {
				UId = Guid.NewGuid();
				Owner = process;
				Type = "ProcessSchemaUserTask";
				Name = "OpenMatchFoundWindowUserTask";
				IsLogging = true;
				SchemaElementUId = new Guid("e1632db6-b725-48a3-8c30-3e992b0923af");
				CreatedInSchemaUId = process.InternalSchemaUId;
				_width = () => (int)((process.Width));
				_height = () => (int)((process.Height));
			}

			#endregion

			#region Properties: Public

			internal Func<int> _width;
			public override int Width {
				get {
					return (_width ?? (_width = () => 0)).Invoke();
				}
				set {
					_width = () => { return value; };
				}
			}

			private string _closeMessage;
			public override string CloseMessage {
				get {
					return _closeMessage ?? (_closeMessage = GetLocalizableString("d389027a600840cdb17b623d1d1344c1",
						 "BaseElements.OpenMatchFoundWindowUserTask.Parameters.CloseMessage.Value"));
				}
				set {
					_closeMessage = value;
				}
			}

			internal Func<int> _height;
			public override int Height {
				get {
					return (_height ?? (_height = () => 0)).Invoke();
				}
				set {
					_height = () => { return value; };
				}
			}

			#endregion

		}

		#endregion

		public FindInSocialMediaModuleProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "FindInSocialMediaModuleProcess";
			SchemaUId = new Guid("d389027a-6008-40cd-b17b-623d1d1344c1");
			Caption = Schema.Caption;
			SchemaManagerName = "ProcessSchemaManager";
			SerializeToDB = false;
			SerializeToMemory = true;
			IsLogging = false;
			UseSystemSecurityContext = false;
			_notificationCaption = () => { return new LocalizableString((Caption)); };
			_height = () => { return (int)(350); };
			_width = () => { return (int)(550); };
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("d389027a-6008-40cd-b17b-623d1d1344c1");
			}
		}

		private string ConditionalExpressionLogMessage {
			get {
				return "Process: FindInSocialMediaModuleProcess, Source element: {0}, Conditional flow: {1}, Expression: {2}, Result: {3}";
			}
		}

		private string DeadEndGatewayLogMessage {
			get {
				return "Process: FindInSocialMediaModuleProcess, Source element: {0}, None of the exclusive gateway conditions are met!";
			}
		}

		#endregion

		#region Properties: Public

		public override int MaxLoopCount {
			get {
				return 101;
			}
		}

		private Func<string> _notificationCaption;
		public virtual string NotificationCaption {
			get {
				return (_notificationCaption ?? (_notificationCaption = () => null)).Invoke();
			}
			set {
				_notificationCaption = () => { return value; };
			}
		}

		public virtual string PageInstanceId {
			get;
			set;
		}

		public virtual Guid ActiveTreeGridCurrentRowId {
			get;
			set;
		}

		public virtual string SocialUsersKey {
			get;
			set;
		}

		public virtual string SocialNetworks {
			get;
			set;
		}

		public virtual string SearchCriteria {
			get;
			set;
		}

		public virtual Guid MatchesFoundPageUId {
			get;
			set;
		}

		private Func<int> _height;
		public virtual int Height {
			get {
				return (_height ?? (_height = () => 0)).Invoke();
			}
			set {
				_height = () => { return value; };
			}
		}

		private Func<int> _width;
		public virtual int Width {
			get {
				return (_width ?? (_width = () => 0)).Invoke();
			}
			set {
				_width = () => { return value; };
			}
		}

		private ProcessLane94 _lane94;
		public ProcessLane94 Lane94 {
			get {
				return _lane94 ?? ((_lane94) = new ProcessLane94(UserConnection, this));
			}
		}

		private ProcessFlowElement _start1;
		public ProcessFlowElement Start1 {
			get {
				return _start1 ?? (_start1 = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartEvent",
					Name = "Start1",
					SchemaElementUId = new Guid("74c6050a-d695-4efc-aa2f-1f3106bfaa82"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
				});
			}
		}

		private ProcessScriptTask _prepareOpenMatchFoundWindowScriptTask;
		public ProcessScriptTask PrepareOpenMatchFoundWindowScriptTask {
			get {
				return _prepareOpenMatchFoundWindowScriptTask ?? (_prepareOpenMatchFoundWindowScriptTask = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "PrepareOpenMatchFoundWindowScriptTask",
					SchemaElementUId = new Guid("b4f8958c-2ef7-4cbd-9859-beabc5f460b9"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
					Script = PrepareOpenMatchFoundWindowScriptTaskExecute,
				});
			}
		}

		private OpenMatchFoundWindowUserTaskFlowElement _openMatchFoundWindowUserTask;
		public OpenMatchFoundWindowUserTaskFlowElement OpenMatchFoundWindowUserTask {
			get {
				return _openMatchFoundWindowUserTask ?? (_openMatchFoundWindowUserTask = new OpenMatchFoundWindowUserTaskFlowElement(UserConnection, this) { ExecutedEventHandler = OnExecuted });
			}
		}

		private ProcessFlowElement _eventSubProcess1;
		public ProcessFlowElement EventSubProcess1 {
			get {
				return _eventSubProcess1 ?? (_eventSubProcess1 = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaEventSubProcess",
					Name = "EventSubProcess1",
					SchemaElementUId = new Guid("6efae6cc-9cc3-4eb3-9ab6-a849f8b0980a"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
				});
			}
		}

		private ProcessFlowElement _matchFoundWindowClosedMessage;
		public ProcessFlowElement MatchFoundWindowClosedMessage {
			get {
				return _matchFoundWindowClosedMessage ?? (_matchFoundWindowClosedMessage = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "MatchFoundWindowClosedMessage",
					SchemaElementUId = new Guid("90430d45-296a-4ef2-b727-db8ba2de0d37"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
				});
			}
		}

		private ProcessScriptTask _setSocialUserScriptTask;
		public ProcessScriptTask SetSocialUserScriptTask {
			get {
				return _setSocialUserScriptTask ?? (_setSocialUserScriptTask = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "SetSocialUserScriptTask",
					SchemaElementUId = new Guid("85d15b6f-b750-4a1e-8403-d7b4d9aa285b"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
					IsLogging = true,
					Script = SetSocialUserScriptTaskExecute,
				});
			}
		}

		#endregion

		#region Methods: Private

		private void InitializeFlowElements() {
			FlowElements[Start1.SchemaElementUId] = new Collection<ProcessFlowElement> { Start1 };
			FlowElements[PrepareOpenMatchFoundWindowScriptTask.SchemaElementUId] = new Collection<ProcessFlowElement> { PrepareOpenMatchFoundWindowScriptTask };
			FlowElements[OpenMatchFoundWindowUserTask.SchemaElementUId] = new Collection<ProcessFlowElement> { OpenMatchFoundWindowUserTask };
			FlowElements[EventSubProcess1.SchemaElementUId] = new Collection<ProcessFlowElement> { EventSubProcess1 };
			FlowElements[MatchFoundWindowClosedMessage.SchemaElementUId] = new Collection<ProcessFlowElement> { MatchFoundWindowClosedMessage };
			FlowElements[SetSocialUserScriptTask.SchemaElementUId] = new Collection<ProcessFlowElement> { SetSocialUserScriptTask };
		}

		private void OnExecuted(object sender, ProcessActivityAfterEventArgs e) {
			switch (e.Context.SenderName) {
					case "Start1":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("PrepareOpenMatchFoundWindowScriptTask", e.Context.SenderName));
						break;
					case "PrepareOpenMatchFoundWindowScriptTask":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("OpenMatchFoundWindowUserTask", e.Context.SenderName));
						break;
					case "OpenMatchFoundWindowUserTask":
						break;
					case "EventSubProcess1":
						break;
					case "MatchFoundWindowClosedMessage":
						e.Context.QueueTasksV2.Enqueue(new ProcessQueueElement("SetSocialUserScriptTask", e.Context.SenderName));
						break;
					case "SetSocialUserScriptTask":
						break;
			}
		}

		private void WritePropertyValues(DataWriter writer, bool useAllValueSources) {
			if (!HasMapping("PageInstanceId")) {
				writer.WriteValue("PageInstanceId", PageInstanceId, null);
			}
			if (!HasMapping("ActiveTreeGridCurrentRowId")) {
				writer.WriteValue("ActiveTreeGridCurrentRowId", ActiveTreeGridCurrentRowId, Guid.Empty);
			}
			if (!HasMapping("SocialUsersKey")) {
				writer.WriteValue("SocialUsersKey", SocialUsersKey, null);
			}
			if (!HasMapping("SocialNetworks")) {
				writer.WriteValue("SocialNetworks", SocialNetworks, null);
			}
			if (!HasMapping("SearchCriteria")) {
				writer.WriteValue("SearchCriteria", SearchCriteria, null);
			}
			if (!HasMapping("MatchesFoundPageUId")) {
				writer.WriteValue("MatchesFoundPageUId", MatchesFoundPageUId, Guid.Empty);
			}
			if (!HasMapping("Height")) {
				writer.WriteValue("Height", Height, 0);
			}
			if (!HasMapping("Width")) {
				writer.WriteValue("Width", Width, 0);
			}
		}

		#endregion

		#region Methods: Protected

		protected override void PrepareStart(ProcessExecutingContext context) {
			base.PrepareStart(context);
			context.Process = this;
			if (IsProcessExecutedBySignal) {
				return;
			}
			context.QueueTasksV2.Enqueue(new ProcessQueueElement("Start1", string.Empty));
			ActivatedEventElements.Add("MatchFoundWindowClosedMessage");
		}

		protected override void CompleteApplyingFlowElementsPropertiesData() {
			base.CompleteApplyingFlowElementsPropertiesData();
			foreach (var item in FlowElements) {
				foreach (var itemValue in item.Value) {
					if (Guid.Equals(itemValue.CreatedInSchemaUId, InternalSchemaUId)) {
						itemValue.ExecutedEventHandler = OnExecuted;
					}
				}
			}
		}

		protected override void InitializeMetaPathParameterValues() {
			base.InitializeMetaPathParameterValues();
			MetaPathParameterValues.Add("5395b142-e19d-4404-9832-d0dd0018dc8a", () => PageInstanceId);
			MetaPathParameterValues.Add("b16d44d3-07fb-4a3f-9150-1d70ebfcc516", () => ActiveTreeGridCurrentRowId);
			MetaPathParameterValues.Add("cec9d094-514a-47ec-943c-abcaee182be1", () => SocialUsersKey);
			MetaPathParameterValues.Add("856f4570-e2c1-421a-8b36-1ca4fdc9ffca", () => SocialNetworks);
			MetaPathParameterValues.Add("24e84ec1-16cf-46da-8db6-13db647a3fd2", () => SearchCriteria);
			MetaPathParameterValues.Add("fa5b71ac-faa8-480c-863b-78eedcb9e206", () => MatchesFoundPageUId);
			MetaPathParameterValues.Add("d9c957b1-ccc6-4858-98d6-88e8e3300945", () => Height);
			MetaPathParameterValues.Add("353019c4-47a0-4f83-b00f-3c00a7c5e9be", () => Width);
			MetaPathParameterValues.Add("e2e21ba3-bb6d-4e10-bce5-4bf650d7b7ba", () => OpenMatchFoundWindowUserTask.PageUId);
			MetaPathParameterValues.Add("e594e5b0-c983-486b-9113-8c72c303d9e0", () => OpenMatchFoundWindowUserTask.PageUrl);
			MetaPathParameterValues.Add("7452b4c9-d854-4ac1-9357-9fef2d645f5b", () => OpenMatchFoundWindowUserTask.OpenerInstanceId);
			MetaPathParameterValues.Add("c02dadae-f305-4ee0-b2a3-d048ef78be5b", () => OpenMatchFoundWindowUserTask.CloseOpenerOnLoad);
			MetaPathParameterValues.Add("54158a13-96c0-4e28-bfee-17cd7c98e909", () => OpenMatchFoundWindowUserTask.PageParameters);
			MetaPathParameterValues.Add("9862e552-2baf-420c-84aa-51b1c5b87a08", () => OpenMatchFoundWindowUserTask.Width);
			MetaPathParameterValues.Add("4f217434-6d17-4938-b1bf-a28f71b418b5", () => OpenMatchFoundWindowUserTask.CloseMessage);
			MetaPathParameterValues.Add("f7c8b17a-e5aa-40eb-845f-3655c06d1dc1", () => OpenMatchFoundWindowUserTask.Height);
			MetaPathParameterValues.Add("22fbda9a-a82c-4aeb-a709-630d00e56f66", () => OpenMatchFoundWindowUserTask.Centered);
			MetaPathParameterValues.Add("4a197821-213b-4f40-95f9-76b973066fe0", () => OpenMatchFoundWindowUserTask.UseOpenerRegisterScript);
			MetaPathParameterValues.Add("7b935efe-de49-4f8b-9fc5-6a0df3434963", () => OpenMatchFoundWindowUserTask.UseCurrentActivePage);
			MetaPathParameterValues.Add("55f3d967-cdbc-4274-a41b-a3b1936260fa", () => OpenMatchFoundWindowUserTask.IgnoreProfile);
		}

		protected override void ApplyPropertiesDataValues(DataReader reader) {
			base.ApplyPropertiesDataValues(reader);
			bool hasValueToRead = reader.HasValue();
			switch (reader.CurrentName) {
				case "PageInstanceId":
					if (!hasValueToRead) break;
					PageInstanceId = reader.GetValue<System.String>();
				break;
				case "ActiveTreeGridCurrentRowId":
					if (!hasValueToRead) break;
					ActiveTreeGridCurrentRowId = reader.GetValue<System.Guid>();
				break;
				case "SocialUsersKey":
					if (!hasValueToRead) break;
					SocialUsersKey = reader.GetValue<System.String>();
				break;
				case "SocialNetworks":
					if (!hasValueToRead) break;
					SocialNetworks = reader.GetValue<System.String>();
				break;
				case "SearchCriteria":
					if (!hasValueToRead) break;
					SearchCriteria = reader.GetValue<System.String>();
				break;
				case "MatchesFoundPageUId":
					if (!hasValueToRead) break;
					MatchesFoundPageUId = reader.GetValue<System.Guid>();
				break;
				case "Height":
					if (!hasValueToRead) break;
					Height = reader.GetValue<System.Int32>();
				break;
				case "Width":
					if (!hasValueToRead) break;
					Width = reader.GetValue<System.Int32>();
				break;
			}
		}

		protected override void WritePropertyValues(DataWriter writer) {
			base.WritePropertyValues(writer);
			WritePropertyValues(writer, true);
		}

		#endregion

		#region Methods: Public

		public virtual bool PrepareOpenMatchFoundWindowScriptTaskExecute(ProcessExecutingContext context) {
			if (MatchesFoundPageUId.IsEmpty()) {
				MatchesFoundPageUId = new Guid("1200bc25-ab67-45c8-9fba-2703ac850351");
			}
			var contact = GetContact();
			var parameters = new Dictionary<string, string>();
			SocialUsersKey = "socialUsers" + Guid.NewGuid().ToString();
			parameters.Add("SocialUsers", SocialUsersKey);
			parameters.Add("SearchCriteria", contact.Name);
			parameters.Add("SocialNetwork", "All");
			parameters.Add("TwitterId", contact.TwitterId);
			parameters.Add("FacebookId", contact.FacebookId);
			parameters.Add("LinkedInId", contact.LinkedInId);
			OpenMatchFoundWindowUserTask.PageUId = MatchesFoundPageUId;
			OpenMatchFoundWindowUserTask.PageParameters = parameters;
			OpenMatchFoundWindowUserTask.OpenerInstanceId = InstanceUId;
			OpenMatchFoundWindowUserTask.UseCurrentActivePage = true;
			OpenMatchFoundWindowUserTask.CloseMessage = "MatchFoundWindowClosed";
			return true;
		}

		public virtual bool SetSocialUserScriptTaskExecute(ProcessExecutingContext context) {
			var sessionData = UserConnection.SessionData;
			if(sessionData[SocialUsersKey] == null){
				return false;
			}
			var contact = new BPMSoft.Configuration.Contact(UserConnection);
			if (contact.FetchFromDB(ActiveTreeGridCurrentRowId)) {
				var users = (IEnumerable<ISocialNetworkUser>)sessionData[SocialUsersKey];
				contact.SetColumnValue("Twitter", string.Empty);
				contact.SetColumnValue("TwitterId", string.Empty);
				contact.SetColumnValue("Facebook", string.Empty);
				contact.SetColumnValue("FacebookId", string.Empty);
				contact.SetColumnValue("LinkedIn", string.Empty);
				contact.SetColumnValue("LinkedInId", string.Empty);
				foreach (var user in users) {
					contact.SetColumnValue(user.SocialNetwork.ToString(), user.Name);
					contact.SetColumnValue(user.SocialNetwork.ToString() + "Id", user.Id);
				}
				contact.Save();
			}
			sessionData.Remove(SocialUsersKey);
			return true;
		}

			
			public virtual BPMSoft.Configuration.Contact GetContact() {
				var contactSchema = UserConnection.EntitySchemaManager.GetInstanceByName("Contact");
			var contact = contactSchema.CreateEntity(UserConnection) as BPMSoft.Configuration.Contact;
			bool fetchResult = contact.FetchFromDB(contactSchema.PrimaryColumn, ActiveTreeGridCurrentRowId, new[] {
			                               contactSchema.Columns.FindByColumnValueName("Name"),
										   contactSchema.Columns.FindByColumnValueName("TwitterId"),
										   contactSchema.Columns.FindByColumnValueName("LinkedInId"),
										   contactSchema.Columns.FindByColumnValueName("FacebookId"),
			                });
			if (!fetchResult){
			   contact = null;
			}
			return contact;
			}
			

		public override void ThrowEvent(ProcessExecutingContext context, string message) {
			switch(message) {
					case "MatchFoundWindowClosed":
							if (ActivatedEventElements.Contains("MatchFoundWindowClosedMessage")) {
							context.QueueTasksV2.Enqueue(new ProcessQueueElement("MatchFoundWindowClosedMessage", "MatchFoundWindowClosedMessage"));
						}
						break;
			}
			base.ThrowEvent(context, message);
		}

		public override void WritePropertiesData(DataWriter writer, bool writeFlowElements = true) {
			if (Status == Core.Process.ProcessStatus.Inactive) {
				return;
			}
			writer.WriteStartObject(Name);
			base.WritePropertiesData(writer, writeFlowElements);
			WritePropertyValues(writer, false);
			writer.WriteFinishObject();
		}

		public override object CloneShallow() {
			var cloneItem = (FindInSocialMediaModuleProcess)base.CloneShallow();
			cloneItem.ExecutedEventHandler = ExecutedEventHandler;
			return cloneItem;
		}

		#endregion

	}

	#endregion

}

