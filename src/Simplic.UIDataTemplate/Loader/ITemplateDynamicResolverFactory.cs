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
        /// <returns>New instance of <see cref="ITemplateDynamicResolver"/></returns>
        ITemplateDynamicResolver Create();
    }
}