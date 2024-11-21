namespace BPMSoft.Configuration
{
	using BPMSoft.Core.Factories;
	using BPMSoft.Web.Common;

	#region Class: OpportunityMLangBinder

	/// <summary>
	/// Opportunity multilanguage class binder.
	/// </summary>
	public class OpportunityMLangBinder : AppEventListenerBase
	{

		#region Methods: Public

		public override void OnAppStart(AppEventContext context) {
			base.OnAppStart(context);
			ClassFactory.Bind<ILanguageIterator, OpportunityLanguageIterator>("Opportunity");
		}

		#endregion

	}

	#endregion

}
