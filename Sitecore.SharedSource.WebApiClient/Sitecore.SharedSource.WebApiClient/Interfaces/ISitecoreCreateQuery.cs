namespace Sitecore.SharedSource.WebApiClient.Interfaces
{
    /// <summary>
    /// Defines the properties and methods that objects wishing to send creation queries to the Sitecore Item Web API must implement
    /// </summary>
    public interface ISitecoreCreateQuery : ISitecoreQuery, ISitecoreItemQuery
    {	
		/// <summary>
        /// Gets or sets the parent query.
        /// </summary>
        /// <value>
        /// The parent query.
        /// </value>
		string ParentQuery { get; set; }
		
		/// <summary>
        /// Gets or sets the Name of the new item.
        /// </summary>
        /// <value>
        /// The Name.
        /// </value>
		string Name { get; set; }

        /// <summary>
        /// Gets or sets the template id or path for create requests.
        /// </summary>
        /// <value>
        /// The template.		
        /// </value>
        /// <remarks>
        ///	<para>Template paths are relative to the /sitecore/Templates folder</para>
        /// </remarks>
        string Template { get; set; }
    }
}
