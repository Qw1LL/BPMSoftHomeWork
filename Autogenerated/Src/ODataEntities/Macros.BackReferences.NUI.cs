namespace BPMSoft.Configuration.OData
{

	using BPMSoft.Core;
	using BPMSoft.Core.Entities.Extensions;
	using System;
	using System.Collections.Generic;
	using System.Drawing;

	#region Class: Macros

	/// <exclude/>
	public class Macros : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public Macros(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "Macros";
		}

		public Macros(BPMSoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "Macros";
			this.CopyEntityLookupProperties(source);
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Id.
		/// </summary>
		public Guid Id {
			get {
				return GetTypedColumnValue<Guid>("Id");
			}
			set {
				SetColumnValue("Id", value);
			}
		}

		/// <summary>
		/// Created on.
		/// </summary>
		public DateTime CreatedOn {
			get {
				return GetTypedColumnValue<DateTime>("CreatedOn");
			}
			set {
				SetColumnValue("CreatedOn", value);
			}
		}

		/// <exclude/>
		public Guid CreatedById {
			get {
				return GetTypedColumnValue<Guid>("CreatedById");
			}
			set {
				SetColumnValue("CreatedById", value);
				_createdBy = null;
			}
		}

		/// <exclude/>
		public string CreatedByName {
			get {
				return GetTypedColumnValue<string>("CreatedByName");
			}
			set {
				SetColumnValue("CreatedByName", value);
				if (_createdBy != null) {
					_createdBy.Name = value;
				}
			}
		}

		private Contact _createdBy;
		/// <summary>
		/// Created by.
		/// </summary>
		public Contact CreatedBy {
			get {
				return _createdBy ??
					(_createdBy = new Contact(LookupColumnEntities.GetEntity("CreatedBy")));
			}
		}

		/// <summary>
		/// Modified on.
		/// </summary>
		public DateTime ModifiedOn {
			get {
				return GetTypedColumnValue<DateTime>("ModifiedOn");
			}
			set {
				SetColumnValue("ModifiedOn", value);
			}
		}

		/// <exclude/>
		public Guid ModifiedById {
			get {
				return GetTypedColumnValue<Guid>("ModifiedById");
			}
			set {
				SetColumnValue("ModifiedById", value);
				_modifiedBy = null;
			}
		}

		/// <exclude/>
		public string ModifiedByName {
			get {
				return GetTypedColumnValue<string>("ModifiedByName");
			}
			set {
				SetColumnValue("ModifiedByName", value);
				if (_modifiedBy != null) {
					_modifiedBy.Name = value;
				}
			}
		}

		private Contact _modifiedBy;
		/// <summary>
		/// Modified by.
		/// </summary>
		public Contact ModifiedBy {
			get {
				return _modifiedBy ??
					(_modifiedBy = new Contact(LookupColumnEntities.GetEntity("ModifiedBy")));
			}
		}

		/// <summary>
		/// Active processes.
		/// </summary>
		public int ProcessListeners {
			get {
				return GetTypedColumnValue<int>("ProcessListeners");
			}
			set {
				SetColumnValue("ProcessListeners", value);
			}
		}

		/// <exclude/>
		public Guid CommandId {
			get {
				return GetTypedColumnValue<Guid>("CommandId");
			}
			set {
				SetColumnValue("CommandId", value);
				_command = null;
			}
		}

		/// <exclude/>
		public string CommandName {
			get {
				return GetTypedColumnValue<string>("CommandName");
			}
			set {
				SetColumnValue("CommandName", value);
				if (_command != null) {
					_command.Name = value;
				}
			}
		}

		private Command _command;
		/// <summary>
		/// Keyword.
		/// </summary>
		public Command Command {
			get {
				return _command ??
					(_command = new Command(LookupColumnEntities.GetEntity("Command")));
			}
		}

		/// <summary>
		/// Name.
		/// </summary>
		public string Name {
			get {
				return GetTypedColumnValue<string>("Name");
			}
			set {
				SetColumnValue("Name", value);
			}
		}

		/// <exclude/>
		public Guid MainParamId {
			get {
				return GetTypedColumnValue<Guid>("MainParamId");
			}
			set {
				SetColumnValue("MainParamId", value);
				_mainParam = null;
			}
		}

		/// <exclude/>
		public string MainParamName {
			get {
				return GetTypedColumnValue<string>("MainParamName");
			}
			set {
				SetColumnValue("MainParamName", value);
				if (_mainParam != null) {
					_mainParam.Name = value;
				}
			}
		}

		private MainParam _mainParam;
		/// <summary>
		/// Primary parameter.
		/// </summary>
		public MainParam MainParam {
			get {
				return _mainParam ??
					(_mainParam = new MainParam(LookupColumnEntities.GetEntity("MainParam")));
			}
		}

		/// <exclude/>
		public Guid AdditionalParamId {
			get {
				return GetTypedColumnValue<Guid>("AdditionalParamId");
			}
			set {
				SetColumnValue("AdditionalParamId", value);
				_additionalParam = null;
			}
		}

		/// <exclude/>
		public string AdditionalParamColumnCaption {
			get {
				return GetTypedColumnValue<string>("AdditionalParamColumnCaption");
			}
			set {
				SetColumnValue("AdditionalParamColumnCaption", value);
				if (_additionalParam != null) {
					_additionalParam.ColumnCaption = value;
				}
			}
		}

		private AdditionalParam _additionalParam;
		/// <summary>
		/// Additional parameter.
		/// </summary>
		public AdditionalParam AdditionalParam {
			get {
				return _additionalParam ??
					(_additionalParam = new AdditionalParam(LookupColumnEntities.GetEntity("AdditionalParam")));
			}
		}

		/// <summary>
		/// Additional parameter value.
		/// </summary>
		public string AdditionalParamValue {
			get {
				return GetTypedColumnValue<string>("AdditionalParamValue");
			}
			set {
				SetColumnValue("AdditionalParamValue", value);
			}
		}

		/// <summary>
		/// Code of main parameter card type.
		/// </summary>
		public string MainParamType {
			get {
				return GetTypedColumnValue<string>("MainParamType");
			}
			set {
				SetColumnValue("MainParamType", value);
			}
		}

		/// <summary>
		/// Common.
		/// </summary>
		public bool IsShared {
			get {
				return GetTypedColumnValue<bool>("IsShared");
			}
			set {
				SetColumnValue("IsShared", value);
			}
		}

		#endregion

	}

	#endregion

}

