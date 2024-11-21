namespace BPMSoft.Configuration.OData
{

	using BPMSoft.Core;
	using BPMSoft.Core.Entities.Extensions;
	using System;
	using System.Collections.Generic;
	using System.Drawing;

	#region Class: SysTranslation

	/// <exclude/>
	public class SysTranslation : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public SysTranslation(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysTranslation";
		}

		public SysTranslation(BPMSoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "SysTranslation";
			this.CopyEntityLookupProperties(source);
		}

		#endregion

		#region Properties: Public

		public IEnumerable<SysTranslationInFolder> SysTranslationInFolderCollectionBySysTranslation {
			get;
			set;
		}

		public IEnumerable<SysTranslationInTag> SysTranslationInTagCollectionByEntity {
			get;
			set;
		}

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

		/// <summary>
		/// Key.
		/// </summary>
		public string Key {
			get {
				return GetTypedColumnValue<string>("Key");
			}
			set {
				SetColumnValue("Key", value);
			}
		}

		/// <summary>
		/// Language0.
		/// </summary>
		public string Language0 {
			get {
				return GetTypedColumnValue<string>("Language0");
			}
			set {
				SetColumnValue("Language0", value);
			}
		}

		/// <summary>
		/// Language1.
		/// </summary>
		public string Language1 {
			get {
				return GetTypedColumnValue<string>("Language1");
			}
			set {
				SetColumnValue("Language1", value);
			}
		}

		/// <summary>
		/// Language2.
		/// </summary>
		public string Language2 {
			get {
				return GetTypedColumnValue<string>("Language2");
			}
			set {
				SetColumnValue("Language2", value);
			}
		}

		/// <summary>
		/// Language3.
		/// </summary>
		public string Language3 {
			get {
				return GetTypedColumnValue<string>("Language3");
			}
			set {
				SetColumnValue("Language3", value);
			}
		}

		/// <summary>
		/// Language4.
		/// </summary>
		public string Language4 {
			get {
				return GetTypedColumnValue<string>("Language4");
			}
			set {
				SetColumnValue("Language4", value);
			}
		}

		/// <summary>
		/// Language5.
		/// </summary>
		public string Language5 {
			get {
				return GetTypedColumnValue<string>("Language5");
			}
			set {
				SetColumnValue("Language5", value);
			}
		}

		/// <summary>
		/// Language6.
		/// </summary>
		public string Language6 {
			get {
				return GetTypedColumnValue<string>("Language6");
			}
			set {
				SetColumnValue("Language6", value);
			}
		}

		/// <summary>
		/// Language7.
		/// </summary>
		public string Language7 {
			get {
				return GetTypedColumnValue<string>("Language7");
			}
			set {
				SetColumnValue("Language7", value);
			}
		}

		/// <summary>
		/// Language8.
		/// </summary>
		public string Language8 {
			get {
				return GetTypedColumnValue<string>("Language8");
			}
			set {
				SetColumnValue("Language8", value);
			}
		}

		/// <summary>
		/// Language9.
		/// </summary>
		public string Language9 {
			get {
				return GetTypedColumnValue<string>("Language9");
			}
			set {
				SetColumnValue("Language9", value);
			}
		}

		/// <summary>
		/// IsVerified0.
		/// </summary>
		public bool IsVerified0 {
			get {
				return GetTypedColumnValue<bool>("IsVerified0");
			}
			set {
				SetColumnValue("IsVerified0", value);
			}
		}

		/// <summary>
		/// IsVerified1.
		/// </summary>
		public bool IsVerified1 {
			get {
				return GetTypedColumnValue<bool>("IsVerified1");
			}
			set {
				SetColumnValue("IsVerified1", value);
			}
		}

		/// <summary>
		/// IsVerified0.
		/// </summary>
		public bool IsVerified2 {
			get {
				return GetTypedColumnValue<bool>("IsVerified2");
			}
			set {
				SetColumnValue("IsVerified2", value);
			}
		}

		/// <summary>
		/// IsVerified3.
		/// </summary>
		public bool IsVerified3 {
			get {
				return GetTypedColumnValue<bool>("IsVerified3");
			}
			set {
				SetColumnValue("IsVerified3", value);
			}
		}

		/// <summary>
		/// IsVerified4.
		/// </summary>
		public bool IsVerified4 {
			get {
				return GetTypedColumnValue<bool>("IsVerified4");
			}
			set {
				SetColumnValue("IsVerified4", value);
			}
		}

		/// <summary>
		/// IsVerified5.
		/// </summary>
		public bool IsVerified5 {
			get {
				return GetTypedColumnValue<bool>("IsVerified5");
			}
			set {
				SetColumnValue("IsVerified5", value);
			}
		}

		/// <summary>
		/// IsVerified6.
		/// </summary>
		public bool IsVerified6 {
			get {
				return GetTypedColumnValue<bool>("IsVerified6");
			}
			set {
				SetColumnValue("IsVerified6", value);
			}
		}

		/// <summary>
		/// IsVerified7.
		/// </summary>
		public bool IsVerified7 {
			get {
				return GetTypedColumnValue<bool>("IsVerified7");
			}
			set {
				SetColumnValue("IsVerified7", value);
			}
		}

		/// <summary>
		/// IsVerified8.
		/// </summary>
		public bool IsVerified8 {
			get {
				return GetTypedColumnValue<bool>("IsVerified8");
			}
			set {
				SetColumnValue("IsVerified8", value);
			}
		}

		/// <summary>
		/// IsVerified9.
		/// </summary>
		public bool IsVerified9 {
			get {
				return GetTypedColumnValue<bool>("IsVerified9");
			}
			set {
				SetColumnValue("IsVerified9", value);
			}
		}

		/// <summary>
		/// IsChanged0.
		/// </summary>
		public bool IsChanged0 {
			get {
				return GetTypedColumnValue<bool>("IsChanged0");
			}
			set {
				SetColumnValue("IsChanged0", value);
			}
		}

		/// <summary>
		/// IsChanged1.
		/// </summary>
		public bool IsChanged1 {
			get {
				return GetTypedColumnValue<bool>("IsChanged1");
			}
			set {
				SetColumnValue("IsChanged1", value);
			}
		}

		/// <summary>
		/// IsChanged2.
		/// </summary>
		public bool IsChanged2 {
			get {
				return GetTypedColumnValue<bool>("IsChanged2");
			}
			set {
				SetColumnValue("IsChanged2", value);
			}
		}

		/// <summary>
		/// IsChanged3.
		/// </summary>
		public bool IsChanged3 {
			get {
				return GetTypedColumnValue<bool>("IsChanged3");
			}
			set {
				SetColumnValue("IsChanged3", value);
			}
		}

		/// <summary>
		/// IsChanged4.
		/// </summary>
		public bool IsChanged4 {
			get {
				return GetTypedColumnValue<bool>("IsChanged4");
			}
			set {
				SetColumnValue("IsChanged4", value);
			}
		}

		/// <summary>
		/// IsChanged5.
		/// </summary>
		public bool IsChanged5 {
			get {
				return GetTypedColumnValue<bool>("IsChanged5");
			}
			set {
				SetColumnValue("IsChanged5", value);
			}
		}

		/// <summary>
		/// IsChanged6.
		/// </summary>
		public bool IsChanged6 {
			get {
				return GetTypedColumnValue<bool>("IsChanged6");
			}
			set {
				SetColumnValue("IsChanged6", value);
			}
		}

		/// <summary>
		/// IsChanged7.
		/// </summary>
		public bool IsChanged7 {
			get {
				return GetTypedColumnValue<bool>("IsChanged7");
			}
			set {
				SetColumnValue("IsChanged7", value);
			}
		}

		/// <summary>
		/// IsChanged8.
		/// </summary>
		public bool IsChanged8 {
			get {
				return GetTypedColumnValue<bool>("IsChanged8");
			}
			set {
				SetColumnValue("IsChanged8", value);
			}
		}

		/// <summary>
		/// IsChanged9.
		/// </summary>
		public bool IsChanged9 {
			get {
				return GetTypedColumnValue<bool>("IsChanged9");
			}
			set {
				SetColumnValue("IsChanged9", value);
			}
		}

		/// <summary>
		/// Language10.
		/// </summary>
		public string Language10 {
			get {
				return GetTypedColumnValue<string>("Language10");
			}
			set {
				SetColumnValue("Language10", value);
			}
		}

		/// <summary>
		/// Language11.
		/// </summary>
		public string Language11 {
			get {
				return GetTypedColumnValue<string>("Language11");
			}
			set {
				SetColumnValue("Language11", value);
			}
		}

		/// <summary>
		/// Language12.
		/// </summary>
		public string Language12 {
			get {
				return GetTypedColumnValue<string>("Language12");
			}
			set {
				SetColumnValue("Language12", value);
			}
		}

		/// <summary>
		/// Language13.
		/// </summary>
		public string Language13 {
			get {
				return GetTypedColumnValue<string>("Language13");
			}
			set {
				SetColumnValue("Language13", value);
			}
		}

		/// <summary>
		/// Language14.
		/// </summary>
		public string Language14 {
			get {
				return GetTypedColumnValue<string>("Language14");
			}
			set {
				SetColumnValue("Language14", value);
			}
		}

		/// <summary>
		/// Language15.
		/// </summary>
		public string Language15 {
			get {
				return GetTypedColumnValue<string>("Language15");
			}
			set {
				SetColumnValue("Language15", value);
			}
		}

		/// <summary>
		/// Language16.
		/// </summary>
		public string Language16 {
			get {
				return GetTypedColumnValue<string>("Language16");
			}
			set {
				SetColumnValue("Language16", value);
			}
		}

		/// <summary>
		/// Language17.
		/// </summary>
		public string Language17 {
			get {
				return GetTypedColumnValue<string>("Language17");
			}
			set {
				SetColumnValue("Language17", value);
			}
		}

		/// <summary>
		/// Language18.
		/// </summary>
		public string Language18 {
			get {
				return GetTypedColumnValue<string>("Language18");
			}
			set {
				SetColumnValue("Language18", value);
			}
		}

		/// <summary>
		/// Language19.
		/// </summary>
		public string Language19 {
			get {
				return GetTypedColumnValue<string>("Language19");
			}
			set {
				SetColumnValue("Language19", value);
			}
		}

		/// <summary>
		/// Language20.
		/// </summary>
		public string Language20 {
			get {
				return GetTypedColumnValue<string>("Language20");
			}
			set {
				SetColumnValue("Language20", value);
			}
		}

		/// <summary>
		/// Language21.
		/// </summary>
		public string Language21 {
			get {
				return GetTypedColumnValue<string>("Language21");
			}
			set {
				SetColumnValue("Language21", value);
			}
		}

		/// <summary>
		/// Language22.
		/// </summary>
		public string Language22 {
			get {
				return GetTypedColumnValue<string>("Language22");
			}
			set {
				SetColumnValue("Language22", value);
			}
		}

		/// <summary>
		/// Language23.
		/// </summary>
		public string Language23 {
			get {
				return GetTypedColumnValue<string>("Language23");
			}
			set {
				SetColumnValue("Language23", value);
			}
		}

		/// <summary>
		/// Language24.
		/// </summary>
		public string Language24 {
			get {
				return GetTypedColumnValue<string>("Language24");
			}
			set {
				SetColumnValue("Language24", value);
			}
		}

		/// <summary>
		/// Language25.
		/// </summary>
		public string Language25 {
			get {
				return GetTypedColumnValue<string>("Language25");
			}
			set {
				SetColumnValue("Language25", value);
			}
		}

		/// <summary>
		/// Language26.
		/// </summary>
		public string Language26 {
			get {
				return GetTypedColumnValue<string>("Language26");
			}
			set {
				SetColumnValue("Language26", value);
			}
		}

		/// <summary>
		/// Language27.
		/// </summary>
		public string Language27 {
			get {
				return GetTypedColumnValue<string>("Language27");
			}
			set {
				SetColumnValue("Language27", value);
			}
		}

		/// <summary>
		/// Language28.
		/// </summary>
		public string Language28 {
			get {
				return GetTypedColumnValue<string>("Language28");
			}
			set {
				SetColumnValue("Language28", value);
			}
		}

		/// <summary>
		/// Language29.
		/// </summary>
		public string Language29 {
			get {
				return GetTypedColumnValue<string>("Language29");
			}
			set {
				SetColumnValue("Language29", value);
			}
		}

		/// <summary>
		/// Language30.
		/// </summary>
		public string Language30 {
			get {
				return GetTypedColumnValue<string>("Language30");
			}
			set {
				SetColumnValue("Language30", value);
			}
		}

		/// <summary>
		/// IsVerified10.
		/// </summary>
		public bool IsVerified10 {
			get {
				return GetTypedColumnValue<bool>("IsVerified10");
			}
			set {
				SetColumnValue("IsVerified10", value);
			}
		}

		/// <summary>
		/// IsVerified11.
		/// </summary>
		public bool IsVerified11 {
			get {
				return GetTypedColumnValue<bool>("IsVerified11");
			}
			set {
				SetColumnValue("IsVerified11", value);
			}
		}

		/// <summary>
		/// IsVerified12.
		/// </summary>
		public bool IsVerified12 {
			get {
				return GetTypedColumnValue<bool>("IsVerified12");
			}
			set {
				SetColumnValue("IsVerified12", value);
			}
		}

		/// <summary>
		/// IsVerified13.
		/// </summary>
		public bool IsVerified13 {
			get {
				return GetTypedColumnValue<bool>("IsVerified13");
			}
			set {
				SetColumnValue("IsVerified13", value);
			}
		}

		/// <summary>
		/// IsVerified14.
		/// </summary>
		public bool IsVerified14 {
			get {
				return GetTypedColumnValue<bool>("IsVerified14");
			}
			set {
				SetColumnValue("IsVerified14", value);
			}
		}

		/// <summary>
		/// IsVerified15.
		/// </summary>
		public bool IsVerified15 {
			get {
				return GetTypedColumnValue<bool>("IsVerified15");
			}
			set {
				SetColumnValue("IsVerified15", value);
			}
		}

		/// <summary>
		/// IsVerified16.
		/// </summary>
		public bool IsVerified16 {
			get {
				return GetTypedColumnValue<bool>("IsVerified16");
			}
			set {
				SetColumnValue("IsVerified16", value);
			}
		}

		/// <summary>
		/// IsVerified17.
		/// </summary>
		public bool IsVerified17 {
			get {
				return GetTypedColumnValue<bool>("IsVerified17");
			}
			set {
				SetColumnValue("IsVerified17", value);
			}
		}

		/// <summary>
		/// IsVerified18.
		/// </summary>
		public bool IsVerified18 {
			get {
				return GetTypedColumnValue<bool>("IsVerified18");
			}
			set {
				SetColumnValue("IsVerified18", value);
			}
		}

		/// <summary>
		/// IsVerified19.
		/// </summary>
		public bool IsVerified19 {
			get {
				return GetTypedColumnValue<bool>("IsVerified19");
			}
			set {
				SetColumnValue("IsVerified19", value);
			}
		}

		/// <summary>
		/// IsVerified20.
		/// </summary>
		public bool IsVerified20 {
			get {
				return GetTypedColumnValue<bool>("IsVerified20");
			}
			set {
				SetColumnValue("IsVerified20", value);
			}
		}

		/// <summary>
		/// IsVerified21.
		/// </summary>
		public bool IsVerified21 {
			get {
				return GetTypedColumnValue<bool>("IsVerified21");
			}
			set {
				SetColumnValue("IsVerified21", value);
			}
		}

		/// <summary>
		/// IsVerified22.
		/// </summary>
		public bool IsVerified22 {
			get {
				return GetTypedColumnValue<bool>("IsVerified22");
			}
			set {
				SetColumnValue("IsVerified22", value);
			}
		}

		/// <summary>
		/// IsVerified23.
		/// </summary>
		public bool IsVerified23 {
			get {
				return GetTypedColumnValue<bool>("IsVerified23");
			}
			set {
				SetColumnValue("IsVerified23", value);
			}
		}

		/// <summary>
		/// IsVerified24.
		/// </summary>
		public bool IsVerified24 {
			get {
				return GetTypedColumnValue<bool>("IsVerified24");
			}
			set {
				SetColumnValue("IsVerified24", value);
			}
		}

		/// <summary>
		/// IsVerified25.
		/// </summary>
		public bool IsVerified25 {
			get {
				return GetTypedColumnValue<bool>("IsVerified25");
			}
			set {
				SetColumnValue("IsVerified25", value);
			}
		}

		/// <summary>
		/// IsVerified26.
		/// </summary>
		public bool IsVerified26 {
			get {
				return GetTypedColumnValue<bool>("IsVerified26");
			}
			set {
				SetColumnValue("IsVerified26", value);
			}
		}

		/// <summary>
		/// IsVerified27.
		/// </summary>
		public bool IsVerified27 {
			get {
				return GetTypedColumnValue<bool>("IsVerified27");
			}
			set {
				SetColumnValue("IsVerified27", value);
			}
		}

		/// <summary>
		/// IsVerified28.
		/// </summary>
		public bool IsVerified28 {
			get {
				return GetTypedColumnValue<bool>("IsVerified28");
			}
			set {
				SetColumnValue("IsVerified28", value);
			}
		}

		/// <summary>
		/// IsVerified29.
		/// </summary>
		public bool IsVerified29 {
			get {
				return GetTypedColumnValue<bool>("IsVerified29");
			}
			set {
				SetColumnValue("IsVerified29", value);
			}
		}

		/// <summary>
		/// IsVerified30.
		/// </summary>
		public bool IsVerified30 {
			get {
				return GetTypedColumnValue<bool>("IsVerified30");
			}
			set {
				SetColumnValue("IsVerified30", value);
			}
		}

		/// <summary>
		/// IsChanged10.
		/// </summary>
		public bool IsChanged10 {
			get {
				return GetTypedColumnValue<bool>("IsChanged10");
			}
			set {
				SetColumnValue("IsChanged10", value);
			}
		}

		/// <summary>
		/// IsChanged11.
		/// </summary>
		public bool IsChanged11 {
			get {
				return GetTypedColumnValue<bool>("IsChanged11");
			}
			set {
				SetColumnValue("IsChanged11", value);
			}
		}

		/// <summary>
		/// IsChanged12.
		/// </summary>
		public bool IsChanged12 {
			get {
				return GetTypedColumnValue<bool>("IsChanged12");
			}
			set {
				SetColumnValue("IsChanged12", value);
			}
		}

		/// <summary>
		/// IsChanged13.
		/// </summary>
		public bool IsChanged13 {
			get {
				return GetTypedColumnValue<bool>("IsChanged13");
			}
			set {
				SetColumnValue("IsChanged13", value);
			}
		}

		/// <summary>
		/// IsChanged14.
		/// </summary>
		public bool IsChanged14 {
			get {
				return GetTypedColumnValue<bool>("IsChanged14");
			}
			set {
				SetColumnValue("IsChanged14", value);
			}
		}

		/// <summary>
		/// IsChanged15.
		/// </summary>
		public bool IsChanged15 {
			get {
				return GetTypedColumnValue<bool>("IsChanged15");
			}
			set {
				SetColumnValue("IsChanged15", value);
			}
		}

		/// <summary>
		/// IsChanged16.
		/// </summary>
		public bool IsChanged16 {
			get {
				return GetTypedColumnValue<bool>("IsChanged16");
			}
			set {
				SetColumnValue("IsChanged16", value);
			}
		}

		/// <summary>
		/// IsChanged17.
		/// </summary>
		public bool IsChanged17 {
			get {
				return GetTypedColumnValue<bool>("IsChanged17");
			}
			set {
				SetColumnValue("IsChanged17", value);
			}
		}

		/// <summary>
		/// IsChanged18.
		/// </summary>
		public bool IsChanged18 {
			get {
				return GetTypedColumnValue<bool>("IsChanged18");
			}
			set {
				SetColumnValue("IsChanged18", value);
			}
		}

		/// <summary>
		/// IsChanged19.
		/// </summary>
		public bool IsChanged19 {
			get {
				return GetTypedColumnValue<bool>("IsChanged19");
			}
			set {
				SetColumnValue("IsChanged19", value);
			}
		}

		/// <summary>
		/// IsChanged20.
		/// </summary>
		public bool IsChanged20 {
			get {
				return GetTypedColumnValue<bool>("IsChanged20");
			}
			set {
				SetColumnValue("IsChanged20", value);
			}
		}

		/// <summary>
		/// IsChanged21.
		/// </summary>
		public bool IsChanged21 {
			get {
				return GetTypedColumnValue<bool>("IsChanged21");
			}
			set {
				SetColumnValue("IsChanged21", value);
			}
		}

		/// <summary>
		/// IsChanged22.
		/// </summary>
		public bool IsChanged22 {
			get {
				return GetTypedColumnValue<bool>("IsChanged22");
			}
			set {
				SetColumnValue("IsChanged22", value);
			}
		}

		/// <summary>
		/// IsChanged23.
		/// </summary>
		public bool IsChanged23 {
			get {
				return GetTypedColumnValue<bool>("IsChanged23");
			}
			set {
				SetColumnValue("IsChanged23", value);
			}
		}

		/// <summary>
		/// IsChanged24.
		/// </summary>
		public bool IsChanged24 {
			get {
				return GetTypedColumnValue<bool>("IsChanged24");
			}
			set {
				SetColumnValue("IsChanged24", value);
			}
		}

		/// <summary>
		/// IsChanged25.
		/// </summary>
		public bool IsChanged25 {
			get {
				return GetTypedColumnValue<bool>("IsChanged25");
			}
			set {
				SetColumnValue("IsChanged25", value);
			}
		}

		/// <summary>
		/// IsChanged26.
		/// </summary>
		public bool IsChanged26 {
			get {
				return GetTypedColumnValue<bool>("IsChanged26");
			}
			set {
				SetColumnValue("IsChanged26", value);
			}
		}

		/// <summary>
		/// IsChanged27.
		/// </summary>
		public bool IsChanged27 {
			get {
				return GetTypedColumnValue<bool>("IsChanged27");
			}
			set {
				SetColumnValue("IsChanged27", value);
			}
		}

		/// <summary>
		/// IsChanged28.
		/// </summary>
		public bool IsChanged28 {
			get {
				return GetTypedColumnValue<bool>("IsChanged28");
			}
			set {
				SetColumnValue("IsChanged28", value);
			}
		}

		/// <summary>
		/// IsChanged29.
		/// </summary>
		public bool IsChanged29 {
			get {
				return GetTypedColumnValue<bool>("IsChanged29");
			}
			set {
				SetColumnValue("IsChanged29", value);
			}
		}

		/// <summary>
		/// IsChanged30.
		/// </summary>
		public bool IsChanged30 {
			get {
				return GetTypedColumnValue<bool>("IsChanged30");
			}
			set {
				SetColumnValue("IsChanged30", value);
			}
		}

		/// <summary>
		/// Language0Short.
		/// </summary>
		public string Language0Short {
			get {
				return GetTypedColumnValue<string>("Language0Short");
			}
			set {
				SetColumnValue("Language0Short", value);
			}
		}

		/// <summary>
		/// Language1Short.
		/// </summary>
		public string Language1Short {
			get {
				return GetTypedColumnValue<string>("Language1Short");
			}
			set {
				SetColumnValue("Language1Short", value);
			}
		}

		/// <summary>
		/// Language2Short.
		/// </summary>
		public string Language2Short {
			get {
				return GetTypedColumnValue<string>("Language2Short");
			}
			set {
				SetColumnValue("Language2Short", value);
			}
		}

		/// <summary>
		/// Language3Short.
		/// </summary>
		public string Language3Short {
			get {
				return GetTypedColumnValue<string>("Language3Short");
			}
			set {
				SetColumnValue("Language3Short", value);
			}
		}

		/// <summary>
		/// Language4Short.
		/// </summary>
		public string Language4Short {
			get {
				return GetTypedColumnValue<string>("Language4Short");
			}
			set {
				SetColumnValue("Language4Short", value);
			}
		}

		/// <summary>
		/// Language5Short.
		/// </summary>
		public string Language5Short {
			get {
				return GetTypedColumnValue<string>("Language5Short");
			}
			set {
				SetColumnValue("Language5Short", value);
			}
		}

		/// <summary>
		/// Language6Short.
		/// </summary>
		public string Language6Short {
			get {
				return GetTypedColumnValue<string>("Language6Short");
			}
			set {
				SetColumnValue("Language6Short", value);
			}
		}

		/// <summary>
		/// Language7Short.
		/// </summary>
		public string Language7Short {
			get {
				return GetTypedColumnValue<string>("Language7Short");
			}
			set {
				SetColumnValue("Language7Short", value);
			}
		}

		/// <summary>
		/// Language8Short.
		/// </summary>
		public string Language8Short {
			get {
				return GetTypedColumnValue<string>("Language8Short");
			}
			set {
				SetColumnValue("Language8Short", value);
			}
		}

		/// <summary>
		/// Language9Short.
		/// </summary>
		public string Language9Short {
			get {
				return GetTypedColumnValue<string>("Language9Short");
			}
			set {
				SetColumnValue("Language9Short", value);
			}
		}

		/// <summary>
		/// Language10Short.
		/// </summary>
		public string Language10Short {
			get {
				return GetTypedColumnValue<string>("Language10Short");
			}
			set {
				SetColumnValue("Language10Short", value);
			}
		}

		/// <summary>
		/// Language11Short.
		/// </summary>
		public string Language11Short {
			get {
				return GetTypedColumnValue<string>("Language11Short");
			}
			set {
				SetColumnValue("Language11Short", value);
			}
		}

		/// <summary>
		/// Language12Short.
		/// </summary>
		public string Language12Short {
			get {
				return GetTypedColumnValue<string>("Language12Short");
			}
			set {
				SetColumnValue("Language12Short", value);
			}
		}

		/// <summary>
		/// Language13Short.
		/// </summary>
		public string Language13Short {
			get {
				return GetTypedColumnValue<string>("Language13Short");
			}
			set {
				SetColumnValue("Language13Short", value);
			}
		}

		/// <summary>
		/// Language14Short.
		/// </summary>
		public string Language14Short {
			get {
				return GetTypedColumnValue<string>("Language14Short");
			}
			set {
				SetColumnValue("Language14Short", value);
			}
		}

		/// <summary>
		/// Language15Short.
		/// </summary>
		public string Language15Short {
			get {
				return GetTypedColumnValue<string>("Language15Short");
			}
			set {
				SetColumnValue("Language15Short", value);
			}
		}

		/// <summary>
		/// Language16Short.
		/// </summary>
		public string Language16Short {
			get {
				return GetTypedColumnValue<string>("Language16Short");
			}
			set {
				SetColumnValue("Language16Short", value);
			}
		}

		/// <summary>
		/// Language17Short.
		/// </summary>
		public string Language17Short {
			get {
				return GetTypedColumnValue<string>("Language17Short");
			}
			set {
				SetColumnValue("Language17Short", value);
			}
		}

		/// <summary>
		/// Language18Short.
		/// </summary>
		public string Language18Short {
			get {
				return GetTypedColumnValue<string>("Language18Short");
			}
			set {
				SetColumnValue("Language18Short", value);
			}
		}

		/// <summary>
		/// Language19Short.
		/// </summary>
		public string Language19Short {
			get {
				return GetTypedColumnValue<string>("Language19Short");
			}
			set {
				SetColumnValue("Language19Short", value);
			}
		}

		/// <summary>
		/// Language20Short.
		/// </summary>
		public string Language20Short {
			get {
				return GetTypedColumnValue<string>("Language20Short");
			}
			set {
				SetColumnValue("Language20Short", value);
			}
		}

		/// <summary>
		/// Language21Short.
		/// </summary>
		public string Language21Short {
			get {
				return GetTypedColumnValue<string>("Language21Short");
			}
			set {
				SetColumnValue("Language21Short", value);
			}
		}

		/// <summary>
		/// Language22Short.
		/// </summary>
		public string Language22Short {
			get {
				return GetTypedColumnValue<string>("Language22Short");
			}
			set {
				SetColumnValue("Language22Short", value);
			}
		}

		/// <summary>
		/// Language23Short.
		/// </summary>
		public string Language23Short {
			get {
				return GetTypedColumnValue<string>("Language23Short");
			}
			set {
				SetColumnValue("Language23Short", value);
			}
		}

		/// <summary>
		/// Language24Short.
		/// </summary>
		public string Language24Short {
			get {
				return GetTypedColumnValue<string>("Language24Short");
			}
			set {
				SetColumnValue("Language24Short", value);
			}
		}

		/// <summary>
		/// Language25Short.
		/// </summary>
		public string Language25Short {
			get {
				return GetTypedColumnValue<string>("Language25Short");
			}
			set {
				SetColumnValue("Language25Short", value);
			}
		}

		/// <summary>
		/// Language26Short.
		/// </summary>
		public string Language26Short {
			get {
				return GetTypedColumnValue<string>("Language26Short");
			}
			set {
				SetColumnValue("Language26Short", value);
			}
		}

		/// <summary>
		/// Language27Short.
		/// </summary>
		public string Language27Short {
			get {
				return GetTypedColumnValue<string>("Language27Short");
			}
			set {
				SetColumnValue("Language27Short", value);
			}
		}

		/// <summary>
		/// Language28Short.
		/// </summary>
		public string Language28Short {
			get {
				return GetTypedColumnValue<string>("Language28Short");
			}
			set {
				SetColumnValue("Language28Short", value);
			}
		}

		/// <summary>
		/// Language29Short.
		/// </summary>
		public string Language29Short {
			get {
				return GetTypedColumnValue<string>("Language29Short");
			}
			set {
				SetColumnValue("Language29Short", value);
			}
		}

		/// <summary>
		/// Language30Short.
		/// </summary>
		public string Language30Short {
			get {
				return GetTypedColumnValue<string>("Language30Short");
			}
			set {
				SetColumnValue("Language30Short", value);
			}
		}

		/// <summary>
		/// Error message.
		/// </summary>
		public string ErrorMessage {
			get {
				return GetTypedColumnValue<string>("ErrorMessage");
			}
			set {
				SetColumnValue("ErrorMessage", value);
			}
		}

		/// <summary>
		/// IsVerified35.
		/// </summary>
		public bool IsVerified35 {
			get {
				return GetTypedColumnValue<bool>("IsVerified35");
			}
			set {
				SetColumnValue("IsVerified35", value);
			}
		}

		/// <summary>
		/// IsVerified34.
		/// </summary>
		public bool IsVerified34 {
			get {
				return GetTypedColumnValue<bool>("IsVerified34");
			}
			set {
				SetColumnValue("IsVerified34", value);
			}
		}

		/// <summary>
		/// IsVerified33.
		/// </summary>
		public bool IsVerified33 {
			get {
				return GetTypedColumnValue<bool>("IsVerified33");
			}
			set {
				SetColumnValue("IsVerified33", value);
			}
		}

		/// <summary>
		/// IsVerified32.
		/// </summary>
		public bool IsVerified32 {
			get {
				return GetTypedColumnValue<bool>("IsVerified32");
			}
			set {
				SetColumnValue("IsVerified32", value);
			}
		}

		/// <summary>
		/// IsVerified31.
		/// </summary>
		public bool IsVerified31 {
			get {
				return GetTypedColumnValue<bool>("IsVerified31");
			}
			set {
				SetColumnValue("IsVerified31", value);
			}
		}

		/// <summary>
		/// IsChanged35.
		/// </summary>
		public bool IsChanged35 {
			get {
				return GetTypedColumnValue<bool>("IsChanged35");
			}
			set {
				SetColumnValue("IsChanged35", value);
			}
		}

		/// <summary>
		/// IsChanged34.
		/// </summary>
		public bool IsChanged34 {
			get {
				return GetTypedColumnValue<bool>("IsChanged34");
			}
			set {
				SetColumnValue("IsChanged34", value);
			}
		}

		/// <summary>
		/// IsChanged33.
		/// </summary>
		public bool IsChanged33 {
			get {
				return GetTypedColumnValue<bool>("IsChanged33");
			}
			set {
				SetColumnValue("IsChanged33", value);
			}
		}

		/// <summary>
		/// IsChanged32.
		/// </summary>
		public bool IsChanged32 {
			get {
				return GetTypedColumnValue<bool>("IsChanged32");
			}
			set {
				SetColumnValue("IsChanged32", value);
			}
		}

		/// <summary>
		/// IsChanged31.
		/// </summary>
		public bool IsChanged31 {
			get {
				return GetTypedColumnValue<bool>("IsChanged31");
			}
			set {
				SetColumnValue("IsChanged31", value);
			}
		}

		/// <summary>
		/// Language35.
		/// </summary>
		public string Language35 {
			get {
				return GetTypedColumnValue<string>("Language35");
			}
			set {
				SetColumnValue("Language35", value);
			}
		}

		/// <summary>
		/// Language34.
		/// </summary>
		public string Language34 {
			get {
				return GetTypedColumnValue<string>("Language34");
			}
			set {
				SetColumnValue("Language34", value);
			}
		}

		/// <summary>
		/// Language33.
		/// </summary>
		public string Language33 {
			get {
				return GetTypedColumnValue<string>("Language33");
			}
			set {
				SetColumnValue("Language33", value);
			}
		}

		/// <summary>
		/// Language32.
		/// </summary>
		public string Language32 {
			get {
				return GetTypedColumnValue<string>("Language32");
			}
			set {
				SetColumnValue("Language32", value);
			}
		}

		/// <summary>
		/// Language31.
		/// </summary>
		public string Language31 {
			get {
				return GetTypedColumnValue<string>("Language31");
			}
			set {
				SetColumnValue("Language31", value);
			}
		}

		/// <summary>
		/// Language35Short.
		/// </summary>
		public string Language35Short {
			get {
				return GetTypedColumnValue<string>("Language35Short");
			}
			set {
				SetColumnValue("Language35Short", value);
			}
		}

		/// <summary>
		/// Language34Short.
		/// </summary>
		public string Language34Short {
			get {
				return GetTypedColumnValue<string>("Language34Short");
			}
			set {
				SetColumnValue("Language34Short", value);
			}
		}

		/// <summary>
		/// Language33Short.
		/// </summary>
		public string Language33Short {
			get {
				return GetTypedColumnValue<string>("Language33Short");
			}
			set {
				SetColumnValue("Language33Short", value);
			}
		}

		/// <summary>
		/// Language32Short.
		/// </summary>
		public string Language32Short {
			get {
				return GetTypedColumnValue<string>("Language32Short");
			}
			set {
				SetColumnValue("Language32Short", value);
			}
		}

		/// <summary>
		/// Language31Short.
		/// </summary>
		public string Language31Short {
			get {
				return GetTypedColumnValue<string>("Language31Short");
			}
			set {
				SetColumnValue("Language31Short", value);
			}
		}

		#endregion

	}

	#endregion

}

