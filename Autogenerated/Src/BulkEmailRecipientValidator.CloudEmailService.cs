namespace BPMSoft.Configuration
{
	using System.Collections.Generic;
	using System.Linq;

	#region Class: BulkEmailRecipientValidator

	/// <summary>
	/// Validates recipient macros from sender name and sender email.
	/// </summary>
	public class BulkEmailRecipientValidator
	{

		#region Fields: Private

		private List<BaseValidationRule> _validationRules;
		private readonly BulkEmailRecipientValidatorBuilder _builder;

		#endregion

		#region Constructors: Public

		/// <summary>
		/// Initializes a new instance of the <see cref="BulkEmailRecipientValidator"/> class.
		/// </summary>
		/// <param name="builder">Class for building validation rules.</param>
		public BulkEmailRecipientValidator(BulkEmailRecipientValidatorBuilder builder) {
			_validationRules = new List<BaseValidationRule>();
			_builder = builder;
			InitRules();
		}

		#endregion

		#region Methods: Protected

		/// <summary>
		/// Initialization of validation rules.
		/// </summary>
		protected void InitRules() {
			_validationRules = _builder.InitRules();
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Validates all recipients all by all rules.
		/// </summary>
		/// <param name="recipients">Recipient of bulk email.</param>
		public void Validate(IEnumerable<IMessageRecipientInfo> recipients) {
			foreach (var recipient in recipients) {
				foreach (var validator in _validationRules) {
					validator.Validate(recipient);
				}
			}
		}

		#endregion

	}

	#endregion
}
