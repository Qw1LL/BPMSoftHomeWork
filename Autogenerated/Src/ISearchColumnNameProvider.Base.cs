 namespace BPMSoft.Configuration
 {

	#region Interface: ISearchColumnNameProvider

	 /// <summary>
	 /// Search column storing name provider.
	 /// </summary>
	 public interface ISearchColumnNameProvider
	 {

		#region Methods : Public

		 /// <summary>
		 /// Returns column storing name.
		 /// </summary>
		 /// <param name="searchColumn">Search column.</param>
		 /// <returns>Storing name.</returns>
		 string GetSearchColumnName(SearchColumn searchColumn);

		 #endregion

	 }

	#endregion

}
