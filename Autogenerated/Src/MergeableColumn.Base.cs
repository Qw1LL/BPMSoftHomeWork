using System;
using BPMSoft.Common;
using BPMSoft.Core;

namespace BPMSoft.Configuration
{
	public class MergeableColumn
	{
		public string ColumnCaption {
			get;
			set;
		}
		
		public string ColumnName {
			get;
			set;
		}
		
		public bool IsAlwaysHidden {
			get;
			set;
		}
	}
}
