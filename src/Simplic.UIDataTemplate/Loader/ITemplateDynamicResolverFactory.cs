namespace Simplic.UIDataTemplate
{
    /// <summary>
    /// Factory for creating a type of <see cref="ITemplateDynamicResolver"/>
    /// </summary>
    public interface ITemplateDynamicResolverFactory
    {
        /// <summary>
        /// Create a new instance of an <see cref="ITemplateDynamicResolver"/>
        /// </summary>
        /// <param name="ns">Namespace of the root control</param>
        /// <param name="dataTemplateName">Name of the template</param>
        /// <returns>New instance of <see cref="ITemplateDynamicResolver"/></returns>
        ITemplateDynamicResolver Create(string ns, string dataTemplateName);
    }
}