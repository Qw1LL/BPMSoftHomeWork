namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using BPMSoft.Core;
	using BPMSoft.Common;
	
	#region Class: HoursOrMinutesClass
	
	public class HoursOrMinutesClass
	{
		#region Fields: Private
		
		private UserConnection _userConnection;
		
		#endregion
		
		#region Properties: Public
		
		public LocalizableString Hours {
			get {
				return new LocalizableString(GetResourceStorage(), "PeriodicityEnums",
					"LocalizableStrings.Hours.Value").ToString();
			}
		}
		
		public LocalizableString Minutes {
			get {
				return new LocalizableString(GetResourceStorage(), "PeriodicityEnums",
					"LocalizableStrings.Minutes.Value").ToString();
			}
		}
		
		#endregion
		
		#region Constructors: Public
		
		public HoursOrMinutesClass(UserConnection userConnection) {
			_userConnection = userConnection;		
		}
		
		#endregion
		
		#region Methods: Private
		
		private IResourceStorage GetResourceStorage()
		{
			//###, ####### ############# ###### # Workspace CR173359
			return _userConnection.ResourceStorage;
		}
		
		#endregion
		
		#region Methods: Public
		
		public Dictionary<Guid, LocalizableString> GetHoursOrMinutes() {
			return new Dictionary<Guid, LocalizableString>() {
						{new Guid("F9B62808-FE60-421F-9584-AAFEC1E21C4D"), Hours},
						{new Guid("12FE1488-46B1-4DFC-B131-187857F385AE"), Minutes}};
		}
		
		#endregion
	}
	
	#endregion
	
	#region Class: DaysOfWeekClass
	
	public class DaysOfWeekClass
	{
		#region Fields: Private
		
		private UserConnection _userConnection;
		
		#endregion
		
		#region Properties: Public
		
		public LocalizableString Sunday {
			get {
				return new LocalizableString(GetResourceStorage(), "PeriodicityEnums",
					"LocalizableStrings.Sunday.Value").ToString();
			}
		}
		
		public LocalizableString Monday {
			get {
				return new LocalizableString(GetResourceStorage(), "PeriodicityEnums",
					"LocalizableStrings.Monday.Value").ToString();
			}
		}
		
		public LocalizableString Tuesday {
			get {
				return new LocalizableString(GetResourceStorage(), "PeriodicityEnums",
					"LocalizableStrings.Tuesday.Value").ToString();
			}
		}
		
		public LocalizableString Wednesday {
			get {
				return new LocalizableString(GetResourceStorage(), "PeriodicityEnums",
					"LocalizableStrings.Wednesday.Value").ToString();
			}
		}
		
		public LocalizableString Thursday {
			get {
				return new LocalizableString(GetResourceStorage(), "PeriodicityEnums",
					"LocalizableStrings.Thursday.Value").ToString();
			}
		}
		
		public LocalizableString Friday {
			get {
				return new LocalizableString(GetResourceStorage(), "PeriodicityEnums",
					"LocalizableStrings.Friday.Value").ToString();
			}
		}
		
		public LocalizableString Saturday {
			get {
				return new LocalizableString(GetResourceStorage(), "PeriodicityEnums",
					"LocalizableStrings.Saturday.Value").ToString();
			}
		}
		
		#endregion
		
		#region Constructors: Public
		
		public DaysOfWeekClass(UserConnection userConnection) {
			_userConnection = userConnection;		
		}
		
		#endregion
		
		#region Methods: Private
		
		private IResourceStorage GetResourceStorage()
		{
			//###, ####### ############# ###### # Workspace CR173359
			return _userConnection.ResourceStorage;
		}
		
		#endregion
		
		#region Methods: Public
		
		public Dictionary<Guid, LocalizableString> GetDaysOfWeek() {
			return new Dictionary<Guid, LocalizableString>() {
						{new Guid("7F3D1E40-2D85-4A43-AFC5-947A3C4774D1"), Sunday},
						{new Guid("F4E98DF3-C4A1-4E1E-8F7E-47343E78E8AD"), Monday},
						{new Guid("7BA77FC2-E06F-4756-98BC-819781458DBE"), Tuesday},
						{new Guid("1E315EAE-46E5-4075-83AC-9B95DD25F472"), Wednesday},
						{new Guid("F84C33A3-24E8-4A31-BC58-DF4C5736DA76"), Thursday},
						{new Guid("FA25085C-D878-450F-8AF8-892D1DAA3004"), Friday},
						{new Guid("3635986E-61CA-4644-973C-8B5D0DA708C0"), Saturday}};
		}
		
		#endregion
	}
	
	#endregion
	
	public enum HoursOrMinutesEnum {
		Hourss, Minutess
	}
	
	public enum DaysOfWeekEnum {
		Sun, Mon, Tue, Wed, Thu, Fri, Sat
	}
}
